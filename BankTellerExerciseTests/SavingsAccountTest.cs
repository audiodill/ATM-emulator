using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        public void CheckForFeeIfBalanceFallsBelowThresholdAndAboveZero()
        {
            SavingsAccount x = new SavingsAccount();
            DollarAmount savingsAccountBalance = new DollarAmount(20000);
            DollarAmount amountToWithdraw = new DollarAmount(5100);
            x.Deposit(savingsAccountBalance);
            x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$147.00", x.Balance.ToString());
        }

        [TestMethod]
        public void IfWithdrawAmountIsMoreThanCurrentBalance()
        {
            SavingsAccount x = new SavingsAccount();
            DollarAmount savingsAccountBalance = new DollarAmount(20000);
            DollarAmount amountToWithdraw = new DollarAmount(20100);
            x.Deposit(savingsAccountBalance);
            x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$200.00", x.Balance.ToString());
        }

        [TestMethod]
        public void CheckToSeeIfWithdrawWorksProperlyWhenItDoesntCrossThreshold()
        {
            SavingsAccount x = new SavingsAccount();
            DollarAmount savingsAccountBalance = new DollarAmount(20000);
            DollarAmount amountToWithdraw = new DollarAmount(4900);
            x.Deposit(savingsAccountBalance);
            x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$151.00", x.Balance.ToString());
        }
    }
}
