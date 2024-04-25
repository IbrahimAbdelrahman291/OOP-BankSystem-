using System;

namespace BankSystem
{
    public class Employee : Person
    {
        private readonly decimal salary;
        private readonly string startContract;
        private readonly string endContract;
        private static int count=0;
        private readonly string ID;
        private readonly string Password;
        public Employee(
            string FName ,
            string LName,
            int age,
            decimal s,
            string sContract,
            string eContract,
            string pass
            )
        {
            count++;
            FirstName = FName;
            LastName = LName;
            Age = age;
            type = Type.Employee;
            salary = s;
            startContract = sContract;
            endContract = eContract;
            Password = pass;
            ID=$"E{count}";
        }

        public string GetID() 
        {
            return ID;
        }
        public string GetPassword() 
        {
            return Password;
        }

        public override void ShowData()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(
                $"Name : {FirstName}"+$" {LastName}\n" +
                $"ID : {ID}\n"+
                $"Age : {Age}\n" +
                $"Salary : {salary}\n" +
                $"Start contract : {startContract}\n" +
                $"End Contract : {endContract}"
                );
            Console.WriteLine("--------------------------------");
        }
        public void ShowEmployeeMenu()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1-Create Client");
            Console.WriteLine("2-Deposit for client");
            Console.WriteLine("3-withdraw for client");
            Console.WriteLine("4-Your information");
            Console.WriteLine("5-Exit");
            Console.WriteLine("--------------------------------");
        }
        public Client CreateClient(string pass, string FName, string LName, int age, SavingAccount? Saccount = null, CheckingAccount? Caccount = null) 
        {
            Client c = new Client(pass, FName, LName, age, Saccount, Caccount);
            return c;
        }
        public void DepositForClient(List<Client> Clients, string AccNumber,decimal amount) 
        {
            int test = -1;
            foreach (var i in Clients)
            {
                if (i.GetCheckingAccounts() != null)
                {
                    foreach (var item in i.GetCheckingAccounts()!)
                    {
                        if (item.AccounNumber == AccNumber)
                        {
                            item.Deposit(amount);
                            test = 1;
                            break;
                        }
                    }
                }
                else if (i.GetSavingAccounts() != null)
                {
                    foreach (var item in i.GetSavingAccounts()!)
                    {
                        if (item.AccounNumber == AccNumber)
                        {
                            item.Deposit(amount);
                            test = 1;
                            break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            if (test!=1)
            {
                Console.WriteLine("There is no account with this account number");
            }
        }
        public void WithdrawForClient(List<Client> Clients, string AccNumber, decimal amount)
        {
            int test = -1;
            foreach (var i in Clients)
            {
                if (i.GetCheckingAccounts() != null)
                {
                    foreach (var item in i.GetCheckingAccounts()!)
                    {
                        if (item.AccounNumber == AccNumber)
                        {
                            item.Withdraw(amount);
                            test = 1;
                            break;
                        }
                    }
                }
                else if (i.GetSavingAccounts() != null)
                {
                    foreach (var item in i.GetSavingAccounts()!)
                    {
                        if (item.AccounNumber == AccNumber)
                        {
                            item.Withdraw(amount);
                            test = 1;
                            break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            if (test != 1)
            {
                Console.WriteLine("There is no account with this account number");
            }
        }
    }
}
