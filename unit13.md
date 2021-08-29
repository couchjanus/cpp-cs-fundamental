## Индексаторы
 
Индексаторы позволяют индексировать объекты и обращаться к данным по индексу. с помощью индексаторов мы можем работать с объектами как с массивами. 
По форме они напоминают свойства со стандартными блоками get и set, которые возвращают и присваивают значение:
```cs
возвращаемый_тип this [Тип параметр1, ...]
{
    get { ... }
    set { ... }
}

```
В отличие от свойств индексатор не имеет названия. Вместо него указывается ключевое слово this, после которого в квадратных скобках идут параметры. Индексатор должен иметь как минимум один параметр.
```cs

есть класс Person, который представляет человека, и класс People, который представляет группу людей. Используем индексаторы для определения класса People:

class Person
{
    public string Name { get; set; }
}
class People
{

    Person[] data;
    public People()
    {
        data = new Person[5];
    }
    
    // Конструкция public Person this[int index] представляет индексатор. 
    // Здесь определяем тип возвращаемого или присваиваемого объекта, то есть тип Person. 
    // определяем через параметр int index способ доступа к элементам.
    
    public Person this[int index]
    {
        // все объекты Person хранятся в классе в массиве data. 
        // Для получения их по индексу в индексаторе определен блок get:
        get
        {
            // Поскольку индексатор имеет тип Person, то в блоке get нам надо возвратить объект этого типа с помощью оператора return. 
            return data[index];
            // Здесь мы можем определить разнообразную логику. В данном случае просто возвращаем объект из массива data.
        }
        // В блоке set получаем через параметр value переданный объект Person и сохраняем его в массив по индексу.
        set
        {
            data[index] = value;
        }
    }
}


// После этого мы можем работать с объектом People как с набором объектов Person:

class Program
    {
    static void Main(string[] args)
    {
        People people = new People();
        people[0] = new Person { Name = "Tom" };
        people[1] = new Person { Name = "Bob" };
 
        Person tom = people[0];
        Console.WriteLine(tom?.Name);
 
        Console.ReadKey();
    }
}

```

Индексатор получает набор индексов в виде параметров. 
## Индексы необязательно должны представлять тип int. 

```cs

// мы можем рассматривать объект как хранилище свойств и передавать имя атрибута объекта в виде строки:

class User
{
    string name;
    string email;
    string phone;
 
    public string this[string propname]
    {
        get
        {
            switch (propname)
            {
                case "name": return "Mr/Ms. " + name;
                case "email": return email;
                case "phone": return phone;
                default: return null;
            }
        }
        set
        {
            switch (propname)
            {
                case "name":
                    name = value;
                    break;
                case "email":
                    email = value;
                    break;
                case "phone":
                    phone = value;
                    break;
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        User janus = new User();
        janus["name"] = "Janus";
        janus["email"] = "couchjanus@gmail.com";
 
        Console.WriteLine(janus["name"]); // Mr/Ms. Janus
 
        Console.ReadKey();
    }
}

```
## Применение нескольких параметров
```cs

// индексатор может принимать несколько параметров. 
// Допустим, у нас есть класс, в котором хранилище определено в виде двухмерного массива или матрицы:

class Matrix
{
    private int[,] numbers = new int[,] { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
    // для определения индексатора используются два индекса - i и j. 
    public int this[int i, int j]
    {
        get
        {
            return numbers[i,j];
        }
        set
        {
            numbers[i, j] = value;
        }
    }
}


// в программе мы должны обращаться к объекту, используя два индекса:

Matrix matrix = new Matrix();
Console.WriteLine(matrix[0, 0]);
matrix[0, 0] = 111;
Console.WriteLine(matrix[0, 0]);

// индексатор не может быть статическим и применяется только к экземпляру класса. 
// индексаторы могут быть виртуальными и абстрактными и могут переопределяться в произодных классах.

```
## Блоки get и set
Как и в свойствах, в индексаторах можно опускать блок get или set, если в них нет необходимости. 
```cs
// Например, удалим блок set и сделаем индексатор доступным только для чтения:
class Matrix
{
    private int[,] numbers = new int[,] { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
    public int this[int i, int j]
    {
        get
        {
            return numbers[i,j];
        }
    }
}

// Также мы можем ограничивать доступ к блокам get и set, используя модификаторы доступа. Например, сделаем блок set приватным:

class Matrix
{
    private int[,] numbers = new int[,] { { 1, 2, 4}, { 2, 3, 6 }, { 3, 4, 8 } };
    public int this[int i, int j]
    {
        get
        {
            return numbers[i,j];
        }
        private set
        {
            numbers[i, j] = value;
        }
    }
}

```
## Перегрузка индексаторов

Подобно методам индексаторы можно перегружать. В этом случае также индексаторы должны отличаться по количеству, типу или порядку используемых параметров:
```cs

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
class People
{
    Person[] data;
    // класс People содержит две версии индексатора. 
    // Первая версия получает и устанавливает объект Person по индексу
    public People()
    {
        data = new Person[5];
    }
    // вторая - только получае объект Person по его имени.
    public Person this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index] = value;
        }
    }

    public Person this[string name]
    {
        get
        {
            Person person = null;
            foreach(var p in data)
            {
                if(p?.Name == name)
                {
                    person = p;
                    break;
                }
            }
            return person;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        People people = new People();
        people[0] = new Person { Name = "Tom" };
        people[1] = new Person { Name = "Bob" };
             
        Console.WriteLine(people[0].Name);      // Tom
        Console.WriteLine(people["Bob"].Name);  // Bob
 
        Console.ReadKey();
    }
}

```

## Наследование
 
Наследование (inheritance) является одним из ключевых моментов ООП. Благодаря наследованию один класс может унаследовать функциональность другого класса.
```cs
class Person
{
    private string _name;
 
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    // наследник от класса Person - класс Employee будет реализовывать тот же функционал, 
    // что и класс Person, который называется базовым классом или родителем (или суперклассом)

    // После двоеточия мы указываем базовый класс для данного класса. 
    // Для класса Employee базовым является Person, 
    // поэтому класс Employee наследует все те же свойства, методы, поля, которые есть в классе Person. 
    // Единственное, что не передается при наследовании, это конструкторы базового класса.
     
}

class Program
{
    // наследование реализует отношение is-a (является), 
    // объект класса Employee также является объектом класса Person:

    static void Main(string[] args)
    {
        Person p = new Person { Name = "Tom"};
        p.Display();

        // поскольку объект Employee является также и объектом Person, 
        // то мы можем так определить переменную: Person p = new Employee().
        
        p = new Employee { Name = "Sam" };
        p.Display();

        Console.Read();
    }
}
```

По умолчанию все классы наследуются от базового класса Object, даже если мы явным образом не устанавливаем наследование. Поэтому классы Person и Employee кроме своих собственных методов, также будут иметь и методы класса Object: ToString(), Equals(), GetHashCode() и GetType().

Все классы по умолчанию могут наследоваться, но есть ряд ограничений:
- Не поддерживается множественное наследование, класс может наследоваться только от одного класса.
- При создании производного класса надо учитывать тип доступа к базовому классу - тип доступа к производному классу должен быть таким же, как и у базового класса, или более строгим. То есть, если базовый класс имеет тип доступа internal, то производный класс может иметь тип доступа internal или private, но не public.
- если базовый и производный класс находятся в разных сборках, то в этом случае производый класс может наследовать только от класса, который имеет модификатор public.

## модификатор sealed
Если класс объявлен с модификатором sealed, то от этого класса нельзя наследовать и создавать производные классы. Например, следующий класс не допускает создание наследников:
```cs

sealed class Admin
{
}

```
## Нельзя унаследовать класс от статического класса.

## Доступ к членам базового класса из класса-наследника
```cs

// Этот код не сработает и выдаст ошибку, так как переменная _name объявлена с модификатором private и поэтому к ней доступ имеет только класс Person. 
class Employee : Person
{
    public void Display()
    {
        Console.WriteLine(_name);
    }
}


// в классе Person определено общедоступное свойство Name, которое мы можем использовать, поэтому следующий код будет работать:

class Employee : Person
{
    public void Display()
    {
        Console.WriteLine(Name);
    }
}

```
производный класс может иметь доступ только к тем членам базового класса, которые определены с модификаторами private protected (если базовый и производный класс находятся в одной сборке), public, internal (если базовый и производный класс находятся в одной сборке), protected и protected internal.

## Ключевое слово base
```cs
using System;

namespace cs
{

// добавим в наши классы конструкторы:

class Person
{
    public string Name { get;  set; }
    
    // Класс Person имеет конструктор, который устанавливает свойство Name. 
    public Person(string name)
    {
        Name = name;
    }
 
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
 
class Employee : Person
{
    public string Company { get; set; }
    

    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }
}



    class Program
    {
        // С помощью ключевого слова base мы можем обратиться к базовому классу. 
        // В нашем случае в конструкторе класса Employee нам надо установить имя и компанию. 
        // Но имя мы передаем на установку в конструктор базового класса, 
        // то есть в конструктор класса Person, с помощью выражения base(name).
        static void Main(string[] args)
        {
            Person p = new Person("Bill");
            p.Display();
            Employee emp = new Employee ("Tom", "Microsoft");
            emp.Display();
            Console.Read();

        }

    }
}
```

## Конструкторы в производных классах

Конструкторы не передаются производному классу при наследовании. если в базовом классе не определен конструктор по умолчанию без параметров, а только конструкторы с параметрами, то в производном классе мы обязательно должны вызвать один из этих конструкторов через ключевое слово base. Например, из класса Employee уберем определение конструктора:
```cs

// В данном случае мы получим ошибку, так как класс Employee не соответствует классу Person, а именно не вызывает конструктор базового класса. 
class Employee : Person
{
    public string Company { get; set; }
}

// Даже если бы мы добавили какой-нибудь конструктор, который бы устанавливал все те же свойства, то мы все равно бы получили ошибку:

public Employee(string name, string company)
{
    Name = name;
    Company = company;
}

// в классе Employee через ключевое слово base надо явным образом вызвать конструктор класса Person:

public Employee(string name, string company)
        : base(name)
{
    Company = company;
}

```

в качестве альтернативы мы могли бы определить в базовом классе конструктор без параметров:

```cs
using System;

namespace cs
{

    class Person
    {
        public string Name { get;  set; }

        // в качестве альтернативы мы могли бы определить в базовом классе конструктор без параметров:
        // конструктор по умолчанию
        public Person()
        {
            Name = "Tom";
            Console.WriteLine("Вызов конструктора без параметров");
        }
        
        // Класс Person имеет конструктор, который устанавливает свойство Name. 
        public Person(string name)
        {
            Name = name;
        }
     
        public void Display()
        {
            Console.WriteLine(Name);
        }

    }

    class Employee : Person
    {
    
        public string Company { get; set; }
        
        // Тогда в любом конструкторе производного класса, где нет обращения конструктору базового класса, 
        // все равно неявно вызывался бы этот конструктор по умолчанию. 

        // Например, следующий конструктор

        public Employee(string company)
        {
            Company = company;
        }

        // был бы эквивалентен следующему конструктору:

        // public Employee(string company)
        //     :base()
        // {
        //     Company = company;
        // }
 
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Employee emp = new Employee ("Microsoft");
            emp.Display();
            Console.Read();

        }

    }
}
```
## Порядок вызова конструкторов
При вызове конструктора класса сначала отрабатывают конструкторы базовых классов и только затем конструкторы производных:

```cs
using System;

namespace cs
{

class Person
{
    string name;
    int age;
 
    public Person(string name)
    {
        this.name = name;
        Console.WriteLine("Person(string name)");
    }
    
    public Person(string name, int age) : this(name)
    {
        this.age = age;
        Console.WriteLine("Person(string name, int age)");
    }
}
class Employee : Person
{
    string company;
 
    public Employee(string name, int age, string company) : base(name, age)
    {
        this.company = company;
        Console.WriteLine("Employee(string name, int age, string company)");
    }
}


    class Program
    {
        // создание объекта Employee:
        static void Main(string[] args)
        {
            Employee tom = new Employee("Tom", 22, "Microsoft");
    
        }

    }
}
```
В итоге мы получаем следующую цепь выполнений.
- Вначале вызывается конструктор Employee(string name, int age, string company). Он делегирует выполнение конструктору Person(string name, int age)
- Вызывается конструктор Person(string name, int age), который сам пока не выполняется и передает выполнение конструктору Person(string name)
- Вызывается конструктор Person(string name), который передает выполнение конструктору класса System.Object, так как это базовый по умолчанию класс для Person.
- Выполняется конструктор System.Object.Object(), затем выполнение возвращается конструктору Person(string name)
- Выполняется тело конструктора Person(string name), затем выполнение возвращается конструктору Person(string name, int age)
- Выполняется тело конструктора Person(string name, int age), затем выполнение возвращается конструктору Employee(string name, int age, string company)
- Выполняется тело конструктора Employee(string name, int age, string company). В итоге создается объект Employee

## Преобразование типов
```cs

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Display()
    {
        Console.WriteLine($"Person {Name}");
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
 
class Client : Person
{
    public string Bank { get; set; }
    public Client(string name, string bank) : base(name)
    {
        Bank = bank;
    }
}

```
## Восходящие преобразования. Upcasting

В иерархии наследования классов мы можем проследить следующую цепь наследования: Object (все классы неявно наследуются от типа Object) -> Person -> Employee|Client.
В иерархии классов базовые типы находятся вверху, а производные типы - внизу.

Объекты производного типа (который находится внизу иерархии) в то же время представляют и базовый тип. Например, объект Employee в то же время является и объектом класса Person. Что в принципе естественно, так как каждый сотрудник (Employee) является человеком (Person). И мы можем написать, например, следующим образом:
```cs

static void Main(string[] args)
{
    Employee employee = new Employee("Tom", "Microsoft");
    Person person = employee;   // преобразование от Employee к Person
 
    Console.WriteLine(person.Name);
    Console.ReadKey();
}

```
В данном случае переменной person, которая представляет тип Person, присваивается ссылка на объект Employee. Но чтобы сохранить ссылку на объект одного класса в переменную другого класса, необходимо выполнить преобразование типов - в данном случае от типа Employee к типу Person. И так как Employee наследуется от класса Person, то автоматически выполняется неявное восходящее преобразование - преобразование к типу, которые находятся вверху иерархии классов, то есть к базовому классу.

В итоге переменные employee и person будут указывать на один и тот же объект в памяти, но переменной person будет доступна только та часть, которая представляет функционал типа Person.

Подобным образом поизводятся и другие восходящие преобразования:
```cs

Person person2 = new Client("Bob", "ContosoBank");   // преобразование от Client к Person

```
Здесь переменная person2, которая представляет тип Person, хранит ссылку на объект Client, поэтому также выполняется восходящее неявное преобразование от производного класса Client к базовому типу Person.

Восходящее неявное преобразование будет происходить и в следующем случае:
```cs

object person1 = new Employee("Tom", "Microsoft");  // от Employee к object
object person2 = new Client("Bob", "ContosoBank");  // от Client к object
object person3 = new Person("Sam");                 // от Person к object

```
Так как тип object - базовый для всех остальных типов, то преобразование к нему будет производиться автоматически.

## Нисходящие преобразования. Downcasting - от базового типа к производному. 

в следующем коде переменная person хранит ссылку на объект Employee:
```cs

Employee employee = new Employee("Tom", "Microsoft");
Person person = employee;   // преобразование от Employee к Person

```
автоматически такие преобразования не проходят, ведь не каждый человек (объект Person) является сотрудником предприятия (объектом Employee). 
для нисходящего преобразования необходимо применить явное преобразования, указав в скобках тип, к которому нужно выполнить преобразование:
```cs

Employee employee = new Employee("Tom", "Microsoft");
Person person = employee;   // преобразование от Employee к Person
 
//Employee employee2 = person;    // так нельзя, нужно явное преобразование
Employee employee2 = (Employee)person;  // преобразование от Person к Employee

```
### примеры преобразований:
```cs

// Объект Employee также представляет тип object
object obj = new Employee("Bill", "Microsoft");
 
// чтобы обратиться к возможностям типа Employee, приводим объект к типу Employee
Employee emp = (Employee) obj;
 
// объект Client также представляет тип Person
Person person = new Client("Sam", "ContosoBank");
// преобразование от типа Person к Client
Client client = (Client)person;
// В первом случае переменной obj присвоена ссылка на объект Employee, поэтому мы можем преобразовать объект obj к любому типу который располагается в иерархии классов между типом object и Employee.

// Если нам надо обратиться к каким-то отдельным свойствам или методам объекта, то нам необязательно присваивать преобразованный объект переменной :

// Объект Employee также представляет тип object
object obj = new Employee("Bill", "Microsoft");
 
// преобразование к типу Person для вызова метода Display
((Person)obj).Display();
// либо так
// ((Employee)obj).Display();
 
// преобразование к типу Employee, чтобы получить свойство Company
string comp = ((Employee)obj).Company;

// необходимо соблюдать осторожность при подобных преобразованиях. Например, что будет в следующем случае:

// Объект Employee также представляет тип object
object obj = new Employee("Bill", "Microsoft");
 
// преобразование к типу Client, чтобы получить свойство Bank
string bank = ((Client)obj).Bank;

// В данном случае мы получим ошибку, так как переменная obj хранит ссылку на объект Employee. Данный объект является также объектом типов object и Person, поэтому мы можем преобразовать его к этим типам. Но к типу Client мы преобразовать не можем.


// В данном случае мы пытаемся преобразовать объект типа Person к типу Employee, а объект Person не является объектом Employee.

Employee emp = new Person("Tom");   // ! Ошибка
 
Person person = new Person("Bob");
Employee emp2 = (Employee) person;  // ! Ошибка

```
## Способы преобразований

можно использовать ключевое слово as. С помощью него программа пытается преобразовать выражение к определенному типу, при этом не выбрасывает исключение. В случае неудачного преобразования выражение будет содержать значение null:
```cs

Person person = new Person("Tom");
Employee emp = person as Employee;
if (emp == null)
{
    Console.WriteLine("Преобразование прошло неудачно");
}
else
{
    Console.WriteLine(emp.Company);
}
// Второй способ заключается в отлавливании исключения InvalidCastException, которое возникнет в результате преобразования:

Person person = new Person("Tom");
try
{
    Employee emp = (Employee)person;
    Console.WriteLine(emp.Company);
}
catch (InvalidCastException ex)
{
    Console.WriteLine(ex.Message);
}
// Третий способ заключается в проверке допустимости преобразования с помощью ключевого слова is:

Person person = new Person("Tom");
if(person is Employee)
{
    Employee emp = (Employee)person;
    Console.WriteLine(emp.Company);
}
else
{
    Console.WriteLine("Преобразование не допустимо");
}
// Выражение person is Employee проверяет, является ли переменная person объектом типа Employee. 
// в данном случае такая проверка вернет значение false, и преобразование не сработает.

```
## Перегрузка операций преобразования типов
 
в классе определяется метод:
```cs

public static implicit|explicit operator Тип_в_который_надо_преобразовать(исходный_тип param)
{
    // логика преобразования
}

```
После модификаторов public static идет ключевое слово explicit (если преобразование явное, то есть нужна операция приведения типов) или implicit (если преобразование неявное). Затем идет ключевое слово operator и далее возвращаемый тип, в который надо преобразовать объект. В скобках в качестве параметра передается объект, который надо преобразовать.

класс Counter, который представляет счетчик-секундомер и хранит количество секунд в свойстве Seconds:
```cs

class Counter
{
    public int Seconds { get; set; }

    // Первый оператор преобразует число - объект типа int к типу Counter. Его логика проста - создается новый объект Counter, у которого устанавливается свойство Seconds.
    public static implicit operator Counter(int x)
    {
        return new Counter { Seconds = x };
    }
    // Второй оператор преобразует объект Counter к типу int, то есть получает из Counter число.
    public static explicit operator int(Counter counter)
    {
        return counter.Seconds;
    }
}


static void Main(string[] args)
{
    Counter counter1 = new Counter { Seconds = 23 };

    // Поскольку операция преобразования из Counter в int определена с ключевым словом explicit, то есть как явное преобразование, то в этом случае необходимо применить операцию приведения типов:
    int x = (int)counter1;
    Console.WriteLine(x);   // 23

    // В случае с операцией преобразования от int к Counter ничего подобного делать не надо, поскольку данная операция определена с ключевым словом implicit, то есть как неявная. 

    Counter counter2 = x;
    Console.WriteLine(counter2.Seconds);  // 23
}

// оператор преобразования типов должен преобразовывать из типа или в тип, в котором этот оператор определен. То есть оператор преобразования, определенный в типе Counter, должен либо принимать в качестве параметра объект типа Counter, либо возвращать объект типа Counter.

```


## преобразования из одного составного типа в другой составной тип. 

```cs

// Класс Timer представляет условный таймер, который хранит часы, минуты и секунды. Класс Counter представляет условный счетчик-секундомер, который хранит количество секунд. Исходя из этого мы можем определить некоторую логику преобразования из одного типа к другому, то есть получение из секунд в объекте Counter часов, минут и секунд в объекте Timer. Например, 3675 секунд по сути это 1 час, 1 минута и 15 секунд

class Timer
{
    public int Hours { get; set; }
    public int Minutes { get; set; }    
    public int Seconds { get; set; }
}
class Counter
{
    public int Seconds { get; set; }
 
    public static implicit operator Counter(int x)
    {
        return new Counter { Seconds = x };
    }
    public static explicit operator int(Counter counter)
    {
        return counter.Seconds;
    }
    public static explicit operator Counter(Timer timer)
    {
        int h = timer.Hours * 3600;
        int m = timer.Minutes * 60;
        return new Counter { Seconds = h + m + timer.Seconds };
    }
    public static implicit operator Timer(Counter counter)
    {
        int h = counter.Seconds / 3600;
        int m = (counter.Seconds % 3600) / 60;
        int s = counter.Seconds % 60;
        return new Timer { Hours = h, Minutes = m, Seconds = s };
    }
}

static void Main(string[] args)
{
    Counter counter1 = new Counter { Seconds = 115 };
 
    Timer timer = counter1;
    Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); // 0:1:55
 
    Counter counter2 = (Counter)timer;
    Console.WriteLine(counter2.Seconds);  //115
     
    Console.ReadKey();
}

```
## Виртуальные методы и свойства
 
При наследовании нередко возникает необходимость изменить в классе-наследнике функционал метода, который был унаследован от базового класса. В этом случае класс-наследник может переопределять методы и свойства базового класса.

Те методы и свойства, которые мы хотим сделать доступными для переопределения, в базовом классе помечается модификатором virtual. Такие методы и свойства называют виртуальными.

чтобы переопределить метод в классе-наследнике, этот метод определяется с модификатором override. Переопределенный метод в классе-наследнике должен иметь тот же набор параметров, что и виртуальный метод в базовом классе.

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


// Чтобы сделать метод Display доступным для переопределения, этот метод определен с модификатором virtual. Поэтому мы можем переопределить этот метод, но можем и не переопределять. Допустим, нас устраивает реализация метода из базового класса. В этом случае объекты Employee будут использовать реализацию метода Display из класса Person:

static void Main(string[] args)
{
    Person p1 = new Person("Bill");
    p1.Display(); // вызов метода Display из класса Person
 
    Employee p2 = new Employee("Tom", "Microsoft");
    p2.Display(); // вызов метода Display из класса Person
 
    Console.ReadKey();
}


```
также можем переопределить виртуальный метод. Для этого в классе-наследнике определяется метод с модификатором override, который имеет то же самое имя и набор параметров:
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


static void Main(string[] args)
{
    Person p1 = new Person("Bill");
    p1.Display(); // вызов метода Display из класса Person
 
    Employee p2 = new Employee("Tom", "Microsoft");
    p2.Display(); // вызов метода Display из класса Employee
 
    Console.ReadKey();
}

```
Виртуальные методы базового класса определяют интерфейс всей иерархии, то есть в любом производном классе, который не является прямым наследником от базового класса, можно переопределить виртуальные методы. Например, мы можем определить класс Manager, который будет производным от Employee, и в нем также переопределить метод Display.

При переопределении виртуальных методов следует учитывать ряд ограничений:
- Виртуальный и переопределенный методы должны иметь один и тот же модификатор доступа. То есть если виртуальный метод определен с помощью модификатора public, то и переопредленный метод также должен иметь модификатор public.
- Нельзя переопределить или объявить виртуальным статический метод.

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

## Скрытие
 
Другим способом изменить функциональность метода, унаследованного от базового класса, является скрытие (shadowing / hiding).

Фактически скрытие представляет определение в классе-наследнике метода или свойства, которые соответствует по имени и набору параметров методу или свойству базового класса. Для скрытия членов класса применяется ключевое слово new:
```cs

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
 
    public void Display()
    {
        Console.WriteLine($"{FirstName} {LastName}");
    }
}
 
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string firstName, string lastName, string company)
            : base(firstName, lastName)
    {
        Company = company;
    }
    // в классе Employee кроме унаследованных свойств есть также и собственное свойство Company, которое хранит название компании. И мы хотели бы в методе Display выводить информацию о компании вместе с именем и фамилией на консоль. Для этого определяется метод Display с ключевым словом new, который скрывает реализацию данного метода из базового класса.
    public new void Display()
    {
        Console.WriteLine($"{FirstName} {LastName} работает в {Company}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person bob = new Person("Bob", "Robertson");
        bob.Display();      // Bob Robertson
 
        Employee tom = new Employee("Tom", "Smith", "Microsoft");
        tom.Display();      // Tom Smith работает в Microsoft
 
        Console.ReadKey();
    }
}

```

Подобным обазом мы можем организовать сокрытие свойств:
```cs

class Person
{
    protected string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
class Employee : Person
{
    public new string Name
    {
        get { return "Employee " + base.Name; }
        set { name = value; }
    }
}

```
При этом если мы хотим обратиться именно к реализации свойства или метода в базовом классе, то опять же мы можем использовать ключевое слово base и через него обращаться к функциональности базового класса.

Более того мы даже можем применять сокрытие к переменным и константам, также используя ключевое слово new:
```cs

class ExampleBase
{
    public readonly int x = 10;
    public const int G = 5;
}
class ExampleDerived : ExampleBase
{
    public new readonly int x = 20;
    public new const int G = 15;
}

```
## Переопределение методов:
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
// создадим объект Employee и передадим его переменной типа Person:

Person tom = new Employee("Tom", "Microsoft");
// при вызове tom.Display() выполняется реализация метода Display из класса Employee.
tom.Display();      // Tom работает в Microsoft

```
Для работы с виртуальными методами компилятор формирует таблицу виртуальных методов (Virtual Method Table или VMT). В нее записывается адреса виртуальных методов. Для каждого класса создается своя таблица.

Когда создается объект класса, то компилятор передает в конструктор объекта специальный код, который связывает объект и таблицу VMT.

при вызове виртуального метода из объекта берется адрес его таблицы VMT. Затем из VMT извлекается адрес метода и ему передается управление. То есть процесс выбора реализации метода производится во время выполнения программы. Собственно так и выполняется виртуальный метод. 

## Скрытие
```cs

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
 
    public void Display()
    {
        Console.WriteLine(Name);
    }
}
 
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
            : base(name)
    {
        Company = company;
    }
    public new void Display()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}
// Переменная tom представляет тип Person, но хранит ссылку на объект Employee. 
// при вызове метода Display будет выполняться та версия метода, которая определена в классе Person, а не в классе Employee. 
// Класс Employee не переопределяет метод Display, унаследованный от базового класса, а  определяет новый метод. Поэтому при вызове tom.Display() вызывается метод Display из класса Person.

Person tom = new Employee("Tom", "Microsoft");
tom.Display();      // Tom

```
