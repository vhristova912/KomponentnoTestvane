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
                throw new InvalidOperationException("negative amount");
            }
            this.Balance += amount;
        }
        public void Credit(decimal cash)
        {
            if (this.Balance<=0)
            {
                throw new ArgumentException("Invalid balance");
            }
            else
            {
                this.Balance = this.Balance - cash;
            }
        }
        public void Increase(double percent)
        {
            decimal percenT = Convert.ToDecimal(percent);
            this.Balance = this.Balance + this.Balance * percenT / 100;
        }
        public void Bonus()
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
        }
    }
}
