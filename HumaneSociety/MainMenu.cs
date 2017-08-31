using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class MainMenu
    {
        string UserInput;
        EmployeeMenu employee;
        
        public MainMenu()
        {

        }

        public void WelcomeMenu()
        {
            Console.WriteLine("Welcome to the Humane Society. Are you an Employee or a Customer?");
            UserInput = Console.ReadLine();
            ChangeMenus(UserInput);
        }

        private void ChangeMenus(string UserChoice)
        {
            switch (UserChoice.ToLower())
            {
                case "employee":
                    employee = new EmployeeMenu();
                    employee.Menu();
                    break;

                case "customer":
                                        
                    break;
            }
        }
    }
}
