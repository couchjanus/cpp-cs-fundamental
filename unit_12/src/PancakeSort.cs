using System;

namespace unit_12
{

class Program
{
    //метод для получения индекса максимального элемента подмассива
    static int IndexOfMax(int[] array, int n)
    {
        int result = 0;
        for (var i = 1; i <= n; ++i)
        {
            if (array[i] > array[result])
            {
                result = i;
            }
        }

        return result;
    }

    //метод для переворота массива
    static void Flip(int[] array, int end)
    {
        for (var start = 0; start < end; start++, end--)
        {
            var temp = array[start];
            array[start] = array[end];
            array[end] = temp;
        }
    }

    //блинная сортировка
    static int[] PancakeSort(int[] array)
    {
        for (var subArrayLength = array.Length - 1; subArrayLength >= 0; subArrayLength--)
        {
            //получаем позицию максимального элемента подмассива
            var indexOfMax = IndexOfMax(array, subArrayLength);
            if (indexOfMax != subArrayLength)
            {
                //переворот массива до индекса максимального элемента
                //максимальный элемент подмассива расположится вначале
                Flip(array, indexOfMax);
                //переворот всего подмассива
                Flip(array, subArrayLength);
            }
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Блинная сортировка");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", PancakeSort(array)));

        Console.ReadLine();
    }

}
