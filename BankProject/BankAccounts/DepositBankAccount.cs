using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BankAccounts
{
    public class DepositBankAccount : BankAccount, IAccountType<DepositBankAccount>
    {
        public DepositBankAccount(int id) : base(id) 
        {
            base.id = id;
            moneyAmmount= 0;
            accountType = "Депозитный";
        }

        public DepositBankAccount GetValue => this;

        public override void ReplenishAccount(float ammount)
        {
            MoneyAmmount += ammount;
        }

        public override void WithdrawFromAccount(float ammount)
        {
            MoneyAmmount -= ammount * 1.05f;
        }

        public override void TransferBetweenAccounts(float ammount, BankAccount target)
        {
            MoneyAmmount -= ammount * 1.05f;
            target.MoneyAmmount += ammount;
        }

        //public static implicit operator DepositBankAccount(NonDepositBankAccount db)
        //{
        //    return new DepositBankAccount(db.Id);
        //}
    }
}
