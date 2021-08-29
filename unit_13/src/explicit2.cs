using System;

namespace cs
{

    // Класс Timer представляет условный таймер, который хранит часы, минуты и секунды. 
    // Класс Counter представляет условный счетчик-секундомер, который хранит количество секунд. 
    // Исходя из этого мы можем определить некоторую логику преобразования из одного типа к другому, 
    // то есть получение из секунд в объекте Counter часов, минут и секунд в объекте Timer. 
    // Например, 3675 секунд по сути это 1 час, 1 минута и 15 секунд

class Timer
{
    public int Hours { get; set; }
    public int Minutes { get; set; }    
    public int Seconds { get; set; }
}
class Counter
{
    public int Seconds { get; set; }
 
    public static implicit operator Counter(int x)
    {
        return new Counter { Seconds = x };
    }
    public static explicit operator int(Counter counter)
    {
        return counter.Seconds;
    }
    public static explicit operator Counter(Timer timer)
    {
        int h = timer.Hours * 3600;
        int m = timer.Minutes * 60;
        return new Counter { Seconds = h + m + timer.Seconds };
    }
    public static implicit operator Timer(Counter counter)
    {
        int h = counter.Seconds / 3600;
        int m = (counter.Seconds % 3600) / 60;
        int s = counter.Seconds % 60;
        return new Timer { Hours = h, Minutes = m, Seconds = s };
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Counter counter1 = new Counter { Seconds = 115 };
         
            Timer timer = counter1;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); // 0:1:55
         
            Counter counter2 = (Counter)timer;
            Console.WriteLine(counter2.Seconds);  //115
             
            Console.ReadKey();
        }
    }
}