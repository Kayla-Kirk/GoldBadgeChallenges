using KomodoCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeTest
{
    [TestClass]
    public class KomodaCafe_RepoTests
    {
        MenuRepo _testRepo = new MenuRepo();
        CafeMenu menu = new CafeMenu(2, "Chicken Goo", "Creamed Chicken On Toast", "Chicken, Cream of Celery soup, Cream of Chicken soup, Butter and Milk", 5.50m);

        [TestMethod]
        public void DisplayMenuInfoTest()
        {
            //Arrange
            List<CafeMenu> retrieveList;

            //Act
            retrieveList = _testRepo.GetMenu();
            int count = retrieveList.Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void DisplayMenuTest()
        {
            //Arrange
            _testRepo.AddContent(menu);

            //Act
            List<CafeMenu> dish = _testRepo.GetMenu();
            bool fullMenu = dish.Contains(menu);

            //Assert
            Assert.IsTrue(fullMenu);

        }

        [TestMethod]
        public void GetMealByNumber()
        {
            //Arrange
            _testRepo.AddContent(menu);
            int number = 2;

            //Act
            CafeMenu dish = _testRepo.FindByNumber(number);

            //Assert
            Assert.AreEqual(dish.MealNumber, number);
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            //Arrange
            CafeMenu dish = new CafeMenu();
            MenuRepo repo = new MenuRepo();
            List<CafeMenu> list = repo.GetMenu();

            //Act
            int beforeCount = list.Count;
            repo.AddContent(dish);
            int afterCount = list.Count;
            int expected = beforeCount + 1;

            //Assert
            Assert.AreEqual(expected, afterCount);
        }

        [TestMethod]
        public void RemoveMenuItemTest()
        {
            //Arrange
            _testRepo.AddContent(menu);

            //Act
            CafeMenu meal = _testRepo.DisplayMenu("Chicken Goo");
            bool wasRemoved = _testRepo.DeleteMenuItem(meal);

            //Assert
            Assert.IsTrue(wasRemoved);

        }
    }
}