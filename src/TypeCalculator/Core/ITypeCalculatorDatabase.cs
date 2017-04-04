using System.Collections.Generic;
using TypeCalculator.Views;

namespace TypeCalculator.Core
{
    public interface ITypeCalculatorDatabase
    {
        ElementTypeAttributes GetAttributesFor(string elementType);
        void UpdateAttributes(ElementTypeAttributes attributes);
        void InsertAttributes(IEnumerable<ElementTypeAttributes> attributes);
        void AddStat(string typeOne, string typeTwo, StatType statType);
        void UpdateTypesList(IEnumerable<string> types);
        TypesList GetTypesList();
    }
}