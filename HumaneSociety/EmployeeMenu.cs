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
                    
                    foreach (var animal in AnimalList)
                    {
                        string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                        Console.WriteLine("ID Number: " + animal.AnimalID + "\n Name:" + animal.AnimalName + "\n Age: " + animal.AnimalAge + " Years old \n Type: " + animal.AnimalType + "\n Breed: " + animal.Breed + "\n Last Shot: " + animal.LastVaccineShot + "\n Needs to be fed " + animal.FoodBowlsNeeded + " times per day. \n Room Number :" + animal.Room + "\n Is Adopted: " + AdoptStatus + "\n $" + animal.Price);
                    }
                    Console.ReadLine();
                    Menu();
                    break;

                case 2:
                    EditAnimalDatabase();
                    break;

                case 3:
                    var CustomerList = GetCustomerData();
                    
                    foreach(var customer in CustomerList)
                    {
                        string Eligibility = CheckCustomerAdoptionStatus(customer);
                        Console.WriteLine(" ID Number : " + customer.CustomerID + "\n Name:" + customer.CustomerFirstName + " " + customer.CustomerLastName + "\n Age: " + customer.CustomerAge + "\n Likes: " + customer.CustomerLikeAnimalType + "\n Specifically Likes: " + customer.CustomerLikeAnimalBreed + "\n Dislikes: " + customer.CustomerDislikeAnimalType + "\n Is Eligible To Adopt an Animal: " + Eligibility);
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

        private string CheckAnimalAdoptionStatus(Animal CurrentAnimal)
        {

            if (CurrentAnimal.IsAdopted == true)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }

        }

        private string CheckCustomerAdoptionStatus(Customer CurrentCustomer)
        {

            if (CurrentCustomer.IsEligibleToAdopt == true)
            {
                return "Yes";
            }
            else
            {
                return "No";
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

            switch (EmployeeInput)
            {
                case 1:
                    AddNewCustomer();
                    break;
                case 2:
                    ChangeEligibility();
                    break;
                default:
                    Console.WriteLine("Sorry. That is not an option. Returning to Menu");
                    Menu();
                    break;
            }

        }

        private void AddNewCustomer()
        {
            Console.WriteLine("Enter Customer's First Name:");
            string NewCustomerFirstName = Console.ReadLine();

            Console.WriteLine("Enter Customer's Last Name:");
            string NewCustomerLastName = Console.ReadLine();

            Console.WriteLine("Enter Customer's Age:");
            int NewCustomerAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Type of Animal the Customer likes:");
            string NewCustomerTypeLikes = Console.ReadLine();

            Console.WriteLine("Enter a Breed of the Animal they like:");
            string NewCustomerBreedLikes = Console.ReadLine();

            Console.WriteLine("Enter an animal the Customer doesn't like:");
            string NewCustomerDislike = Console.ReadLine();

            bool IsCustomerEligible = CheckIfCustomerCanAdopt(NewCustomerAge);

            var NewCustomer = new Customer
            {
                CustomerFirstName = NewCustomerFirstName,
                CustomerLastName = NewCustomerLastName,
                CustomerAge = NewCustomerAge,
                CustomerLikeAnimalType = NewCustomerTypeLikes,
                CustomerLikeAnimalBreed = NewCustomerBreedLikes,
                CustomerDislikeAnimalType = NewCustomerDislike,
                IsEligibleToAdopt = IsCustomerEligible
            };

            HumaneDatabase.Customers.InsertOnSubmit(NewCustomer);
            HumaneDatabase.SubmitChanges();
        }
        private bool CheckIfCustomerCanAdopt(int AgeOfCustomer)
        {
            if (AgeOfCustomer >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ChangeEligibility()
        {
            var CustomerList = GetCustomerData();
            Console.WriteLine("Enter the Customer's First Name");
            string FirstName = Console.ReadLine();

            Console.WriteLine("Enter the Customer's Last Name");
            string LastName = Console.ReadLine();

            if (CustomerList.Any(x => x.CustomerFirstName == FirstName && x.CustomerLastName == LastName == true))
                {
                var SelectedCustomer = CustomerList.First(y => y.CustomerFirstName == FirstName && y.CustomerLastName == LastName);
                Console.WriteLine($"What is {SelectedCustomer.CustomerFirstName} {SelectedCustomer.CustomerLastName}'s current eligiblity to adopt?");
                Console.WriteLine("1 - Can Adopt \n 2 - Can't Adopt");
                int AdoptStatus = Convert.ToInt32(Console.ReadLine());

                switch (AdoptStatus)
                {
                    case 1:
                        SelectedCustomer.IsEligibleToAdopt = true;
                        break;
                    case 2:
                        SelectedCustomer.IsEligibleToAdopt = false;
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option. Returning to menu");
                        Menu();
                        break;
                }

            }
        }

    }
}
