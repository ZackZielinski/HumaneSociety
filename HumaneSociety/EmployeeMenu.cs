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

        HumaneSocietyDataDataContext HumaneSocietyDatabase;

        public EmployeeMenu()
        {
            HumaneSocietyDatabase = new HumaneSocietyDataDataContext();
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
                    var AnimalList = from i in HumaneSocietyDatabase.Animals select i;
                    AnimalList.ToList();
                    foreach (var element in AnimalList)
                    {
                        Console.WriteLine(element);
                    }
                    Console.ReadLine();
                    break;

                case 2:
                    EditAnimalDatabase();
                    break;

                case 3:
                    var CustomerList = from x in HumaneSocietyDatabase.Customers select x;
                    CustomerList.ToList();
                    foreach(var element in CustomerList)
                    {
                        Console.WriteLine(element);
                    }
                    break;

                case 4:
                    EditCustomerDatabase();
                    break;

                    case 5:
                    Console.WriteLine("Thank you. Please come again!");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Sorry, that is not an option. Please try again.");
                    SelectOption(Input);
                    break;
            }

        }

        private void EditAnimalDatabase()
        {
            Console.WriteLine("Would you like to add an animal (1) \n or change an animal's adoption status? (2)");
            EmployeeInput = Convert.ToInt32(Console.ReadLine());

            switch (EmployeeInput)
            {
                case 1:

                    break;
            }

        }

        private void EditCustomerDatabase()
        {
            Console.WriteLine("Would you like to add a customer (1) \n or change a customer's adoption eligibility? (2)");
            EmployeeInput = Convert.ToInt32(Console.ReadLine());
        }


    }
}
