using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace TypeCalculator.Core
{
    public class ElementTypeAttributes
    {
        public ObjectId Id { get; set; }
        public ElementType ElementType { get; set; }
        public bool Updated { get; set; }

        public IList<ElementType> StrongAttack { get; set; }
        public IList<ElementType> WeakAttack { get; set; }
        public IList<ElementType> StrongDefense { get; set; }
        public IList<ElementType> WeakDefense { get; set; }
        public IList<ElementType> ImmuneDefense { get; set; }

        public ElementTypeAttributes()
        {
            StrongAttack = new List<ElementType>();
            WeakAttack = new List<ElementType>();
            StrongDefense = new List<ElementType>();
            WeakDefense = new List<ElementType>();
            ImmuneDefense = new List<ElementType>();
            Updated = false;
        }

        public void SetStrongAttack(IEnumerable<ElementType> elementTypes)
        {
            StrongAttack = elementTypes.ToList();
            Updated = true;
        }

        public void SetWeakAttack(IEnumerable<ElementType> elementTypes)
        {
            WeakAttack = elementTypes.ToList();
            Updated = true;
        }

        public void SetStrongDefense(IEnumerable<ElementType> elementTypes)
        {
            StrongDefense = elementTypes.ToList();
            Updated = true;
        }

        public void SetWeakDefense(IEnumerable<ElementType> elementTypes)
        {
            WeakDefense = elementTypes.ToList();
            Updated = true;
        }

        public void SetImmuneDefense(IEnumerable<ElementType> elementTypes)
        {
            ImmuneDefense = elementTypes.ToList();
            Updated = true;
        }
    }
}