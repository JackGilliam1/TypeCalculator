using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Serenity;
using Serenity.Fixtures;
using StoryTeller;
using StoryTeller.Engine;
using TypeCalculator.Core;

namespace TypeCalculator.StoryTeller.Fixtures
{
    public class TypeFixture : ScreenFixture
    {
        public TypeFixture()
        {
            AddSelectionValues("BadgeStatus", new [] {
                "Updating", "Updated"
            });
        }

        [FormatAs("Select Type One: {selectType}")]
        public void SelectType([EnumSelectionValues(typeof(ElementType))] string selectType)
        {
            var selector = By.CssSelector("#typeOneSidebarSelect .selection-item." + selectType.ToLower());
            Driver.WaitForElement(selector);
            Driver.FindElement(selector)
                .Click();
            WaitForStatus("Updated");
        }

        [FormatAs("Select Type Two: {selectType}")]
        public void SelectTypeTwo([EnumSelectionValues(typeof(ElementType))] string selectType)
        {
            var selector = By.CssSelector("#typeTwoSidebarSelect .selection-item." + selectType.ToLower());
            Driver.WaitForElement(selector);
            Driver.FindElement(selector)
                .Click();
            WaitForStatus("Updated");
        }

        [FormatAs("Wait for Status {status}")]
        public void WaitForStatus([SelectionValues("BadgeStatus")] string status)
        {
            Wait.Until(() =>
            {
                try
                {
                    return Driver.FindElement(By.Id("#statusBadge")).Text == status;
                }
                catch(NoSuchElementException)
                {
                }
                return false;
            }, timeoutInMilliseconds: 2000);
        }

        public IGrammar SwitchLayouts()
        {
            return Embed<SwitchLayoutsFixture>("Switch Layouts");
        }

        public IGrammar TableLayout()
        {
            return Embed<TableLayoutFixture>("Table Layout");
        }

        public IGrammar Sidebar()
        {
            return Embed<SidebarFixture>("Sidebar");
        }

        public IGrammar StrengthsShouldContain()
        {
            return TypesShouldContain("attackSection", "strong", "Strong Attack");
        }

        public IGrammar WeakAttackShouldContain()
        {
            return TypesShouldContain("attackSection", "weak", "Weak Attack");
        }

        public IGrammar WeaknessesShouldContain()
        {
            return TypesShouldContain("defenseSection", "weak", "Weak Defense");
        }

        public IGrammar ImmunitiesShouldContain()
        {
            return TypesShouldContain("defenseSection", "immune", "Immune Defense");
        }

        public IGrammar StrongAgainstShouldContain()
        {
            return TypesShouldContain("defenseSection", "strong", "Strong Defense");
        }

        private IGrammar TypesShouldContain(string section, string type, string listName)
        {
            return VerifyStringList(() => GetTypes(section, type)
                .Select(x => x.Text)
                .ToList())
                .Ordered()
                .Titled("The List " + listName + " Should Contain")
                .Grammar();
        }

        private IEnumerable<IWebElement> GetTypes(string sectionId, string type)
        {
            var columnTypes = Driver.FindElement(By.CssSelector("." + sectionId + "." + type));
            return columnTypes.FindElements(By.ClassName("type"));
        }
    }
}
