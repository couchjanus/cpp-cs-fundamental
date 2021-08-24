using System;

namespace unit_12
{

class Program
{
    //метод для слияния массивов
    static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArray = new int[highIndex - lowIndex + 1];
        var index = 0;

        while ((left <= middleIndex) && (right <= highIndex))
        {
            if (array[left] < array[right])
            {
                tempArray[index] = array[left];
                left++;
            }
            else
            {
                tempArray[index] = array[right];
                right++;
            }

            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArray[index] = array[i];
            index++;
        }

        for (var i = 0; i < tempArray.Length; i++)
        {
            array[lowIndex + i] = tempArray[i];
        }
    }

    //сортировка слиянием
    static int[] MergeSort(int[] array, int lowIndex, int highIndex)
    {
        if (lowIndex < highIndex)
        {
            var middleIndex = (lowIndex + highIndex) / 2;
            MergeSort(array, lowIndex, middleIndex);
            MergeSort(array, middleIndex + 1, highIndex);
            Merge(array, lowIndex, middleIndex, highIndex);
        }

        return array;
    }

    static int[] MergeSort(int[] array)
    {
        return MergeSort(array, 0, array.Length - 1);
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка слиянием");
        Console.Write("Введите элементы массива: ");
        var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            array[i] = Convert.ToInt32(s[i]);
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

        Console.ReadLine();
    }

}
