using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTellerExercise.Classes;

namespace BankTellerExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     $$$$$$$      $$$$$$$$$$$        $$$$$$$$$    $$$      $$$   $$$$$$$$$$$   $$$$$$$$$      ");
            Console.WriteLine("     $$$  $$$         $$$         $$$$$$$$$$$     $$$      $$$       $$$       $$$$$$$$     ");
            Console.WriteLine("     $$$  $$$         $$$       $$$$              $$$      $$$       $$$       $$$ ");
            Console.WriteLine("     $$$  $$          $$$       $$$$              $$$$$$$$$$$$       $$$       $$$$$$     ");
            Console.WriteLine("     $$$$$$           $$$       $$$$              $$$$$$$$$$$$       $$$       $$$$$$    ");
            Console.WriteLine("     $$$ $$$          $$$       $$$$              $$$      $$$       $$$       $$$       ");
            Console.WriteLine("     $$$  $$$         $$$       $$$$              $$$      $$$       $$$       $$$       ");
            Console.WriteLine("     $$$   $$$        $$$         $$$$$$$$$$$     $$$      $$$       $$$       $$$$$$$$   ");
            Console.WriteLine("     $$$    $$$   $$$$$$$$$$$       $$$$$$$$$$$   $$$      $$$   $$$$$$$$$$$   $$$$$$$$$        ");
            Console.WriteLine();
            Console.WriteLine("     $$$$$$$      $$$$$$$$$$$        $$$$$$$$$    $$$      $$$                 $$$$$$$$$$$   $$$$        $$$        $$$$$$$$$$     ");
            Console.WriteLine("     $$$  $$$         $$$         $$$$$$$$$$$     $$$      $$$                     $$$       $$$$$$      $$$      $$$$$$$$$$$      ");
            Console.WriteLine("     $$$  $$$         $$$       $$$$              $$$      $$$                     $$$       $$$ $$$     $$$    $$$$            ");
            Console.WriteLine("     $$$  $$          $$$       $$$$              $$$$$$$$$$$$                     $$$       $$$  $$$    $$$    $$$$            ");
            Console.WriteLine("     $$$$$$           $$$       $$$$              $$$$$$$$$$$$                     $$$       $$$   $$$   $$$    $$$$           ");
            Console.WriteLine("     $$$ $$$          $$$       $$$$              $$$      $$$                     $$$       $$$    $$$  $$$    $$$$              ");
            Console.WriteLine("     $$$  $$$         $$$       $$$$              $$$      $$$                     $$$       $$$     $$$ $$$    $$$$              ");
            Console.WriteLine("     $$$   $$$        $$$         $$$$$$$$$$$     $$$      $$$                     $$$       $$$      $$$$$$      $$$$$$$$$$$    $$   ");
            Console.WriteLine("     $$$    $$$   $$$$$$$$$$$       $$$$$$$$$$$   $$$      $$$                 $$$$$$$$$$$   $$$       $$$$$        $$$$$$$$$$   $$  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     ==============================================================================================================================");


            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Are you a current customer? (answer y or n) ");
            string currentCustomer = Console.ReadLine();
            currentCustomer = currentCustomer.ToLower();
            if (currentCustomer == "n" || currentCustomer == "no")
            {
                Console.Write("Would you like to be added as a new customer? (answer y or n) ");
                string addCustomer = Console.ReadLine();
                addCustomer = addCustomer.ToLower();
                if (addCustomer == "n" || addCustomer == "no")
                {
                    System.Environment.Exit(1);
                }

                Console.Clear();
                Console.Write("What is your full name: ");

                BankCustomer newCustomer = new BankCustomer();
                newCustomer.Name = Console.ReadLine();

                Console.Write("What is your full address: ");
                newCustomer.Address = Console.ReadLine();

                Console.Write("What is your phone number: ");
                newCustomer.PhoneNumber = Console.ReadLine();

                string addAccount = "";
                Console.WriteLine("Would you like to open a new account? (answer y or n)");
                addAccount = Console.ReadLine();
                addAccount = addAccount.ToLower();
                while (addAccount == "y" || addAccount == "yes")
                {
                    string accountType = "";

                    Console.Write("Enter [1] for Checking Account or [2] for Savings Account: ");
                    accountType = Console.ReadLine();
                    if (accountType == "1")
                    {
                        CheckingAccount checkingAccount = new CheckingAccount();
                        Console.Write("How much money would you like to deposit? ");
                        string s = Console.ReadLine();
                        int amountToDeposit = int.Parse(s);
                        amountToDeposit = amountToDeposit * 100;
                        DollarAmount x = new DollarAmount(amountToDeposit);
                        checkingAccount.Deposit(x);
                        newCustomer.AddAccount(checkingAccount);
                        Console.Write("Would you like to add another account? (answer y or n) ");
                        addAccount = Console.ReadLine();
                    }
                    else
                    {
                        SavingsAccount savingsAccount = new SavingsAccount();
                        int amountToDeposit = 0;
                        string s = "";
                        Console.Write("How much money would you like to deposit? (Must be at least $150) ");
                        s = Console.ReadLine();
                        amountToDeposit = int.Parse(s);
                        amountToDeposit = amountToDeposit * 100;
                        if(amountToDeposit < 15000)
                        {
                            while(amountToDeposit < 15000)
                            {
                                Console.Write("You did not deposit enough! What is the amount you would like to deposit? ");
                                s = Console.ReadLine();
                                amountToDeposit = int.Parse(s);
                                amountToDeposit = amountToDeposit * 100;
                            }
                        }
                        DollarAmount x = new DollarAmount(amountToDeposit);
                        savingsAccount.Deposit(x);
                        newCustomer.AddAccount(savingsAccount);
                        Console.Write("Would you like to add another account? (answer y or n) ");
                        addAccount = Console.ReadLine();
                    }
                }
                Console.Clear();
                Console.WriteLine($"Name: {newCustomer.Name.PadLeft(15)}");
                Console.WriteLine($"Address: {newCustomer.Address.PadLeft(10)}");
                Console.WriteLine($"Phone Number: {newCustomer.PhoneNumber.PadLeft(5)}");
                int accountBalanceTotals = 0;
                for(int i = 0; i < newCustomer.Accounts.Length; i++)
                {
                    accountBalanceTotals += newCustomer.Accounts[i].Balance.Dollars;
                    Console.WriteLine($"Bank Account {i + 1}: {newCustomer.Accounts[i].Balance.ToString()}");
                }
                Console.WriteLine($"Total Balance: ${accountBalanceTotals}");

                Console.ReadLine();
            }
        }
    }
}
