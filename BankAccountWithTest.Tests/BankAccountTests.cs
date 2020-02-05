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
        [TestMethod()]
        public void Deposit_PositiveValue_AddsToBalance()
        {
            //Arrange: Get objects and variables set up.
            BankAccount acc = new BankAccount("986321457");
            double depositAmount = 99.99;
            double expectedBalance = 99.99;

            //Act: Call the method under test.
            acc.Deposit(depositAmount);

            //Assert: 
            Assert.AreEqual(expectedBalance, acc.Balance);

        }
    }
}