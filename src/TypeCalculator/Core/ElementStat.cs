using TypeCalculator.Views;

namespace TypeCalculator.Core
{
    public class ElementStat
    {
        public string ElementType { get; private set; }
        public MultiplierStrength MultiplierStrength { get; private set; }

        public ElementStat(string elementType, MultiplierStrength multiplierStrength)
        {
            ElementType = elementType;
            MultiplierStrength = multiplierStrength;
        }
    }
}