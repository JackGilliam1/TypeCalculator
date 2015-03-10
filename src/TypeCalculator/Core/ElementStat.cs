namespace TypeCalculator.Core
{
    public class ElementStat
    {
        public string ElementType { get; private set; }
        public double Multiplier { get; private set; }

        public ElementStat(string elementType, double multiplier)
        {
            ElementType = elementType;
            Multiplier = multiplier;
        }
    }
}