using System;
using cs.company;

namespace cs
{

    // public struct Person
    // {
    //     public int age;
    //     public int height;
    // }
    
    // public class Persons
    // {
    //     public int age;
    //     public int height;
    // }


    class Program
    {

    static void Calculate(int t)
    {
        int x = 6;
        int y = 7;
        int z = y + t;
    }

        static void Main(string[] args)
        {

            // unsafe
            // {       
            //     // При объявлении указателя указываем тип int* x; - в данном случае объявляется указатель на целое число. Но кроме типа int можно использовать и другие: sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal или bool. Также можно объявлять указатели на типы enum, структуры и другие указатели.


            //     int* x; // определение указателя
            //     int y = 10; // определяем переменную

            //     // Выражение x = &y; позволяет нам получить адрес переменной y и установить на него указатель x. До этого указатель x не на что не указывал.

            //     x = &y; // указатель x теперь указывает на адрес переменной y
            //     Console.WriteLine(*x); // 10
                
            //     // После этого все операции с y будут влиять на значение, получаемое через указатель x и наоборот, так как они указывают на одну и ту же область в памяти.
            //     y = y + 20;
            //     Console.WriteLine(*x);// 30

            //     // Для получения значения, которое хранится в области памяти, на которую указывает указатель x, используется выражение *x.
            //     *x = 50; 
            //     Console.WriteLine(y); // переменная y=50

            //     // Указатель на другой указатель
            //     // int* x; // определение указателя
            //     // int y = 10; // определяем переменную
         
            //     // x = &y; // указатель x теперь указывает на адрес переменной y
            //     int** z = &x; // указатель z теперь указывает на адрес, который указывает и указатель x
            //     **z = **z + 40; // изменение указателя z повлечет изменение переменной y
            //     Console.WriteLine(y); // переменная y=50
            //     Console.WriteLine(**z); // переменная **z=50


            //     // Указатели на структуры, члены классов и массивы
 
            //     // ## Указатели на типы и операция ->
            //     // Кроме указателей на простые типы можно использовать указатели на структуры. А для доступа к полям структуры, на которую указывает указатель, используется операция ->:

            //     Person person;
            //     person.age = 29;
            //     person.height = 176;
            //     Person* p = &person;
            //     p->age = 30;
            //     Console.WriteLine(p->age);
     
            //     // разыменовывание указателя
            //     (*p).height = 180;
            //     Console.WriteLine((*p).height);

            //     // Указатели на массивы и stackalloc
            //     // С помощью ключевого слова stackalloc можно выделить память под массив в стеке. Смысл выделения памяти в стеке в повышении быстродействия кода. Посмотрим на примере вычисления факториала:
            //     const int size = 7;
            //     int* factorial = stackalloc int[size]; // выделяем память в стеке под семь объектов int
            //     int* pf = factorial;
                             
            //     *(pf++)= 1; // присваиваем первой ячейке значение 1 и
            //     // увеличиваем указатель на 1
            //     for (int i = 2; i <= size; i++, pf++)
            //     {
            //         // считаем факториал числа
            //         *pf = pf[-1] *i;
            //     }
            //     for (int i = 1; i <= size; ++i)
            //     {
            //         Console.WriteLine(factorial[i-1]);
            //     }


            //     Persons person1 = new Persons();
            //     person1.age = 28;
            //     person1.height = 178;
            //     // блок фиксации указателя
            //     fixed(int* p1 = &person1.age)
            //     {
            //         if (*p1 < 30)
            //         {
            //             *p1 = 30;
            //         }
            //     }
            //     Console.WriteLine(person1.age); // 30    


            //     int[] nums = { 0, 1, 2, 3, 7, 88 };
            //     string str = "Привет мир";
            //     fixed(int* pa = nums)
            //     {
            //         int third = *(pa+2);     // получим третий элемент
            //         Console.WriteLine(third); // 2
            //     }
            //     fixed(char* pa = str)
            //     // При инициализации указателей на строку следует учитывать, что указатель должен иметь тип char*.
            //     {
            //         char forth = *(pa + 3);     // получим четвертый элемент
            //         Console.WriteLine(forth); // в
            //     }
                
            // }


            // Calculate(5);

            cs.company.BaseClass bs = new cs.company.BaseClass();
            bs.DisplayName();
            
            Console.ReadLine();
        }
    }
}
