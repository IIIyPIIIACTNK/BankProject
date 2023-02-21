using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BankProject.AccountOperationLog;
using BankProject.BankAccounts;
using BankProject.Interfaces;

namespace BankProject
{
    public class BankAccountsRepository : 
        IAccountType<BankAccount>, 
        ITargetContr<BankAccount>,
        IEventProvider
    {
        private ObservableCollection<BankAccount> bankAccounts =  new ObservableCollection<BankAccount>();
        private static HashSet<int> bankAccountIds = new HashSet<int>();
        private Resident owner;

        public event Action<Resident, BankAccount, float, OperationType> OperationEvent;

        public BankAccount SelectedBankAccount { get; set; }
        public ObservableCollection<BankAccount> Accounts { get { return bankAccounts; } set { bankAccounts = value; } }

        public BankAccount GetValue => SelectedBankAccount;
        public BankAccountsRepository(Resident owner) 
        {
            this.owner = owner;
            bankAccounts.Add(new NonDepositBankAccount(NotExistingBankAccountId(),owner));
            bankAccounts.Add(new DepositBankAccount(NotExistingBankAccountId(),owner));
            OperationEvent += ViewModel.Log.ReciveData;
        }
        public void AddBankAccount()
        {
            DepositBankAccount bankAccount = new DepositBankAccount(NotExistingBankAccountId(), owner);
            bankAccounts.Add(bankAccount);
            OperationEvent?.Invoke(owner, bankAccount,0,OperationType.OpenAccount);
        }

        public void DeleteBankAccount(BankAccount b)
        {
            bankAccountIds.Remove(b.Id);
            bankAccounts.Remove(b);
            OperationEvent?.Invoke(owner, b, 0, OperationType.CloseAccount);
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
            OperationEvent?.Invoke(owner, SelectedBankAccount, ammount, OperationType.Transfer);
        }
    }
}
