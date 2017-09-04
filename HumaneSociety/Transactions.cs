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
        int AnimalIDNumber;
        public Transactions()
        {
            HumaneDatabase = new HumaneSocietyDataDataContext();
        }

        public void StartTransaction()
        {
            Console.WriteLine("Please Enter the Animal's ID Number");
            AnimalIDNumber = Convert.ToInt32(Console.ReadLine());

        }
    }
}
