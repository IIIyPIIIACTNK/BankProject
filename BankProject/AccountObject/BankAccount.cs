using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BankProject.AccountOperationLog;
using BankProject.Interfaces;

namespace BankProject
{
    public class BankAccount : 
        INotifyPropertyChanged, 
        ITargetContr<BankAccount>,
        IEventProvider
    {
        protected float moneyAmmount;
        protected int id;
        protected string accountType;
        /// <summary>
        /// Владелец счета
        /// </summary>
        protected Resident owner;
        private static OperationLog log = ViewModel.Log;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action<Resident, BankAccount, float, OperationType> OperationEvent;

        public float MoneyAmmount { get { return moneyAmmount; } set { moneyAmmount = value; OnPropertyChanged(); } }
        public int Id { get { return id; } }
        public string AccountType { get { return accountType; } }


        public BankAccount(int id, Resident owner)
        {
            moneyAmmount = 0;
            this.id = id;
            OperationEvent += log.ReciveData;
            this.owner = owner;
        }

        public virtual void ReplenishAccount(float ammount) { }

        public virtual void WithdrawFromAccount(float ammount) { }

        public void TransferToClient(BankAccount target, float ammount)
        {
            moneyAmmount -= ammount;
            target.moneyAmmount += ammount;
            InvokeAccountOperationEvent(owner,this,ammount,OperationType.Transfer);
        }

        protected void InvokeAccountOperationEvent(Resident res,BankAccount target,float ammount, OperationType oP)
        {
            OperationEvent?.Invoke(res, target, ammount, oP);
        }

        public static void SetLog(OperationLog operationLog) 
        { 
            log = operationLog;
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
