using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepo
{
    public class CafeMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string ListOfIngredients { get; set; }
        public decimal Price { get; set; }

        public CafeMenu()
        {

        }

        public CafeMenu(int mealNumber, string mealName, string decription, string listofingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = decription;
            ListOfIngredients = listofingredients;
            Price = price;

        }
    }
}
