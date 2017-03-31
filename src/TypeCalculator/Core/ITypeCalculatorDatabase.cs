namespace TypeCalculator.Core
{
    public interface ITypeCalculatorDatabase
    {
        ElementTypeAttributes GetAttributesFor(string elementType);
        void UpdateAttributes(ElementTypeAttributes attributes);
    }
}