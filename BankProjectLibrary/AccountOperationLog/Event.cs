using BankProject.BankAccounts;
using BankProject.CustomExceptions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.AccountOperationLog
{
    public enum OperationType
    {
        OpenAccount,
        CloseAccount,
        Replenish,
        Withdraw,
        Transfer,
    }

    public class Event
    {
        public string eventDate { get; private set; }
        public Resident eventCaller { get; private set; }
        public BankAccount eventTarget { get; private set; }
        public float operationMoneyAmmount { get; private set; }

        public string ExceptionButtonColor
        {
            get
            {
                return exceptionButtonColor();
            }
        }
        public Exception eventException { get; private set; }
        public string eventExceptionName { get { return eventException.GetType().ToString(); } }
        public string AccountName { get => $"№{eventTarget.Id} {eventTarget.AccountType}"; }

        public OperationType operationType { get; private set; }
        public Event(Resident eventCaller, BankAccount eventTarget, float ammount, OperationType operationType)
        {
            this.eventDate = DateTime.Now.ToShortTimeString();
            this.eventCaller = eventCaller;
            this.eventTarget = eventTarget;
            this.operationMoneyAmmount = ammount;
            this.operationType = operationType;
        }
        public Event(Resident eventCaller, BankAccount eventTarget, float ammount, OperationType operationType,Exception exception) :
            this(eventCaller,eventTarget,ammount,operationType)
        {
            eventDate= DateTime.Now.ToShortTimeString();
            eventException= exception;
        }
        private string exceptionButtonColor()
        {
            if (eventException == null)
            {
                return "#FF00FF34";
            }
            else
            {
                return "#FFFF0000";
            }
        }
    }
}
