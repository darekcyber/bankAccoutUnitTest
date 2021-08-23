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
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginingBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount(beginingBalance);

            account.Withdraw(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual);
        }

        

        [Test]
        public void Debit_WhenAmmountIsLessThenZero_ShouldThrowArgumentOutOfRange()
        {
            double beginingBalance = 11.99;
            double debitAmount = -100;
            BankAccount account = new BankAccount(beginingBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(debitAmount));
        }


    }
}