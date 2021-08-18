using System;
using System.Collections;
 
namespace cs
{
class WeekEnumerator : IEnumerator
    {
        string[] days;
        // для хранения текущей позиции определена переменная position. 
        int position = -1;
        // в самом начале (в исходном состоянии) указатель должен указывать на позицию условно перед первым элементом. 
        // Когда будет производиться цикл foreach, то данный цикл вначале вызывает метод MoveNext и фактически перемещает указатель на одну позицию вперед и только затем обращается к свойству Current для получения элемента в текущей позиции.
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }
 
        public bool MoveNext()
        {
            if(position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
 
        public void Reset()
        {
            position = -1;
        }
    }
    // класс Week использует не встроенный перечислитель, а WeekEnumerator, который реализует IEnumerator.
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
 
        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(days);
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
