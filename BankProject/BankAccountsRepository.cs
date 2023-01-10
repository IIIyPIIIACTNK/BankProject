using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject
{
    public class BankAccountsRepository : IMoneyOperations
    {
        ObservableCollection<BankAccount> bankAccounts =  new ObservableCollection<BankAccount>();
        private static HashSet<int> bankAccountIds = new HashSet<int>();

        public BankAccount SelectedBankAccount { get; set; }
        public ObservableCollection<BankAccount> Accounts { get { return bankAccounts; } set { bankAccounts = value; } }
        public BankAccountsRepository() { }

        public void ReplenishAccount(int ammount)
        {
            SelectedBankAccount.MoneyAmmount += ammount;
        }

        public void WithdrawFromAccount(int ammount)
        {
            SelectedBankAccount.MoneyAmmount -= ammount;
        }

        public void TransferBetweenAccounts(int ammount, BankAccount target)
        {
            SelectedBankAccount.MoneyAmmount -= ammount;
            target.MoneyAmmount += ammount;
        }

        public void AddBankAccount()
        {
            int tempId;
            tempId = NotExistingBankAccountId();
            bankAccountIds.Add(tempId);
            bankAccounts.Add(new BankAccount(tempId));
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            bankAccountIds.Add(NotExistingBankAccountId());
            bankAccounts.Add(bankAccount);
        }

        public void DeleteBankAccount(BankAccount b)
        {
            //string d = string.Empty;
            //foreach(var a in bankAccountIds)
            //{
            //    d += $"{a} " ; 
            //}
            //MessageBox.Show(d);
            //bankAccountIds.ExceptWith();
            bankAccounts.Remove(b);
        }

        private int NotExistingBankAccountId()
        {
            int i = 0;

            for (int p = 0; p < bankAccountIds.Count + 1; p++)
            {
                if (bankAccountIds.Contains(p))
                    continue;
                i = p;
                break;
            }
            return i;
        }
    }
}
