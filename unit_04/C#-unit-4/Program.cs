using System;
using User;

namespace C__unit_4
{
    class DemoClass
    {
        public DemoClass()
        {
         
        }
        public DemoClass(int field)
        {
            this.field = field;
        }

        public DemoClass(int field, int prop)
        {
            this.field = field;
            Property = prop;
        }

        // Поле класса
        int field = 0;
        
        // Свойство класса
        public int Property {get;set;}
        
        // Метод класса
        public void Method()
        {
            Console.WriteLine("Method");
        }

        // Если метод объявлен с модификатором public, то его можно использовать вне класса, например метод Printer из DemoClass:

        public void Printer()
        {
            Console.WriteLine($"field: {field}, Property: {Property}");
        }

        // Если мы объявим метод с модификатором private или без модификатора (тогда, по умолчанию, будет принят private), то его уже нельзя будет вызвать снаружи класса:

        private void PrivateMethod() 
        { 
            Console.WriteLine($"Secret method"); 
        } 
        // Но при этом внутри класса его вызвать можно:
        public void PublicMethod() 
        { 
            Console.WriteLine($"Public method");     
            PrivateMethod(); 
        } 
        // Статические имеют модификатор static перед именем метода и принадлежат классу. Для вызова таких методов не обязательно создавать экземпляры класса, мы уже пользовались такими методами из класса Console – это методы Write и WriteLine. 
        // Для вызова метода объекта, необходимо предварительно создать экземпляр класса, пример – это метод PublicMethod и Priter у класса DemoClass. 
        // Добавим статический метод и метод класса в DemoClass:

        public static void StaticMethod()
        {
            Console.WriteLine("Message from static method");
        }
        public void NoneStaticMethod()
        {
            Console.WriteLine("Message from non static method");
        }
        // методы могут принимать данные через аргументы и возвращать значения:
        public int MulField(int value) 
        { 
            return field * value; 
        } 

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Создание объекта класса DemoClass
            DemoClass demo = new DemoClass();
            // Вызов метода Method объекта demo
            demo.Method();

            // Если у класса есть несколько конструкторов, то при инициализации можно выбрать один из существующих:
            DemoClass d2 = new DemoClass(1);
            d2.Method(); // field: 1, Property: 0
            DemoClass d3 = new DemoClass(1, 2);
            d3.Method(); // field: 1, Property: 2

            // Доступна возможность использования неявного объявления с помощью ключевого слова  var:
            var d4 = new DemoClass();

            // Если у класса есть публичные свойства, то им можно присвоить значения при инициализации:
            var d5 = new DemoClass(10) { Property = 11 };
            d5.Method(); // field: 10, Property: 11

            var d6 = new DemoClass(11) { Property = 12 };
            d6.Printer(); // field: 11, Property: 12

            var d7 = new DemoClass();
            d7.PrivateMethod(); // Ошибка компиляции!!!

            DemoClass.StaticMethod(); // Message from static method
            var d8 = new DemoClass();
            d8.NoneStaticMethod(); // Message from none static method

            var d8 = new DemoClass(10);
            Console.WriteLine($"MulField() result: {d8.MulField(2)}"); // MulField() result: 20
            
            User tom = new User("Tom cat");
            Console.WriteLine($"result: {tom.nmae}"); 
        }
    }
}
