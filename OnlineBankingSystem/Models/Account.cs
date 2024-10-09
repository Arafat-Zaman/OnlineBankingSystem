using System;
using System.Collections.Generic;
using System.Transactions;

namespace OnlineBankingSystem.Models
{
    public abstract class Account
    {
        public string AccountNumber { get; }
        public string AccountHolder { get; }
        private decimal _balance;
        public List<Transaction> TransactionHistory { get; }

        protected Account(string accountHolder, string accountNumber)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            _balance = 0;
            TransactionHistory = new List<Transaction>();
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            _balance += amount;
            TransactionHistory.Add(new Transaction("Deposit", amount));
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (_balance < amount)
                throw new InvalidOperationException("Insufficient funds.");
            _balance -= amount;
            TransactionHistory.Add(new Transaction("Withdraw", amount));
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void ShowTransactionHistory()
        {
            // This will be handled in the View
        }
    }
}
