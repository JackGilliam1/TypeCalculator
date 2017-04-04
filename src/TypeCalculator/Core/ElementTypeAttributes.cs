using System.Collections.Generic;
using System.Linq;
using Marten.Schema;

namespace TypeCalculator.Core
{
    public class ElementTypeAttributes
    {
        [Identity]
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

        public void AddStrongAttack(string elementType)
        {
            if (StrongAttack.Contains(elementType))
            {
                return;
            }
            WeakAttack.Remove(elementType);
            StrongAttack.Add(elementType);
        }

        public void AddWeakAttack(string elementType)
        {
            if (WeakAttack.Contains(elementType))
            {
                return;
            }
            StrongAttack.Remove(elementType);
            WeakAttack.Add(elementType);
        }

        public void AddStrongDefense(string elementType)
        {
            if (StrongDefense.Contains(elementType))
            {
                return;
            }
            ImmuneDefense.Remove(elementType);
            WeakDefense.Remove(elementType);
            StrongDefense.Add(elementType);
        }

        public void AddWeakDefense(string elementType)
        {
            if (WeakDefense.Contains(elementType))
            {
                return;
            }
            ImmuneDefense.Remove(elementType);
            StrongDefense.Remove(elementType);
            WeakDefense.Add(elementType);
        }

        public void AddImmuneDefense(string elementType)
        {
            if (ImmuneDefense.Contains(elementType))
            {
                return;
            }
            StrongDefense.Remove(elementType);
            WeakDefense.Remove(elementType);
            ImmuneDefense.Add(elementType);
        }

        public void SetStrongAttack(IEnumerable<string> elementTypes)
        {
            StrongAttack = elementTypes.Where(x => !WeakAttack.Contains(x)).Distinct().ToList();
            Updated = true;
        }

        public void SetWeakAttack(IEnumerable<string> elementTypes)
        {
            WeakAttack = elementTypes.Where(x => !StrongAttack.Contains(x)).Distinct().ToList();
            Updated = true;
        }

        public void SetStrongDefense(IEnumerable<string> elementTypes)
        {
            StrongDefense = elementTypes.Where(x => !WeakDefense.Contains(x)).Distinct().ToList();
            Updated = true;
        }

        public void SetWeakDefense(IEnumerable<string> elementTypes)
        {
            WeakDefense = elementTypes.Where(x => !StrongDefense.Contains(x)).Distinct().ToList();
            Updated = true;
        }

        public void SetImmuneDefense(IEnumerable<string> elementTypes)
        {
            ImmuneDefense = elementTypes.Where(x => !StrongDefense.Contains(x) && !WeakDefense.Contains(x)).Distinct().ToList();
            Updated = true;
        }
    }
}