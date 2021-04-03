using KomodoBadgeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadgeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBadgetest()
        {
            BadgeRepo repo = new BadgeRepo();
            Dictionary<int, Badges> badge = repo.ShowBadges();

            Badges test = new Badges(42, new List<string> { "D3", "E4" });
            repo.AddABadge(test);

            Assert.IsTrue(badge.ContainsValue(test));
        }

        [TestMethod]
        public void EditAddTest()
        {
            BadgeRepo repo = new BadgeRepo();
            Dictionary<int, Badges> badge = repo.ShowBadges();

            Badges test = new Badges(42, new List<string> { "D3", "E4" });
            repo.AddABadge(test);
            repo.EditABadge(test.BadgeID, false, "A2");

            Assert.IsTrue(badge[test.BadgeID].Doors.Contains("A2"));
        }

        [TestMethod]
        public void EditRemoveTest()
        {
            BadgeRepo repo = new BadgeRepo();
            Dictionary<int, Badges> badge = repo.ShowBadges();

            Badges test = new Badges(42, new List<string> { "D3", "E4" });
            repo.AddABadge(test);
            repo.EditABadge(test.BadgeID, true, "D3");

            Assert.IsFalse(badge[test.BadgeID].Doors.Contains("D3"));
        }
    }
}
