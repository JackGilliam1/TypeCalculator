using System.Collections.Generic;

namespace TypeCalculator.Core
{
    public class ElementStats
    {
        public string ElementType { get; private set; }
        public IList<ElementStat> Stats { get; private set; }

        public ElementStats(string elementType)
        {
            ElementType = elementType;
            Stats = new List<ElementStat>();
        }
    }
}