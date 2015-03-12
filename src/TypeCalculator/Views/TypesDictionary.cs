using System;
using System.Collections.Generic;
using System.Linq;
using TypeCalculator.Core;

namespace TypeCalculator.Views
{
    public interface ITypesDictionary
    {
        ElementTypeAttributes GetAttributes(ElementType type);
        IList<ElementStats> GetStats();
    }

    public class TypesDictionary : ITypesDictionary
    {
        private readonly ITypeCalculatorDatabase _database;
        private IList<ElementStats> _elementStats;

        public TypesDictionary(ITypeCalculatorDatabase database)
        {
            _database = database;
        }

        public ElementTypeAttributes GetAttributes(ElementType type)
        {
            return _database.GetAttributesFor(type);
        }

        public IList<ElementStats> GetStats()
        {
            if (_elementStats != null)
            {
                return _elementStats;
            }
            _elementStats = new List<ElementStats>();

            var elementTypes = ((ElementType[]) Enum.GetValues(typeof (ElementType)))
                .Where(x => !x.Equals(ElementType.None))
                .ToList();

            var tempDictionary = new Dictionary<ElementType, ElementStats>();

            elementTypes.Each(x => tempDictionary.Add(x, new ElementStats(x)));

            var strongDefenseMultiplier = new MultiplierStrength(0.5, "Weak");
            var weakDefenseMultiplier = new MultiplierStrength(2, "Strong");
            var immuneDefenseMultiplier = new MultiplierStrength(0, "Immune");
            var normalMultiplier = new MultiplierStrength(1, "");
            foreach (var elementType in elementTypes)
            {
                var attributes = GetAttributes(elementType);
                foreach (var strongDefense in attributes.StrongDefense)
                {
                    tempDictionary[strongDefense].Stats.Add(new ElementStat(elementType, strongDefenseMultiplier));
                }

                foreach (var weakDefense in attributes.WeakDefense)
                {
                    tempDictionary[weakDefense].Stats.Add(new ElementStat(elementType, weakDefenseMultiplier));
                }

                foreach (var immuneDefense in attributes.ImmuneDefense)
                {
                    tempDictionary[immuneDefense].Stats.Add(new ElementStat(elementType, immuneDefenseMultiplier));
                }

                foreach (var elementTypeTwo in elementTypes)
                {
                    var stats = tempDictionary[elementTypeTwo].Stats;
                    if (!stats.Any(x => x.ElementType.Equals(elementType.ToString())))
                    {
                        stats.Add(new ElementStat(elementType, normalMultiplier));
                    }
                }
            }

            return _elementStats = tempDictionary.Values.ToList();
        }

        private static IList<ElementType> GetFrom(IDictionary<ElementType, IList<ElementType>> typeDictionary, ElementType type)
        {
            if (!typeDictionary.ContainsKey(type))
            {
                return new List<ElementType>();
            }
            return typeDictionary[type];
        }
    }

    public class MultiplierStrength
    {
        public double Multiplier { get; private set; }
        public string Strength { get; private set; }

        public MultiplierStrength(double multiplier, string strength)
        {
            Multiplier = multiplier;
            Strength = strength;
        }
    }
}