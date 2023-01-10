using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class BankAccount 
    {
        private int moneyAmmount;
        private int id;
        public int MoneyAmmount { get { return moneyAmmount;} set { moneyAmmount = value; } }
        public int Id { get { return id; } }
        public BankAccount(int id) 
        {
            moneyAmmount = 0;
            this.id = id;
        }

        
    }
}
