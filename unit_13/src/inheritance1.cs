using System;

namespace cs
{

class Person
{
    private string _name;
 
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    // наследник от класса Person - класс Employee будет реализовывать тот же функционал, 
    // что и класс Person, который называется базовым классом или родителем (или суперклассом)

    // После двоеточия мы указываем базовый класс для данного класса. 
    // Для класса Employee базовым является Person, 
    // поэтому класс Employee наследует все те же свойства, методы, поля, которые есть в классе Person. 
    // Единственное, что не передается при наследовании, это конструкторы базового класса.
     
}

class Program
{
    // наследование реализует отношение is-a (является), 
    // объект класса Employee также является объектом класса Person:

    static void Main(string[] args)
    {


        Person p = new Person { Name = "Tom"};
        p.Display();

        // поскольку объект Employee является также и объектом Person, 
        // то мы можем так определить переменную: Person p = new Employee().
        
        p = new Employee { Name = "Sam" };
        p.Display();

        Console.Read();

    }

}
}