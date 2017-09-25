using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankTellerExercise.Classes;

namespace BankTellerExerciseTests
{
    [TestClass]
    public class BankCustomerTest
    {
        [TestMethod]
        public void CheckToSeeIfWeCanCreateOneProfileWithMultipleAccounts()
        {
            BankCustomer newCustomer = new BankCustomer(); //I wanted to be dilegent about the amount of accounts the customer had
            CheckingAccount accountOne = new CheckingAccount();
            SavingsAccount accountTwo = new SavingsAccount();
            SavingsAccount accountThree = new SavingsAccount();
            newCustomer.AddAccount(accountTwo);
            newCustomer.AddAccount(accountOne);
            newCustomer.AddAccount(accountThree);
            Assert.AreEqual(3, newCustomer.Accounts.Length);
            Assert.AreEqual(newCustomer.Accounts[0], accountTwo);
            Assert.AreEqual(newCustomer.Accounts[1], accountOne);
            Assert.AreEqual(newCustomer.Accounts[2], accountThree);
        }

        [TestMethod]
        public void CheckToMakeSureWeCanCreateANameForCustomerProfile()
        {
            BankCustomer newCustomer = new BankCustomer();
            newCustomer.Name = "Richard";
            Assert.AreEqual("Richard", newCustomer.Name);
        }

        [TestMethod]
        public void TestPhoneNumberForCustomerProfile()
        {
            BankCustomer newCustomer = new BankCustomer();
            newCustomer.PhoneNumber = "(216)473-2345";
            Assert.AreEqual("(216)473-2345", newCustomer.PhoneNumber);
        }

        [TestMethod]
        public void TestAddressCanBeCreatedForCustomerProfile()
        {
            BankCustomer newCustomer = new BankCustomer();
            newCustomer.Address = "7100 Euclid Ave";
            Assert.AreEqual("7100 Euclid Ave", newCustomer.Address);
        }

        [TestMethod]
        public void TestToSeeIfCustomerQualifiesForVIPStatus()
        {
            BankCustomer newCustomer = new BankCustomer();
            CheckingAccount a1 = new CheckingAccount();
            DollarAmount d1 = new DollarAmount(3000000);
            SavingsAccount a2 = new SavingsAccount();
            newCustomer.AddAccount(a1);
            newCustomer.AddAccount(a2);
            a1.Deposit(d1);
            DollarAmount d2 = new DollarAmount(1000000);
            a2.Deposit(d2);
            Assert.IsTrue(newCustomer.IsVip);
        }

        [TestMethod]
        public void TestToSeeIfCustomerDoesntMakeVIPStatus()
        {
            BankCustomer newCustomer = new BankCustomer();
            CheckingAccount a1 = new CheckingAccount();
            DollarAmount d1 = new DollarAmount(1000000);
            SavingsAccount a2 = new SavingsAccount();
            newCustomer.AddAccount(a1);
            newCustomer.AddAccount(a2);
            a1.Deposit(d1);
            DollarAmount d2 = new DollarAmount(1000000);
            a2.Deposit(d2);
            Assert.IsFalse(newCustomer.IsVip);
        }

    }
}
