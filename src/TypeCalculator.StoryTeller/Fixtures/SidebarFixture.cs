using System.Linq;
using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller.Engine;
using TypeCalculator.Core;

namespace TypeCalculator.StoryTeller.Fixtures
{
    [Hidden]
    public class SidebarFixture : ScreenFixture
    {
        public SidebarFixture()
        {
            AddSelectionValues("Types",
                ElementTypes.Types.ToArray());
        }

        [FormatAs("Select Type One: {selectType}")]
        public void SelectType([SelectionValues("Types")] string selectType)
        {
            Driver.FindElement(By.CssSelector("#typeOneSidebarSelect .selection-item." + selectType.ToLower()))
                .Click();
        }

        [FormatAs("Select Type Two: {selectType}")]
        public void SelectTypeTwo([SelectionValues("Types")] string selectType)
        {
            Driver.FindElement(By.CssSelector("#typeTwoSidebarSelect .selection-item." + selectType.ToLower()))
                .Click();
        }

        [FormatAs("The First Type Selected Should be {return}")]
        [return: AliasAs("Type"), SelectionValues("Types")]
        public string FirstTypeSelectedShouldBe()
        {
            return Driver.FindElement(By.CssSelector("#typeOneSidebarSelect .selected")).Text;
        }

        [FormatAs("The Second Type Selected Should be {return}")]
        [return: AliasAs("Type"), SelectionValues("Types")]
        public string SecondTypeSelectedShouldBe()
        {
            return Driver.FindElement(By.CssSelector("#typeTwoSidebarSelect .selected")).Text;
        }
    }
}
