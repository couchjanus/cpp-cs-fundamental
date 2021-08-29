using System;

namespace cs
{

    class Person
    {
        public string Name { get;  set; }

        // в качестве альтернативы мы могли бы определить в базовом классе конструктор без параметров:
        // конструктор по умолчанию
        public Person()
        {
            Name = "Tom";
            Console.WriteLine("Вызов конструктора без параметров");
        }
        
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
        
        // Тогда в любом конструкторе производного класса, где нет обращения конструктору базового класса, 
        // все равно неявно вызывался бы этот конструктор по умолчанию. 

        // Например, следующий конструктор

        public Employee(string company)
        {
            Company = company;
        }

        // был бы эквивалентен следующему конструктору:

        // public Employee(string company)
        //     :base()
        // {
        //     Company = company;
        // }

    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Employee emp = new Employee ("Microsoft");
            emp.Display();
            Console.Read();

        }

    }
}