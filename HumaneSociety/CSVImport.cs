using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class CSVImport
    {
        HumaneSocietyDataDataContext HumaneDatabase;
        private DataTable AnimalTable;
        public CSVImport()
        {
            HumaneDatabase = new HumaneSocietyDataDataContext();
        }
        public void StartImport()
        {
            foreach(string line in File.ReadLines(@"C:\Users\Zack\Desktop\C# (Sharp)\HumaneSociety\NewAnimal.csv"))
            {
                ImportCSVAndAddToDatabase(line);
            }
            
        }
        private void ImportCSVAndAddToDatabase(string line)
        {
            AnimalTable = new DataTable();

            string[] row = line.Split(',');

            Animal newAnimalFromCSV = new Animal
            {
            AnimalName = row[0],
            AnimalAge = int.Parse(row[1]),
            AnimalType = row[2],
            Breed = row[3],
            Room = CheckIfRoomIsAlreadyUsed(row[4]),
            FoodBowlsNeeded = int.Parse(row[5]),
            Price = int.Parse(row[6]),
            IsAdopted = AdoptionStatus(int.Parse(row[7]))
            };

            HumaneDatabase.Animals.InsertOnSubmit(newAnimalFromCSV);
            HumaneDatabase.SubmitChanges();
        }

        private bool AdoptionStatus(int AdoptedOrNot)
        {
            if (AdoptedOrNot == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string CheckIfRoomIsAlreadyUsed(string RoomNumber)
        {
            var AnimalList = GetAnimalData();


            for (int x = 0; x < AnimalList.Count; x++)
            {
                if (AnimalList[x].Room == RoomNumber)
                {
                    Console.WriteLine("Error. Room has already been taken. Unable to import file");
                    Console.ReadLine();
                    break;
                }
            }
            return RoomNumber;
        }
        private List<Animal> GetAnimalData()
        {
            var result = from i in HumaneDatabase.Animals select i;
            return result.ToList();
        }
    }
}
