using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankProject.AccountOperationLog
{
    internal static class NotificationHandler
    {
        public static void NotificationMessage(Resident owner, BankAccount bankAccount,float ammmount, OperationType operationType)
        {
            switch (operationType) 
            {
                case OperationType.OpenAccount:
                    MessageBox.Show($"{owner.Name} открыл {bankAccount.Id} {bankAccount.AccountType}");
                    break;
                case OperationType.CloseAccount:
                    MessageBox.Show($"{owner.Name} закрыл {bankAccount.Id} {bankAccount.AccountType}");
                    break;
                case OperationType.Replenish:
                    MessageBox.Show($"{owner.Name} пополнил {bankAccount.Id} {bankAccount.AccountType} на {ammmount}$");
                    break;
                case OperationType.Withdraw:
                    MessageBox.Show($"{owner.Name} снял с {bankAccount.Id} {bankAccount.AccountType} {ammmount}$");
                    break;
                case OperationType.Transfer:
                    MessageBox.Show($"{owner.Name} перевел с {bankAccount.Id} {bankAccount.AccountType} {ammmount}$");
                    break;
            }
        }

        public static void MoneyOperationMessage(string message, float ammount)
        {
            MessageBox.Show($"{message} {ammount}");
        }
    }
}
