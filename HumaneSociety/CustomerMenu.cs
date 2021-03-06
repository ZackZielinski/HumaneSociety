﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class CustomerMenu
    {
        int CustomerInput;
        HumaneSocietyDataDataContext HumaneDatabase;

        public CustomerMenu()
        {
            HumaneDatabase = new HumaneSocietyDataDataContext();
           
        }

        public void Menu()
        {
            Console.WriteLine("Hello, Customer. What would you like to do?");
            Console.WriteLine(" 1 - Search Animal Database \n 2 - Add Yourself to the database \n 3 - View Your Profile \n 4 - Exit");
            Console.Write(" ");
            CustomerInput = Convert.ToInt32(Console.ReadLine());
            SelectOption(CustomerInput);
        }

        private void SelectOption(int Input)
        {
            switch (Input)
            {
                case 1:
                    SearchAnimalList();
                    break;
                case 2:
                    AddNewCustomer();
                    break;
                case 3:
                    ViewCustomerProfile();
                    break;
                default:
                    Console.WriteLine("GoodBye");
                    Console.ReadLine();
                    break;
            }
        }
        private void SearchAnimalList()
        {

            Console.WriteLine("What would you like to see? \n 1 - All Animals \n 2 - Search by specifics");
            CustomerInput = Convert.ToInt32(Console.ReadLine());

            switch (CustomerInput)
            {
                case 1:
                    var AnimalList = GetAnimalData();
                    string AdoptStatus;
                    foreach (var element in AnimalList)
                    {
                        if (element.IsAdopted == false)
                        {
                            AdoptStatus = "Yes";
                        }
                        else
                        {
                            AdoptStatus = "No";
                        }
                        Console.WriteLine(" Name:" + element.AnimalName + "\n Age: " + element.AnimalAge + " Years old \n Type: " + element.AnimalType + "\n Breed: " + element.Breed + "\n Last Shot: " + element.LastVaccineShot + "\n Needs to be fed " + element.FoodBowlsNeeded + " times per day. \n Room Number :" + element.Room + "\n Is Adopted: " + AdoptStatus + "\n $" + element.Price);
                        Console.ReadLine();
                    }
                    Menu();
                    break;
                case 2:
                    SearchByTraits();
                    break;

                default:
                    Console.WriteLine("Sorry, that is not an option. Returning to menu.");
                    Menu();
                    break;
            }

        }

        
        private void AddNewCustomer()
        {
            Console.WriteLine("Enter Your First Name:");
            string NewCustomerFirstName = Console.ReadLine();

            Console.WriteLine("Enter Your Last Name:");
            string NewCustomerLastName = Console.ReadLine();

            Console.WriteLine("Enter Your Age:");
            int NewCustomerAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Type of Animal you like:");
            string NewCustomerTypeLikes = Console.ReadLine();

            Console.WriteLine("Enter a Breed of the Animal you like:");
            string NewCustomerBreedLikes = Console.ReadLine();

            Console.WriteLine("Enter an animal you don't like:");
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
            Menu();
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

        private void SearchByTraits()
        {
            
            Console.WriteLine("What type of animal would you like to see? \n 1 - Type And/Or Breed \n 2 - Age \n 3 - Price");
            int AnimalSearch = Convert.ToInt32(Console.ReadLine());

            switch (AnimalSearch)
            {
                case 1:
                    SearchByTypeAndBreed();
                    break;
                case 2:
                    SearchByAge();
                    break;
                case 3:
                    SearchByPrice();
                    break;
            }

        }

        private void ViewCustomerProfile()
        {
            var CustomerList = GetCustomerData();

            Console.WriteLine("Please Enter your ID Number or Your First Name");
            string FirstCustomerInput = Console.ReadLine();


            if (CustomerList.Any(x => x.CustomerFirstName == FirstCustomerInput) == true)
            {
                Console.WriteLine("Please Enter your Last Name");
                string SecondCustomerInput = Console.ReadLine();

                var CurrentCustomer = CustomerList.First(x => x.CustomerFirstName == FirstCustomerInput && x.CustomerLastName == SecondCustomerInput);

                string Eligibility = CheckCustomerAdoptionStatus(CurrentCustomer);

                Console.WriteLine("ID Number: " + CurrentCustomer.CustomerID + "\n Name:" + CurrentCustomer.CustomerFirstName + " " + CurrentCustomer.CustomerLastName + "\n Age: " + CurrentCustomer.CustomerAge + "\n Likes: " + CurrentCustomer.CustomerLikeAnimalType + "\n Specifically Likes: " + CurrentCustomer.CustomerLikeAnimalBreed + "\n Dislikes: " + CurrentCustomer.CustomerDislikeAnimalType + "\n Is Eligible To Adopt an Animal: " + Eligibility);
            }
            else if(CustomerList.Any(x => x.CustomerID == Convert.ToInt32(FirstCustomerInput)) == true)
            {
                var CurrentCustomer = CustomerList.First(x => x.CustomerID == Convert.ToInt32(FirstCustomerInput));

                string Eligibility = CheckCustomerAdoptionStatus(CurrentCustomer);
                
                Console.WriteLine("ID Number: " + CurrentCustomer.CustomerID + "\n Name:" + CurrentCustomer.CustomerFirstName + " " + CurrentCustomer.CustomerLastName + "\n Age: " + CurrentCustomer.CustomerAge + "\n Likes: " + CurrentCustomer.CustomerLikeAnimalType + "\n Specifically Likes: " + CurrentCustomer.CustomerLikeAnimalBreed + "\n Dislikes: " + CurrentCustomer.CustomerDislikeAnimalType + "\n Is Eligible To Adopt an Animal: " + Eligibility);


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
        private void SearchByTypeAndBreed()
        {
            var AnimalList = GetAnimalData();
            Console.WriteLine("What type of animal are you looking for?");
            string AnimalSearch = Console.ReadLine();


            if (AnimalList.Any(x => x.AnimalType == AnimalSearch) == true)
            {
                var SearchedAnimals = AnimalList.Where(x => x.AnimalType == AnimalSearch);

                foreach (var animal in SearchedAnimals)
                {
                    string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                    Console.WriteLine("Name: " + animal.AnimalName + "\n Age: " + animal.AnimalAge + "Years old \n Breed:" + animal.Breed + "Needs to be fed " + animal.FoodBowlsNeeded + " per day \n Last Vaccine Shot:" + animal.LastVaccineShot + "\n Adoption Status: " + AdoptStatus + " \n $" + animal.Price);

                }
            }
            else if (AnimalList.Any(x => x.Breed == AnimalSearch) == true)
            {
                var SearchedAnimals = AnimalList.Where(x => x.Breed == AnimalSearch);

                foreach (var animal in SearchedAnimals)
                {
                    string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                    Console.WriteLine("Name: " + animal.AnimalName + "\n Age: " + animal.AnimalAge + "Years old \n Type:" + animal.AnimalType + "Needs to be fed " + animal.FoodBowlsNeeded + " per day \n Last Vaccine Shot:" + animal.LastVaccineShot + "\n Adoption Status: " + AdoptStatus + " \n $" + animal.Price);

                }
            }
            else
            {
                Console.WriteLine("Sorry. We don't have that type here. Want to search for something else? (y/n)");
                AnimalSearch = Console.ReadLine().ToLower();
                if (AnimalSearch == "y")
                {
                    SearchByTraits();
                }
                else
                {
                    Console.WriteLine("Okay. Returning to Menu.");
                    Menu();
                }
            }
        }

        private void SearchByAge()
        {
            var AnimalList = GetAnimalData();
            Console.WriteLine("Enter an Age to search for");
            int SearchAge = Convert.ToInt32(Console.ReadLine());

            if (AnimalList.Any(x => x.AnimalAge == SearchAge) == true)
            {
                var SearchedAnimalList = AnimalList.Where(y => y.AnimalAge == SearchAge);
                foreach(var animal in SearchedAnimalList)
                {
                    string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                    Console.WriteLine("Name:" + animal.AnimalName + "\n Age: " + animal.AnimalAge + " Years old \n Type: " + animal.AnimalType + "\n Breed: " + animal.Breed + "\n Last Vaccine Shot: " + animal.LastVaccineShot + "\n Needs to be fed " + animal.FoodBowlsNeeded + " times per day.\n Is Adopted: " + AdoptStatus + "\n $" + animal.Price);
                }
            }

        }
        private void SearchByPrice()
        {
            var AnimalList = GetAnimalData();
            Console.WriteLine("Do you wish to see from? \n 1 - Least to Greatest price \n 2 - Greatest to Least price");
            int OrderOfList = Convert.ToInt32(Console.ReadLine());

            switch (OrderOfList)
            {
                case 1:
                    var PriceSearch = AnimalList.OrderBy(x => x.Price);
                    foreach (var animal in PriceSearch)
                    {
                        string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                        Console.WriteLine("Name:" + animal.AnimalName + "\n Age: " + animal.AnimalAge + " Years old \n Type: " + animal.AnimalType + "\n Breed: " + animal.Breed + "\n Last Vaccine Shot: " + animal.LastVaccineShot + "\n Needs to be fed " + animal.FoodBowlsNeeded + " times per day.\n Is Adopted: " + AdoptStatus + "\n $" + animal.Price);
                    }
                    break;
                case 2:
                    var PriceDecendingSearch = AnimalList.OrderByDescending(x => x.Price);
                    foreach (var animal in PriceDecendingSearch)
                    {
                        string AdoptStatus = CheckAnimalAdoptionStatus(animal);
                        Console.WriteLine("Name:" + animal.AnimalName + "\n Age: " + animal.AnimalAge + " Years old \n Type: " + animal.AnimalType + "\n Breed: " + animal.Breed + "\n Last Vaccine Shot: " + animal.LastVaccineShot + "\n Needs to be fed " + animal.FoodBowlsNeeded + " times per day.\n Is Adopted: " + AdoptStatus + "\n $" + animal.Price);
                    }
                    break;
                default:
                    Console.WriteLine("Sorry. That is not an option. Returning to Menu.");
                    Console.ReadLine();
                    Menu();
                    break;

            }

        }
    }
    }
