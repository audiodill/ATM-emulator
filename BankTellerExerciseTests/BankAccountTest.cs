using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class BankAccountTest //our class wasn't made public in the Bank Account Class to call bankAccount method
    {
        [TestMethod]
        public void BankAccountBeginningZeroBalance()
        {
            BankAccount x = new BankAccount();
            Assert.AreEqual("$0.00", x.Balance.ToString());
        }

        [TestMethod]
        public void ThisIsADepositTestWithStartingBalanceZero()
        {
            BankAccount x = new BankAccount();
            DollarAmount amountToDesposit = new DollarAmount(1000);
            DollarAmount newBalance = x.Deposit(amountToDesposit);
            Assert.AreEqual("$10.00", x.Balance.ToString());
        }

        [TestMethod]
        public void ThisIsADepositTestWithStartingBalanceOfTenDollars()
        {
            BankAccount x = new BankAccount();
            DollarAmount amountToDeposit = new DollarAmount(1000);
            DollarAmount newBalance = x.Deposit(amountToDeposit);
            DollarAmount newDeposit = new DollarAmount(2000);
            newBalance = x.Deposit(newDeposit);
            Assert.AreEqual("$30.00", x.Balance.ToString());
        }

        [TestMethod]
        public void WithdrawTestTakingTenDollarsAwayFromThirtyDollarBalance()
        {
            BankAccount x = new BankAccount();
            DollarAmount amountToDeposit = new DollarAmount(3000);
            DollarAmount newBalance = x.Deposit(amountToDeposit);
            DollarAmount amountToWithdraw = new DollarAmount(1000);
            newBalance = x.Withdraw(amountToWithdraw);
            Assert.AreEqual("$20.00", x.Balance.ToString());
        }

        [TestMethod]
        public void LetsTestMoneyTransferingFromOneAccountToAnother()
        {
            BankAccount a = new BankAccount();
            BankAccount b = new BankAccount();
            DollarAmount amountToDeposit = new DollarAmount(5000);
            DollarAmount newBalance = a.Deposit(amountToDeposit);
            DollarAmount amountToTransfer = new DollarAmount(1000);
            //a.Deposit(amountToDeposit);
            a.Transfer(b, amountToTransfer);
            Assert.AreEqual("$40.00", a.Balance.ToString());
            Assert.AreEqual("$10.00", b.Balance.ToString());
        }
    }
}
