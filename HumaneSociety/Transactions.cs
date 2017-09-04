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

        }
    }
}
