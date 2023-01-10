using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject
{
    public class Resident
    {
        #region Поля
        private string name;
        private BankAccountsRepository bankAccountsRepository;
        #endregion

        #region Свойства
        public string Name { get { return name; } set { name = value; } }
        public BankAccountsRepository BankAccountsRepository { get { return bankAccountsRepository; } set { bankAccountsRepository = value; } }
        public ObservableCollection<BankAccount> ResidentAccounts { get { return bankAccountsRepository.Accounts; } }
        #endregion

        #region Конструктор
        public Resident(string name)
        {
            bankAccountsRepository= new BankAccountsRepository();
            this.name = name;
        }
        #endregion
        
    }
}
