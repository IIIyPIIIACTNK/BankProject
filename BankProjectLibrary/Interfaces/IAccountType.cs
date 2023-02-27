using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.BankAccounts;

namespace BankProject.Interfaces
{
    /// <summary>
    /// Ковариантный интерфейс для пополнения счета клиента
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAccountType<out T>
    {
        T GetValue { get; }

    }
}
