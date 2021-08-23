using NUnit.Framework;
using BankAccountNS;
using System;

namespace BankAccountTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Deposit_ValidAmount_UpdateBalance()
        {
            double currentBalance = 11.45;
            double depositValue = 6.25;
            double expectedBalance = 17.70;
            BankAccount account = new BankAccount(currentBalance);

            account.Deposit(depositValue);

            Assert.AreEqual(account.Balance, expectedBalance);
        }

        [Test]
        public void Deposit_InvalidAmount_UpdateBalance()
        {
            double currentBalance = 11.45;
            double depositValue = -1;
            BankAccount account = new BankAccount(currentBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(depositValue));
        }


    }
}