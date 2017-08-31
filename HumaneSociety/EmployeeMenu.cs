using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class EmployeeMenu
    {
        int EmployeeInput;
        AnimalDatabaseDataContext AnimalDatabase;
        CustomerProfileDatabaseDataContext CustomerDatabase;

        public EmployeeMenu()
        {
            AnimalDatabase = new AnimalDatabaseDataContext();
            CustomerDatabase = new CustomerProfileDatabaseDataContext();
        }

        public void Menu()
        {
            Console.WriteLine("Hello, employee. What would you like to do?");
            Console.WriteLine(" 1 - View Animal Database \n 2 - Edit Animal Database \n 3 - View Customer Database \n 4 - Edit Customer Database 5 - Exit");
            EmployeeInput = Convert.ToInt32(Console.ReadLine());

            SelectOption(EmployeeInput);
        }

        private void SelectOption(int Input)
        {
            switch (Input)
            {
                case 1:
                    GetAnimals();
                    break;

                case 2:
                    
                    break;

                case 3:

                    break;

                case 4:
                    break;
            }

        }

        private void GetAnimals()
        {

        }

    }
}
