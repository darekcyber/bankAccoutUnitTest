using NUnit.Framework;
using BankAccountNS;

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
            BankAccount account = new BankAccount("Mr Banan", beginingBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual);
        }
    }
}