using System;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core;
using TypeCalculator.Core;

namespace TypeCalculator.Views.Types
{
    public class TypesEndpoint
    {
        private readonly ITypesDictionary _typesDictionary;

        public TypesEndpoint(ITypesDictionary typesDictionary)
        {
            _typesDictionary = typesDictionary;
        }

        [UrlPattern("types/getStats")]
        public TypesResponse GetStats(TypesRequest request)
        {
            if (request.ElementTwo == ElementTypes.None || request.ElementOne == request.ElementTwo)
            {
                return GetStatsFor(request.ElementOne);
            }
            if (request.ElementOne == ElementTypes.None)
            {
                return GetStatsFor(request.ElementTwo);
            }

            var typeOne = request.ElementOne;
            var typeTwo = request.ElementTwo;
            var typeOneAttributes = _typesDictionary.GetAttributes(typeOne);
            var typeTwoAttributes = _typesDictionary.GetAttributes(typeTwo);
            var strongDefense = typeOneAttributes.StrongDefense
                .Concat(typeTwoAttributes.StrongDefense)
                .GroupBy(x => x)
                .ToList();
            var weakDefense = typeOneAttributes.WeakDefense
                .Concat(typeTwoAttributes.WeakDefense)
                .GroupBy(x => x)
                .ToList();

            var commonElements = strongDefense.Where(y => weakDefense.Any() && weakDefense.Any(x => x.Key == y.Key))
                .Select(x => x.Key)
                .ToList();

            var immuneDefense = typeOneAttributes.ImmuneDefense
                .Concat(typeTwoAttributes.ImmuneDefense)
                .Distinct();

            weakDefense = weakDefense.Where(x => !commonElements.Contains(x.Key) && !immuneDefense.Contains(x.Key)).ToList();

            strongDefense = strongDefense.Where(x => !commonElements.Contains(x.Key) && !immuneDefense.Contains(x.Key)).ToList();

            return new TypesResponse
            {
                StrongAttack = GetMultiTypeAttackStats(typeOne, typeTwo, typeOneAttributes.StrongAttack, typeTwoAttributes.StrongAttack),
                WeakAttack = GetMultiTypeAttackStats(typeOne, typeTwo, typeOneAttributes.WeakAttack, typeTwoAttributes.WeakAttack),
                StrongDefense = GetMultiTypeStats(strongDefense),
                WeakDefense = GetMultiTypeStats(weakDefense),
                ImmuneDefense = immuneDefense.Select(x => x.ToString()).ToList()
            };
        }

        private TypesResponse GetStatsFor(string type)
        {
            var attributes = _typesDictionary.GetAttributes(type);
            return new TypesResponse
            {
                StrongAttack = attributes.StrongAttack.Select(x => x.ToString()),
                WeakAttack = attributes.WeakAttack.Select(x => x.ToString()),
                StrongDefense = attributes.StrongDefense.Select(x => x.ToString()),
                WeakDefense = attributes.WeakDefense.Select(x => x.ToString()),
                ImmuneDefense = attributes.ImmuneDefense.Select(x => x.ToString()),
            };
        }

        private IEnumerable<string> GetMultiTypeAttackStats(string typeOne, string typeTwo,
            ICollection<string> typeOneAttack, ICollection<string> typeTwoAttack)
        {
            return typeOneAttack
                .Concat(typeTwoAttack)
                .Distinct()
                .Select(x =>
                {
                    if (typeOneAttack.Contains(x) && typeTwoAttack.Contains(x))
                    {
                        return x.ToString();
                    }
                    if (typeOneAttack.Contains(x))
                    {
                        return x + " (" + typeOne.ToString() + ")";
                    }
                    return x + " (" + typeTwo.ToString() + ")";
                }); 
        }

        private IEnumerable<string> GetMultiTypeStats(IEnumerable<IGrouping<string, string>> typeGroups)
        {
            return typeGroups.Select((typeGroup) =>
            {
                var type = typeGroup.Key.ToString();
                var count = typeGroup.Count();

                if (count > 1)
                {
                    return type.ToString() + " x" + count;
                }
                return type.ToString();
            })
            .OrderBy(x => x);
        }
            
        [UrlPattern("types/getTypes")]
        public GetTypesResponse GetTypes(GetTypesRequest request)
        {
            return new GetTypesResponse
            {
                Types = ElementTypes.Types
            };
        }

        [UrlPattern("types/getTypesTable")]
        public TypesTableResponse GetTypes(TypesTableRequest request)
        {
            return new TypesTableResponse
            {
                Stats = _typesDictionary.GetStats(),
            };
        }

        [UrlPattern("types/addType")]
        public TypesTableResponse AddType(AddTypeRequest request)
        {
            _typesDictionary.AddType(request.TypeOne, request.TypeTwo, request.Stat);
            return GetTypes(new TypesTableRequest());
        }
    }
}