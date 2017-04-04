using System;
using System.Collections.Generic;
using System.Linq;
using FubuCore.Binding.Values;
using Marten;
using TypeCalculator.Views;

namespace TypeCalculator.Core
{
    public class MartenDbDatabase : ITypeCalculatorDatabase
    {
        private readonly IDocumentStore _docStore;

        public MartenDbDatabase(MartenDbSettings settings)
        {
            _docStore = DocumentStore.For($"host={settings.Url};database={settings.DatabaseName};password={settings.Password};username={settings.Username}");
        }

        public ElementTypeAttributes GetAttributesFor(string elementType)
        {
            using (var session = _docStore.OpenSession())
            {
                var attributes = session
                    .Query<ElementTypeAttributes>()
                    .SingleOrDefault(x => x.ElementType == elementType);
                if (attributes != null)
                {
                    return attributes;
                }
                attributes = new ElementTypeAttributes
                {
                    ElementType = elementType
                };
                session.Store(attributes);
                session.SaveChanges();
            }
            return GetAttributesFor(elementType);
        }

        public void UpdateAttributes(ElementTypeAttributes attributes)
        {
            using (var session = _docStore.OpenSession())
            {
                session.Patch<ElementTypeAttributes>(x => x.ElementType == attributes.ElementType).Set(x => x.ImmuneDefense, attributes.ImmuneDefense);
                session.Patch<ElementTypeAttributes>(x => x.ElementType == attributes.ElementType).Set(x => x.StrongAttack, attributes.StrongAttack);
                session.Patch<ElementTypeAttributes>(x => x.ElementType == attributes.ElementType).Set(x => x.StrongDefense, attributes.StrongDefense);
                session.Patch<ElementTypeAttributes>(x => x.ElementType == attributes.ElementType).Set(x => x.WeakAttack, attributes.WeakAttack);
                session.Patch<ElementTypeAttributes>(x => x.ElementType == attributes.ElementType).Set(x => x.WeakDefense, attributes.WeakDefense);
                session.SaveChanges();
            }
        }

        public void AddStat(string typeOne, string typeTwo, StatType statType)
        {
            addStat(typeOne, typeTwo, statType);
            var oppositeStat = StatType.ImmuneDefense;
            switch (statType)
            {
                case StatType.StrongAttack:
                    oppositeStat = StatType.WeakDefense;
                    break;
                case StatType.WeakAttack:
                    oppositeStat = StatType.StrongDefense;
                    break;
                case StatType.StrongDefense:
                    oppositeStat = StatType.WeakAttack;
                    break;
                case StatType.WeakDefense:
                    oppositeStat = StatType.StrongAttack;
                    break;
                case StatType.ImmuneDefense:
                    break;
                default:
                    throw new Exception("No Stat types found matching: " + statType);
            }
            if (statType != StatType.ImmuneDefense)
            {
                addStat(typeTwo, typeOne, oppositeStat);
            }
        }

        private void addStat(string typeOne, string typeTwo, StatType statType)
        {
            var attributes = GetAttributesFor(typeOne);

            switch (statType)
            {
                case StatType.StrongAttack:
                    attributes.AddStrongAttack(typeTwo);
                    break;
                case StatType.WeakAttack:
                    attributes.AddWeakAttack(typeTwo);
                    break;
                case StatType.StrongDefense:
                    attributes.AddStrongDefense(typeTwo);
                    break;
                case StatType.WeakDefense:
                    attributes.AddWeakDefense(typeTwo);
                    break;
                case StatType.ImmuneDefense:
                    attributes.AddImmuneDefense(typeTwo);
                    break;
                default:
                    throw new Exception("No Stat types found matching: " + statType);
            }

            UpdateAttributes(attributes);
            var types = GetTypesList();
            types.Add(typeOne);
            types.Add(typeTwo);
            UpdateTypesList(types);
        }

        public void UpdateTypesList(IList<string> types)
        {
            using (var session = _docStore.OpenSession())
            {
                var typesList = session.Query<TypesList>()
                    .SingleOrDefault();
                if (typesList == null)
                {
                    typesList = new TypesList();
                }
                var newTypes = types.Concat(typesList.Types).Distinct().ToList();
                typesList.Types = newTypes;
                session.Store(typesList);
                session.SaveChanges();
            }
        }

        public IList<string> GetTypesList()
        {
            using (var session = _docStore.OpenSession())
            {
                return session.Query<TypesList>().SingleOrDefault()?.Types ?? new List<string>();
            }
        }

        public void InsertAttributes(IEnumerable<ElementTypeAttributes> attributes)
        {
            _docStore.BulkInsert(attributes.ToArray(), BulkInsertMode.OverwriteExisting);
        }
    }
}