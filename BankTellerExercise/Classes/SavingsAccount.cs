using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public override DollarAmount Withdraw(DollarAmount amountToWithdraw)
        {
            DollarAmount Threshold = new DollarAmount(15000);
            DollarAmount ServiceFee = new DollarAmount(200);
            DollarAmount futureAmount = this.balance.Minus(amountToWithdraw);
            if((futureAmount.Dollars < Threshold.Dollars) && !futureAmount.IsNegative)
            {
                this.balance = this.balance.Minus(amountToWithdraw);
                this.balance = this.balance.Minus(ServiceFee);
                return this.balance;
            }
            else if (futureAmount.IsNegative)
            {
                return this.balance;
            }
            return base.Withdraw(amountToWithdraw);
        }
    }
}
