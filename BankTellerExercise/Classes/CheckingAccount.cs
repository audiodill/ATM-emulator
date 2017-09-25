using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public override DollarAmount Withdraw(DollarAmount amountToWithdraw)
        {
            DollarAmount overdraftFeeAmount = new DollarAmount(1000);
            DollarAmount futureAmount = this.balance.Minus(amountToWithdraw);

            if(futureAmount.IsNegative && futureAmount.Dollars < -100)
            {
                return this.balance;
            }else if (futureAmount.IsNegative)
            {
                this.balance = this.balance.Minus(overdraftFeeAmount );
                this.balance = this.balance.Minus(amountToWithdraw);
                return this.balance;
            }
            return base.Withdraw(amountToWithdraw);
       }
    }
}
