using KomodoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            FullMenu();
            Menu();

        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe!\n" +
                    "Please select what you would like to do!\n" +
                    "1) View All Menu Items\n" +
                    "2) Display All Information About Dishes\n" +
                    "3) Create A New Menu Item\n" +
                    "4) Delete A Menu Item\n" +
                    "5) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        DisplayMenuInfo();
                        break;
                    case "3":
                        CreateNewMenuItem();
                        break;
                    case "4":
                        RemoveMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();

            List<CafeMenu> listOfMenuItems = _menuRepo.GetMenu();

            foreach(CafeMenu dish in listOfMenuItems)
            {
                Console.WriteLine($"Dish Number: {dish.MealNumber}\n" +
                    $"Dish Name: {dish.MealName}\n" +
                    $"Dish Description: {dish.Description}\n");
            }
        }
        private void DisplayMenuInfo()
        {
            Console.Clear();
            List<CafeMenu> listOfMenuItems = _menuRepo.GetMenu();

            foreach(CafeMenu dish in listOfMenuItems)
            {
                Console.WriteLine($"Dish Number: {dish.MealNumber}\n" +
                    $"Dish Name: {dish.MealName}\n" +
                    $"Dish Description: {dish.Description}\n" +
                    $"List Of Ingredients: {dish.ListOfIngredients}\n" +
                    $"Price Of Dish: {dish.Price}\n");
            }
        }

        private void CreateNewMenuItem()
        {

            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();

            Console.WriteLine("Enter a number for your meal:");
            string mealNumber = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumber);
            Console.WriteLine("Enter the name of your new dish:");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter your description of your dish:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("List the main ingredients of the dish:");
            newMenuItem.ListOfIngredients = Console.ReadLine();
            Console.WriteLine("Enter the price of your dish:");
            string price = Console.ReadLine();
            newMenuItem.Price = decimal.Parse(price);

            _menuRepo.AddContent(newMenuItem);

        }

        private void RemoveMenuItem()
        {
            Console.WriteLine("\nWhich number would you like to remove?");

            List<CafeMenu> listOfMenuItems = _menuRepo.GetMenu();
            
            foreach (CafeMenu dish in listOfMenuItems)
            {
                Console.WriteLine($"#{dish.MealNumber} - {dish.MealName}\n");
            }

            int removeDish = int.Parse(Console.ReadLine());

            CafeMenu menuItem = _menuRepo.FindByNumber(removeDish);

            _menuRepo.DeleteMenuItem(menuItem);

            Console.WriteLine("BAM! It's gone!");
        }


        private void FullMenu()
        {
            CafeMenu chickenPesto = new CafeMenu(1, "Chicken Penne Pesto", "Grilled Chicken, penne pasta, spinach, and tomatoes in a basil pesto sauce", "Chicken, Penne, Basil Pesto, Spinach, and Tomatoes.", 7.75m);
            CafeMenu chickenGoo = new CafeMenu(2, "Chicken Goo", "Creamed Chicken On Toast", "Chicken, Cream of Celery soup, Cream of Chicken soup, Butter and Milk", 5.50m);
            CafeMenu tofuTacos = new CafeMenu(3, "Tofu Tacos", "Crumbled taco inspired tofu, lettuce, cheese, and spicy baja sauce layered into a crunchy taco shell","Taco Spiced Tofu, Lettuce, Cheese, Spicy Baja sauce, and Taco shells", 2.75m);
            CafeMenu tofuChickpeaSalad = new CafeMenu(4, "Tofu and Chickpea Salad", "A bed of mixed greens and veggies topped with roasted Moroccan-inspired spiced chickpea and diced tofu", "Moroccan Spice mix, Chickpeas, Tofu, Mixed Greens, Yellow and Orange Bell Peppers, Cucumbers", 5.50m);

            _menuRepo.AddContent(chickenPesto);
            _menuRepo.AddContent(chickenGoo);
            _menuRepo.AddContent(tofuTacos);
            _menuRepo.AddContent(tofuChickpeaSalad);

        }
    }
}
