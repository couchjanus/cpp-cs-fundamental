﻿using System;

namespace Unit2
{
    // Ключевое слово new, как правило, используется при инициализации переменных, которые имеют ссылочный тип данных. 
    
    // Пусть у нас есть класс Rectangle:
            
    class Rectangle
    {
        public double Width = 0;
        public double Height = 0;
    }

    // Перечисления (enum)
            // Перечисления являются набором целочисленных именованных констант. Переменные типа перечисления создаются с помощью ключевого слово enum, после которого следует имя типа и набор значений в фигурных скобках. Создадим enum для представления дней недели:
            
    enum Day
    {
                Sunday,
                Monday,
                Tuesday, 
                Wednesday, 
                Thursday, 
                Friday, 
                Saturday
    };

    // Структуры по своей внутренней организации похожи на классы, они содержат набор полей и методов. Как правило, их используют для объявления типов, которые определяются только значениями полей и не имеют индивидуальности. Например, объекты, описывающие транзакции, несмотря на то, что значения их полей могут совпадать не будут тождественными, то есть нам их нужно уметь различать несмотря на внешнее сходство. А точки на геометрической плоскости, которые задаются двумя координатами, такой индивидуальности не имеют, и если координаты двух точек совпадают, то это значит, что речь идет об одной и той же точке. Именно для таких типов хорошо подходят структуры. Для их объявления используется ключевое слово struct:
            
    struct Point
    {
                public Point(double x, double y)
                {
                    X = x;
                    Y = y;
                }
                
                public double X {get;}
                public double Y {get;}
    }

    // Классы являются наиболее фундаментальным элементов в системе типов C#. Тип System.Object, который является родительским для всех типов данных представляет собой класс. Класс больше всего похож на структуру, у них даже объявление похожи, только вместо ключевого слова struct нужно использовать class.
    
    class Persone
    {
        public Persone(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name {get;set;}
        public int Age {get;set;}
    }

    // Интерфейс представляет собой набор методов, свойств, событий и индексаторов. До версии C# 8.0 интерфейс предполагал только декларацию (объявление) указанных выше элементов, начиная с 8.0, в рамках интерфейса можно располагать реализацию по умолчанию. Фактически интерфейс представляет собой контракт, а класс, который от него наследуюется, реализует этот контракт.

    // Создадим интерфейс для описания человека, у которого есть два свойства имя: Name, и возраст: Age:

    interface IPersone
    {
        string Name {get;set;}
        int Age {get;set;}
    }


    // Изменим объявление класса Persone, так, чтобы он представлял реализацию интерфейса IPersone:

    class Persones: IPersone
    {
        public Persones(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name {get;set;}
        public int Age {get;set;}
    }

    
            
    class Program
    {
       // Второй вариант позволяет более лаконично обрабатывать ситуацию, когда вызов какого-то метода может возвращать null, а результат его работы нужно присвоить типу-значению, при этом заранее известно, какое значение нужно присвоить переменной в этой ситуации:

        static int? GetValue(bool flag)
        {
                    if (flag == true)
                        return 1000;
                    else
                        return null;
        }

        // оператор default полезен при разработке методов с обобщенным типом. Создадим метод, который выводит на консоль значение по умолчанию для типа переданного в нее аргумента:

        static void PrintDefaultValue<T>(T val)
        {
                Console.WriteLine($"Type of val: {val.GetType()}, default value: {default(T)}, current value: {val}");
        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // В языках с сильной типизацией операции над значениями и присваивания можно производить только над переменными одного типа. Иногда это приведение выполняется автоматически, например:

            int v1 = 4;
            double v2 = v1 + 0.123;
            // В этом случае, при выполнении второй строки в первую очередь будет выполнено приведение переменной v1 к типу double, а потом сложение. 
            Console.WriteLine(v2);

            // Но следующий код вызовет ошибку:
            // double v3 = "4" + 0.123;
            // error CS0029: Не удается неявно преобразовать тип "string" в "double". [Unit2/Unit2.csproj]
            // Ошибка сборки. Устраните ошибки сборки и повторите попытку.


            // Создадим переменную класса Rectangle:
            
            Rectangle rect = new Rectangle();
            Console.WriteLine($"Rectangle Width={rect.Width}, Height={rect.Height}");


            // Необходимо иметь ввиду, что переменную нельзя использовать до тех пор пока она не будет проинициализирована, Например, выполнение следующей программы завершится с ошибкой:

            // int notInitedVal;
            // Console.Write(notInitedVal);

            // Переменные типа int, double и т.п. можно проинициализировать с помощью ключевого слова new, в этом случае будет присвоено значение по умолчанию:
            
            int newInitedValue = new int();
            Console.WriteLine("Default int value: " + newInitedValue);

            // Ключевое слово var. Неявная типизация
            // При объявлении переменной вместо явного задания типа можно поставить ключевое слово var. В этом случае будет использована система вывода типов для определения типа переменной по ее значению.
            
            int v4 = 12345;
            var v5 = 12345;
            Console.WriteLine($"Type of v4: {v4.GetType()}\nType of v5: {v5.GetType()}");
            
            // Каждому значению перечисления соответствует целое число.
            // Пример создания переменной типа Day:
            
            Day day1 = Day.Monday;
            var day2 = Day.Tuesday;
            Console.WriteLine($"day1={day1}, day2={day2}");
            
            Point p1 = new Point(1,2);
            Console.WriteLine($"({p1.X}, {p1.Y})");

            // Кортежи используются для группировки данных, которые могут иметь разные типы в единую именованную сущность. Они являются объектами типа System.ValueTuple. Объявим кортеж, состоящий из двух элементов типа double:
            
            (double, double) tp1 = (1.0, 2.0); // явное задание типов элементов кортежа
            var tp2 = (8.1, 4.3); // использование var для объявления кортежа

            
            // Поля кортежа могут быть именованными:
            
            (double X, double Y) tp3 = (3.2, 5.34);
            var tp4 = (X: 1.2, Y: 3.4);
            var X = 5.6;
            var Y = 7.8;
            var tp5 = (X, Y);

            Persone persone1 = new Persone("John", 21);
            Console.WriteLine($"Persone: Name: {persone1.Name}, Age: {persone1.Age})");

            // Объявим переменную типа IPersone:

            IPersone persone2 = new Persones("Jim", 25);
            Console.WriteLine($"Persone: Name: {persone2.Name}, Age: {persone2.Age})");

            // Массив – это структура данных, которая позволяет хранить один или более элементов. Массивы в C# делятся на одномерные и многомерные, среди последних наибольшее распространение получили двумерные массивы. Все массивы являются наследниками класса System.Array. 

            // Создание и инициализация одномерного массива:

                int[] nArr1 = new int[5];
                nArr1[0] = 0;
                nArr1[1] = 1;
                nArr1[2] = 2;
                nArr1[3] = 3;
                nArr1[4] = 4;
                // Пример прямоугольного массива, в нем строки имеют одинаковую длину:

                int[,] nMx = new int[2,2]; // прямоугольный массив
                nMx[0,0]=0;
                nMx[0,1]=1;
                nMx[1,0]=2;
                nMx[1,1]=3;

                // Пример зубчатого (jagged) массива, в нем строки могут иметь разную длину:
                
                int[][] jg = new int[2][]; // зубчатый массив
                jg[0] = new int[3];
                jg[1] = new int[1];



            // Делегаты являются аналогом указателей на функции из языков C / C++. Они используются в случаях, когда нужно передать некоторую функциональность как аргумент, перенаправлять вызовы и т.д.

            // Nullable-типы (нулевые типы) и операция ??
            // Объявление и инициализация Nullable-переменных
            // В работе с типами-значениями есть одна особенность, они не могут иметь значение null. При наличии любой из следующих строк кода, компиляция программы не будет выполнена:
            
            // int nv = null;
            // bool bv = null;
           
            // На практике, особенно при работе с базами данных, может возникнуть ситуация, когда в записи из таблицы пропущены несколько столбцов (нет данных), в этом случае, соответствующей переменной нужно будет присвоить значение null, но она может иметь тип int или double, что приведет к ошибке.

            // Можно объявить переменную с использованием символа ? после указания типа, тогда она станет nullable-переменной – переменной поддерживающей null-значение:

            int? nv1 = null;
            bool? bv1 = null;

            // Использование символа ? является синтаксическим сахаром для конструкции Nullable<T>, где T – это имя типа. 

            // Представленные выше примеры можно переписать так:
            
            // Nullable<int> nv1 = null;
            // Nullable<bool> bv1 = null;

            
            // Проверка на null. Работа с HasValue и Value
            // Для того чтобы проверить, что переменная имеет значение null можно воспользоваться оператором is с шаблоном типа:
            
            bool? flagA = true;
            if(flagA is bool valueOfFlag)
            {
                Console.WriteLine("flagA is not null, value: {valueOfFlag}");
            }

            // Также можно воспользоваться свойствами класса Nullable:
            
            // Nullable<T>.HasValue
            // Возвращает true если переменная имеет значение базового типа. То есть если она не null.
            
            // Nullable<T>.Value
            // Возвращает значение переменной если HasValue равно true, иначе выбрасывает исключение InvalidOperationException.

            bool? flagB = false;
            if(flagB.HasValue)
            {
                Console.WriteLine("flagB is not null, value: {flagB.Value}");
            }

            // Приведение Nullable-переменной к базовому типу
            // При работе с Nullable-переменными их нельзя напрямую присваивать переменным базового типа. Следующий код не будет скомпилирован:
            
            double? nvd1 = 12.3;
            // double nvd2 = nvd1; // error

            
            // Для приведения Nullable-переменной к базовому типу можно воспользоваться явным приведением:
            
            double nvd3 = (double) nvd1;

            
            // В этом случае следует помнить, что если значение Nullable-переменной равно null, то при выполнении данной операции будет выброшено исключение InvalidOperationException.

            // Второй вариант – это использование оператора ??, при этом нужно дополнительно задаться значением, которое будет присвоено переменной базового типа если в исходной лежит значение null:

            double nvd4 = nvd1 ?? 0.0;
            Console.WriteLine(nvd4);
            bool? nvb1 = null;
            bool nvb2 = nvb1 ?? false;
            Console.WriteLine(nvb1);
            Console.WriteLine(nvb2);


            // Второй вариант позволяет более лаконично обрабатывать ситуацию, когда вызов какого-то метода может возвращать null, а результат его работы нужно присвоить типу-значению, при этом заранее известно, какое значение нужно присвоить переменной в этой ситуации:

            // static int? GetValue(bool flag)
            // {
            //     if (flag == true)
            //         return 1000;
            //     else
            //         return null;
            // }
            int test1 = GetValue(true) ?? 123;
            Console.WriteLine(test1);
            int test2 = GetValue(false) ?? 123;
            Console.WriteLine(test2);


            // С помощью ключевого слова dynamic объявляются переменные, для которых нужно опустить проверку типов в процессе компиляции. Для этой переменной не производится присвоение типа из BCL (Base Class Library) – стандартной библиотеки классов .NET, фактически dynamic – это тип System.Object с дополнительным набором метаданных, они нужны для определения типа переменной в процессе выполнения (так называемое, позднее связывание).

            // как работать с dynamic:

            // Создадим переменную типа dynamic и проинициализируем ее double значением
            dynamic dval1 = 12.3;
            
            // Посмотрим на ее значение и тип
            Console.WriteLine($"Value: {dval1}");
            Console.WriteLine(dval1.GetType().Name);
            // Console.WriteLine($"Type: {typeof(dval1)}");
            
            // Изменим значение переменной:
            dval1 += 17;
            Console.WriteLine($"Value: {dval1}"); 
            Console.WriteLine(dval1.GetType().Name);
            // Console.WriteLine($"Type: {typeof(dval1)}");
            
            // Присвоим переменной значение другого типа: bool
            dval1 = true;
            // Посмотрим на ее значение и тип
            Console.WriteLine($"Value: {dval1}"); 
            Console.WriteLine(dval1.GetType().Name);
            // Console.WriteLine($"Type: {typeof(dval1)}");

            // Как вы можете видеть значение и тип переменной dval1 менялись в процессе выполнения программы. При этом нужно помнить, что если вы присвоили переменной dynamic, какое-то значение, которое определило ее тип, а пытаетесь с ней работать как с переменной другого типа, то будет вызвано исключение:

            dynamic dval2 = "hello"; // в переменной dval2 хранится строковое значение
            Console.WriteLine($"Value: {dval2}"); 
            Console.WriteLine(dval2.GetType().Name);
            // Console.WriteLine($"Type: {typeof(dval2)}");
            dval2 = 123; // теперь значение типа int
            // dval2 = dval2.ToUpper() // попытка вызвать на ней .ToUpper() приведет к ошибке

            // Оператор default
            // Оператор default создает значение по умолчанию для указанного типа, используется оно следующим образом: default(T), где T – это тип, для которого нужно создать соответствующее значение.

            //Объявим переменную типа int и присвоим ей значение по умолчанию с помощью new:

            int n3 = new int();
            Console.WriteLine($"Default int value: {n3}");
            // Тоже самое можно сделать с помощью оператора default:

            int n4 = default(int);
            Console.WriteLine($"Value of int that inited by default(T): {n4}");


            // Если C# может самостоятельно вывести тип, то можно воспользоваться не оператором, а литерой default, без явного указания типа:

            int n5 = default;
            Console.WriteLine($"Value of int that inited by default: {n5}");


            // Данный оператор полезен при разработке методов с обобщенным типом. Создадим метод, который выводит на консоль значение по умолчанию для типа переданного в нее аргумента:

            // static void PrintDefaultValue<T>(T val)
            // {
            //     Console.WriteLine($"Type of val: {val.GetType()}, default value: {default(T)}, current value: {val}");
            // }
            // Вызовем эту  функцию:

            PrintDefaultValue<int>(5);
            PrintDefaultValue<bool>(true);


            // Примеры работы с методом Write без форматирования
            Console.Write("Текущая дата: ");
            Console.Write(DateTime.Now);
            Console.Write("\n");
            Console.Write($"Текущая дата: {DateTime.Now}\n");
                      
            // Примеры работы с методом Write с использованием форматирования
            Console.Write("Текущая дата: {0}\n", DateTime.Now);
            Console.Write("Число: {0:E}\n", 123.456789);

            Console.WriteLine("Текущая дата: ");
            Console.WriteLine(DateTime.Now);

            DateTime nowDate = DateTime.Now;
            string someText = "Сегодня";
            int number = 924;
            Console.WriteLine(nowDate);
            Console.WriteLine(someText);
            Console.WriteLine(number);

            // Методы WriteLine и Write позволяют использовать форматирование:

            Console.WriteLine("{1}:{0:yyyy-MM-dd}, Число: {2}", nowDate, someText, number);

            Console.WriteLine("Нажмите любую клавишу, а затем Enter");
            int key1 = Console.Read();
            Console.WriteLine($"Код нажатой клавиши: {key1}");
            Console.WriteLine("Символьное представление: " + Convert.ToChar(key1));
            
            Console.WriteLine("Введите ваше имя, а затем нажмите Enter");
            string name = Console.ReadLine();
            Console.WriteLine($"Привет, {name}!");

            Console.WriteLine("Нажмите любую клавишу:");
            var key2 = Console.ReadKey();
            Console.WriteLine(key2.Key);
            Console.WriteLine(key2.KeyChar);





        }
    }
}
