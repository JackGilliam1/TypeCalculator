using System;
using System.Linq;
using StoryTeller.Engine;

namespace TypeCalculator.StoryTeller
{
    public class EnumSelectionValuesAttribute : SelectionValuesAttribute
    {
        public EnumSelectionValuesAttribute(Type names, params string[] exclude)
            : base(Enum.GetNames(names)
            .Where(x => !exclude.Contains(x))
            .ToArray())
        {
            
        }
    }
}
