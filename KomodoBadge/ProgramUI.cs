using KomodoBadgeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge
{
    class ProgramUI
    {
        BadgeRepo badgeRepo = new BadgeRepo();
        bool isRunning = true;

        public void Run()
        {
            badgeRepo.AddABadge(new Badges(12345, new List<string> { "A7" }));
            badgeRepo.AddABadge(new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" }));
            badgeRepo.AddABadge(new Badges(32345, new List<string> { "A4", "A5" }));

            Menu();
        }

        public void Menu()
        {            
            while (isRunning)
            {
                Console.WriteLine("Hello Security Admin!\n" +
                    "What would you like to do?\n" +
                    "1) Add a badge\n" +
                    "2) Edit a badge\n" +
                    "3) List all badges\n" +
                    "4) Exit");

                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void AddABadge()
        {
            bool valid = false;
            int id = -1;
            Console.Clear();
            ListAllBadges();
            Console.WriteLine("What is the number for the badge?");

            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out id);
                    if (!valid)
                {
                    Console.WriteLine("Please enter a valid number:");
                }
            }
            valid = false;
            List<string> doors = new List<string>();
            badgeRepo.AddABadge(new Badges(id, doors));

            Console.WriteLine("Enter a door for this badge to have access to:");
            while (!valid)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "menu")
                {
                    valid = true;
                }
                else
                {
                    badgeRepo.EditABadge(id, false, input);
                    Console.WriteLine("Please enter the next door for this badge or menu to return to that main menu.");
                }
            }

        }

        public void EditABadge()
        {
            Console.Clear();
            ListAllBadges();
            Console.WriteLine("Which bagde would you like to edit?");
            bool valid = false;
            int id = -1;
                while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out id);
                if (!valid)
                {
                    Console.WriteLine("Please enter a valid number:");
                }
            }
            Badges fix = badgeRepo.ShowBadges()[id];
            bool edit = true;

            while (edit)
            {
                Console.WriteLine("What would you like to do? Add, Remove, or Menu?");
                switch (Console.ReadLine().ToLower())
                {
                    case "add":
                        Console.WriteLine("What door would you like to add?");
                        badgeRepo.EditABadge(fix.BadgeID, false, Console.ReadLine());
                        break;
                    case "remove":
                        Console.WriteLine("What door would you like to remove?");
                        badgeRepo.EditABadge(fix.BadgeID, true, Console.ReadLine());
                        break;
                    case "menu":
                        edit = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 'Add', 'Remove', or 'Menu'");
                        break;

                }
            }
        }

        public void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Here are the badges:\nBadge #: \tDoor Access:");
            Dictionary<int, Badges> badges = badgeRepo.ShowBadges();
            foreach(var item in badges)
            {
                string list = "";
                foreach(var door in item.Value.Doors)
                {
                    list += door + " ";
                }
                Console.WriteLine(item.Value.BadgeID + "\t\t" + list + "\n");
            }
        }        
    }
}
