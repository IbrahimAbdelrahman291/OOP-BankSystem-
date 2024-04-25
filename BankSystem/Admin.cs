using System;

namespace BankSystem
{
    public class Admin 
    {
        private static Admin? _instance;
        private readonly string FirstName;
        private readonly string LastName;
        private const string Id="admin";
        private const string password="admin@2024";
        private Type type;
        private Admin()
        {
            FirstName = "Ibrahim";
            LastName = "Abdelrahman";
            type = Type.Admin;
        }
        public static Admin GetAdmin()
        {
            if (_instance == null)
            {
                _instance = new Admin();
            }
            return _instance;
        }
        public static string GetID()
        {
            return Id;
        }
        public static string GetPassword() 
        {
            return password;
        }
        public Type checkType()
        {
            return type;
        }
        public void showAdminMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("1-Create Employee");
            Console.WriteLine("2-Show Employees data");
            Console.WriteLine("3-Show Clients data");
            Console.WriteLine("4-Log out");
            Console.WriteLine("------------------------------");
        }
        public Employee CreateEmployee(string FName, string LName, int age, string StartContract, string EndContract, decimal salary, string password)
        {
            Employee e1 = new Employee(FName!, LName!, age, salary, StartContract!, EndContract!, password!);
            return e1;
        }
        
        public void EmployeesData(List<Employee> Employees)
        {
            if (Employees.Count==0)
            {
                Console.WriteLine("There is no data yet");
            }
            else
            {
                foreach (var item in Employees)
                {
                    item.ShowData();
                }
            }
        }
        public void ClientsData(List<Client> Clients)
        {
            if (Clients.Count==0)
            {
                Console.WriteLine("There is no data yet");
            }
            else
            {
                foreach (var item in Clients)
                {
                    item.ShowData();
                }
            }
        }
    }
}
