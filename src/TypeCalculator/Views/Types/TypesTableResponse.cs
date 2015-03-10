using System.Collections.Generic;
using TypeCalculator.Core;

namespace TypeCalculator.Views.Types
{
    public class TypesTableResponse
    {
        public IList<ElementStats> Stats { get; set; }
    }
}