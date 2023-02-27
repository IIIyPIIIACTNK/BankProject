using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.AccountOperationLog;
using BankProject.CustomExceptions;
using BankProject.Interfaces;

namespace BankProject.BankAccounts
{
    public class DepositBankAccount : BankAccount, 
        ITargetContr<BankAccount>, 
        IAccountType<DepositBankAccount>
    {
        public DepositBankAccount GetValue => this;
        public DepositBankAccount(int id,Resident owner) : base(id,owner) 
        {
            base.id = id;
            moneyAmmount= 0;
            accountType = "Депозитный";
        }


        public override void ReplenishAccount(float ammount)
        {
            MoneyAmmount += ammount;
            InvokeAccountOperationEvent(owner,this,ammount,OperationType.Replenish);
        }

        public override void WithdrawFromAccount(float ammount)
        {
            if (MoneyAmmount - (ammount * 1.05f) < 0)
            {
                InvokeCanselOperationEvent(owner, this, ammount, OperationType.Withdraw, new NegativeAmmountExeption());
                throw new NegativeAmmountExeption();
            }
            MoneyAmmount -= ammount * 1.05f;
            InvokeAccountOperationEvent(owner, this, ammount, OperationType.Withdraw);
        }

        public void TransferBetweenAccounts(float ammount, BankAccount target)
        {
            if (MoneyAmmount - (ammount * 1.05f) < 0)
            {
                InvokeCanselOperationEvent(owner, this, ammount, OperationType.Withdraw, new NegativeAmmountExeption());
                throw new NegativeAmmountExeption();
            }
            if (target == this)
            {
                InvokeCanselOperationEvent(owner, this, ammount, OperationType.Withdraw, new TargetAccountException());
                throw new TargetAccountException();
            }
            MoneyAmmount -= ammount * 1.05f;
            target.MoneyAmmount += ammount;
        }

        public void TransferToClient(BankAccount target, float ammount)
        {
            if (MoneyAmmount - (ammount * 1.05f) < 0)
            {
                InvokeCanselOperationEvent(owner, this, ammount, OperationType.Withdraw, new NegativeAmmountExeption());
                throw new NegativeAmmountExeption();
            }
            if (target == this)
            {
                InvokeCanselOperationEvent(owner, this, ammount, OperationType.Withdraw, new TargetAccountException());
                throw new TargetAccountException();
            }
            MoneyAmmount -= ammount * 1.08f;
            target.MoneyAmmount += ammount;
        }
    }
}
