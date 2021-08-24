using System;

namespace unit_12
{

class Program
{
    //метод обмена элементов
    static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //сортировка перемешиванием
    static int[] ShakerSort(int[] array)
    {
        for (var i = 0; i < array.Length / 2; i++)
        {
            var swapFlag = false;
            //проход слева направо
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            //проход справа налево
            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1] > array[j])
                {
                    Swap(ref array[j - 1], ref array[j]);
                    swapFlag = true;
                }
            }

            //если обменов не было выходим
            if (!swapFlag)
            {
                break;
            }
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Шейкерная сортировка");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", ShakerSort(array)));

        Console.ReadLine();
    }
}
