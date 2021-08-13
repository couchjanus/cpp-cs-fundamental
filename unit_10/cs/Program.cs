using System;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // int x = 5;
            // int y = x / 10;
            // Console.WriteLine($"Результат: {y}");
            // Console.WriteLine("Конец программы");
            // Console.Read();
            
// 
            // try
            // {
            //     int x = 5;
            //     int y = x / 0;
            //     Console.WriteLine($"Результат: {y}");
            // }
            // catch
            // {
            //     Console.WriteLine("Возникло исключение!");
            // }
            // finally
            // {
            //     Console.WriteLine("Блок finally");
            // }
            // Console.WriteLine("Конец программы");
            // Console.Read();


            // 

            // Console.WriteLine("Введите число");
            // int x = Int32.Parse(Console.ReadLine());
         
            // x *= x;
            // Console.WriteLine("Квадрат числа: " + x);
            // Console.Read();

            // 

            // Console.WriteLine("Введите число");
            // int x;
            // string input = Console.ReadLine();
            // if (Int32.TryParse(input, out x))
            // {
            //     x *= x;
            //     Console.WriteLine("Квадрат числа: " + x);
            // }
            // else
            // {
            //     Console.WriteLine("Некорректный ввод");
            // }
            // Console.Read();

            // 

            // try
            // {
            //     int x = 5;
            //     int y = x / 0;
            //     Console.WriteLine($"Результат: {y}");
            // }
            // catch(DivideByZeroException)
            // {
            //     Console.WriteLine("Возникло исключение DivideByZeroException");
            // }

            // 

            // try
            // {
            //     int x = 5;
            //     int y = x / 0;
            //     Console.WriteLine($"Результат: {y}");
            // }
            // catch(DivideByZeroException ex)
            // {
            //     Console.WriteLine($"Возникло исключение {ex.Message}");
            // }

            // 

            // int x = 0;
            // int y = 0;
             
            // try
            // {
            //     int result = x / y;
            // }
            // catch(DivideByZeroException) when (y==0 && x == 0)
            // {
            //     Console.WriteLine("y не должен быть равен 0");
            // }
            // catch(DivideByZeroException ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }

            // 

            // try
            // {
            //     int x = 5;
            //     int y = x / 0;
            //     Console.WriteLine($"Результат: {y}");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Исключение: {ex.Message}");
            //     Console.WriteLine($"Метод: {ex.TargetSite}");
            //     Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            // }
         
            // Console.Read();


            // 


            // try
            // {
            //     int[] numbers = new int[4];
            //     numbers[7] = 9;     // IndexOutOfRangeException
         
            //     int x = 5;
            //     int y = x / 0;  // DivideByZeroException
            //     Console.WriteLine($"Результат: {y}");
            // }
            // catch (DivideByZeroException)
            // {
            //     Console.WriteLine("Возникло исключение DivideByZeroException");
            // }
            // catch (IndexOutOfRangeException ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
                     
            // Console.Read();

            // 


            // try
            // {
            //     object obj = "you";
            //     int num = (int)obj;     // System.InvalidCastException
            //     Console.WriteLine($"Результат: {num}");
            // }
            // catch (DivideByZeroException)
            // {
            //     Console.WriteLine("Возникло исключение DivideByZeroException");
            // }
            // catch (IndexOutOfRangeException)
            // {
            //     Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            // }
                     
            // Console.Read();

            // 
            // try
            // {
            //     object obj = "you";
            //     int num = (int)obj;     // InvalidCastException
            //     Console.WriteLine($"Результат: {num}");
            // }
            // catch (DivideByZeroException)
            // {
            //     Console.WriteLine("Возникло исключение DivideByZeroException");
            // }
            // catch (IndexOutOfRangeException)
            // {
            //     Console.WriteLine("Возникло исключение IndexOutOfRangeException");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Исключение: {ex.Message}");
            // }  
            // Console.Read();

            // 
            // try
            // {
            //     Person p = new Person { Name = "Tom", Age = 17 };
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Ошибка: {ex.Message}");
            // }
            // Console.Read();


            // 

            // try
            // {
            //     Person p = new Person { Age = 17 };
            //     // Person p = new Person { Name = "Tom", Age = 17 };
            // }
            // catch (PersonException ex)
            // {
            //     Console.WriteLine("Ошибка: " + ex.Message);
            // }
            // Console.Read();

            try
            {
                Person p = new Person { Name = "Tom", Age = 13 };
            }
            catch (PersonException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            Console.Read();


            // 

            try
            {
                TestClass.Method1();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Catch в Main : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Main");
            }
            Console.WriteLine("Конец метода Main");
            Console.Read();


            // 

            try
            {
                Console.Write("Введите строку: ");
                string message = Console.ReadLine();
                if (message.Length > 6)
                {
                    throw new Exception("Длина строки больше 6 символов");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            Console.Read();


        }
    }

// class Person
// {
//     private int age;
//     public string Name { get; set; }
//     public int Age
//     {
//         get { return age; }
//         set
//         {
//             if (value < 18)
//             {
//                 throw new Exception("Лицам до 18 регистрация запрещена");
//             }
//             else
//             {
//                 age = value;
//             }
//         }
//     }
// }

    // class Person
    // {
    //     private int age;
    //     public int Age
    //     {
    //         get { return age; }
    //         set
    //         {
    //             if (value < 18)
    //                 throw new PersonException("Лицам до 18 регистрация запрещена");
    //             else
    //                 age = value;
    //         }
    //     }
    // }

    // class PersonException : Exception
    // {
    //     public PersonException(string message)
    //         : base(message)
    //     { }
    // }


    class PersonException : ArgumentException
    {
        public int Value { get;}
        public PersonException(string message, int val)
            : base(message)
        {
            Value = val;
        }
    }

    class Person
    {
        public string Name { get; set; }
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18)
                    throw new PersonException("Лицам до 18 регистрация запрещена", value);
                else
                    age = value;
            }
        }
    }


    class TestClass
    {
        public static void Method1()
        {
            try
            {
                Method2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Catch в Method1 : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally в Method1");
            }
            Console.WriteLine("Конец метода Method1");
        }
        static void Method2()
        {
            try
            {
                int x = 8;
                int y = x / 0;
            }
            finally
            {
                Console.WriteLine("Блок finally в Method2");
            }
            Console.WriteLine("Конец метода Method2");
        }
    }
}
