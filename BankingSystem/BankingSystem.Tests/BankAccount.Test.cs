using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DepositShouldIncreaseBalance()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = 100;
                bankAccount.Deposit(depositAmount);
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }
        [Test]
        public void AccountInicialiseWithPositiveValue()
        {
            {
                BankAccount bankAccount = new BankAccount(123, 2000m);
                Assert.AreEqual(2000m, bankAccount.Balance);
            }
        }
        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalance(decimal depositAmount)
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                bankAccount.Deposit(depositAmount);
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }
        public void NegativeAmountShouldThrowInvalidOperationExceptions()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;
                Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            }
        }
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            Assert.AreEqual("Negative amount", ex.Message);
        }
        
    }

}
