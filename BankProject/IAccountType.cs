using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public interface IAccountType <out T>
    {
        T GetValue { get; }
    }
}
