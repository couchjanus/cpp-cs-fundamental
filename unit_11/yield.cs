using System;
using System.Collections;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // с помощью цикла foreach мы можем перебрать объект Numbers как обычную коллекцию. 
            // При получении каждого элемента в цикле foreach будет срабатывать оператор yield return, который будет возвращать один элемент и запоминать текущую позицию.

            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
 
    class Numbers
    {
        // метод GetEnumerator() представляет итератор. 
        // С помощью оператора yield return возвращается значение (в данном случае квадрат числа).

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < 6; i++)
            {
                yield return i * i;
            }
        }
    }
}
