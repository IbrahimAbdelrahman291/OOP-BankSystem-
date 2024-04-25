using System;

namespace BankSystem
{
    public abstract class BanckAccount
    {

        public string? AccounNumber;
        public decimal balance;

        public static int count = 0; 
        public abstract void Deposit(decimal deposit);

        public abstract void Withdraw(decimal withdraw);

        public abstract void log(string message);
    }
}
