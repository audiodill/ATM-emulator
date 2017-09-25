using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class BankAccount 
    {
        //variables
        private string accountNumber;
        protected DollarAmount balance;

        //properties
        public string AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }

        public DollarAmount Balance
        {
            get { return this.balance; }
        }

        //constructor
        public BankAccount()
        {
            this.balance = new DollarAmount(0); 
        }
        //methods
        public DollarAmount Deposit(DollarAmount amountToDeposit)
        {
            this.balance = this.balance.Plus(amountToDeposit);
            return this.balance;
        }

        public virtual DollarAmount Withdraw(DollarAmount amountToWithdraw)
        {
            this.balance = this.balance.Minus(amountToWithdraw);
            return this.balance;
        }

        public void Transfer(BankAccount destinationAccount, DollarAmount transferAmount)
        {
            this.Withdraw(transferAmount);
            destinationAccount.Deposit(transferAmount);
        }
    }
}
