# Пространства имен в C#

Пространства имен (namespace) — это способ, благодаря которому .NET избегает конфликтов имен между классами. Они предназначены для того, чтобы исключить ситуации, когда вы определяете класс, представляющий заказчика, называете его Customer, а после этого кто-то другой делает то же самое.

Пространство имен — это не более чем группа типов данных, но дающая тот эффект, что имена всех типов данных в пределах пространства имен автоматически снабжаются префиксом - названием пространства имен. Пространства имен можно вкладывать друг в друга. Например, большинство базовых классов .NET общего назначения находятся в пространстве имен System. Базовый класс Array относится к этому пространству, поэтому его полное имя — System.Array.
 
Платформа .NET требует, чтобы все имена были объявлены в пределах пространства имен; например, вы можете поместить свой класс MyClass в пространство имен MyCompany. Тогда полное имя этого класса будет выглядеть как MyCompany.MyClass.

Если пространство имен не указано явно, тип будет добавлен к безымянному глобальному пространству имен.

В большинстве ситуаций Microsoft рекомендует применять хотя бы два вложенных пространства имен: первое — наименование вашей компании, а второе — название технологии или пакета программного обеспечения, к которому относится класс, чтобы это выглядело примерно так: MyCompany.SomeNamespace.MyClass. В большинстве случаев такой подход защитит классы вашего приложения от возможных конфликтов с именами классов, написанных разработчиками из других компаний.

Пространство имен (namespace) в C# представляет собой некий контейнер для логического объединения именованных сущностей, таких как классы, интерфейсы, перечисления и тому подобное. 
пространства имен позволяют логически группировать классы и другие сущности, а во-вторых, позволяют использовать одни и те же имена для сущностей в разных пространствах имен. Причем, вторая функция даже больше востребована, так как логическую группировку тех же классов, программист может игнорировать, особенно, если классов не так много, а вот создать два класса с одним именем уже нельзя, не даст компилятор! 

При создании нового проекта в Visual Studio автоматически создает пространство имен:
```cs

//Блок подключения других пространств имен
using System;

//Пространство имен с названием Coom;
namespace Coom
{//Начало пространства имен
    //Основной класс программы
    class Program
    {
        //Главный метод программы (точка входа)
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}//Конец пространства имен


```
Для создания пространства имен используется ключевое слово namespace, после которого, через пробел, указывается название пространства имен. 
Всё, что объявляется внутри фигурных скобок, следующих на за названием, относится к пространству имен.

Пространство имен задает префикс к имени любой сущности, в нем объявленной. Таким образом имя сущности, например класса становится составным. 

## Класс BaseClass, который объявлен в пространстве имен Coom.Common
```cs

//Блок подключения других пространств имен

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пространство имен с названием Coom.Common;
namespace Coom.Common
{//Начало пространства имен
    //Основной класс программы
    public class BaseClass
    {
    }
}//Конец пространства имен

```

Доступ к этому классу из метода Main таким:
```cs

//Главный метод программы (точка входа)
static void Main(string[] args)
{
    //Создание объекта класса BaseClass из пространства имен Coom.Common
    Coom.Common.BaseClass obj = new Coom.Common.BaseClass();
} 

```
Т.е. перед указанием имени класса, указывает имя пространства имен, к которому он принадлежит, а потом, через точку — имя самого класса. Пространство имен Coom.Common ограничивает область видимости для класса BaseClass, и получить доступ, к этому классу мы можем только через пространство имен, его содержащее.

представим, что у нас есть еще один класс с именем BaseClass, но принадлежащий пространству имен «OtherNamespace«, и тогда создание его объекта в том же методе Main будет таким:
```cs

//Главный метод программы (точка входа)
static void Main(string[] args)
{
    //Создание объекта класса BaseClass из пространства имен OtherNamespace
    OtherNamespace.BaseClass tmpObj = new OtherNamespace.BaseClass(); 
} 

```
используя пространства имен, мы можем конкретно указать нужный нам класс, если его имя совпадает с каким-либо классом из другого пространства имен. Но мы получаем и побочный эффект — имена сущностей становятся длиннее. 

Если мы точно уверены, что ни одна сущность из пространства имен «SomeNamespace» не будет создавать конфликты имен с сущностями текущей области видимости, мы можем его подключить (раскрыть) одной строкой кода:
```cs
using SomeNamespace;
```
Которую добавляют в самом начале файла с исходным кодом. И тогда, в методе Main, мы сможем создавать объект класса BaseClass так (без явного указания пространства имен, к которому он принадлежит):
```cs

//Главный метод программы (точка входа)
static void Main(string[] args)
{
    //Создание объекта класса BaseClass из пространства имен SomeNamespace
    BaseClass tmpObj = new BaseClass();
} 

```
Но подключить оба наших вымышленных пространства имен в одном файле, мы уже не сможем, так как, они содержать две одноименных сущности (в данном случае, два класса BaseClass).

пространства имен могут быть вложенными, т.е. одно пространство имен может находиться внутри другого, например так:
```cs

//Какое-то пространство имен
namespace SomeNamespace
{
    //Вложенное пространство имен
    namespace OtherNamespace
    {
        //Некий класс
        class SomeClass
        { 
  
        }
    }
}

```
класс SomeClass принадлежит пространству имен OtherNamespace, а то, в свою очередь, вложено в пространство SomeNamespace. А полное имя класса SomeClass будет таким: SomeNamespace.OtherNamespace.SomeClass

## Абстрактные классы

Модификатор abstract указывает, что реализация сущности с данным модификатором является неполной или отсутствует. Модификатор abstract может использоваться с классами, методами, свойствами, индексаторами и событиями. Модификатор abstract в объявлении класса указывает, что класс предназначен только для использования в качестве базового класса для других классов. Члены, помеченные как абстрактные или включенные в абстрактный класс, должны быть реализованы с помощью классов, производных от абстрактных классов.
## Создать абстрактный класс:
```cs

namespace Coom.Common
{
    public abstract class BaseClass
    {
        
    }
}

using System;
using Coom.Common;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
        }
    }
}

```
Попытаемся скомпилировать этот код:

Compile time error: Cannot create an instance of the abstract class or interface 

Мы не можем создать экземпляр абстрактного класса с помощью ключевого слова new.

## Описание методов в абстрактном классе
```cs

namespace Coom.Common
{
    public abstract class BaseClass
    {
        private int id;

        public int getId()
        {
            return id;
        }
    }
}


using System;
using Coom.Common;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
        }
    }
}

```
Скомпилировать снова не получается, потому что нельзя создавать экземпляры абстрактных классов.

## Использование абстрактного класса в качестве базового

Мы можем унаследовать обычный класс от абстрактного:
```cs

namespace Coom.Common
{
    public abstract class BaseClass
    {
        private int id;

        public int getId()
        {
            return id;
        }
    }
}

using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {

    }
}

```

Мы можем создать экземпляр обычного класса, унаследованного от абстрактного, с помощью ключевого слова new.
```cs

using System;
using Coom.Employees;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mary = new Employee();
        }
    }
}

```

## Декларация методов в абстрактном классе
```cs
namespace Coom.Common
{
    public abstract class BaseClass
    {
        private int id;

        public int getId()
        {
            return id;
        }

        public string info();
        
    }
}


using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {

    }
}


using System;
using Coom.Employees;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mary = new Employee();
        }
    }
}

```
получаем ошибку компиляции: Compile time error: must declare a body because it is not marked abstract, extern, or partial

Дело в том, что если мы объявляем метод в абстрактном классе и при этом хотим, чтобы его конкретное поведение было определено в производных классах, то к такому методу мы должны так же добавить ключевое слово abstract. Добавим его:

```cs
namespace Coom.Common
{
    public abstract class BaseClass
    {
        private int id;

        public int getId()
        {
            return id;
        }

        abstract public string info();
        
    }
}


using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {

    }
}


using System;
using Coom.Employees;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mary = new Employee();
        }
    }
}

```
получим ошибку компиляции: Compiler error: Employees does not implement
inherited abstract member BaseClass.info()

Если мы хотим объявить метод в абстрактном классе, но не реализовывать его, к методу нужно добавить ключевое слово abstract.

Если мы объявляем абстрактный метод в абстрактном классе, то этот метод должен реализовываться в неабстрактных наследниках этого класса.

## Реализация абстрактного метода в производном классе
Так, давайте тогда попробуем реализовать метод YYY() в классе ClassB:

```cs
namespace Coom.Common
{
    public abstract class BaseClass
    {
        private int id;

        public int getId()
        {
            return id;
        }

        abstract public string info();
        
    }
}


using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {
        public void info(){

        }

    }
}


using System;
using Coom.Employees;

namespace Coom
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mary = new Employee();
        }
    }
}

```

На этот раз мы получим сразу две ошибки компиляции:

Compile time error: does not implement inherited abstract member 
Compile time warning: hides inherited member

Дело в том, что в C# нужно явно объявить, что мы реализуем абстрактный метод класса-родителя с помощью ключевого слова override:

```cs
using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {
        public override void info(){

        }

    }
}

```

Абстрактный метод базового класса и метод с override класса-наследника должны быть одинаковы

Это значит, что мы не можем менять тип возвращаемого значения или аргументы, которые передаются в метод. Например, если мы напишем такое:

```cs
using Coom.Common;

namespace Coom.Employees
{
    class Employee:BaseClass
    {
        public override void info(){

        }

    }
}

```

в консоли увидим следующую ошибку:

Compile time error: return type must be ‘void’ to match overridden member

## Инициализация переменных в абстрактных классах

переменная int a будет обладать значением по умолчанию (0). 
Мы можем изменить его на нужное нам прямо в абстрактном классе — с этим не связано никаких особенностей.

## Абстрактные методы в неабстрактных классах
```cs

public class ClassA
{
    public int a;
    public void XXX()
    {

    }

   abstract public void YYY();
}

public class ClassB:ClassA
{
    public override void YYY()
    {

    }
}

public class Program
{
    private static void Main(string[] args)
    {
        ClassB classB = new ClassB();
        Console.ReadKey();
    }
}

```
Такой код не скомпилируется: Compiler error: ClassA.YYY() is abstract but it is contained in non-abstract class ClassA

Абстрактные методы могут быть объявлены только в абстрактных классах.

## Виртуальные методы и свойства
 
При наследовании нередко возникает необходимость изменить в классе-наследнике функционал метода, который был унаследован от базового класса. В этом случае класс-наследник может переопределять методы и свойства базового класса.

Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual. Такие методы и свойства называют виртуальными.

А чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override. Переопределенный метод в классе-наследнике должен иметь тот же набор параметров, что и виртуальный метод в базовом классе.
```cs

class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine(Name);
    }
}

class Employee : Person
{
    public string Company { get; set; }


    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }
}

```
Здесь класс Person представляет человека. Класс Employee наследуется от Person и представляет сотруднника предприятия. Этот класс кроме унаследованного свойства Name имеет еще одно свойство - Company.

Чтобы сделать метод Display доступным для переопределения, этот метод определен с модификатором virtual. Поэтому мы можем переопределить этот метод, но можем и не переопределять. Допустим, нас устраивает реализация метода из базового класса. В этом случае объекты Employee будут использовать реализацию метода Display из класса Person:
```cs

static void Main(string[] args)
{
    Person p1 = new Person("Bill");
    p1.Display(); // вызов метода Display из класса Person
 
    Employee p2 = new Employee("Tom", "Microsoft");
    p2.Display(); // вызов метода Display из класса Person
 
}

```

Но также можем переопределить виртуальный метод. Для этого в классе-наследнике определяется метод с модификатором override, который имеет то же самое имя и набор параметров:
```cs

class Employee : Person
{
    public string Company { get; set; }

    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }
 
    public override void Display()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}

// Возьмем те же самые объекты:

static void Main(string[] args)
{
    Person p1 = new Person("Bill");
    p1.Display(); // вызов метода Display из класса Person
 
    Employee p2 = new Employee("Tom", "Microsoft");
    p2.Display(); // вызов метода Display из класса Employee
 
}

```
Виртуальные методы базового класса определяют интерфейс всей иерархии, то есть в любом производном классе, который не является прямым наследником от базового класса, можно переопределить виртуальные методы. Например, мы можем определить класс Manager, который будет производным от Employee, и в нем также переопределить метод Display.

При переопределении виртуальных методов следует учитывать ряд ограничений:

Виртуальный и переопределенный методы должны иметь один и тот же модификатор доступа. То есть если виртуальный метод определен с помощью модификатора public, то и переопредленный метод также должен иметь модификатор public.

Нельзя переопределить или объявить виртуальным статический метод.

## Переопределение свойств
Также как и методы, можно переопределять свойства:
```cs

class Credit
{
    public virtual decimal Sum { get; set; }
}
class LongCredit : Credit
{
    private decimal sum;
    public override decimal Sum
    {
        get
        {
            return sum;
        }
        set
        {
            if(value > 1000)
            {
                sum = value;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LongCredit credit = new LongCredit { Sum = 6000 };
        credit.Sum = 490;
        Console.WriteLine(credit.Sum);
        Console.ReadKey();
    }
}

```
## Ключевое слово base
Кроме конструкторов, мы можем обратиться с помощью ключевого слова base к другим членам базового класса. В нашем случае вызов base.Display(); будет обращением к методу Display() в классе Person:
```cs

class Employee : Person
{
    public string Company { get; set; }
  
    public Employee(string name, string company)
            :base(name)
    {
        Company = company;
    }
  
    public override void Display()
    {
        base.Display();
        Console.WriteLine($"работает в {Company}");
    }
}

```
## Запрет переопределения методов
Также можно запретить переопределение методов и свойств. В этом случае их надо объявлять с модификатором sealed:
```cs

class Employee : Person
{
    public string Company { get; set; }
  
    public Employee(string name, string company)
                : base(name)
    {
        Company = company;
    }
 
    public override sealed void Display()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}

```
При создании методов с модификатором sealed надо учитывать, что sealed применяется в паре с override, то есть только в переопределяемых методах.

И в этом случае мы не сможем переопределить метод Display в классе, унаследованном от Employee.

## Абстрактный класс, который наследуется от другого абстрактного класса
```cs

public class ClassA
{
    public virtual void XXX()
    {
        Console.WriteLine("ClassA XXX");
    }
}

public abstract class ClassB:ClassA
{
    public new abstract void XXX();
}

public class ClassC:ClassB
{
    public override void XXX()
    {
        System.Console.WriteLine("ClassC XXX");
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        ClassA classA = new ClassC();
        ClassB classB = new ClassC();
        classA.XXX(); classB.XXX();
    }
}

```
Может ли абстрактный класс быть sealed? Проверим:
```cs
public sealed abstract class ClassA
{
    public abstract void XXX()
    {
        Console.WriteLine("ClassA XXX");
    }
}

public class Program
{
    private static void Main(string[] args)
    {
    }
}

```
получим ошибку: Compile time error: ClassA: an abstract class cannot be sealed or static
Разумеется, абстрактный класс не может быть sealed, т.к. он для того и создан, чтобы от него создавались производные классы.

- Абстрактный класс не может иметь модификатор sealed.
- Абстрактный класс не может иметь модификатор static.

- Мы не можем создать экземпляр абстрактного класса с помощью ключевого слова new;
- Мы можем унаследовать обычный класс от абстрактного;
- Мы можем создать экземпляр обычного класса, унаследованного от абстрактного, с помощью ключевого слова new;
- Если мы хотим объявить метод в абстрактном классе, но не реализовывать его, к методу нужно добавить ключевое слово abstract;
- Если мы объявляем абстрактный метод в абстрактном классе, то этот метод должен реализовываться в неабстрактных наследниках этого класса;
- Абстрактные методы могут быть объявлены только в абстрактных классах;
- Абстрактный класс не может иметь модификатор sealed;
- Абстрактный класс не может иметь модификатор static.
