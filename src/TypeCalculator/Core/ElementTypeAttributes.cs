using System.Collections.Generic;
using System.Linq;

namespace TypeCalculator.Core
{
    public class ElementTypeAttributes
    {
        public int Id { get; set; }
        public string ElementType { get; set; }
        public bool Updated { get; set; }

        public IList<string> StrongAttack { get; set; }
        public IList<string> WeakAttack { get; set; }
        public IList<string> StrongDefense { get; set; }
        public IList<string> WeakDefense { get; set; }
        public IList<string> ImmuneDefense { get; set; }

        public ElementTypeAttributes()
        {
            StrongAttack = new List<string>();
            WeakAttack = new List<string>();
            StrongDefense = new List<string>();
            WeakDefense = new List<string>();
            ImmuneDefense = new List<string>();
            Updated = false;
        }

        public void SetStrongAttack(IEnumerable<string> elementTypes)
        {
            StrongAttack = elementTypes.ToList();
            Updated = true;
        }

        public void SetWeakAttack(IEnumerable<string> elementTypes)
        {
            WeakAttack = elementTypes.ToList();
            Updated = true;
        }

        public void SetStrongDefense(IEnumerable<string> elementTypes)
        {
            StrongDefense = elementTypes.ToList();
            Updated = true;
        }

        public void SetWeakDefense(IEnumerable<string> elementTypes)
        {
            WeakDefense = elementTypes.ToList();
            Updated = true;
        }

        public void SetImmuneDefense(IEnumerable<string> elementTypes)
        {
            ImmuneDefense = elementTypes.ToList();
            Updated = true;
        }
    }
}