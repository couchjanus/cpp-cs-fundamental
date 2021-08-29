
using System;

namespace cs
{

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Display()
    {
        Console.WriteLine($"Person {Name}");
    }
}
 
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }
}
 
class Client : Person
{
    public string Bank { get; set; }
    public Client(string name, string bank) : base(name)
    {
        Bank = bank;
    }
}
    class Program
    {
        
        static void Main(string[] args)
        {
            Employee employee = new Employee("Tom", "Microsoft");
            Person person = employee;   // преобразование от Employee к Person
         
            Console.WriteLine(person.Name);
            Console.ReadKey();
    
        }
    }
}