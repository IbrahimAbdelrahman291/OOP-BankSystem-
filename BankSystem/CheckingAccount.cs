using System;

namespace BankSystem
{
    public class CheckingAccount : BanckAccount
    {
        private const decimal DailyMaxWithDraw = 5000;
        public CheckingAccount()
        {
            count++;
            AccounNumber = $"C{count}";
            balance = 0 ;
        }
        public override void Deposit(decimal deposit)
        {
            if (deposit < 0)
            {
                log("Rejected : Negative amount");
                return;
            }
            balance += deposit;
            log("Accepted deposit");
        }

        public override void Withdraw(decimal withdraw)
        {
            if (withdraw < 0)
            {
                log("Rejected : Negative amount");
                return;
            }
            else if (withdraw > balance)
            {
                log("Rejected : Your current is not enough");
                return;
            }
            else if (withdraw > DailyMaxWithDraw)
            {
                log($"Rejected : Your max amount by day is : {DailyMaxWithDraw}");
                return;
            }
            balance -= withdraw;
            log("Accepted withdraw");
        }
        public override void log(string message)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(message);
            Console.WriteLine($"Account number : {this.AccounNumber}");
            Console.WriteLine($"Current balance : {balance}");
            Console.WriteLine("------------------------------");
        }
    }
}
