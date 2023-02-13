using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankProject.BankAccounts;

namespace BankProject
{
    public class BankAccountsRepository : IAccountType<BankAccount>, ITargetContr<BankAccount>
    {
        ObservableCollection<BankAccount> bankAccounts =  new ObservableCollection<BankAccount>();
        private static HashSet<int> bankAccountIds = new HashSet<int>();

        public BankAccount SelectedBankAccount { get; set; }
        public ObservableCollection<BankAccount> Accounts { get { return bankAccounts; } set { bankAccounts = value; } }

        public BankAccount GetValue => SelectedBankAccount;
        public BankAccountsRepository() 
        {
            bankAccounts.Add(new NonDepositBankAccount(NotExistingBankAccountId()));
            bankAccounts.Add(new DepositBankAccount(NotExistingBankAccountId()));
        }

        public void AddBankAccount()
        {
            bankAccounts.Add(new DepositBankAccount(NotExistingBankAccountId()));
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            bankAccountIds.Add(NotExistingBankAccountId());
            bankAccounts.Add(bankAccount);
        }

        public void DeleteBankAccount(BankAccount b)
        {
            bankAccountIds.Remove(b.Id);
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
            bankAccountIds.Add(i);
            return i;
        }

        public void TransferToClient(BankAccount target, float ammount)
        {

            SelectedBankAccount.MoneyAmmount -= ammount; 
            target.MoneyAmmount += ammount;
        }
    }
}
