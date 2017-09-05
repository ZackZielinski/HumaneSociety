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

            var AdoptedAnimal = AnimalList.First(x => x.AnimalID == AnimalIDNumber);

            var NewLog = new AdoptionLog
            {
               AnimalID = AnimalIDNumber,
               CustomerFirstName = CustomerFirstName,
               CustomerLastName = CustomerLastName,
               Profit = AdoptedAnimal.Price
            };
            Console.WriteLine("Adoption Logged. Have a nice Day!");
            Console.ReadLine();
        }

        private List<Animal> GetAnimalData()
        {
            var result = from i in HumaneDatabase.Animals select i;
            return result.ToList();
        }

    }
}
