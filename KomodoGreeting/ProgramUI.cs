using KomodoGreetingRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreeting
{
    class ProgramUI
    {
        private GreetingRepo _repo = new GreetingRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please select what you would like to do:");
                Console.WriteLine("1)Add New Customer\n" +
                    "2)Show All Customers\n" +
                    "3)Update Customer Information\n" +
                    "4)Delete A Customer\n" +
                    "5)Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ShowAll();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        Console.ReadLine();
                        keepRunning = false;
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();

            }
        }

        private void AddCustomer()
        {

        }

        private void ShowAll()
        {
            Console.Clear();

            List<GreetingRepo> listOfCustomers = _repo.ListAll();
            
            foreach(GreetingRepo person in listOfCustomers)
            {
                Console.WriteLine($"Name: {person.FullName}\n +" +
                    $"Type: {person.Type}\n" +
                    $"Email: {CustomerType}";
            }
        }

        private void UpdateCustomer()
        {

        }

        private void DeleteCustomer()
        {

        }

        private void Customers()
        {
            GreetingRepo jakeSmith = new GreetingRepo("Jake", "Smith", CustomerType.Potential);
            GreetingRepo jamesSmith = new GreetingRepo("James", "Smith", CustomerType.Current);
            GreetingRepo janeSmith = new GreetingRepo("Jane", "Smith", CustomerType.Past);

            _repo.AddACustomer(jakeSmith);
            _repo.AddACustomer(jamesSmith);
            _repo.AddACustomer(janeSmith);

        }
    }
}
