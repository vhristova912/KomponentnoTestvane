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

        public void DepositShouldIncreaseBalance()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = 100;

            bankAccount.Deposit(depositAmount);
            Assert.AreEqual(depositAmount, bankAccount.Balance);
        }
        [Test]
        public void AccountInicializeWithPositiveValue()
        {
            BankAccount bankAccount = new BankAccount(123, 2000m);
            Assert.AreEqual(2000m, bankAccount.Balance);
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationException()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
        }
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionWithMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;
            var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            Assert.AreEqual("Negative amount",ex.Message );
        }
        [Test]
        public void NegativeCashShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal cashCredit = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Credit(cashCredit));

                Assert.AreEqual(ex.Message, "Negative balance");
            }
        }
        [Test]
        public void PercentShouldBeAPositiveNumber()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                double percent = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Increase(percent));

                Assert.AreEqual(ex.Message, "The percent must be positive!");
            }
        }
        [Test]
        public void BonusShouldIncreaseBalanceWithBonusWithMessage()
        {
            BankAccount bankAccount = new BankAccount(123);
            bankAccount.Balance = bankAccount.Bonus();
            Assert.AreEqual(bankAccount.Bonus(), bankAccount.Balance);
        }
        [Test]
        public void NegativePaymentShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment));
                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void ZeroPaymentShouldThrowInvalidOperationExceptionWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = 0;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment));
                Assert.AreEqual(ex.Message, "Payment cannot be zero or negative!");
            }
        }
        [Test]
        public void NotEnoughPaymentShouldThrowInvalidOperationExceptionWithMessage() 
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal payment = 100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.PaymentForCredit(payment));
                Assert.AreEqual(ex.Message, "Not enough money!");
            }
        }
        [Test]
        public void BalanceMinusPaymentIfEnoughMoney() 
        {
            BankAccount bankAccount = new BankAccount(123, 1000);

            bankAccount.Balance = bankAccount.PaymentForCredit(100);
            Assert.AreEqual(bankAccount.PaymentForCredit(100), bankAccount.Balance);
        }
    }

}
