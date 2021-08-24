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
            double currentBalance = 11.49;
            double depositValue = 6.25;
            double expectedBalance = 17.74;
            BankAccount account = new BankAccount(currentBalance);

            account.Deposit(depositValue);

            Assert.AreEqual(account.Balance, expectedBalance, 0.01);
        }

        [Test]
        public void Deposit_InvalidAmount_UpdateBalance()
        {
            double currentBalance = 11.45;
            double depositValue = -1;
            BankAccount account = new BankAccount(currentBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(depositValue));
        }

        [Test]
        public void Withdraw_ValidAmount_UpdateBalance()
        {
            double currentBalance = 11.45;
            double withdrawValue = 6.55;
            double expectedBalance = 4.90;

            BankAccount account = new BankAccount(currentBalance);

            account.Withdraw(withdrawValue);

            Assert.AreEqual(expectedBalance, account.Balance, 0.01);
        }

        [Test]
        public void Withdraw_NegativeAmount_Throws()
        {
            double currentBalance = 11.45;
            double withdrawValue = -100;

            BankAccount account = new BankAccount(currentBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(withdrawValue));
        }

        [Test]
        public void Withdraw_MoreWithdrawValueThenBalance_Throws()
        {
            double currentBalance = 11.45;
            double withdrawValue = 100;

            BankAccount account = new BankAccount(currentBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(withdrawValue));
        }
    }
}