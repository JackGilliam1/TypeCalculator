using System.Collections.Generic;
using TypeCalculator.Views;

namespace TypeCalculator.Core
{
    public interface ITypeCalculatorDatabase
    {
        ElementTypeAttributes GetAttributesFor(string elementType);
        void UpdateAttributes(ElementTypeAttributes attributes);
        void AddStat(string typeOne, string typeTwo, StatType statType);
        void UpdateTypesList(IList<string> types);
        IList<string> GetTypesList();
    }
}