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
    public virtual void Display()
    {
        Console.WriteLine(Name);
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



    class Program
    {
        // Чтобы сделать метод Display доступным для переопределения, 
        // этот метод определен с модификатором virtual. 
        // Поэтому мы можем переопределить этот метод, но можем и не переопределять. 
        // Допустим, нас устраивает реализация метода из базового класса. 
        // В этом случае объекты Employee будут использовать реализацию метода Display из класса Person:

        static void Main(string[] args)
        {
            Person p1 = new Person("Bill");
            p1.Display(); // вызов метода Display из класса Person
         
            Employee p2 = new Employee("Tom", "Microsoft");
            p2.Display(); // вызов метода Display из класса Person
         
            Console.ReadKey();
        }

    }
}