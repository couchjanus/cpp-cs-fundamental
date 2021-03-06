# Обработка исключений. 

Обработка исключений в C# использует три ключевых слова: try, try...catch..finally. 

## Конструкция try..catch..finally
```cs
try{     
}catch{
}finally{
}
```
При использовании блока try...catch..finally вначале выполняются все инструкции в блоке try. Если в этом блоке не возникло исключений, то после его выполнения начинает выполняться блок finally. И затем конструкция try..catch..finally завершает свою работу.

Если же в блоке try вдруг возникает исключение, то обычный порядок выполнения останавливается, и среда CLR начинает искать блок catch, который может обработать данное исключение. Если нужный блок catch найден, то он выполняется, и после его завершения выполняется блок finally.

Если нужный блок catch не найден, то при возникновении исключения программа аварийно завершает свое выполнение.

```cs
class Program
{
    static void Main(string[] args)
    {
        int x = 5;
        int y = x / 0;
        Console.WriteLine($"Результат: {y}");
        Console.WriteLine("Конец программы");
        Console.Read();
    }
}
```
В данном случае происходит деление числа на 0, что приведет к генерации исключения. И при запуске приложения в режиме отладки мы увидим в Visual Studio окошко, которое информирует об исключении:

## Исключения в C#

возникло исключение, которое представляет тип System.DivideByZeroException, то есть попытка деления на ноль. И в этом случае единственное, что нам остается, это завершить выполнение программы.

Чтобы избежать подобного аварийного завершения программы, следует использовать для обработки исключений конструкцию try...catch...finally. Так, перепишем пример следующим образом:
```cs
class Program
{
    static void Main(string[] args)
    {
        try
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine($"Результат: {y}");
        }
        catch
        {
            Console.WriteLine("Возникло исключение!");
        }
        finally
        {
            Console.WriteLine("Блок finally");
        }
        Console.WriteLine("Конец программы");
        Console.Read();
    }
}
```
В данном случае у нас опять же возникнет исключение в блоке try, так как мы пытаемся разделить на ноль. И дойдя до строки
int y = x / 0;
выполнение программы остановится. CLR найдет блок catch и передаст управление этому блоку.
После блока catch будет выполняться блок finally.

Таким образом, программа по-прежнему не будет выполнять деление на ноль и соответственно не будет выводить результат этого деления, но теперь она не будет аварийно завершаться, а исключение будет обрабатываться в блоке catch.

в этой конструкции обязателен блок try. 
При наличии блока catch мы можем опустить блок finally:
```cs
try
{
    int x = 5;
    int y = x / 0;
    Console.WriteLine($"Результат: {y}");
}
catch
{
    Console.WriteLine("Возникло исключение!");
}

// И, наоборот, при наличии блока finally мы можем опустить блок catch и не обрабатывать исключение:

try
{
    int x = 5;
    int y = x / 0;
    Console.WriteLine($"Результат: {y}");
}
finally
{
    Console.WriteLine("Блок finally");
}
```
хотя с точки зрения синтаксиса C# такая конструкция вполне корректна, тем не менее, поскольку CLR не сможет найти нужный блок catch, то исключение не будет обработано, и программа аварийно завершится.

## Обработка исключений и условные конструкции
Ряд исключительных ситуаций может быть предвиден разработчиком. Например, пусть программа предусматривает ввод числа и вывод его квадрата:
```cs
static void Main(string[] args)
{
    Console.WriteLine("Введите число");
    int x = Int32.Parse(Console.ReadLine());
 
    x *= x;
    Console.WriteLine("Квадрат числа: " + x);
    Console.Read();
}
```
Если пользователь введет не число, а строку, какие-то другие символы, то программа выпадет в ошибку. С одной стороны, здесь как раз та ситуация, когда можно применить блок try..catch, чтобы обработать возможную ошибку. Однако гораздо оптимальнее было бы проверить допустимость преобразования:
```cs
static void Main(string[] args)
{
    Console.WriteLine("Введите число");
    int x;
    string input = Console.ReadLine();
    if (Int32.TryParse(input, out x))
    {
        x *= x;
        Console.WriteLine("Квадрат числа: " + x);
    }
    else
    {
        Console.WriteLine("Некорректный ввод");
    }
    Console.Read();
}
```
Метод Int32.TryParse() возвращает true, если преобразование можно осуществить, и false - если нельзя. При допустимости преобразования переменная x будет содержать введенное число. Так, не используя try...catch можно обработать возможную исключительную ситуацию.

С точки зрения производительности использование блоков try..catch более накладно, чем применение условных конструкций. Поэтому по возможности вместо try..catch лучше использовать условные конструкции на проверку исключительных ситуаций.

## Блок catch и фильтры исключений

За обработку исключения отвечает блок catch, который может иметь следующие формы:
```cs
catch
{
    // выполняемые инструкции
}
```
Обрабатывает любое исключение, которое возникло в блоке try.
```cs
catch (тип_исключения)
{
    // выполняемые инструкции
}
```
Обрабатывает только те исключения, которые соответствуют типу, указаному в скобках после оператора catch.

Например, обработаем только исключения типа DivideByZeroException:
```cs
try
{
    int x = 5;
    int y = x / 0;
    Console.WriteLine($"Результат: {y}");
}
catch(DivideByZeroException)
{
    Console.WriteLine("Возникло исключение DivideByZeroException");
}
```
Однако если в блоке try возникнут исключения каких-то других типов, отличных от DivideByZeroException, то они не будут обработаны.
```cs
catch (тип_исключения имя_переменной)
{
    // выполняемые инструкции
}
```
Обрабатывает только те исключения, которые соответствуют типу, указаному в скобках после оператора catch. А вся информация об исключении помещается в переменную данного типа:
```cs
try
{
    int x = 5;
    int y = x / 0;
    Console.WriteLine($"Результат: {y}");
}
catch(DivideByZeroException ex)
{
    Console.WriteLine($"Возникло исключение {ex.Message}");
}
```
Фактически этот случай аналогичен предыдущему за тем исключением, что здесь используется переменная. В данном случае в переменную ex, которая представляет тип DivideByZeroException, помещается информация о возникшем исключени. И с помощью свойства Message мы можем получить сообщение об ошибке.

Если нам не нужна информация об исключении, то переменную можно не использовать как в предыдущем случае.

## Фильтры исключений
Фильтры исключений позволяют обрабатывать исключения в зависимости от определенных условий. Для их применения после выражения catch идет выражение when, после которого в скобках указывается условие:
```cs
catch when(условие)
{
     
}
````
В этом случае обработка исключения в блоке catch производится только в том случае, если условие в выражении when истинно. Например:
```cs
int x = 1;
int y = 0;
 
try
{
    int result = x / y;
}
catch(DivideByZeroException) when (y==0 && x == 0)
{
    Console.WriteLine("y не должен быть равен 0");
}
catch(DivideByZeroException ex)
{
    Console.WriteLine(ex.Message);
}
```
В данном случае будет выброшено исключение, так как y=0. Здесь два блока catch, и оба они обрабатывают исключения типа DivideByZeroException, то есть по сути все исключения, генерируемые при делении на ноль. Но поскольку для первого блока указано условие y == 0 && x == 0, то оно не будет обрабатывать исключение - условие, указанное после оператора when возвращает false. Поэтому CLR будет дальше искать соответствующие блоки catch далее и для обработки исключения выберет второй блок catch. В итоге если мы уберем второй блок catch, то исключение вобще не будет обрабатываться.


## Типы исключений. Класс Exception
 
Базовым для всех типов исключений является тип Exception. Этот тип определяет ряд свойств, с помощью которых можно получить информацию об исключении.

InnerException: хранит информацию об исключении, которое послужило причиной текущего исключения

Message: хранит сообщение об исключении, текст ошибки

Source: хранит имя объекта или сборки, которое вызвало исключение

StackTrace: возвращает строковое представление стека вызывов, которые привели к возникновению исключения

TargetSite: возвращает метод, в котором и было вызвано исключение

Например, обработаем исключения типа Exception:
```cs
static void Main(string[] args)
{
    try
    {
        int x = 5;
        int y = x / 0;
        Console.WriteLine($"Результат: {y}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Исключение: {ex.Message}");
        Console.WriteLine($"Метод: {ex.TargetSite}");
        Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
    }
 
    Console.Read();
}
```
## Обработка исключений и класс Exception в C#
Однако так как тип Exception является базовым типом для всех исключений, то выражение catch (Exception ex) будет обрабатывать все исключения, которые могут возникнуть.

Но также есть более специализированные типы исключений, которые предназначены для обработки каких-то определенных видов исключений. Их довольно много, я приведу лишь некоторые:

- DivideByZeroException: представляет исключение, которое генерируется при делении на ноль

- ArgumentOutOfRangeException: генерируется, если значение аргумента находится вне диапазона допустимых значений

- ArgumentException: генерируется, если в метод для параметра передается некорректное значение

- IndexOutOfRangeException: генерируется, если индекс элемента массива или коллекции находится вне диапазона допустимых значений

- InvalidCastException: генерируется при попытке произвести недопустимые преобразования типов

- NullReferenceException: генерируется при попытке обращения к объекту, который равен null (то есть по сути неопределен)

И при необходимости мы можем разграничить обработку различных типов исключений, включив дополнительные блоки catch:
```cs
static void Main(string[] args)
{
    try
    {
        int[] numbers = new int[4];
        numbers[7] = 9;     // IndexOutOfRangeException
 
        int x = 5;
        int y = x / 0;  // DivideByZeroException
        Console.WriteLine($"Результат: {y}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Возникло исключение DivideByZeroException");
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
             
    Console.Read();
}
```
В данном случае блоки catch обрабатывают исключения типов IndexOutOfRangeException, DivideByZeroException и Exception. Когда в блоке try возникнет исключение, то CLR будет искать нужный блок catch для обработки исключения. Так, в данном случае на строке
```cs

numbers[7] = 9;

```
происходит обращение к 7-му элементу массива. Однако поскольку в массиве только 4 элемента, то мы получим исключение типа IndexOutOfRangeException. CLR найдет блок catch, который обрабатывает данное исключение, и передаст ему управление.

Следует отметить, что в данном случае в блоке try есть ситуация для генерации второго исключения - деление на ноль. поскольку после генерации IndexOutOfRangeException управление переходит в соответствующий блок catch, то деление на ноль int y = x / 0 в принципе не будет выполняться, поэтому исключение типа DivideByZeroException никогда не будет сгенерировано.

рассмотрим другую ситуацию:
```cs
static void Main(string[] args)
{
    try
    {
        object obj = "you";
        int num = (int)obj;     // InvalidCastException
        Console.WriteLine($"Результат: {num}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Возникло исключение DivideByZeroException");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Возникло исключение IndexOutOfRangeException");
    }
             
    Console.Read();
}
```
В данном случае в блоке try генерируется исключение типа InvalidCastException, однако соответствующего блока catch для обработки данного исключения нет. Поэтому программа аварийно завершит свое выполнение.

Мы также можем определить для InvalidCastException свой блок catch, однако суть в том, что теоретически в коде могут быть сгенерированы сами различные типы исключений. А определять для всех типов исключений блоки catch, если обработка исключений однотипна, не имеет смысла. И в этом случае мы можем определить блок catch для базового типа Exception:
```cs
static void Main(string[] args)
{
    try
    {
        object obj = "you";
        int num = (int)obj;     // InvalidCastException
        Console.WriteLine($"Результат: {num}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Возникло исключение DivideByZeroException");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Возникло исключение IndexOutOfRangeException");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Исключение: {ex.Message}");
    }  
    Console.Read();
}
```
в данном случае блок catch (Exception ex){} будет обрабатывать все исключения кроме DivideByZeroException и IndexOutOfRangeException. 
При этом блоки catch для более общих, более базовых исключений следует помещать в конце - после блоков catch для более конкретный, специализированных типов. Так как CLR выбирает для обработки исключения первый блок catch, который соответствует типу сгенерированного исключения. Поэтому в данном случае сначала обрабатывается исключение DivideByZeroException и IndexOutOfRangeException, и только потом Exception (так как DivideByZeroException и IndexOutOfRangeException наследуется от класса Exception).

## Создание классов исключений
 
Если нас не устраивают встроенные типы исключений, то мы можем создать свои типы. Базовым классом для всех исключений является класс Exception, соответственно для создания своих типов мы можем унаследовать данный класс.

Допустим, у нас в программе будет ограничение по возрасту:
```cs
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Person p = new Person { Name = "Tom", Age = 17 };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.Read();
    }
}
class Person
{
    private int age;
    public string Name { get; set; }
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 18)
            {
                throw new Exception("Лицам до 18 регистрация запрещена");
            }
            else
            {
                age = value;
            }
        }
    }
}
```
В классе Person при установке возраста происходит проверка, и если возраст меньше 18, то выбрасывается исключение. Класс Exception принимает в конструкторе в качестве параметра строку, которое затем передается в его свойство Message.

Но иногда удобнее использовать свои классы исключений. Например, в какой-то ситуации мы хотим обработать определенным образом только те исключения, которые относятся к классу Person. Для этих целей мы можем сделать специальный класс PersonException:
```cs
class PersonException : Exception
{
    public PersonException(string message)
        : base(message)
    { }
}
```
класс кроме пустого конструктора ничего не имеет
в конструкторе мы просто обращаемся к конструктору базового класса Exception, передавая в него строку message. 
Но теперь мы можем изменить класс Person, чтобы он выбрасывал исключение именно этого типа и соответственно в основной программе обрабатывать это исключение:
```cs
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Person p = new Person { Name = "Tom", Age = 17 };
        }
        catch (PersonException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        Console.Read();
    }
}
class Person
{
    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 18)
                throw new PersonException("Лицам до 18 регистрация запрещена");
            else
                age = value;
        }
    }
}
```
необязательно наследовать свой класс исключений именно от типа Exception, можно взять какой-нибудь другой производный тип. Например, в данном случае мы можем взять тип ArgumentException, который представляет исключение, генерируемое в результате передачи аргументу метода некорректного значения:
```cs
class PersonException : ArgumentException
{
    public PersonException(string message)
        : base(message)
    { }
}
```
Каждый тип исключений может определять какие-то свои свойства. Например, в данном случае мы можем определить в классе свойство для хранения устанавливаемого значения:
```cs
class PersonException : ArgumentException
{
    public int Value { get;}
    public PersonException(string message, int val)
        : base(message)
    {
        Value = val;
    }
}
```
В конструкторе класса мы устанавливаем это свойство и при обработке исключения мы его можем получить:
```cs
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
class Program
{
    static void Main(string[] args)
    {
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
    }
}
```
## Поиск блока catch при обработке исключений
 
Если код, который вызывает исключение, не размещен в блоке try или помещен в конструкцию try..catch, которая не содержит соответствующего блока catch для обработки возникшего исключения, то система производит поиск соответствующего обработчика исключения в стеке вызовов.

```cs
using System;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
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
```
В данном случае стек вызовов выглядит следующим образом: метод Main вызывает метод Method1, который, в свою очередь, вызывает метод Method2. И в методе Method2 генерируется исключение DivideByZeroException. Визуально стек вызовов можно представить следующим образом:

## Поиск блока catch при обработке исключения в C#
Внизу стека метод Main, с которого началось выполнение, и на самом верху метод Method2.

Что будет происходить в данном случае при генерации исключения?

Метод Main вызывает метод Method1, а тот вызывает метод Method2, в котором генерируется исключение DivideByZeroException.

Система видит, что код, который вызывал исключение, помещен в конструкцию try..catch
```cs
try
{
    int x = 8;
    int y = x / 0;
}
finally
{
    Console.WriteLine("Блок finally в Method2");
}
```
Система ищет в этой конструкции блок catch, который обрабатывает исключение DivideByZeroException. Однако такого блока catch нет.

Система опускается в стеке вызовов в метод Method1, который вызывал Method2. Здесь вызов Method2 помещен в конструкцию try..catch
```cs
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
```
Система также ищет в этой конструкции блок catch, который обрабатывает исключение DivideByZeroException. Однако здесь также подобный блок catch отсутствует.

Система далее опускается в стеке вызовов в метод Main, который вызывал Method1. Здесь вызов Method1 помещен в конструкцию try..catch
```cs
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
```
Система снова ищет в этой конструкции блок catch, который обрабатывает исключение DivideByZeroException. И в данном случае ткой блок найден.

Система наконец нашла нужный блок catch в методе Main, для обработки исключения, которое возникло в методе Method2 - то есть к начальному методу, где непосредственно возникло исключение. Но пока данный блок catch НЕ выполняется. Система поднимается обратно по стеку вызовов в самый верх в метод Method2 и выполняет в нем блок finally:
```cs
finally
{
    Console.WriteLine("Блок finally в Method2");
}
// Далее система возвращается по стеку вызовов вниз в метод Method1 и выполняет в нем блок finally:

finally
{
    Console.WriteLine("Блок finally в Method1");
}
```
Затем система переходит по стеку вызовов вниз в метод Main и выполняет в нем найденный блок catch и последующий блок finally:
```cs
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Catch в Main : {ex.Message}");
}
finally
{
    Console.WriteLine("Блок finally в Main");
}
```

Далее выполняется код, который идет в методе Main после конструкции try..catch:
```cs
Console.WriteLine("Конец метода Main");
```
код, который идет после конструкции try...catch в методах Method1 и Method2, не выполняется, потому что обработчик исключения найден именно в методе Main.

## Генерация исключения и оператор throw
 
Обычно система сама генерирует исключения при определенных ситуациях, например, при делении числа на ноль. Но язык C# также позволяет генерировать исключения вручную с помощью оператора throw. То есть с помощью этого оператора мы сами можем создать исключение и вызвать его в процессе выполнения.

Например, в нашей программе происходит ввод строки, и мы хотим, чтобы, если длина строки будет больше 6 символов, возникало исключение:
```cs
static void Main(string[] args)
{
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
```
После оператора throw указывается объект исключения, через конструктор которого мы можем передать сообщение об ошибке. вместо типа Exception мы можем использовать объект любого другого типа исключений.

Затем в блоке catch сгенерированное нами исключение будет обработано.

Подобным образом мы можем генерировать исключения в любом месте программы. Но существует также и другая форма использования оператора throw, когда после данного оператора не указывается объект исключения. В подобном виде оператор throw может использоваться только в блоке catch:
```cs
try
{
    try
    {
        Console.Write("Введите строку: ");
        string message = Console.ReadLine();
        if (message.Length > 6)
        {
            throw new Exception("Длина строки больше 6 символов");
        }
    }
    catch
    {
        Console.WriteLine("Возникло исключение");
        throw;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```
В данном случае при вводе строки с длиной больше 6 символов возникнет исключение, которое будет обработано внутренним блоком catch. 
поскольку в этом блоке используется оператор throw, то исключение будет передано дальше внешнему блоку catch.

## Обработка исключений в С++
Обработка исключений (exception handling) позволяет упорядочить обработку ошибок времени исполнения. Используя обработку исключений С++, программа может автоматически вызвать функцию-обработчик ошибок тогда, когда такая ошибка возникает. Принципиальным достоинством обработки исключений служит то, что она позволяет автоматизировать большую часть кода для обработки ошибок, для чего раньше требовалось ручное кодирование.

Обработка исключений в С++ использует три ключевых слова: try, catch и throw. Те инструкции программы, где ожидается возможность появления исключительных ситуаций, содержатся в блоке try. Если в блоке try возникает исключение, т. е. ошибка, то генерируется исключение. Исключение перехватывается, используя catch, и обрабатывается. 

Инструкция, генерирующая исключение, должна исполняться внутри блока try. Вызванные из блока try функции также могут генерировать исключения. Всякое исключение должно быть перехвачено инструкцией catch, которая непосредственно следует за инструкцией try, сгенерировавшей исключение. 

Общая форма блоков try и catch:
```c
try {
    // блок try
catch (тип1 аргумент) {
    // блок catch
catch (тип2 аргумент) {
    // блок catch
catch (типЗ аргумент) {
    // блок catch
}
...
catch (типN аргумент) {
    // блок catch
}

```
Размеры блока try могут изменяться в больших пределах. Например, блок try может содержать несколько инструкций какой-либо функции, либо же, напротив, включать в себя весь код функции main(), так что вся программа будет охвачена обработкой исключений.

Когда исключение сгенерировано, оно перехватывается соответствующей инструкцией catch, обрабатывающей это исключение. Одному блоку try может отвечать несколько инструкций catch, Какая именно инструкция catch исполняется, зависит от типа исключения. Это означает, что если тип данных, указанных в инструкции catch, соответствует типу данных исключения, то только эта инструкция catch и будет исполнена. Когда исключение перехвачено, arg получает ее значение. Перехваченным может быть любой тип данных, включая созданные программистом классы. Если никакого исключения не сгенерировано, то есть никакой ошибки не возникло в блоке try, то инструкции catch выполняться не будут.

Общая форма записи инструкции throw имеет вид:
```c
throw исключение;
```
Инструкция throw должна выполняться либо внутри блока try, либо в функции, вызванной из блока try. В записанном выше выражении исключение обозначает сгенерированное значение.

Если генерируется исключение, для которого отсутствует подходящая инструкция catch, может произойти аварийное завершение программы. При генерации необработанного исключения
вызывается функция terminate(). По умолчанию terminate() вызывает функцию abort(), завершающую выполнение программы. Однако можно задать свою собственную обработку, используя функцию set_terminate(). 

## способ обработки исключений в С++:
```c

// пример обработки простого исключения
#include <iostream.h>

int main()
{
    cout << "Start\n";
    try { // начало блока try
        cout << "Inside try block\n";
        throw 100; // генерация ошибки
        cout << "This will not execute";
    }
    catch (int i) { // перехват ошибки
        cout << "Caught an exception -- value is: ";
        cout << i << " \n";
    }
    cout << "End";
    return 0;
}
```
Как можно видеть, блок try содержит три инструкции. За ним следует инструкция catch(int i), обрабатывающая исключения целого типа. В блоке try будут выполняться только две инструкции: первая и вторая — throw. Как только исключение было сгенерировано, управление передается инструкции catch, а блок try прекращает свое исполнение. Таким образом, catch не вызывается. Скорее можно сказать, что к ней переходит исполнение программы. Для этого автоматически осуществляется переустановка стека. Таким образом, инструкция после инструкции throw никогда не выполняется.

Обычно код в инструкции catch пытается исправить ошибку путем выполнения подходящих действий. Если ошибку удалось исправить, то выполнение продолжается с инструкции, непосредственно следующей за catch. Однако иногда не удается справиться с ошибкой, и блок catch завершает программу путем вызова функции exit() или функции abort().

тип исключения должен соответствовать указанному в инструкции типу. Напри­мер, в предыдущем примере если изменить тип инструкции catch на double, то исключение не будет перехвачено и произойдет аварийное завершение программы:
```c

// данный пример не будет работать
#include <iostream.h>

int main()
{
    cout << "Start\n";
    try { // начало блока try
        cout << "Inside try block\n";
        throw 100; // генерация ошибки
        cout << "This will not execute";
    }
        catch (double i) { // не будет работать для целочисленного исключения
        cout << "Caught an exception -- value is: ";
        cout << i << "\n";
    }
    cout << "End";
    
    return 0;
    // Эта программа выдаст следующий результат, поскольку исключение целого типа не будет перехвачено инструкцией catch (double i):

}
```

Исключение может также быть сгенерировано из функции, вызванной изнутри блока try. В качестве примера рассмотрим следующую программу:
```c
/* генерация исключения из функции, находящейся вне блока try */

#include <iostream.h>

void Xtest(int test)
{
    cout << "Inside Xtest, test is: " << test << "\n";
    if (test) throw test;
}

int main()
{
    cout << "Start\n";
    try { // начало блока try
        cout << "Inside try block\n";
        Xtest (0);
        Xtest (1);
        Xtest (2);
    }
    catch (int i) { // перехват ошибки
        cout << "Caught an exception -- value is: ";
        cout << i << "\n";
    }

    cout << "End";
    
    return 0;
}
```
Блок try может быть локализован в какой-то функции. В таком случае всякий раз при входе в функцию начинается обработка исключений:
```c
#include <iostream.h>

// try/catch могут находиться в функции вне main()
void Xhandler(int test)
{
    try {
    if (test) throw test;
    }

    catch(int i) {
        cout << "Caught Exception #: " << i << '\n';
    }
}

int main()
{
    cout << "Start\n";
    
    Xhandler(1);
    Xhandler(2);
    Xhandler(0);
    Xhandler(3);

    cout << "End";
    
    return 0;

// Как видно, сгенерировано три исключения. После каждого исключения функция возвращает управление в функцию main. При каждом новом вызове функции возвращается обработка исключений.

}
```
код, ассоциированный с инструкцией catch, будет исполняться только тогда, когда перехвачено исключение. В противном случае выполнение программы просто обойдет инструкцию catch.
