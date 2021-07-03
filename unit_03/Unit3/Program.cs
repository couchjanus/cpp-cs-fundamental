using System;
using System.Text;

namespace Unit3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Приведение типов
            // При работе с числовыми типами данных довольно часто приходится сталкиваться с “расширением” и с “сужением” типа. Для начала рассмотрим несколько примеров:

            byte b1 = 100;
            short s1 = b1; // расширение типа
            Console.WriteLine($"byte value: {b1}, short value: {s1}");

            // В обратную сторону это сделать не получится, если вы напишите код, приведенный ниже, то компиляция будет прервана с ошибкой:

            short s2 = 100;
            // byte b2 = s2; // приведет к ошибке компиляции

            // Для того, чтобы такая операция могла быть выполнена, необходимо использовать явное приведение, тем самым, мы как бы говорим компилятору, что в курсе того, что делаем. Для явного приведения необходимо тип, к которому приводится значение переменной, указать перед ней в круглых скобках. Перепишем наш второй пример с использованием явного приведения:

            byte b2 = (byte)s2;
            Console.WriteLine($"byte value: {b2}, short value: {s2}");

            // такая операция не является безопасной, так как в этом случае возможно переполнение, что приведет к получению результата, который скорее всего вы не ожидаете:

            short s3 = 150;
            short s4 = 150;
            byte b3 = (byte)(s3 + s4);
            Console.WriteLine($"Result: {b3}");
            // В результате на консоль будет выведено следующее:
            // Result: 44
            // Это произошло вследствие того, что сумма s3 и s4 равна 300, а максимальное значение, которое может храниться в byte – это 127.

            // Проверка переполнения
            // Если переполнение является критичным моментом для некоторого участка кода вашего приложения, то можете использовать проверку переполнения с помощью ключевого слова checked. 
            // Суть его работы заключается в том, что если в рамках контекста, обозначенного через checked происходит переполнение, то будет выброшено исключение OverflowException. 
            try
            {
                short s5 = 150;
                short s6 = 150;
                byte b44 = checked((byte)(s5 + s6));
            }
            catch(OverflowException)
            {
                Console.WriteLine("Overflow is detected!");
            }

            // Если необходимо провести проверку для группы операторов, то используйте checked следующим образом:
            
            // try
            // {
            //     checked
            //     {
            //         short s5 = 150;
            //         short s6 = 150;
            //         byte b4 = checked((byte)(s5 + s6));
            //         byte b5 = checked((byte)(s5 * 100));
            //     }
            // }
            // catch(OverflowException)
            // {
            //     Console.WriteLine("Overflow is detected!");
            // }
            // В результате выполнения любого из примеров, на консоль будет выведено сообщение:
            // Overflow is detected!

            // Класс System.Convert
            // Для приведения типов можно воспользоваться классом System.Convert, который содержит методы для приведения одного типа к другому.

            // Вариант, когда приведение типа не приводит к переполнению:

            short s7 = 100;
            byte b6 = System.Convert.ToByte(s7);
            Console.WriteLine($"byte value: {b6}, short value: {s7}");
            
            // Вариант, когда приведение типа приводит к переполнению, в этом случае будет выброшено исключение:
            
            // short s8 = 500;
            // byte b7 = System.Convert.ToByte(s8);
            // Console.WriteLine($"byte value: {b7}, short value: {s8}");

            // Класс Math
            Console.WriteLine(Math.Ceiling(4.5)); // вернет 5

            // Преобразование числа в строку
            // Так как все классы числовых типов в C# являются наследниками от System.Object, то это означает, что у них у всех есть метод ToString(), который переводит численное значение в строковое представление:
            
            Console.WriteLine(123.ToString());
            int n5 = 701;
            Console.WriteLine(n5.ToString());
            Console.WriteLine(5.234.ToString());

            // Для форматирования строкового представления числа с плавающей точкой используйте Format с соответствующим набором маркеров, пример:
            
            Console.WriteLine(String.Format("{0:0.00}", 123.4567));
            
            // Преобразование строки в число
            // Преобразовать строку в число можно либо с помощью методов класса Convert, либо с помощью методов классов, представляющих числа.

            // Класс Convert предоставляет набор статических методов для преобразования в базовые типы данных и обратно. Поддерживается следующий набор типов: SByte, Byte, Int16, Int32, Int64, UInt16, UInt32, UInt64, Single, Double, Decimal, Boolean, Char, DateTime, String.

            int n1 = Convert.ToInt32("123");
            int n2 = Convert.ToInt32(true);
            Console.WriteLine($"n1 = {n1}, n2 = {n2}");
            int n3 = Convert.ToInt32("0x0d", 16);
            string s11 = Convert.ToString(n3, 16);
            Console.WriteLine($"n3 = {n3}, hex format: n3 = 0x{s11}");

            // При работе с Convert может происходить:

            // 1. Успешное преобразование.
            // 2. Выброс исключения InvalidCastException, если запрашиваемое преобразование не может быть выполнено. Это может происходить при попытке преобразовать типы Boolean, Double, Decimal, Single, DateTime в Char и обратно, DateTime в не строковый тип и обратно.
            // 3. Выброс исключения FormatException, если преобразование завершается с ошибкой.
            // 4. Выброс исключения OverflowException, если происходит потеря данных при сужении типа (см. Приведение типов).

            // Класс Convert позволяет работать с разными системами счисления. Поддерживаются двоичное (2), восьмеричное (8), десятичное (10) и шестнадцатеричное (16) основание:
            Console.WriteLine($"From bin: {Convert.ToInt32("1111011", 2)}");
            Console.WriteLine($"From oct: {Convert.ToInt32("173", 8)}");
            Console.WriteLine($"From hex: {Convert.ToInt32("7b", 16)}");


            // Методы числовых типов
            // Другим способом преобразования строки в число является использование методов Parse и TryParse, которые предоставляют числовые типы данных. Метод TryParse пытает преобразовать переданную в него строку в число, если это возможно, то полученное значение присваивается второму аргументу с ключевым словом out и возвращает значение true, в ином случае возвращает значение false.

            int value;
            if(int.TryParse("123", out value))
            {
                Console.WriteLine($"Value: {value}");
            } // Будет выведено: Value: 123
            if(int.TryParse("hello", out value))
            {
                Console.WriteLine($"Value: {value}");
            }
            else
            {
                Console.WriteLine("Can't parse string");
            } // Будет выведено: Can't parse string

            // В первом случае преобразование строки “123” в число будет выполнено успешно, во втором нет.

            // Преобразовать строку в число можно также с помощью метода Parse, если процесс пройдет успешно, то будет возвращено численное значение соответствующего типа, если нет, то будет выброшено исключение ArgumentNullException, ArgumentException, FormatException или OverflowException.
            
            Console.WriteLine(int.Parse("123"));
            
            try
            {
                int n55 = int.Parse("hello");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // примеры использования логических операторов:

            bool bo1 = true;
            bool bo2 = !bo1; // false
            bool bo3 = true & bo1; // true
            bool bo4 = false & bo1; // true
            bool bo5 = bo1 && bo2; // false
            bool bo6 = bo1 || bo2; // true
            bo1 &= true; // true
            bo1 |= false; // true


            // Работа со строками

            // За представление строк в C# отвечает класс System.String. В коде, для объявления переменной соответствующего типа, предпочтительно использовать следующий вариант написания: string – с маленькой буквы. Это ключевое слово языка, используя которое можно объявлять строковые переменные, также как int является псевдонимом для  System.Int32, а bool – для System.Boolean.
            
            string hw = "Hello, World!";
            Console.WriteLine(hw);

            // Допустимо объявление строковых переменных через ключевое слово var:
            
            var cbv = "Create by var";
            Console.WriteLine(cbv);

            // Для объединения строк используется оператор +:
            
            string h1 = "Hello, ";
            string hj = h1 + "John!";
            Console.WriteLine(hj);

            
            // При работе со String следует помнить, что при переопределении значения переменной создается новый экземпляр строковой переменной в памяти. Поэтому, если вам нужно собрать строку из большого количества составляющих, то использование оператора + не самый лучший вариант. В этом случае будет происходить перерасход памяти: при выполнении операции объединения с присваиванием для очень большого количества подстрок, приложение может аварийно завершиться из-за того, что сборщик мусора не будет успевать удалять неиспользуемые объекты, а новые будут продолжать появляться с большой скоростью. Для решения этой задачи используйте StringBuilder.

            // Создание и инициализация объекта класса String
            // Существует несколько способов создать объект класса String и проинициализировать его. Рассмотрим варианты, которые доступны в C#. Наиболее распространенный способ сделать эту операцию – это присвоить строковое значение переменной без явного вызова конструктора, так, как мы это делали в предыдущем разделе:
            
            string st5 = "test1";
            var st6 = "test2";

            
            // Для дословного представления строки, для того чтобы проигнорировать управляющие последовательности, используйте префикс @ перед значением. Сравните вывод следующей конструкции:
            
            Console.WriteLine("first line\nSecond line");

            // С вариантом:

            Console.WriteLine(@"first line\nSecond line");
            // Если требуется подготовить строковое значение с использованием набора переменных, то можно воспользоваться статическим методом Format класса String, либо префиксом $:
            
            int age = 27;
            Console.WriteLine(String.Format("Age: {0}", age));
            Console.WriteLine("");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("");

            // Можно явно вызвать конструктор типа c передачей в него параметров. Самый простой вариант – это передать строку:
            
            string st7 = new string("test3");

            // В качестве параметра может выступать массив Char элементов:

            char[] charArray = {'H', 'e', 'l', 'l', 'o'};
            string st8 = new string(charArray);

            // Ещё вариант – это указать элемент типа char и количество раз, которое его нужно повторить:
            
            string st9 = new string('O', 10); // "OOOOOOOOOO"
            // Для создания строки также можно использовать указатели на Char* и SByte*.

            // Базовый API для работы со строками

            // Объединение строк. Оператор +, методы Concat и Join
            // Сцеплять строки между собой можно с помощью оператора +, при этом, в результате объединения, будет создан новый объект:
            
            string st10 = "Area";
            string st11 = " 51";
            Console.WriteLine("Concat by +: " + st10 + st11);

            // В составе API, который предоставляет System.String, есть метод Concat, который может выполнять ту же работу:
            
            Console.WriteLine("Concat by Concat(): " + string.Concat(st10, st11));
            
            // Метод Concat позволяет объединить до четырех строк через прямое перечисление. Если нужно таким образом объединить больше строковых переменных и значений, то используйте оператор +. Полезным свойством Concat является то, что он может принять на вход массив элементов типа String  и объединить их:
            
            string[] sArr1 = {"First ", "Second ", "Third "};
            Console.WriteLine(string.Concat(sArr1));

            
            // Для объединения элементов с указанием разделителя используется метод Join. В предыдущем примере, элементы в массиве sArr1 уже содержали пробел, это не всегда удобно, решим задачу объединения элементов, которые не содержат разделителей, с помощью Join:
            string[] sArr2 = {"First", "Second", "Third"};
            Console.WriteLine("Join elements in array by Join() with space: " + string.Join(" ", sArr2));

            // В качестве разделителя можно использовать любую строку:
            Console.WriteLine("Join elements in array by Join() with <->: " + string.Join("<->", sArr2));

            // Поиск и извлечение элементов из строки. 
            // Оператор [], методы IndexOf, IndexOfAny, LastIndexOf, LastIndexOfAny, Substring
            // Для получения символа из строки с конкретной позиции можно использовать синтаксис подобный тому, что применяется при работе с массивами – через квадратные скобки []:
            
            string s12 = "Hello";
            Console.WriteLine("Get element by index s12[3]: " + s12[3]);

            // Для решения обратной задачи: поиск индекса первого (последнего) вхождения элемента или сроки в данной строке используются методы IndexOf, IndexOfAny и LastIndexOf, LastIndexOfAny.

            // Метод IndexOf(Char) Возвращает индекс первого вхождения символа.

            // IndexOf(Char, Int32)
            // Возвращает индекс первого вхождения символа начиная с заданной позиции.

            // IndexOf(Char, Int32, Int32)
            // Возвращает индекс первого вхождения символа начиная с заданной позиции, проверяется указанное количество элементов.

            // IndexOf(String)
            // IndexOf(String, Int32)
            // IndexOf(String, Int32, Int32)
            // Назначение методов совпадает с перечисленными выше, но поиск выполняется для строки.

            // IndexOfAny(Char[])
            // IndexOfAny(Char[], Int32)
            // IndexOfAny(Char[], Int32, Int32)
            // Назначение методов совпадает с перечисленными выше, но выполняется поиск индекса первого вхождения любого из переданных в массиве элементов.

            // LastIndexOf([Char | String])
            // LastIndexOf([Char | String], Int32)
            // LastIndexOf([Char | String], Int32, Int32)
            // Возвращает индекс последнего вхождения символа или строки. Можно задавать индекс, с которого начинать поиск и количество проверяемых позиций. [Char | String] – означает Char или String

            // LastIndexOfAny(Char[])
            // LastIndexOfAny(Char[], Int32)
            // LastIndexOfAny(Char[], Int32, Int32)
            // Возвращает индекс последнего вхождения любого из переданных в массиве элементов.Можно задавать индекс с которого начинать поиск и количество проверяемых позиций

            var hello1 = "Hello, World!";
            // Поиск первого вхождения символа 'r'
            Console.WriteLine("Index of \'r\': " + hello1.IndexOf('r'));
            // Поиск первого вхождения символа 'l' начиная с позиции 4
            Console.WriteLine("Index of \'l\', start at 4: " + hello1.IndexOf('l', 4));
            // Поиск первого вхождения строки "World"
            Console.WriteLine("Index of \"World\": " + hello1.IndexOf("World"));
            // Поиск первого вхождения символа из набора ['o', 'd', ',']
            Console.WriteLine("Index of pos of any symbol in array: " + hello1.IndexOfAny(new char[] {'o', 'd', ','}));
            // Поиск последнего вхождения символа 'l'
            Console.WriteLine("Last index of \'l\': " + hello1.LastIndexOf('l'));
            // Поиск последнего вхождения строки "or"
            Console.WriteLine("Last index of \"or\": " + hello1.LastIndexOf("or"));
            // Поиск последнего вхождения символа из набора ['o', 'd', ',']
            Console.WriteLine("Last index of pos of any symbol in array: " + hello1.LastIndexOfAny(new char[] {'o', 'd', ','}));

            // Для определения того, содержит ли данная строка указанную подстроку, а также для проверки равенства начала или конца строки заданному значению используйте методы: Contains, StartsWith и EndsWith.

            // Метод Contains(Char) Contains(String)
            // Возвращает True если строка содержит указанный символ или подстроки.

            // Метод StartsWith(Char) StartsWith(String)
            // Возвращает True если строка начинается с заданного символа или подстроки.

            // Метод EndsWith(Char) EndsWith(String)
            // Возвращает True если строка заканчивается на заданный символ или подстроку.
            

            Console.WriteLine("Contains \"World\"? " + hello1.Contains("World")); // True
            Console.WriteLine("Starts with \"He\"? " + hello1.StartsWith("He")); // True
            Console.WriteLine("Ends with \"ld\"? " + hello1.EndsWith("ld")); // False

            
            // Задачу извлечения подстроки из данной строки решает метод SubString:

            // Метод Substring(Int32)
            // Возвращает подстроку начиная с указанной позиции и до конца исходной строки.

            // Метод Substring(Int32, Int32)
            // Возвращает подстроку начиная с указанной позиции с заданной длины.
            
            Console.WriteLine("Substring start at pos 7: " + hello1.Substring(7));  // World!
            Console.WriteLine("Substring start at pos 7 (4 chars): " + hello1.Substring(7, 4)); // Worl

            // Сравнение срок
            // Для сравнения строк можно использовать оператор сравнения ==, при этом будут сравниваться значения строковых переменных, а не их ссылки, как это делается для других ссылочных типов.
            
            string t1 = "John";
            string t2 = "John";
            string t3 = "Mary";
            Console.WriteLine("t1 == t2: " + (t1 == t2));   // True
            Console.WriteLine("t1 != t2: " + (t1 != t2));   // False
            Console.WriteLine("t1 == t3: " + (t1 == t3));   // False


            // Для сравнения также можно использовать метод Equals, но это менее удобный вариант:
            

            Console.WriteLine("Equals method: t1.Equals(t2)" + t1.Equals(t2));   // True
            Console.WriteLine("Equals method: t1.Equals(t3)" + t1.Equals(t3));   // False

            
            // Модификация срок
            // Класс String предоставляет довольно большое количество инструментов для изменения строк. 
            // Вставка строки в исходную в заданную позицию осуществляется с помощью метода Insert:
            
            Console.WriteLine("Insert: " + "26".Insert(1, "[4]")); // 2[4]6

            // Для приведения строки к заданной длине с выравниванием по левому (правому) краю с заполнением недостающих символов пробелами используются методы PadLeft и PadRight:
            
            Console.WriteLine("PadLeft: ");
            Console.WriteLine("some string".PadLeft(15)); // "    some string"
            Console.WriteLine("some string".PadLeft(15, '*')); // "****some string"
            Console.WriteLine("PadRight: ");
            Console.WriteLine("some string".PadRight(15)); // "some string    "
            Console.WriteLine("some string".PadRight(15, '*')); // "some string****"

            
            // Метод Remove удаляет подстроку из исходной строки. Возможны два варианта использования:

            // Метод Remove(Int32)
            // Удаляет все символы начиная с заданного и до конца строки.

            // Remove(Int32, Int32)
            // Удаляет с указанной позиции заданное число символов.
            

            Console.WriteLine("Remove demo1: " + "Hello".Remove(2));
            Console.WriteLine("Remove demo2: " + "Hello".Remove(2, 2));

            // Замена элементов строки производится с помощью метода Replace. Наиболее часто используемые варианты – это замена символа на символ и строки на подстроку:
            
            Console.WriteLine("Hello, World!".Replace('!', '.')); // Hello, World.
            Console.WriteLine("Hello, World!".Replace("World", "John")); // Hello, John!
            
            // Для преобразования строки к верхнему регистру используйте метод ToUpper(), к нижнему – ToLower():
            
            Console.WriteLine("Hello, World!".ToUpper()); // HELLO, WORLD!
            Console.WriteLine("Hello, World!".ToLower()); // hello, world!

            // За удаление начальных и конечных символов отвечают методы, начинающиеся на Trim.

            // Метод Trim()
            // Удаляет символы пробелы из начала и конца строки.

            // Trim(Char)
            // Удаляет экземпляры символа из начала и конца строки.

            // Trim(Char[])
            // Удаляет экземпляры символов из начала и конца строки.

            // TrimStart() TrimStart(Char) TrimStart(Char[])
            // Удаляет экземпляры символов из начала строки.

            // TrimEnd() TrimEnd(Char) TrimEnd(Char[])
            // Удаляет экземпляры символов из конца строки.
            

            Console.WriteLine("   hello   ".Trim());    // "hello"
            Console.WriteLine("***hello---".Trim('*'));    // "hello---"
            Console.WriteLine("***hello---".Trim(new char[] {'*', '-'}));    // "hello"
            Console.WriteLine("   hello   ".TrimStart());   // "hello   "           
            Console.WriteLine("   hello   ".TrimEnd()); // "   hello"

            
            // Методы и свойства общего назначения
            // Рассмотрим некоторые из полезных методов и свойств, которые не вошли в приведенные выше группы.

            // System.Length – возвращает длину строки:
            

            Console.WriteLine("Hello".Length); // 5

            
            // System.Split() – разделяет заданную строку на подстроки, в качестве разделителя используется указанный через параметр символ (или группа символов):
            

            foreach(var s in "1 2 3".Split(' '))
            Console.WriteLine(s);
            foreach(var s in "1 2 3-4-5-6".Split(new char[]{' ', '-'}))
            Console.WriteLine(s);

            
            // System.Empty – возвращает пустую строку.

            // Форматирование строк
            // Под форматированием строк, в рамках данного раздела, понимается встраивание в строку различных элементом  (число, дата и т.п.), представленных в заданном формате. Форматирование можно осуществлять с помощью метода ToString с передачей в него нужных описателей, метода Format, который, в качестве аргументов, получает строку со специальными вставками, определяющими представление элементов и непосредственно сами элементы.

            // Для начала рассмотрим на нескольких примерах работу с этими методоми:
            
            // ToString
            Console.WriteLine(12345.ToString("X"));
            // String.Format
            Console.WriteLine(string.Format("value: {0}", 1.23456));
            Console.WriteLine(string.Format("value: {0:F}", 1.23456));
            Console.WriteLine(string.Format("value: {0:E}", 1.23456));
                    
            // WriteLine без использования String.Format
            Console.WriteLine("value: {0}", 1.23456);   // 1,23456
            Console.WriteLine("value: {0:F}", 1.23456); // 1.235
            Console.WriteLine("date: {0:d}", DateTime.Now); // 07.09.2020

            
            // Эта функциональность также доступна для методов  StringBuilder.AppendFormat,  TextWriter.WriteLine,  Debug.WriteLine, методов из Trace, которые выводят текстовые сообщения, например: Trace.TraceError и метод TraceSource.TraceInformation.

            // Каждый элемент форматирования представляется следующим образом:
            
            // {index[,alignment][:formatString]}

            // где index – это индекс элемента, которым будет замещена данная конструкция;
            // alignment – выравнивание;
            // formatString – формат.

            
            
            Console.WriteLine("Only index: {0}", 123); // Only index: 123
            Console.WriteLine("Index with alignment: {0,-5}{1,5}", 123, 456); // Index with alignment: 123    456
            Console.WriteLine("Index with format: 0x{0:X}", 123); // Index with format: 0x7B

            
            // Представление чисел
            // Для представления чисел используются следующие описатели формата:

            // - “C” или “c” - Представление валюты.
            // - “D” или “d” - Представление целого числа.
            // - “E” или “e” - Представление числа в экспоненциальном виде.
            // - “F” или “f” - Представление числа в формате с плавающей точкой.
            // - “P” или “p” - Представление процентов, выводит число умноженное на 100 со знаком процента.
            // - “X” или “x” - Шестнадцатеричное представление.
            // - “0” - Заместитель нуля.
            // - “#” - Заместитель цифры.
            // - “.” - Разделитель целой и дробной части.

            
            Console.WriteLine("C symbol: {0:C}", 123);      // 123,00 ₽
            Console.WriteLine("D symbol: {0:D5}", 123);     // 00123
            Console.WriteLine("E symbol: {0:E}", 123456789);// 1,234568E+008
            Console.WriteLine("F symbol: {0:F2}", 123.4567);// 123,46
            Console.WriteLine("P symbol: {0:P}", 0.123);    // 123,46
            Console.WriteLine("X symbol: 0x{0:X}", 567);    // 0x237
            Console.WriteLine("0 symbol: {0:000.00}", 12.6789);// 012,68
            Console.WriteLine("# symbol: {0:##}", 14.6789); // 15

            
            // Представление даты и времени
            // Для представления даты и времени используются следующие описатели формата:

            // - “d” - Сокращенный формат даты
            // - “D” - Полный формат даты
            // - “f”, “F” - Полный формат даты и времени с коротким (полным) форматом времени
            // - “g”, “G” - Общий формат даты и времени с коротким (полным) форматом времени
            // - “t” - Короткий формат времени
            // - “T” - Полный формат времени
            // - “M”, “m” - Шаблон дней месяца.
            // - “Y”, “y” - Шаблон месяца года.

            Console.WriteLine("d symbol: {0:d}", DateTime.Now);
            Console.WriteLine("D symbol: {0:D}", DateTime.Now);
            Console.WriteLine("f symbol: {0:f}", DateTime.Now);
            Console.WriteLine("F symbol: {0:F}", DateTime.Now);
            Console.WriteLine("g symbol: {0:g}", DateTime.Now);
            Console.WriteLine("G symbol: {0:G}", DateTime.Now);
            Console.WriteLine("t symbol: {0:t}", DateTime.Now);
            Console.WriteLine("T symbol: {0:T}", DateTime.Now);
            Console.WriteLine("{0:yyyy-MM-dd}", DateTime.Now);
            Console.WriteLine("{0:dd/MM/yy}", DateTime.Now);
            Console.WriteLine("{0:dd/MM/yy HH:mm:ss}", DateTime.Now);

            // $ — интерполяция строк
            // Начиная с C# 6 появилась возможность строить интерполированную строку, формат которой позволяет более просто, по сравнению с составным форматированием, рассмотренным нами выше, создавать строки. Интерполированная строка содержит специальные выражения интерполяции, они похожи на элементы форматирования. Выражения интерполяции имеют следующий вид:
            

            // {<interpolationExpression>[,<alignment>][:<formatString>]}

            // где interpolationExpression – элемент, значение, которого будет интегрироваться в строку;
            // alignment – выравнивание;
            // formatString – формат

            
            int in1 = 45678;
            double id1 = 123.34567;
            bool ib1 = true;
            string isv = "test";
            Console.WriteLine($"int val: {in1}, double val: {id1:#.###}");
            Console.WriteLine($"bool val: {ib1}, string val: {isv}");

            // Управляющие символы (литералы)
            // Управляющие символы позволяют вводить в текст команды управления кареткой и символы, которые имеют специальное назначение (одинарные и двойные кавычки).
            // - \a - Звуковой сигнал
            // - \b - Возврат на одну позицию
            // - \f - Перевод страницы
            // - \n - Новая строка
            // - \r - Возврат каретки
            // - \t - Горизонтальная табуляция
            // - \v - Вертикальная табуляция
            // - \0 - Пустой символ
            // - \’ - Одинарная кавычка
            // - \” - Двойная кавычка
            // - \\ - Обратная косая черта
            Console.WriteLine("\aName:\t\"John\"\nAge:\t\"27\"");

            // @ – буквальный идентификатор
            // Еще один элемент, который можно использовать при создании срок – это буквальный идентификатор @. Если его поставить перед строкой, то она будет интерпретироваться буквально, в ней, escape-последовательности представляются без преобразования.
            
            Console.WriteLine(@"escape is not work: \a\t\n\x1234");

            // Класс StringBuilder следует использовать, если вам нужно собрать строку из большого набора элементов через конкатенацию, которая, например, может осуществляется в цикле. В этом случае использование String может оказаться не эффективным решением.

            // Если для построения итоговой строки использовать оператор +, как это сделано в примере ниже, то при выполнении операции += каждый раз будет создавать новый объект класса String в памяти. Если количество таких присваиваний будет достаточно большим, то программа может аварийно завершиться из-за нехватки памяти, либо занять ее в очень большом объеме. Это происходит из-за того, что сборщик мусора не будет успевать уничтожать неиспользуемые объекты, которые создаются с большой скоростью. Пример реализации с использованием оператора +:

            string outString = "";
            for(int i = 0; i < 10; i++)
            {
            outString += i.ToString() + " - ";
            }
            Console.WriteLine(outString);

            // Более эффективным решением будет использование StringBuilder:
            // using System.Text;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 10; i++)
            {
                sb.Append(i.ToString());
                sb.Append(" - ");
            }
            outString = sb.ToString();
            Console.WriteLine(outString);

        }
    }
}
