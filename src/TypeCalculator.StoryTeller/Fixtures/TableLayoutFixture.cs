using OpenQA.Selenium;
using Serenity;
using Serenity.Fixtures;
using StoryTeller.Engine;

namespace TypeCalculator.StoryTeller.Fixtures
{
    [Hidden]
    public class TableLayoutFixture : ScreenFixture
    {
        [FormatAs("Select Type Combination {typeOne}, {typeTwo}")]
        public void SelectTypeCombination(
            [EnumSelectionValues(typeof (string), "None")] string typeOne,
            [EnumSelectionValues(typeof (string), "None")] string typeTwo)
        {
            var selector = By.ClassName(typeOne + typeTwo);
            Driver.FindElement(selector)
                .Click();
        }

        [FormatAs("Type Combination {typeOne} and {typeTwo} Should Be Selected")]
        public bool TypeCombinationShouldBeSelected(
            [EnumSelectionValues(typeof (string), "None")] string typeOne,
            [EnumSelectionValues(typeof (string), "None")] string typeTwo)
        {
            var selector = By.ClassName(typeOne + typeTwo);
            return Wait.Until(() => Driver.FindElement(selector).HasClass("selected"));
        }
    }
}
