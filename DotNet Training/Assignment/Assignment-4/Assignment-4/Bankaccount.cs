using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New balance: {balance:C}.");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for the withdrawal.");
            }
            balance -= amount;
            Console.WriteLine($"Withdrew: {amount:C}. New balance: {balance:C}.");
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Current balance: {balance:C}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000m);

            try
            {
                account.Deposit(200m);
                account.Withdraw(500m);
                account.CheckBalance();
                account.Withdraw(1000m);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Transaction error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
