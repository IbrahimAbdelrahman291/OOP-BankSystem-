using System;

namespace BankSystem
{
    public class Client : Person
    {
        List<SavingAccount>? SavingAccounts = new List<SavingAccount>();
        List<CheckingAccount>? CheckingAccounts = new List<CheckingAccount>();
        private static int count = 0;
        private readonly string Password;
        private readonly string ID;
        public Client(string pass,string FName,string LName,int age,SavingAccount? Saccount = null,CheckingAccount? Caccount = null)
        {
            count++;
            ID = $"C{count}";
            FirstName = FName;
            LastName = LName;
            Age = age;
            type = Type.Client;
            if (Saccount != null)
            {
                SavingAccounts.Add(Saccount);
            }
            if (Caccount != null)
            {
                CheckingAccounts.Add(Caccount);
            }
            Password = pass;
            
         }

        public string GetID() 
        {
            return ID;
        }

        public string GetPassword()
        {
            return Password;
        }

        public List<SavingAccount>? GetSavingAccounts() 
        {
            try 
            {
                if (SavingAccounts!.Count == 0)
                {
                    return null;
                }
            } 
            catch 
            {
                return null;
            }
            return SavingAccounts;
        }

        public List<CheckingAccount>? GetCheckingAccounts() 
        {
            try
            {
                if (CheckingAccounts!.Count == 0)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            return CheckingAccounts;
        }

        public override void ShowData()
        {
            Console.WriteLine($"Name : {FirstName} {LastName}\nID : {ID}\nAge : {Age}\nType : {type}\n");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Saving Accounts : ");
            try 
            {
                foreach (var item in SavingAccounts!)
                {
                    item.log("Account info:");
                }
            } 
            catch
            {
                Console.WriteLine("Doesn't have saving accounts");
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("Checking Accounts : ");
            try 
            {
                foreach (var item in CheckingAccounts!)
                {
                    item.log("Account info:");
                }
            }
            catch 
            {
                Console.WriteLine("Doesn't have Checking accounts");
            }
            Console.WriteLine("------------------------------");
        }

        public void ShowClientMenu() 
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("1-Create Saving Account");
            Console.WriteLine("2-Create Checking Account");
            Console.WriteLine("3-Deposit");
            Console.WriteLine("4-withdraw");
            Console.WriteLine("5-Your information");
            Console.WriteLine("6-Exit");
            Console.WriteLine("------------------------------");
        }
        public void CreateSavingAccount()
        {
            SavingAccount account = new SavingAccount();
            if (SavingAccounts == null)
            {
                SavingAccounts = new List<SavingAccount>();
                SavingAccounts.Add(account);
                account.log("Account Created Successfully");
            }
            else
            {
                SavingAccounts.Add(account);
                account.log("Account Created Successfully");
            }
        }
        public void CreateCheckingAccount()
        {
            CheckingAccount account = new CheckingAccount();
            if (CheckingAccounts == null)
            {
                CheckingAccounts = new List<CheckingAccount>();
                CheckingAccounts.Add(account);
                account.log("Account Created Successfully");
            }
            else
            {
                CheckingAccounts.Add(account);
                account.log("Account Created Successfully");
            }
        }
        public void DoDeposit(string accountNumber,decimal amount)
        {
            try
            {
                foreach (var item in SavingAccounts!)
                {
                    if (item.AccounNumber==accountNumber)
                    {
                        item.Deposit(amount);
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Doesn't have saving accounts");
            }
            try
            {
                foreach (var item in CheckingAccounts!)
                {
                    if (item.AccounNumber==accountNumber)
                    {
                        item.Deposit(amount);
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Doesn't have checking accounts");
            }
        }
        public void DoWithdraw(string accountNumber, decimal amount)
        {
            try
            {
                foreach (var item in SavingAccounts!)
                {
                    if (item.AccounNumber == accountNumber)
                    {
                        item.Withdraw(amount);
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Doesn't have saving accounts");
            }
            try
            {
                foreach (var item in CheckingAccounts!)
                {
                    if (item.AccounNumber == accountNumber)
                    {
                        item.Withdraw(amount);
                        return;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Doesn't have checking accounts");
            }
        }
    }
}
