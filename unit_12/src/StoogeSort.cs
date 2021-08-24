using System;

namespace unit_12
{

class Program
{
    //метод обмена элементов
    static void Swap(ref int a, ref int b)
    {
        var t = a;
        a = b;
        b = t;
    }

    //сортировка по частям
    static int[] StoogeSort(int[] array, int startIndex, int endIndex)
    {
        if (array[startIndex] > array[endIndex])
        {
            Swap(ref array[startIndex], ref array[endIndex]);
        }

        if (endIndex - startIndex > 1)
        {
            var len = (endIndex - startIndex + 1) / 3;
            StoogeSort(array, startIndex, endIndex - len);
            StoogeSort(array, startIndex + len, endIndex);
            StoogeSort(array, startIndex, endIndex - len);
        }

        return array;
    }

    static int[] StoogeSort(int[] array)
    {
        return StoogeSort(array, 0, array.Length - 1);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка по частям");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", StoogeSort(array)));

        Console.ReadLine();
    }

}
