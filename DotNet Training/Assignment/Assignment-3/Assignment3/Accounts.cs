using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Accounts
    {
        private int accountNo;
        private string customerName;
        private string accountType;
        private string transactionType;
        private int amount;
        private int balance;

        public Accounts(int accountNo, string customerName, string accountType, int initialBalance)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.balance = initialBalance;
        }

        public void UpdateBalance(string transactionType, int amount)
        {
            this.transactionType = transactionType;
            this.amount = amount;

            if (transactionType == "D")
            {
                Credit(amount);
            }
            else if (transactionType == "W")
            {
                Debit(amount);
            }
        }

        private void Credit(int amount)
        {
            balance += amount;
        }

        private void Debit(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }

        public void ShowData()
        {
            Console.WriteLine($"Account No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Balance: {balance}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Accounts account = new Accounts(12345, "Jack Justin", "Savings", 2000);
            account.UpdateBalance("D", 700);
            account.ShowData();

            account.UpdateBalance("W", 400);
            account.ShowData();
            Console.ReadLine();
        }
    }
}
