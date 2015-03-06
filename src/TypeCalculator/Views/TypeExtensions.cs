using System.Collections.Generic;
using System.Linq;
using TypeCalculator.Core;

namespace TypeCalculator.Views
{
    public static class TypeExtensions
    {
        public static void Add(this IDictionary<ElementType, IList<ElementType>> elementDictionary, ElementType element, params ElementType[] elementTypes)
        {
            elementDictionary.Add(element, elementTypes.ToList());
        }
    }
}