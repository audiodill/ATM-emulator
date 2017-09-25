using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
    public class BankCustomer
    {
        private string name;
        private string address;
        private string phoneNumber;
        private List<BankAccount> newList = new List<BankAccount>();
        protected bool isVIP = false;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public bool IsVip
        {
            get 
            {
                int totalAccountBalanceInt = 0;
                for (int i = 0; i < newList.Count; i++)
                {
                    totalAccountBalanceInt += newList[i].Balance.Dollars;
                }
                if (totalAccountBalanceInt >= 25000)
                {
                    isVIP = true;
                    return this.isVIP;
                }
                else
                {
                    isVIP = false;
                    return this.isVIP;
                }
            }
        }

        public BankAccount[] Accounts
        {
            get
            {
                return newList.ToArray();
            }
        }
        
        public void AddAccount(BankAccount newAccount)
        {
            newList.Add(newAccount);
        }
    }
}
