using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class AnimalDatabaseEditing
    {
        string EmployeeInput;
        public AnimalDatabaseEditing()
        {

        }

        public void EditingMenu()
        {
            Console.WriteLine("What are you editing the database for?");
            Console.WriteLine(" Adding a new Animal \n Adopt Status \n Room Number \n Feeding");
            EmployeeInput = (Console.ReadLine());
        }

    }
}
