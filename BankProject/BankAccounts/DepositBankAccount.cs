using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccounts
{
    public class DepositBankAccount : BankAccount, ITargetContr<BankAccount>, IAccountType<DepositBankAccount>
    {
        public DepositBankAccount GetValue => this;

        public DepositBankAccount(int id) : base(id) 
        {
            base.id = id;
            moneyAmmount= 0;
            accountType = "Депозитный";
        }


        public override void ReplenishAccount(float ammount)
        {
            MoneyAmmount += ammount;
        }

        public override void WithdrawFromAccount(float ammount)
        {
            MoneyAmmount -= ammount * 1.05f;
        }

        public void TransferBetweenAccounts(float ammount, BankAccount target)
        {
            MoneyAmmount -= ammount * 1.05f;
            target.MoneyAmmount += ammount;
        }

        public void TransferToClient(BankAccount target, float ammount)
        {
            MoneyAmmount -= ammount * 1.08f;
            target.MoneyAmmount += ammount;
        }
    }
}
