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

        public void AddStrongAttack(string elementType)
        {
            if (!WeakAttack.Contains(elementType) && !StrongAttack.Contains(elementType))
            {
                StrongAttack.Add(elementType);
            }
        }

        public void AddWeakAttack(string elementType)
        {
            if (!StrongAttack.Contains(elementType) && !WeakAttack.Contains(elementType))
            {
                WeakAttack.Add(elementType);
            }
        }

        public void AddStrongDefense(string elementType)
        {
            if (!WeakDefense.Contains(elementType) && !StrongDefense.Contains(elementType))
            {
                StrongDefense.Add(elementType);
            }
        }

        public void AddWeakDefense(string elementType)
        {
            if (!StrongDefense.Contains(elementType) && !WeakDefense.Contains(elementType))
            {
                WeakDefense.Add(elementType);
            }
        }

        public void AddImmuneDefense(string elementType)
        {
            if (!StrongDefense.Contains(elementType) && !WeakDefense.Contains(elementType) && !ImmuneDefense.Contains(elementType))
            {
                ImmuneDefense.Add(elementType);
            }
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