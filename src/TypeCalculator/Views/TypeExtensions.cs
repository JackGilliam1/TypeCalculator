using System.Collections.Generic;
using System.Linq;

namespace TypeCalculator.Views
{
    public static class TypeExtensions
    {
        public static void Add(this IDictionary<string, IList<string>> elementDictionary, string element, params string[] elementTypes)
        {
            elementDictionary.Add(element, elementTypes.ToList());
        }
    }
}