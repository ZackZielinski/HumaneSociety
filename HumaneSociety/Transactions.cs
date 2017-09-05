using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Transactions
    {
        HumaneSocietyDataDataContext HumaneDatabase;

        public Transactions()
        {
            HumaneDatabase = new HumaneSocietyDataDataContext();
        }

        public void StartTransaction()
        {
            Console.WriteLine("Please Enter the Animal's ID Number");
            int AnimalIDNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter the Customer's First Name");
            string CustomerFirstName = Console.ReadLine();

            Console.WriteLine("Please Enter the Customer's Last Name");
            string CustomerLastName = Console.ReadLine();

            var AnimalList = GetAnimalData();
            if (AnimalList.Any(x => x.AnimalID == AnimalIDNumber) == true)
            {
                var AdoptedAnimal = AnimalList.First(y => y.AnimalID == AnimalIDNumber);

                var NewLog = new AdoptionLog
                {
                    AnimalID = AdoptedAnimal.AnimalID,
                    CustomerFirstName = CustomerFirstName,
                    CustomerLastName = CustomerLastName,
                    Profit = AdoptedAnimal.Price
                };

                HumaneDatabase.AdoptionLogs.InsertOnSubmit(NewLog);
                HumaneDatabase.SubmitChanges();


                Console.WriteLine("Adoption Logged. Have a nice Day!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Sorry, we couldn't find the animal you were looking for. Please try again.");
            }
            StartTransaction();
        }

        private List<Animal> GetAnimalData()
        {
            var result = from i in HumaneDatabase.Animals select i;
            return result.ToList();
        }

    }
}
