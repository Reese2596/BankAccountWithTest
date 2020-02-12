using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountWithTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTest.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        ///RED: create test
        ///Green: create code that pass at any cost
        ///Refactor: clean up and refractor code

        [TestMethod]
        [TestCategory("Constructor")]
        #region Constructor Values
        [DataRow("a")]
        [DataRow("ABC123")]
        [DataRow("$money!!")]
        [DataRow("😭")]
        #endregion
        public void Constructor_ValidAccountNumber_SetsAccountNumber(string accNum)
        {
            //Arrange => Act
            BankAccount acc = new BankAccount(accNum);

            //Assert
            Assert.AreEqual(accNum, acc.AccountNumber);
        }

        [TestMethod]
        [TestCategory("Constructor")]
        #region Constructor Values
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        #endregion
        public void Constructor_InvalidAccountNumbers_ThrowsArgException(string accNum)
        {
            //Assert => Arrange => Act
            Assert.ThrowsException<ArgumentException> (() => new BankAccount(accNum));

        }

        [TestMethod()]
        [TestCategory("Deposit")]
        public void Deposit_PositiveValue_AddsToBalance()
        {
            //Arrange: Get objects and variables set up.
            BankAccount acc = new BankAccount("986321457");
            double depositAmount = 100.0;
            double expectedBalance = 100.0;

            //Act: Call the method under test.
            acc.Deposit(depositAmount);

            //Assert: Test
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_PositiveAmountWithCents_AddsToBalance()
        {
            //Arrange
            BankAccount acc = new BankAccount("MoneyMoney");
            double depositAmt = 99.99;
            double expectedBalance = 99.99;

            //Act
            acc.Deposit(depositAmt);

            //Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        #region Deposit Amounts
        [DataRow(100)]
        [DataRow(99.99)]
        [DataRow(9999.81)]
        [DataRow(0.01)]
        [DataRow(9999999999999.96)]
        #endregion
        public void Deposit_PsitiveAmount_ReturnsUpdatedBalance(double depositAmount)
        {
            //Arrange
            BankAccount acc = new BankAccount("MoneyMoney");
            double initialBalance = 0;
            double expectedBalance = initialBalance + depositAmount;

            //Act
            double returnedBalance = acc.Deposit(depositAmount);

            //Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
            //Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(2)]
        #region Deposit Amounts
        [DataRow(-1)]
        [DataRow(-100)]
        [DataRow(-99.99)]
        [DataRow(0)]
        [DataRow(-90909090.75)]
        #endregion
        public void Deposit_NegativeAmount_ThrowsArgException(double depositAmt)
        {
            //Arrange
            BankAccount acc = new BankAccount("MakeMonteys");

            //Assert => Act
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(depositAmt));
        }

        [TestMethod]
        [TestCategory("Deposit")]
        [Priority(1)]
        public void Deposit_MultiplePositiveAmounts_AddsToBalance()
        {
            //Arrange
            BankAccount acc = new BankAccount("123");
            double amt1 = 300.00;
            double amt2 = 99.99;

            //Act
            acc.Deposit(amt1);
            Assert.AreEqual(amt1, acc.Balance);

            acc.Deposit(amt2);
            Assert.AreEqual(amt1 + amt2, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Withdrawal")]
        #region Deposit Amounts
        [DataRow(1)]
        [DataRow(100)]
        [DataRow(99.99)]
        [DataRow(9.75)]
        [DataRow(0.01)]
        #endregion
        public void Withdraw_PositiveAmount_RemovesFromBalance(double withdrawAmount)
        {
            //Arrange
            string accountNumber = "123";
            double initialBalance = 100;
            BankAccount acc = new BankAccount(accountNumber, initialBalance);    //Second Parameter is initial value 
            double expectedBalance = initialBalance - withdrawAmount;
            
            //Act
            acc.Withdraw(withdrawAmount);

            //Assert            
            Assert.AreEqual(expectedBalance, acc.Balance);
        }


    }
}