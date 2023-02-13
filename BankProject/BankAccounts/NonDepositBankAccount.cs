using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace BankProject.BankAccounts
{
    public class NonDepositBankAccount : BankAccount, ITargetContr<BankAccount>,IAccountType<NonDepositBankAccount>
    {
        public NonDepositBankAccount GetValue => this;

        public NonDepositBankAccount(int id) : base(id)
        {
            base.id = id;
            moneyAmmount= 0;
            accountType = "Не депозитный";
        }

        public override void ReplenishAccount(float ammount)
        {
            MoneyAmmount += ammount * 2;
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
