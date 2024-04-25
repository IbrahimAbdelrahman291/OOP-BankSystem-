using System;


namespace BankSystem
{
    public abstract class Person
    {
        public string? FirstName;
        public string? LastName;
        public int Age;
        public Type type;

        public abstract void ShowData();
    }
}
