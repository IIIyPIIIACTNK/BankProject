using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Interfaces
{
    /// <summary>
    /// Контрвариантный интерфейс для перевода между клиентами
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ITargetContr<in T>
    {
        void TransferToClient(T target, float ammount);
    }
}
