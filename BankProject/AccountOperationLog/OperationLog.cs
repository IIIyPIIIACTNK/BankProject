using BankProject.BankAccounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.AccountOperationLog
{
    public class OperationLog
    {
        public ObservableCollection<Event> OperationCollection { get; set; }
        public event Action<Resident,BankAccount,float,OperationType> NotificateData;
        public OperationLog() 
        {
            OperationCollection = new ObservableCollection<Event>();
            NotificateData += NotificationHandler.NotificationMessage;
        }

        // Добавить пополнение AllAcounts и динамическая подписка на событие SetEventLog
        public void ReciveData(Resident res,BankAccount ba, float ammount,OperationType operationType) 
        {
            OperationCollection.Add(new Event(res, ba, ammount, operationType));
            NotificateData(res, ba, ammount, operationType);
        }
    }
}
