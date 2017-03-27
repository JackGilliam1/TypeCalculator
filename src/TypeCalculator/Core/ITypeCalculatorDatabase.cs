namespace TypeCalculator.Core
{
    public interface ITypeCalculatorDatabase
    {
        ElementTypeAttributes GetAttributesFor(ElementType elementType);
        void UpdateAttributes(ElementTypeAttributes attributes);
    }
}