using System.Linq;
using Marten;

namespace TypeCalculator.Core
{
    public class MartenDbDatabase : ITypeCalculatorDatabase
    {
        private readonly IDocumentStore _docStore;
        private MartenDbSettings _settings;

        public MartenDbDatabase(MartenDbSettings settings)
        {
            _settings = settings;
            _docStore = DocumentStore.For($"host={settings.Url};database={settings.DatabaseName}");
        }

        public ElementTypeAttributes GetAttributesFor(ElementType elementType)
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
                return attributes;
            }
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
    }
}