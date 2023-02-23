using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class BankAccount
    {
        public BankAccount(int id, decimal balance=0)
        {
            this.Id = id;
            this.Balance = balance;
        }
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public void Deposit(decimal amount)
        {
            if(amount<=0)
            {
                throw new InvalidOperationException("Negative amount");
            }
            this.Balance += amount;
        }
        public void Credit(decimal cash)
        {
            if (cash <= 0 || cash > Balance)
            {
                throw new InvalidOperationException("Negative balance");
            }
            this.Balance = this.Balance - cash;
        }
        public void Increase(double percent)
        {
            if (percent <= 0)
            {
                throw new InvalidOperationException("The percent must be positive!");
            }
            this.Balance = this.Balance + this.Balance * (decimal)percent / 100;
        }
        public decimal Bonus()
        {
            if (Balance > 1000 && Balance < 2000)
            {
                this.Balance = this.Balance + 100;
            }
            else if (Balance > 2000 && Balance < 3000)
            {
                this.Balance = this.Balance + 200;
            }
            else if (Balance > 3000)
            {
                this.Balance = this.Balance + 300;
            }
            return this.Balance;
        }
        public decimal PaymentForCredit(decimal payment)
        {
            if (payment <= 0)
            {
                throw new InvalidOperationException("Payment cannot be zero or negative!");
            }
            if (this.Balance < payment)
            {
                throw new InvalidOperationException("Not enough money!");
            }
            return this.Balance -= payment;
        }
    }
}
