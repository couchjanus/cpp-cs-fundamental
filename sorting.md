# Сортировка

## Случайная сортировка (Bogosort)

Случайная сортировка (Bogosort) – один из самых неэффективных алгоритмов сортировки массивов.

Алгоритм случайной сортировки: 
- вначале массив проверяется на упорядоченность, если элементы не отсортированы, то перемешиваем их случайным образом и снова проверяем, 
- операции повторяются до тех пор, пока массив не будет отсортирован.
```cs

// Реализация случайной сортировки
using System;

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

```
## Сортировка пузырьком (bubble sort)

Сортировка пузырьком (bubble sort) - один из самых простых для понимания методов сортировки массивов.

Алгоритм заключается в циклических проходах по массиву, за каждый проход элементы массива попарно сравниваются и, если их порядок не правильный, то осуществляется обмен. Обход массива повторяется до тех пор, пока массив не будет упорядочен.

```cs
using System;

class Program
{
    //метод обмена элементов
    static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //сортировка пузырьком
    static int[] BubbleSort(int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка пузырьком");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BubbleSort(array)));

        Console.ReadLine();
    }
}

```

## Сортировка перемешиванием (cocktail sort, shaker sort)

Сортировка перемешиванием (cocktail sort, shaker sort), или шейкерная сортировка – это усовершенствованная разновидность сортировки пузырьком, при которой сортировка производиться в двух направлениях, меняя направление при каждом проходе.

Проанализировав алгоритм пузырьковой сортировки, можно заметить:
- если при обходе части массива не было обменов элементов, то эту часть можно исключить, так как она уже отсортирована;
- при проходе от конца массива к началу минимальное значение сдвигается на первую позицию, при этом максимальный элемент перемещается только на один индекс вправо.

модифицируем сортировку пузырьком следующим образом:
- на каждой итерации, фиксируем границы части массива в которой происходит обмен;
- массив обходиться поочередно от начала массива к концу и от конца к началу;

При этом минимальный элемент перемещается в начало массива, а максимальный - в конец, после этого уменьшается рабочая область массива.

```cs
using System;

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

```
## Сортировка вставками (insertion sort)

Сортировка вставками (insertion sort) - это алгоритм сортировка, в котором все элементы массива просматриваются поочередно, при этом каждый элемент размещается в соответственное место среди ранее упорядоченных значений.

Алгоритм работы сортировки вставками заключается в следующем:
- в начале работы упорядоченная часть пуста;
- добавляем в отсортированную область первый элемент массива из неупорядоченных данных;
- переходим к следующему элементу в не отсортированных данных, и находим ему правильную позицию в отсортированной части массива, тем самым мы расширяем область упорядоченных данных;
- повторяем предыдущий шаг для всех оставшихся элементов.

```cs
using System;

class Program
{
    //метод обмена элементов
    static void Swap(ref int e1, ref int e2)
    {
        var temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //сортировка вставками
    static int[] InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 1) && (array[j - 1] > key))
            {
                Swap(ref array[j - 1], ref array[j]);
                j--;
            }

            array[j] = key;
        }

        return array;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка вставками");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", InsertionSort(array)));

        Console.ReadLine();
    }
}

```
## Сортировка по частям (Stooge sort)
Сортировка по частям (Stooge sort) – рекурсивный алгоритм сортировки массива.

Алгоритм сортировки stooge sort заключается в следующем:
- Если значение последнего элемента массива меньше, чем значение первого элемента, то меняем их местами;
- Если в массиве содержится три и более элемента, то:
- Рекурсивно вызываем метод для первых 2⁄3 элементов;
- Рекурсивно вызываем метод для последних 2⁄3 элементов;
- Снова рекурсивно вызываем метод для первых 2⁄3 элементов;

```cs
using System;

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

```
## Блинная сортировка (pancake sort)

Блинная сортировка (pancake sort) – алгоритм сортировки массива, в котором сортировка осуществляется переворотом части массива.

В этом алгоритме, к массиву, позволено применять только одну операцию – переворот части массива. И в отличии от других методов сортировки, где пытаются уменьшить количество сравнений, в этом нужно минимизировать количество переворотов.

Идея алгоритма заключается в том, чтобы за каждый проход, переместить максимальный элемент в конец массива. Для этого необходимо выполнить следующие шаги:
- В начале выбрать подмассив равный по длине текущему массиву;
- Найти в нем позицию максимального элемента;
- Если максимальный элемент расположен не в конце подмассива, то:
- Переворачиваем часть массива от начала до максимального значения;
- Переворачиваем весь выбранный подмассив;
- Уменьшаем рабочую область массива и переходим ко второму шагу.

```cs
using System;

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

```
## Сортировка Шелла (Shell sort)
Сортировка Шелла (Shell sort) – алгоритм сортировки массива, который является обобщением сортировки вставками.

Алгоритм сортировки Шелла базируется на двух идеях:
- Сортировка вставками показывает лучшие результаты на практически упорядоченных массивах данных;
- Сортировка вставками неэффективна для смешанных данных, потому что за одну итерацию элементы смещаются только на одну позицию.

Для устранения недостатков алгоритма Insertion Sort, в сортировке Шелла осуществляется несколько сортировок вставками. При этом в каждой итерации сравниваются элементы, которые размещены на разных расстояниях один от другого, начиная с наиболее отдаленных (d = 1⁄2 длины массива) до сравнения соседних элементов (d = 1).

```cs
using System;

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

```
## Сортировка слиянием (Merge sort)

Сортировка слиянием (Merge sort) – алгоритм сортировки массива, который реализован по принципу “разделяй и властвуй”. Задача сортировки массива разбивается на несколько подзадач сортировки массивов меньшего размера, после выполнения которых, результат комбинируется, что и приводит к решению начальной задачи.

Алгоритм сортировки слиянием выглядит следующим образом:
- Входной массив разбивается на две части одинакового размера;
- Каждый из подмассивов сортируется отдельно, по этому же принципу, тоесть производится повторное разбитие до тех пор, пока длина подмассива не достигнет единицы. В таком случае каждый единичный массив считается отсортированным;
- После этого осуществляется слияние всех подмассивов в один, в результате чего получаем отсортированные данные.

```cs
using System;

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

```
## Сортировка выбором (Selection sort)
Сортировка выбором (Selection sort) – алгоритм сортировки массива, который по скорости выполнения сравним с сортировкой пузырьком.

Алгоритм сортировки выбором состоит из следующих шагов:
- Для начала определяем позицию минимального элемента массива;
- Делаем обмен минимального элемента с элементом в начале массива. Получается, что первый элемент массива уже отсортирован;
- Уменьшаем рабочую область массива, отбрасывая первый элемент, а для подмассива который получился, повторяем сортировку.

```cs
using System;

class Program
{
    //метод поиска позиции минимального элемента подмассива, начиная с позиции n
    static int IndexOfMin(int[] array, int n)
    {
        int result = n;
        for (var i = n; i < array.Length; ++i)
        {
            if (array[i] < array[result])
            {
                result = i;
            }
        }

        return result;
    }

    //метод для обмена элементов
    static void Swap(ref int x, ref int y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //сортировка выбором
    static int[] SelectionSort(int[] array, int currentIndex = 0)
    {
        if (currentIndex == array.Length)
            return array;

        var index = IndexOfMin(array, currentIndex);
        if (index != currentIndex)
        {
            Swap(ref array[index], ref array[currentIndex]);
        }

        return SelectionSort(array, currentIndex + 1);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка выбором");
        Console.Write("Введите элементы массива: ");
        var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var a = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            a[i] = Convert.ToInt32(s[i]);
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", SelectionSort(a)));
        Console.ReadLine();
    }
}

```
## Быстрая сортировка (quick sort)
Быстрая сортировка (quick sort), или сортировка Хоара – один из самых быстрых алгоритмов сортирования данных.

Алгоритм Хоара – это модифицированный вариант метода прямого обмена. Другие популярные варианты этого метода - сортировка пузырьком и шейкерная сортировка, в отличии от быстрой сортировки, не очень эффективны.

Идея алгоритма следующая:
- Необходимо выбрать опорный элемент массива, им может быть любой элемент, от этого не зависит правильность работы алгоритма;
- Разделить массив на три части, в первую должны войти элементы меньше опорного, во вторую - равные опорному и в третью - все элементы больше опорного;
- Рекурсивно выполняются предыдущие шаги, для подмассивов с меньшими и большими значениями, до тех пор, пока в них содержится больше одного элемента.

Поскольку метод быстрой сортировки разделяет массив на части, он относиться к группе алгоритмов разделяй и властвуй.

```cs
using System;

class Program
{
    //метод для обмена элементов массива
    static void Swap(ref int x, ref int y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //метод возвращающий индекс опорного элемента
    static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    //быстрая сортировка
    static int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        QuickSort(array, minIndex, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int[] QuickSort(int[] array)
    {
        return QuickSort(array, 0, array.Length - 1);
    }

    static void Main(string[] args)
    {
        Console.Write("N = ");
        var len = Convert.ToInt32(Console.ReadLine());
        var a = new int[len];
        for (var i = 0; i < a.Length; ++i)
        {
            Console.Write("a[{0}] = ", i);
            a[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(a)));

        Console.ReadLine();
    }
}
Метод Partition возвращает индекс опорного елемента, который делит массив на элементы меньше опорного слева, и элементы больше опорного справа. В самом методе в качестве опорного выбирается последний элемент, а обход осуществляется от начала массива.

```
## Гномья сортировка (Gnome sort)

Гномья сортировка (Gnome sort) – простой в реализации алгоритм сортировки массива, назван в честь садового гнома, который предположительно таким методом сортирует садовые горшки.

Алгоритм находит первую пару неотсортированных элементов массива и меняет их местами. При этом учитывается факт, что обмент приводит к неправильному расположению элементов примыкающих с обеих сторон к только что переставленным. Поскольку все элементы массива после переставленных не отсортированны, необходимо перепроверить только элементы до переставленных.

```cs
using System;

class Program
{
    //метод для обмена элементов
    static void Swap(ref int item1, ref int item2)
    {
        var temp = item1;
        item1 = item2;
        item2 = temp;
    }

    //Гномья сортировка
    static int[] GnomeSort(int[] unsortedArray)
    {
        var index = 1;
        var nextIndex = index + 1;

        while (index < unsortedArray.Length)
        {
            if (unsortedArray[index - 1] < unsortedArray[index])
            {
                index = nextIndex;
                nextIndex++;
            }
            else
            {
                Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                index--;
                if (index == 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
            }
        }

        return unsortedArray;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Гномья сортировка");
        Console.Write("Введите элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = Convert.ToInt32(parts[i]);
        }

        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", GnomeSort(array)));

        Console.ReadLine();
    }
}

```
## Сортировка бинарным деревом (Tree sort)

Сортировка бинарным деревом (Tree sort) – алгоритм сортировки, который заключается в построении двоичного дерева поиска по ключам массива, с последующим построением результирующего массива упорядоченных элементов путем обхода дерева.

Элементы неотсортированного массива данных добавляются в двоичное дерево поиска;
Для получения отсортированного массива, производится обход бинарного дерева с переносом данных из дерева в результирующий массив.

```cs
using System;
using System.Collections.Generic;

namespace TreeSortApp
{
    //простая реализация бинарного дерева
    public class TreeNode
    {
        public TreeNode(int data)
        {
            Data = data;
        }

        //данные
        public int Data { get; set; }

        //левая ветка дерева
        public TreeNode Left { get; set; }

        //правая ветка дерева
        public TreeNode Right { get; set; }

        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        //преобразование дерева в отсортированный массив
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                Left.Transform(elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }

    class Program
    {
        //метод для сортировки с помощью двоичного дерева
        private static int[] TreeSort(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            var a = new int[n];
            var random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(0, 100);
            }

            Console.WriteLine("Random Array: {0}", string.Join(" ", a));

            Console.WriteLine("Sorted Array: {0}", string.Join(" ", TreeSort(a)));
        }
    }
}

```
## Сортировка расчёской (Comb sort)

Сортировка расчёской (Comb sort) – алгоритм сортировки массива, является улучшенным вариантом сортировки пузырьком, при этом, по скорости выполнения, конкурирует с алгоритмом быстрой сортировки.

Основная идея сортировки расческой заключается в устранении черепах – маленьких значений в конце массива, которые существенно замедляют сортировку пузырьком.

В сортировке пузырьком всегда сравниваются два соседних элемента массива данных, расстояние между ними равно единице. Основная идея сортировки расческой в использовании большего расстояния между сравниваемыми элементами. При этом первоначально необходимо брать большое расстояние, и постепенно уменьшать его, по мере упорядочивания данных вплоть до единицы. Изначально сравнивается первый и последний элемент массива, и на каждой итерации уменьшается разрыв между элементами на фактор уменьшения. Итерации продолжаются до тех пор, пока разность индексов больше единицы, а затем массив сортируется пузырьковой сортировкой.

Оптимальное значение фактора уменьшения равно 1/(1-e-φ) ≈ 1.247, где е – основание натурального логарифма, а φ – золотое сечение.

```cs
using System;

class Program
{
    //метод обмена элементов
    static void Swap(ref int value1, ref int value2)
    {
        var temp = value1;
        value1 = value2;
        value2 = temp;
    }
    
    //метод для генерации следующего шага
    static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }

    static int[] CombSort(int[] array)
    {
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;
        
        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    Swap(ref array[i], ref array[i + currentStep]);
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        //сортировка пузырьком
        for (var i = 1; i < arrayLength; i++)
        {
            var swapFlag = false;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
            {
                break;
            }
        }

        return array;
    }

    //метод для получения массива заполненного случайными числами
    static int[] GetRandomArray(int length, int minValue, int maxValue)
    {
        var r = new Random();
        var outputArray = new int[length];
        for (var i = 0; i < outputArray.Length; i++)
        {
            outputArray[i] = r.Next(minValue, maxValue);
        }

        return outputArray;
    }

    static void Main(string[] args)
    {
        var arr = GetRandomArray(15, 0, 10);
        Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));
        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CombSort(arr)));
        Console.ReadLine();
    }
}

```
## Сортировка подсчетом (Counting sort)

Сортировка подсчетом (Counting sort) – алгоритм сортировки, который применяется при небольшом количестве разных значений элементов массива данных.

Время работы алгоритма, линейно зависит от общего количества элементов массива и от количества разных элементов.

Идея алгоритма заключается в следующем:
- считаем количество вхождений каждого элемента массива;
- исходя из данных полученных на первом шаге, формируем отсортированный массив.

Рассмотрим реализацию алгоритма для массива, который может содержать значения от 0 до k:
```cs
using System;

class Program
{
    //простой вариант сортировки подсчетом
    static int[] BasicCountingSort(int[] array, int k)
    {
        var count = new int[k + 1];
        for (var i = 0; i < array.Length; i++)
        {
            count[array[i]]++;
        }

        var index = 0;
        for (var i = 0; i < count.Length; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                array[index] = i;
                index++;
            }
        }

        return array;
    }

    //метод для получения массива заполненного случайными числами
    static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
    {
        var random = new Random();
        var randomArray = new int[arraySize];
        for (var i = 0; i < randomArray.Length; i++)
        {
            randomArray[i] = random.Next(minValue, maxValue);
        }

        return randomArray;
    }

    static void Main(string[] args)
    {
        var arr = GetRandomArray(10, 0, 9);
        Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));
        Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BasicCountingSort(arr, 9)));
        Console.ReadLine();
    }
}

```
## Обобщение на произвольный целочисленный диапазон
Если диапазон возможных значений элементов массива данных заранее не известен, производим поиск минимального и максимального значения.

Поскольку индекс массива не может быть отрицательным, то приведем минимальное значение диапазона к нулю, при этом будем учитывать поправку на всех последующих шагах. Это также позволит экономить память на массивах данных, в которых минимальное значение больше нуля.
```cs
//обобщенный вариант сортировки подсчетом
static int[] CountingSort(int[] array)
{
    //поиск минимального и максимального значений
    var min = array[0];
    var max = array[0];
    foreach (int element in array)
    {
        if (element > max)
        {
            max = element;
        }
        else if (element < min)
        {
            min = element;
        }
    }

    //поправка
    var correctionFactor = min != 0 ? -min : 0;
    max += correctionFactor;

    var count = new int[max + 1];
    for (var i = 0; i < array.Length; i++)
    {
        count[array[i] + correctionFactor]++;
    }

    var index = 0;
    for (var i = 0; i < count.Length; i++)
    {
        for (var j = 0; j < count[i]; j++)
        {
            array[index] = i - correctionFactor;
            index++;
        }
    }

    return array;
}

```
