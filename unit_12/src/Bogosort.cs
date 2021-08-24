using System;


// Случайная сортировка (Bogosort) – один из самых неэффективных алгоритмов сортировки массивов.

// Алгоритм случайной сортировки: 
// - вначале массив проверяется на упорядоченность, если элементы не отсортированы, то перемешиваем их случайным образом и снова проверяем, 
// - операции повторяются до тех пор, пока массив не будет отсортирован.

class Program
{
    //метод для проверки упорядоченности массива
    static bool IsSorted(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1])
                return false;
        }

        return true;
    }

    //перемешивание элементов массива
    static int[] RandomPermutation(int[] a)
    {
        Random random = new Random();
        var n = a.Length;
        while (n > 1)
        {
            n--;
            var i = random.Next(n + 1);
            var temp = a[i];
            a[i] = a[n];
            a[n] = temp;
        }

        return a;
    }

    //случайная сортировка
    static int[] BogoSort(int[] a)
    {
        while(!IsSorted(a))
        {
            a = RandomPermutation(a);
        }

        return a;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Случайная сортировка");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length;i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BogoSort(array)));

        Console.ReadLine();
    }
  }
