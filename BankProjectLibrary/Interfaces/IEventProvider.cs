using BankProject.AccountOperationLog;
using BankProject.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Interfaces
{
    internal interface IEventProvider
    {
        event Action<Resident,BankAccount,float,OperationType> OperationEvent;
        event Action<Resident,BankAccount,float,OperationType,Exception> OperationCancelEvent;
    }
}
