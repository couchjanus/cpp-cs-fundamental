using System;

namespace cs
{

// добавим в наши классы конструкторы:

class Person
{
    public string Name { get;  set; }
    
    // Класс Person имеет конструктор, который устанавливает свойство Name. 
    public Person(string name)
    {
        Name = name;
    }
 
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
 
class Employee : Person
{
    public string Company { get; set; }
    

    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }
}



    class Program
    {
        // С помощью ключевого слова base мы можем обратиться к базовому классу. 
        // В нашем случае в конструкторе класса Employee нам надо установить имя и компанию. 
        // Но имя мы передаем на установку в конструктор базового класса, 
        // то есть в конструктор класса Person, с помощью выражения base(name).
        static void Main(string[] args)
        {
            Person p = new Person("Bill");
            p.Display();
            Employee emp = new Employee ("Tom", "Microsoft");
            emp.Display();
            Console.Read();

        }

    }
}