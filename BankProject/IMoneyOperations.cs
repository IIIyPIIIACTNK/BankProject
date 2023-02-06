using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.BankAccounts;

namespace BankProject
{
    public interface IMoneyOperations
    {
        public void ReplenishAccount(int ammount);
        public void WithdrawFromAccount(int ammount);
        public void TransferBetweenAccounts(int ammount, BankAccount target);
    }
}
