using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace BankProject.BankAccounts
{
    public class NonDepositBankAccount : BankAccount, IAccountType<NonDepositBankAccount>
    {
        public NonDepositBankAccount(int id) : base(id)
        {
            base.id = id;
            moneyAmmount= 0;
            accountType = "Не депозитный";
        }


        public NonDepositBankAccount GetValue { get { return this; } }

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
            MessageBox.Show($"{MoneyAmmount}");
            target.MoneyAmmount += ammount;
        }

        public static implicit operator NonDepositBankAccount(DepositBankAccount db)
        {
            var account = new NonDepositBankAccount(db.Id);
            MessageBox.Show($"{db.MoneyAmmount}", "account");
            MessageBox.Show($"{account.MoneyAmmount}", "operator");
            return account;
        }
    }
}
