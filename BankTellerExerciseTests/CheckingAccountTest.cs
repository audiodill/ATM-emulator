using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class CheckingAccountTest
    {
        [TestMethod]
        public void CheckForOverDraft()
        {
            CheckingAccount x = new CheckingAccount();
            DollarAmount amountToWithdraw = new DollarAmount(1000);
            x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$-20.00", x.Balance.ToString());
        }

        [TestMethod]
        public void CheckForNegativeOneHundredDollars()
        {
            CheckingAccount x = new CheckingAccount();
            DollarAmount amountToWithdraw = new DollarAmount(10100);
            x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$0.00", x.Balance.ToString());

        }

        [TestMethod]
        public void CheckToSeeIfPostWithdrawBalanceIsGreaterThanZero()
        {
            CheckingAccount x = new CheckingAccount();
            DollarAmount y = new DollarAmount(10000);
            DollarAmount w = new DollarAmount(5000);
            x.Deposit(y);
            x.Withdraw(w);
            Assert.AreEqual("$50.00", x.Balance.ToString());
            
        }

    }
}
