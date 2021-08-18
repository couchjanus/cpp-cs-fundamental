using System;
using System.Collections.Generic;
 
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаются два списка: для чисел и для объектов класса Person. 

            LinkedList<int> numbers = new LinkedList<int>();
 
            numbers.AddLast(1); // вставляем узел со значением 1 на последнее место
            // так как в списке нет узлов, то последнее будет также и первым
            numbers.AddFirst(2); // вставляем узел со значением 2 на первое место
            numbers.AddAfter(numbers.Last, 3); // вставляем после последнего узла новый узел со значением 3
            // теперь у нас список имеет следующую последовательность: 2, 1, 3
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            
            
            
            LinkedList<Person> persons = new LinkedList<Person>();
 
            // добавляем persona в список и получим объект LinkedListNode<Person>, в котором хранится имя Tom
            LinkedListNode<Person> tom = persons.AddLast(new Person() { Name = "Tom" });
            
            // Методы вставки (AddLast, AddFirst) при добавлении в список возвращают ссылку на добавленный элемент LinkedListNode<T> (LinkedListNode<Person>). 
            persons.AddLast(new Person() { Name = "John" });
            persons.AddFirst(new Person() { Name = "Bill" });
            
            // управляя свойствами Previous и Next, мы можем получить ссылки на предыдущий и следующий узлы в списке.

            Console.WriteLine(tom.Previous.Value.Name); // получаем узел перед томом и его значение
            Console.WriteLine(tom.Next.Value.Name); // получаем узел после тома и его значение
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
