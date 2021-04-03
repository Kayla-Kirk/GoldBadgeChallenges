using KomodoClaimRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ProgramUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            ClaimList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Claims Department\n" +
                    "Please select an option:\n" +
                    "1) See all claims\n" +
                    "2) Take care of next claim\n" +
                    "3) Enter a new claim\n" +
                    "4) Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please try again");
                        break;
                }

            }
        }

        
        private void SeeAllClaims()
        {            
            Queue<Claims> claimList = _repo.GetClaims();

            Console.Clear();
            Console.WriteLine("ClaimID  Type    Description         Amount     DateOfAccident       DateOfClaim");
            foreach (Claims claims in claimList)
            {
                Console.WriteLine($"{claims.ClaimID}         {claims.TypeOfClaim}  {claims.Description}  {claims.ClaimAmount}           {claims.DateOfIncident.ToShortDateString()}         {claims.DateOfClaim.ToShortDateString()}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void GetNextClaim()
        {
            Console.Clear();
            Console.WriteLine("The next claim to be handled is:\n");

            Queue<Claims> newList = _repo.GetClaims();
            Claims nextClaim = newList.Peek();

            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"DateOfAccount: {nextClaim.DateOfIncident}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n" +
                "Do you want to deal with this claim now (y/n)?");

            string userInput = Console.ReadLine();

            switch (userInput.ToLower())
            {
                case "y":
                    newList.Dequeue();
                    Console.WriteLine("Congradulations! It's yours now!\n Press any key to continue...");
                    break;
                case "n":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please enter either y or n");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }

        public void NewClaim()
        {
            Claims claims = new Claims();
            Console.Clear();
            Console.WriteLine("Enter the claim ID:");
            claims.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type:\n" +
                "1)Car\n" +
                "2)Home\n" +
                "3)Theft");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    claims.TypeOfClaim = ClaimType.Car;
                    break;
                case "2":
                    claims.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    claims.TypeOfClaim = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a vaid number.");
                    break;
            }

            Console.WriteLine("Enter a claim decription:");
            claims.Description = Console.ReadLine();

            Console.WriteLine("Enter amount of damage:");
            claims.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the accident(mm/dd/yyyy):");
            claims.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of the claim(mm/dd/yyyy):");
            claims.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _repo.IsValid(claims);

            _repo.AddClaim(claims);

            Console.WriteLine("Successfully Added to the queue!");
            Console.ReadKey();
            Console.Clear();
        }

        private void ClaimList()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, DateTime.Parse("04/25/2018"),DateTime.Parse("04/27/2018"), true);
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/12/2018"), true);
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen Pancakes", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("06/01/2018"), false);

            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
    }
}