using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetingRepo
{
    class GreetingRepo
    {
        List<GreetingRepo> _listOfGreetings = new List<GreetingRepo>();
        public void AddACustomer(GreetingRepo customer)
        {
            _listOfGreetings.Add(customer);
        }

        public List<GreetingRepo> ListAll()
        {
            return _listOfGreetings;
        }

        public GreetingRepo Customer(string name)
        {
            foreach(GreetingRepo customer in _listOfGreetings)
            {
                if(customer.FullName.ToLower() == name.ToLower())
                {
                    return customer;
                }
            }

            return null;
        }

        public bool Update(string customer, GreetingRepo updatedCustomer)
        {
            GreetingRepo oldInfo = Customer(customer);

            if (oldInfo != null)
            {
                oldInfo.FirstName = updatedCustomer.FirstName;
                oldInfo.LastName = updatedCustomer.LastName;
                oldInfo.Type = updatedCustomer.Type;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(GreetingRepo customer)
        {
            _listOfGreetings.Remove(customer);
        }

        public void Email(CustomerType email)
        {
            switch (email)
            {
                case CustomerType.Potential:
                    Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                    break;
                case CustomerType.Current:
                    Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                    break;
                case CustomerType.Past:
                    Console.WriteLine("It's been a long time since we've heard from you, we want you back");
                    break;
            }
        }
    }
}
