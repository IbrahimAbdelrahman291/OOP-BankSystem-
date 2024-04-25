using BankSystem;

internal class Program
{
    static List<Employee> Employees = new List<Employee>();
    static List<Client> Clients = new List<Client>();
    private static void Main(string[] args)
    {
        Employee? TempEmployee;
        Client? TempClient;
        decimal Amount;
        bool mainLoop=true,Loop = true ;
        int personChoice, TempNum , age;
        string? AccountNumber, FName, LName, passwordForCreatePersons; 
        string? IdForLogIn, PassForLogIn;
        do
        {
            Console.WriteLine("Enter ID : ");
            IdForLogIn = Console.ReadLine();
            Console.WriteLine("Enter Password");
            PassForLogIn = Console.ReadLine();
            if (CheckIfIdOrPassIsNull(IdForLogIn!, PassForLogIn!))
            {
                Console.WriteLine("Can't be null");
                continue;
            }
            else if (CheckAdmin(IdForLogIn, PassForLogIn))
            {
                do
                {
                    Admin A = Admin.GetAdmin();
                    A.showAdminMenu();
                    Console.WriteLine("Enter your choice :");
                    try
                    {
                        personChoice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Is not a number try again plz");
                        continue;
                    }
                    Loop = (personChoice == 4) ? false : true;
                    switch (personChoice)
                    {
                        case 1:
                            decimal salary;
                            string? StartContract;
                            string? EndContract;

                            Console.WriteLine("Enter First Name");
                            FName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name");
                            LName = Console.ReadLine();
                            Console.WriteLine("Enter his age");
                            try
                            {
                                age = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            Console.WriteLine("Enter Salary");
                            try
                            {
                                salary = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            Console.WriteLine("Enter Start of contract");
                            StartContract = Console.ReadLine();
                            Console.WriteLine("Enter End of contract");
                            EndContract = Console.ReadLine();
                            Console.WriteLine("Create a password");
                            passwordForCreatePersons = Console.ReadLine();
                            Employees.Add(A.CreateEmployee(FName!, LName!, age, StartContract!, EndContract!, salary, passwordForCreatePersons!));
                            break;
                        case 2:
                            A.EmployeesData(Employees);
                            break;
                        case 3:
                            A.ClientsData(Clients);
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                } while (Loop);
            }
            else if (CheckEmployee(IdForLogIn, PassForLogIn, out TempEmployee))
            {
                do
                {
                    TempEmployee!.ShowEmployeeMenu();
                    Console.WriteLine("Enter your choice :");
                    try
                    {
                        personChoice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Is not a number try again plz");
                        continue;
                    }
                    Loop = (personChoice == 5) ? false : true;
                    switch (personChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter client first name :");
                            FName = Console.ReadLine();
                            Console.WriteLine("Enter client last name :");
                            LName = Console.ReadLine();
                            Console.WriteLine("Enter client age :");
                            try
                            {
                                age = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            Console.WriteLine("Enter Client Password");
                            passwordForCreatePersons = Console.ReadLine();
                            Console.WriteLine("1-Create saving account");
                            Console.WriteLine("2-Create Checking account");
                            Console.WriteLine("3-Skip");
                            TempNum = Convert.ToInt32(Console.ReadLine());
                            SavingAccount? savingAccount;
                            CheckingAccount? checkingAccount;
                            switch (TempNum)
                            {
                                case 1:
                                    savingAccount = new SavingAccount();
                                    TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!, Saccount: savingAccount);
                                    Clients.Add(TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!, Saccount: savingAccount));
                                    savingAccount.log("Account Created Successfully");
                                    break;
                                case 2:
                                    checkingAccount = new CheckingAccount();
                                    TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!, Caccount: checkingAccount);
                                    Clients.Add(TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!, Caccount: checkingAccount));
                                    checkingAccount.log("Account Created Successfully");
                                    break;
                                case 3:
                                    TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!);
                                    Clients.Add(TempEmployee!.CreateClient(passwordForCreatePersons!, FName!, LName!, age!));
                                    Console.WriteLine("Client Created Successfully");
                                    break;
                                default:
                                    Console.WriteLine("Invalid option");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Account number");
                            AccountNumber = Console.ReadLine();
                            Console.WriteLine("Enter Amount :");
                            try
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            TempEmployee!.DepositForClient(Clients, AccountNumber!, Amount);
                            break;
                        case 3:
                            Console.WriteLine("Enter Account number");
                            AccountNumber = Console.ReadLine();
                            Console.WriteLine("Enter Amount :");
                            try
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            TempEmployee!.WithdrawForClient(Clients, AccountNumber!, Amount);
                            break;
                        case 4:
                            TempEmployee.ShowData();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Invaild option");
                            break;
                    }
                } while (Loop);
            }
            else if (CheckClient(IdForLogIn, PassForLogIn, out TempClient))
            {
                do
                {
                    TempClient!.ShowClientMenu();
                    Console.WriteLine("Enter your choice :");
                    try
                    {
                        personChoice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Is not a number try again plz");
                        continue;
                    }
                    Loop = (personChoice == 6) ? false : true;
                    switch (personChoice)
                    {
                        case 1:
                            TempClient!.CreateSavingAccount();
                            break;
                        case 2:
                            TempClient!.CreateCheckingAccount();
                            break;
                        case 3:
                            Console.WriteLine("Enter your account number :");
                            AccountNumber = Console.ReadLine();
                            Console.WriteLine("Enter amount");
                            try
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            TempClient!.DoDeposit(AccountNumber!, Amount);
                            break;
                        case 4:
                            Console.WriteLine("Enter your account number :");
                            AccountNumber = Console.ReadLine();
                            Console.WriteLine("Enter amount");
                            try
                            {
                                Amount = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("It is not a number");
                                continue;
                            }
                            TempClient!.DoWithdraw(AccountNumber!, Amount);
                            break;
                        case 5:
                            Console.WriteLine("your information:");
                            TempClient!.ShowData();
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Invaild Option");
                            break;
                    }
                } while (Loop);
            }
            else
            {
                Console.WriteLine("You are not a member in our bank");
            }
        } while (mainLoop);
    }

    public static bool CheckIfIdOrPassIsNull(string Id , string pass)
    {
        if (Id != null || pass != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool CheckAdmin(string? Id,string? pass)
    {
        
         if (Id == Admin.GetID() && pass ==Admin.GetPassword())
         {
            return true;
         }
         else
         {
            return false;
         }
    }
    public static bool CheckEmployee(string? Id , string? pass,out Employee? TempEmployee)
    {
        if (Employees.Count==0)
        {
            TempEmployee = null;
            return false ;
        }
        else
        {
            foreach (Employee item in Employees)
            {
                if (Id == item.GetID() && pass == item.GetPassword())
                {
                    TempEmployee = item;
                    return true ;
                }
            }
            TempEmployee = null;
            return false;
        }
    }
    public static bool CheckClient(string? Id , string? pass,out Client? TempClient)
    {
        if (Clients.Count==0)
        {
            TempClient = null;
            return false;
        }
        else
        {
            foreach (Client item in Clients)
            {
                if (Id == item.GetID() && pass == item.GetPassword())
                {
                    TempClient = item;
                    return true;
                }
            }
            TempClient = null;
            return false;
        }
    }
}