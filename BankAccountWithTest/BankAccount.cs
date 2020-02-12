using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTest
{
    public class BankAccount
    {
        private string accountNumber;

        public string AccountNumber 
        {
            get 
            { 
                return accountNumber; 
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Account Number cannot be null or White Space");
                }
                accountNumber = value; 
            }
        }

        public string AccountHolder { get; set; }

        public double Balance { get; private set; }

        public BankAccount(string accNum):this(accNum, 0){ }

        public BankAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        /// <summary>
        /// Deposits a positive amount of money into said account.
        /// Returns the new balance.
        /// <see cref="Balance"/>
        /// </summary>
        /// <param name="amt">amount of money to be deposited</param>
        /// <exception cref="ArgumentException">If deposit is zero or below</exception>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentException(message: "You must deposit a positive amount.");
            }
            Balance += amt;
            return Balance;
        }

        public void Withdraw(double withdrawAmount)
        {
            Balance -= withdrawAmount;
        }


    }
}
