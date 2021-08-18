using System;
using System.Collections;
 
namespace cs
{
    // класс Week, который представляет неделю и хранит все дни недели, реализует интерфейс IEnumerable. 
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", 
                         "Friday", "Saturday", "Sunday" };
 
        // возвращаем в методе GetEnumerator объект IEnumerator для массива.
        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }
            Console.Read();
        }
    }
}
