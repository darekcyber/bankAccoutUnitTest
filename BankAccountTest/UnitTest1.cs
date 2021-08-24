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

        [Test]
        public void Transfer_ValidAmountMoney_UpdateBothAccounts()
        {
            double currentBalanceAccount1 = 11.45;
            double currentBalanceAccount2 = 10.45;
            double tranferValue = 10.1;
            double expectedBalance1 = 1.35;
            double expectedBalance2 = 20.55;

            BankAccount account1 = new BankAccount(currentBalanceAccount1);
            BankAccount account2 = new BankAccount(currentBalanceAccount2);

            account1.Transfer(account2, tranferValue);

            Assert.AreEqual(expectedBalance1, account1.Balance, 0.01);
            Assert.AreEqual(expectedBalance2, account2.Balance, 0.01);
        }

        [Test]
        
        public void Transfer_toNonExistingAccount_Throws()
        {
            BankAccount account = new BankAccount();
            
            Assert.Throws<ArgumentNullException>(() => account.Transfer(null, 10));
        }


    }
}