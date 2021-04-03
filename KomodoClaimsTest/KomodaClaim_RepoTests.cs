using KomodoClaimRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoClaimsTest
{
    [TestClass]
    public class KomodaClaim_RepoTests
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        private Claims claims = new Claims();

        [TestMethod]
        public void GetAllClaims()
        {
            _repo.GetClaims();
            Assert.IsNotNull(_repo);
        }

        [TestMethod]
        public void AddAClaim()
        {
            _repo.AddClaim(claims);

            int expected = 1;
            int actual = _repo.GetClaims().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAClaim()
        {
            _repo.AddClaim(claims);

            int actual = _repo.GetClaims().Count;
            _repo.RemoveClaims();
            int removed = _repo.GetClaims().Count;

            Assert.AreNotEqual(actual, removed);
        }

        [TestMethod]
        public void ClaimIsValid()
        {
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            _repo.AddClaim(claimTwo);

            bool expected = true;
            bool actual = claimTwo.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsIsNotValid()
        {
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);
            _repo.AddClaim(claimThree);

            bool expected = false;
            bool actual = claimThree.IsValid;

            Assert.AreEqual(expected, actual);
        }
    }
}
