using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccounts
{
    public class BankAccount : INotifyPropertyChanged, ITargetContr<BankAccount>
    {
        protected float moneyAmmount;
        protected int id;
        protected string accountType;

        public event PropertyChangedEventHandler? PropertyChanged;

        public float MoneyAmmount { get { return moneyAmmount; } set { moneyAmmount = value; OnPropertyChanged(); } }
        public int Id { get { return id; } }
        public string AccountType { get { return accountType; } }


        public BankAccount(int id)
        {
            moneyAmmount = 0;
            this.id = id;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void ReplenishAccount(float ammount) { }

        public virtual void WithdrawFromAccount(float ammount) { }

        public void TransferToClient(BankAccount target, float ammount)
        {
            moneyAmmount -= ammount;
            target.moneyAmmount += ammount;
        }

        //public abstract void TransferBetweenAccounts(float ammount, BankAccount target);
    }
}
