using System;
using System.Collections.Generic;
 
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Здесь создаются два списка: один для объектов типа int, а другой - для объектов Person. 

            // В первом случае мы выполняем начальную инициализацию списка: List<int> numbers = new List<int>() { 1, 2, 3, 45 };

            List<int> numbers = new List<int>() { 1, 2, 3, 45 };
            numbers.Add(6); // добавление элемента
 
            numbers.AddRange(new int[] { 7, 8, 9 });
 
            numbers.Insert(0, 666); // вставляем на первое место в списке число 666
 
            numbers.RemoveAt(1); //  удаляем второй элемент
 
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            // Во втором случае мы используем другой конструктор, в который передаем начальную емкость списка: List<Person> people = new List<Person>(3);. 
            // Указание начальной емкости списка (capacity) позволяет в будущем увеличить производительность и уменьшить издержки на выделение памяти при добавлении элементов. 
            // Также начальную емкость можно установить с помощью свойства Capacity, которое имеется у класса List.

            List<Person> people = new List<Person>(3);
            people.Add(new Person() { Name = "Том" });
            people.Add(new Person() { Name = "Билл" });
 
            foreach (Person p in people)
            {
                Console.WriteLine(p.Name);
            }
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
