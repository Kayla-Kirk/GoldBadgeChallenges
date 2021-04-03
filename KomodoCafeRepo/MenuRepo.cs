using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepo
{
    public class MenuRepo
    {
        List<CafeMenu> _listOfCafeMenu = new List<CafeMenu>();

        //CRUD

        //Create
        public void AddContent(CafeMenu dish)
        {
            _listOfCafeMenu.Add(dish);
        }

        //Read
        public List<CafeMenu> GetMenu() //List all Orders
        {
            return _listOfCafeMenu;
        }

        public CafeMenu FindByNumber(int menuNumber) //List by number
        {
            foreach(CafeMenu menuItem in _listOfCafeMenu)
            {
                if(menuItem.MealNumber == menuNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

       
        //Delete
        public bool DeleteMenuItem(CafeMenu dish)
        {
            int initialCount = _listOfCafeMenu.Count;

            _listOfCafeMenu.Remove(dish);

            if(initialCount > _listOfCafeMenu.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public CafeMenu DisplayMenu(string mealName)
        {
            foreach (CafeMenu dish in _listOfCafeMenu)
            {
                if (dish.MealName.ToLower() == mealName.ToLower())
                {
                    return dish;
                }
            }

            return null;
        }
    }
}
