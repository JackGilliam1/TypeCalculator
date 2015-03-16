using System;
using System.Linq;
using OpenQA.Selenium;
using Serenity;
using Serenity.Fixtures;
using StoryTeller.Engine;

namespace TypeCalculator.StoryTeller.Fixtures
{
    [Hidden]
    public class SwitchLayoutsFixture : ScreenFixture
    {
        private const string TableLayoutId = "typesTableSection";
        private const string ColumnLayoutId = "typesColumnSection";

        [FormatAs("Switch to Layout: {layout}")]
        public bool SwitchToLayout([EnumSelectionValues(typeof(TypeLayout))] string layout)
        {
            SetData(By.CssSelector("#switchLayoutSection select"), layout);
            return WaitForLayoutSwitch((TypeLayout) Enum.Parse(typeof(TypeLayout), layout));
        }

        private bool WaitForLayoutSwitch(TypeLayout layout)
        {
            var id = "";
            switch (layout)
            {
                case TypeLayout.Column:
                    id = ColumnLayoutId;
                    break;
                case TypeLayout.Table:
                    id = TableLayoutId;
                    break;
            }
            return Wait.Until(() => Driver.FindElements(By.Id(id)).Any(x => x.Displayed), timeoutInMilliseconds: 1000);
        }
    }

    public enum TypeLayout
    {
        Column,
        Table
    }
}
