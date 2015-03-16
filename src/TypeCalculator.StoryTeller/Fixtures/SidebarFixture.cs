using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller.Engine;
using TypeCalculator.Core;

namespace TypeCalculator.StoryTeller.Fixtures
{
    [Hidden]
    public class SidebarFixture : ScreenFixture
    {
        [FormatAs("Select Type One: {selectType}")]
        public void SelectType([EnumSelectionValues(typeof(ElementType))] string selectType)
        {
            Driver.FindElement(By.CssSelector("#typeOneSidebarSelect .selection-item[value=" + selectType.ToLower() + "]"))
                .Click();
        }

        [FormatAs("Select Type Two: {selectType}")]
        public void SelectTypeTwo([EnumSelectionValues(typeof(ElementType))] string selectType)
        {
            Driver.FindElement(By.CssSelector("#typeTwoSidebarSelect .selection-item[value=" + selectType.ToLower() + "]"))
                .Click();
        }

        [FormatAs("The First Type Selected Should be {return}")]
        [return: AliasAs("Type"), EnumSelectionValues(typeof(ElementType))]
        public string FirstTypeSelectedShouldBe()
        {
            return Driver.FindElement(By.CssSelector("#typeOneSidebarSelect .selected")).Text;
        }

        [FormatAs("The Second Type Selected Should be {return}")]
        [return: AliasAs("Type"), EnumSelectionValues(typeof(ElementType))]
        public string SecondTypeSelectedShouldBe()
        {
            return Driver.FindElement(By.CssSelector("#typeTwoSidebarSelect .selected")).Text;
        }
    }
}
