using System;

namespace cs
{

class Counter
{
    public int Seconds { get; set; }

    // Первый оператор преобразует число - объект типа int к типу Counter. Его логика проста - создается новый объект Counter, у которого устанавливается свойство Seconds.
    public static implicit operator Counter(int x)
    {
        return new Counter { Seconds = x };
    }
    // Второй оператор преобразует объект Counter к типу int, то есть получает из Counter число.
    public static explicit operator int(Counter counter)
    {
        return counter.Seconds;
    }
}

    class Program
    {

static void Main(string[] args)
{
    Counter counter1 = new Counter { Seconds = 23 };

    // Поскольку операция преобразования из Counter в int определена с ключевым словом explicit, то есть как явное преобразование, то в этом случае необходимо применить операцию приведения типов:
    int x = (int)counter1;
    Console.WriteLine(x);   // 23

    // В случае с операцией преобразования от int к Counter ничего подобного делать не надо, поскольку данная операция определена с ключевым словом implicit, то есть как неявная. 

    Counter counter2 = x;
    Console.WriteLine(counter2.Seconds);  // 23
}

// оператор преобразования типов должен преобразовывать из типа или в тип, в котором этот оператор определен. То есть оператор преобразования, определенный в типе Counter, должен либо принимать в качестве параметра объект типа Counter, либо возвращать объект типа Counter.
}
}