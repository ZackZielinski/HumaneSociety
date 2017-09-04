using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class CustomerMenu
    {
        int CustomerInput;
        string AdoptStatus;
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
            }
        }
        private void SearchAnimalList()
        {

            Console.WriteLine("What would you like to see? \n 1 - All Animals \n 2 - Search by specifics");
            CustomerInput = Convert.ToInt32(Console.ReadLine());

            if (CustomerInput == 1)
            {
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
                }
                Console.ReadLine();
            }
            else
            {
                SearchByTraits();
            }

        }

        
        private void AddNewCustomer()
        {
            Console.WriteLine("Enter Your Name:");
            string NewCustomerName = Console.ReadLine();

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
                CustomerName = NewCustomerName,
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

        private void SearchByTraits()
        {
            var AnimalList = GetAnimalData();
            Console.WriteLine("What type of animal would you like to see?");
            string AnimalSearch = Console.ReadLine();


            if (AnimalList.Any(x => x.AnimalType == AnimalSearch) == true)
            {
                var SearchedAnimals = AnimalList.Where(x => x.AnimalType == AnimalSearch);
                
                foreach (var animal in SearchedAnimals)
                {
                    if (animal.IsAdopted == false)
                    {
                        AdoptStatus = "No";
                    }
                    else
                    {
                        AdoptStatus = "Yes";
                    }
                    Console.WriteLine("Name: " + animal.AnimalName + "\n Age: " + animal.AnimalAge + "Years old \n Breed:" + animal.Breed + "Needs to be fed "+ animal.FoodBowlsNeeded + " per day \n Last Vaccine Shot:" + animal.LastVaccineShot + "\n Adoption Status: " + AdoptStatus + " \n $" + animal.Price);
                    
                }
            }
            else if (AnimalList.Any(x => x.Breed == AnimalSearch) == true)
            {
                var SearchedAnimals = AnimalList.Where(x => x.Breed == AnimalSearch);

                foreach (var animal in SearchedAnimals)
                {
                    if (animal.IsAdopted == false)
                    {
                        AdoptStatus = "No";
                    }
                    else
                    {
                        AdoptStatus = "Yes";
                    }
                    Console.WriteLine("Name: " + animal.AnimalName + "\n Age: " + animal.AnimalAge + "Years old \n Type:" + animal.AnimalType + "Needs to be fed " + animal.FoodBowlsNeeded + " per day \n Last Vaccine Shot:" + animal.LastVaccineShot + "\n Adoption Status: " + AdoptStatus + " \n $" + animal.Price);

                }
            }

        }

        private List<Animal> GetAnimalData()
        {
            var result = from i in HumaneDatabase.Animals select i;
            return result.ToList();
        }
    }
    }
