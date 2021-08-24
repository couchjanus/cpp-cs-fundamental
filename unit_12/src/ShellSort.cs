using System;

namespace unit_12
{

class Program
{
    //метод для обмена элементов
    static void Swap(ref int a, ref int b)
    {
        var t = a;
        a = b;
        b = t;
    }

    static int[] ShellSort(int[] array)
    {
        //расстояние между элементами, которые сравниваются
        var d = array.Length / 2;
        while (d >= 1)
        {
            for (var i = d; i < array.Length; i++)
            {
                var j = i;
                while ((j >= d) && (array[j - d] > array[j]))
                {
                    Swap(ref array[j], ref array[j - d]);
                    j = j - d;
                }
            }

            d = d / 2;
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка Шелла");
        Console.Write("Введите элементы массива: ");
        var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            array[i] = Convert.ToInt32(s[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", ShellSort(array)));

        Console.ReadLine();
    }

}
