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
        HumaneSocietyDataDataContext HumaneDatabase;
        Transactions AdoptingAnAnimal;

        public EmployeeMenu()
        {
            HumaneDatabase = new HumaneSocietyDataDataContext();
        }

        public void Menu()
        {
            Console.WriteLine("Hello, employee. What would you like to do?");
            Console.WriteLine(" 1 - View Animal Database \n 2 - Edit Animal Database \n 3 - View Customer Database \n 4 - Edit Customer Database \n 5 - Exit");
            Console.Write(" ");
            EmployeeInput = Convert.ToInt32(Console.ReadLine());

            SelectOption(EmployeeInput);
        }

        private void SelectOption(int Input)
        {
            switch (Input)
            {
                case 1:
                    var AnimalList = GetAnimalData();
                    string AdoptStatus;
                    foreach (var animal in AnimalList)
                    {
                        if (animal.IsAdopted == false)
                        {
                            AdoptStatus = "Yes";
                        }
                        else
                        {
                            AdoptStatus = "No";
                        }
                        Console.WriteLine(" ID Number : " + animal.AnimalID + "\n Name:" + animal.AnimalName + "\n Age: " + animal.AnimalAge + " Years old \n Type: " + animal.AnimalType + "\n Breed: " + animal.Breed + "\n Last Shot: " + animal.LastVaccineShot + "\n Needs to be fed " + animal.FoodBowlsNeeded + " times per day. \n Room Number :" + animal.Room + "\n Is Adopted: " + AdoptStatus + "\n $" + animal.Price);
                    }
                    Console.ReadLine();
                    Menu();
                    break;

                case 2:
                    EditAnimalDatabase();
                    break;

                case 3:
                    var CustomerList = GetCustomerData();
                    string Eligibility;
                    foreach(var customer in CustomerList)
                    {
                        if(customer.IsEligibleToAdopt == false)
                        {
                            Eligibility = "Yes";
                        }
                        else
                        {
                            Eligibility = "No";
                        }
                        Console.WriteLine(" ID Number : " + customer.CustomerID + ", Name:" + customer.CustomerName + " Age: " + customer.CustomerAge + "\n Likes: " + customer.CustomerLikeAnimalType + " Specifically: " + customer.CustomerLikeAnimalBreed + "\n Dislikes: " + customer.CustomerDislikeAnimalType + "\n Is Eligible To Adopt an Animal: " + Eligibility);
                    }
                    break;

                case 4:
                    EditCustomerDatabase();
                    break;


                case 5:
                    AdoptingAnAnimal = new Transactions();
                    AdoptingAnAnimal.StartTransaction();
                    break;

                case 6:
                    Console.WriteLine("Thank you. Please come again!");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Sorry, that is not an option. Please try again.");
                    SelectOption(Input);
                    break;
            }

        }

        private List<Animal> GetAnimalData()
        {
            var result = from i in HumaneDatabase.Animals select i;
            return result.ToList();
        }

        private List<Customer> GetCustomerData()
        {
            var result = from i in HumaneDatabase.Customers select i;
            return result.ToList();
        }

        private void EditAnimalDatabase()
        {
            Console.WriteLine("Would you like to add an animal (Y/N)");
            string EditInput = Console.ReadLine();

            switch (EditInput.ToLower())
            {
                case "y":
                    AddNewAnimal();
                    Menu();
                    break;
                case "n":
                    Menu();
                    break;
            }

        }

        private void EditAdoptionStatus()
        {
            HumaneSocietyDataDataContext HumaneData = new HumaneSocietyDataDataContext();
            var AnimalList = GetAnimalData();
            int AdoptStatus;

            Console.WriteLine("Please enter the Animal's ID Number");
            int IDNumber = Convert.ToInt32(Console.ReadLine());

            bool Match = AnimalList.Any(x => x.AnimalID == IDNumber);

            if (Match == true)
            {
                var SelectedAnimal = AnimalList.First(x => x.AnimalID == IDNumber);
                Console.WriteLine($"What is their adoption status? \n 1 - Adopted \n 2 - Not Adopted");
                AdoptStatus = Convert.ToInt32(Console.ReadLine());

                switch (AdoptStatus)
                {
                    case 1:
                        SelectedAnimal.IsAdopted = true;
                        break;
                    case 2:
                        SelectedAnimal.IsAdopted = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option. Returning to menu");
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Sorry, we couldn't find that animal.");
                Menu();
            }

        }

        private void AddNewAnimal()
        {               
            Console.WriteLine("Enter Animal's Name: ");
            string NewAnimalName = Console.ReadLine();

            Console.WriteLine("Enter Animal's Age: ");
            int NewAnimalAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Type of Animal: ");
            string NewAnimalType = Console.ReadLine();

            Console.WriteLine("Enter the Breed of the Animal: ");
            string NewAnimalBreed = Console.ReadLine();

            Console.WriteLine("When was the Animal's Last shot taken?");
            string LastShotTaken = Console.ReadLine();

            Console.WriteLine("How many times does this animal need to be fed?");
            int FoodNeeded = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter The Room the Animal will be staying in: ");
            string RoomNumber = CheckIfRoomIsAlreadyUsed();

            var NewAnimal = new Animal
            {
                AnimalName = NewAnimalName,
                AnimalAge = NewAnimalAge,
                AnimalType = NewAnimalType,
                Breed = NewAnimalBreed,
                LastVaccineShot = LastShotTaken,
                FoodBowlsNeeded = FoodNeeded,
                Room = RoomNumber
            };

            HumaneDatabase.Animals.InsertOnSubmit(NewAnimal);
            HumaneDatabase.SubmitChanges();
            Menu();
           }


       private string CheckIfRoomIsAlreadyUsed()
        {
            HumaneSocietyDataDataContext HumaneData = new HumaneSocietyDataDataContext();
            var AnimalList = GetAnimalData();

            string RoomNumber = Console.ReadLine();

            for (int x = 0; x < AnimalList.Count; x++)
            {
                if (AnimalList[x].Room == RoomNumber)
                {
                    Console.WriteLine("Sorry, that room is already taken. Please Enter Another Room");
                    CheckIfRoomIsAlreadyUsed();
                }
            }
            return RoomNumber;
        }
        private void EditCustomerDatabase()
        {
            Console.WriteLine("Would you like to add a customer (1) \n or change a customer's adoption eligibility? (2)");
            EmployeeInput = Convert.ToInt32(Console.ReadLine());
        }


    }
}
