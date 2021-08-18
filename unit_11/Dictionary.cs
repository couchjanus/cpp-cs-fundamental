using System;
using System.Collections.Generic;
 
namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>(5);
            countries.Add(1, "Russia");
            countries.Add(3, "Great Britain");
            countries.Add(2, "USA");
            countries.Add(4, "France");
            countries.Add(5, "China");          
             
            foreach (KeyValuePair<int, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
             
            // получение элемента по ключу
            string country = countries[4];
            // изменение объекта
            countries[4] = "Spain";
            // удаление по ключу
            countries.Remove(2);
 
            Dictionary<char, Person> people = new Dictionary<char, Person>();
            people.Add('b', new Person() { Name = "Bill" });
            people.Add('t', new Person() { Name = "Tom" }); 
            people.Add('j', new Person() { Name = "John" });

            // Так как ключами является объекты типа int, а значениями - объекты типа string, то словарь будет хранить объекты KeyValuePair<int, string>. 

            // В цикле foreach их можем получить и извлечь из них ключ и значение.

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                // keyValue.Value представляет класс Person
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name); 
            }

            // в качестве ключей выступают объекты типа char, а значениями - объекты Person. 
            // Используя свойство Keys, мы можем получить ключи словаря, 
            // свойство Values хранит все значения в словаре.

            // мы можем получить отдельно коллекции ключей и значений словаря:
            // перебор ключей
            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }
             
            // перебор по значениям
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
