# Наследование в С#

Наследование - Это механизм создания нового класса на основе уже существующего старого.
- Старый класс называется родительским, предком (super class).
- Новый класс называется дочерним, наследником (sub class).

Наследование нужно для повторного использования кода, которое облегчает следование принципу DRY (Don’t Repeat Yourself — Не повторяйся).

Дочерний класс содержит методы и переменные родительского.


## Human:
```cs

class Human
{
    public sytring name = "I am Human";
 
    public void DisplayName()
    {
        Console.WriteLine("Human Display Name");
    }

}

```

## Employee:
```cs

class Employee
{

    public int salary = 2000;
 
    public void DisplaySalary()
    {
        Console.WriteLine("Employee Display Salary");
    }
     
}


```
Теперь измените описание первого класса на следующее:

Employee:
```cs

  class Employee:Human
  {
        
  }

```
Теперь после выполнения программы мы получим:

```cs

using System;

namespace cs
{
    class Human
    {
        public string name = "I am Human";
    
        public void DisplayName()
        {
            Console.WriteLine("Human Display Name " + name);
        }

    }

    class Employee:Human
    {

        public int salary = 2000;
     
        public void DisplaySalary()
        {
            Console.WriteLine("Employee Display Salary");
        }
         
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human hum = new Human();
            hum.DisplayName();
            Console.ReadKey();
            
            Employee emp = new Employee();
            emp.DisplayName();
            Console.ReadKey();
            
        }
    }
}

```
Employee наследует публичные методы из Human. Employee — дочерний класс, а Human — родительский.

дочерний класс имеет параметры родительского.

Теперь давайте представим, что Employee тоже имеет метод DisplayName:
```cs

    class Employee:Human
    {

        public int salary = 2000;
    
        public void DisplaySalary()
        {
            Console.WriteLine("Employee Display Salary");
        }

        public void DisplayName()
        {
            Console.WriteLine("Employee Display Name");
        }
        
    }

```
Однако мы также получим предупреждение:
```cs

    class Program
    {
        static void Main(string[] args)
        {
            Human hum = new Human();
            hum.DisplayName();
            Console.ReadKey();

            Employee emp = new Employee();
            emp.DisplayName();
            // warning CS0108: "Employee.DisplayName()" скрывает наследуемый член "Human.DisplayName()". 
            // Если скрытие было намеренным, используйте ключевое слово new. [/home/janus/work/cpp-cs-fundamental/unit_05/cs/cs.csproj]

            Console.ReadKey();

            
        }
    }

```
ничто не может помешать создать в дочернем классе такой же метод, как и в родительском.

Когда мы вызываем .DisplayName(), C# сначала ищет DisplayName() в Employee, а только потом в Human. Поскольку в Employee такой метод есть, вызывается именно он.

## методы дочерних классов имеют приоритет при выполнении.

## Ключевое слово base

Такая возможность нам даётся для того, чтобы мы могли изменить поведение методов предка, если оно нас не устраивает. 

вызывать методы родительского класса мы всё равно можем следующим образом:
```cs

    class Employee:Human
    {

        public int salary = 2000;
    
        public void DisplaySalary()
        {
            Console.WriteLine("Employee Display Salary");
        }

        public void DisplayName()
        {
            Console.WriteLine("Employee Display Name");
            base.DisplayName();
        }
        
    }

```
ключевое слово base может быть использовано для обращения к методам класса-предка.

вверх по иерархии мы обращаться можем. 

## наследование не имеет обратной совместимости

Когда класс Employee наследуется от Human, он получает все его методы и может их использовать. Однако методы, которые были добавлены в Employee, не загружаются наверх в Human, наследование не имеет обратной совместимости. Если попытаться вызвать из класса-родителя метод, который создан в классе-наследнике, вы получите ошибку.

кроме конструкторов и деструкторов, дочерний класс получает от родителя абсолютно всё.

## транзитивное свойство наследования
Если класс Student, будет унаследован от класса Employee, который, в свою очередь, будет унаследован от класса Human, то класс Student унаследует члены как от класса Human, так и от класса Employee. Это транзитивное свойство наследования. Потомок перенимает все члены родителей и не может исключить какие-либо. Он может спрятать их, создав свой метод с тем же именем. Конечно, это никак не повлияет на родительский класс, просто в дочернем метод не будет виден.

## Члены класса
Члены класса могут быть двух типов — статический, который принадлежит именно классу, или обычный, который доступен только из реализаций класса (его объектов). Чтобы сделать член статическим мы должны использовать ключевое слово static.

Если мы не наследуем класс ни от какого другого, подразумевается, что мы наследуем его от класса object. Это — родитель всех классов, и он единственный не унаследован ни от чего. Таким образом, такой код:
```cs

 public class ClassB
 {
 }

 public class ClassA : ClassB
 {
 }

```
Автоматически воспринимается C# так:
```cs

public class ClassB:object
{
}

public class ClassA : ClassB
{
}

```
Таким образом, по свойству транзитивности, ClassA также является наследником object.

классы не могут быть унаследованы от встроенных special классов вроде System.ValueType, System.Enum, System.Delegate, System.Array и т.д.

## множественное наследование в C# не поддерживается
```cs

  public class ClassW
  {
  }

  public class ClassX
  {
  }

  public class ClassY : ClassW, ClassX
  {
  }

```
класс может иметь только одного родителя, множественное наследование в C# не поддерживается.

Если мы попробуем обойти это правило таким образом:
```cs

 public class ClassW:ClassY
 {
 }

 public class ClassX:ClassW
 {
 }

 public class ClassY :  ClassX
 {
 }

```
 То это не пройдёт

классы не могут наследоваться циклически (1-й от 2-го, 2-й от 3-го 3-й от 1-го), что логично.

## Операции с объектами
```cs

// ClassB:
public class ClassB
    {
        public int b = 100;
    }

// ClassA:

    public class ClassA
    {
        public int a = 100;
    }


public class Program
{
    private static void Main(string[] args)
    {
        ClassB classB = new ClassB();
        ClassA classA = new ClassA();
        classA = classB;
        classB = classA;
    }
}

```
Здесь мы пытаемся приравнять объект от разных классов друг к другу.

вы не можете приравнять два объекта от двух независимых классов. 

Однако, если бы класс C наследовался от B:
```cs

 public class ClassC:ClassB
 {
     public int a = 100;
 }

```
Класс C унаследован от B, значит, имеет все его поля и методы — при назначении переменной типа B объекта типа C проблем не возникает. Однако в обратную сторону это не работает — в классе B нет полей и методов, которые могут быть в C.

вы можете назначить переменной родительского типа объект дочернего, но не наоборот.

Приведение типа здесь сработает, но только потому, что эти классы находятся в наследственных отношениях. 
```cs

    public class ClassB
    {
        public int b = 100;
    }

    public class ClassC:ClassB
    {
        public int a = 100;
    }

    
    public class Program
    {
        private static void Main(string[] args)
        {
            ClassB classB = new ClassB();
            ClassA classC = new ClassC();
            classB=classC;
            classC = (ClassA)classB;
        }
    }

```
Два обособленных непримитивных типа привести друг к другу нельзя.
```cs

public class Program
{
    private static void Main(string[] args)
    {
        int integerA = 10;
        char characterB = 'A';
        integerA = characterB;
        characterB = integerA;
    }
}

```
можно конвертировать char в int. Нельзя конвертировать int в char (причина в том, что диапазон целого числа больше, чем символа).
