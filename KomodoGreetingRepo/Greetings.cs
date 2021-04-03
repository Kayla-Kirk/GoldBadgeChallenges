using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetingRepo
{
    public enum CustomerType
    {
        Potential = 1,
        Current,
        Past
    }

    public class GreetingRepo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }                
                }
        public CustomerType Type { get; set; }

        public GreetingRepo()
        {

        }

        public GreetingRepo(string firstName, string lastName, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = customerType;
        }
    }
}