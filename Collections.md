# Коллекции
 
Массив хранит фиксированное количество объектов, но мы заранее не знаем, сколько нам потребуется объектов. В этом случае удобнее применять коллекции. Коллекции реализует стандартные структуры данных, например, стек, очередь, словарь, которые могут пригодиться для решения различных специальных задач.

Большая часть классов коллекций содержится в пространствах имен System.Collections (простые необобщенные классы коллекций), System.Collections.Generic (обобщенные или типизированные классы коллекций) и System.Collections.Specialized (специальные классы коллекций). Также для обеспечения параллельного выполнения задач и многопоточного доступа применяются классы коллекций из пространства имен System.Collections.Concurrent

## Класс ArrayList
Класс ArrayList представляет коллекцию объектов. И если надо сохранить вместе разнотипные объекты - строки, числа и т.д., то данный класс как раз для этого подходит.

### Основные методы класса:
- int Add(object value): добавляет в список объект value
- void AddRange(ICollection col): добавляет в список объекты коллекции col, которая представляет интерфейс ICollection - интерфейс, реализуемый коллекциями.
- void Clear(): удаляет из списка все элементы
- bool Contains(object value): проверяет, содержится ли в списке объект value. Если содержится, возвращает true, иначе возвращает false
- void CopyTo(Array array): копирует текущий список в массив array.
- ArrayList GetRange(int index, int count): возвращает новый список ArrayList, который содержит count элементов текущего списка, начиная с индекса index
- int IndexOf(object value): возвращает индекс элемента value
- void Insert(int index, object value): вставляет в список по индексу index объект value
- void InsertRange(int index, ICollection col): вставляет в список начиная с индекса index коллекцию ICollection
- int LastIndexOf(object value): возвращает индекс последнего вхождения в списке объекта value
- void Remove(object value): удаляет из списка объект value
- void RemoveAt(int index): удаляет из списка элемент по индексу index
- void RemoveRange(int index, int count): удаляет из списка count элементов, начиная с индекса index
- void Reverse(): переворачивает список
- void SetRange(int index, ICollection col): копирует в список элементы коллекции col, начиная с индекса index
- void Sort(): сортирует коллекцию

С помощью свойства Count можно получить количество элементов в списке.

```cs

using System;
// так как класс ArrayList находится в пространстве имен System.Collections, то подключаем его.
using System.Collections;
 
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вначале создаем объект коллекции через конструктор как объект любого другого класса: 
            
            ArrayList list = new ArrayList();

            // При необходимости мы могли бы так же, как и с массивами, 
            // выполнить начальную инициализацию коллекции, 
            // например, ArrayList list = new ArrayList(){1, 2, 5, "string", 7.7};

            // Далее последовательно добавляем разные значения. 
            // Данный класс коллекции, как и большинство других коллекций, 
            // имеет два способа добавления: одиночного объекта через метод Add и набора объектов,
            // например, массива или другой коллекции через метод AddRange

            list.Add(2.3); // заносим в список объект типа double
            list.Add(55); // заносим в список объект типа int
            list.AddRange(new string[] { "Hello", "world" }); // заносим в список строковый массив
 
            // перебор значений
            // Через цикл foreach мы можем пройтись по всем объектам списка. И поскольку данная коллекция хранит разнородные объекты, а не только числа или строки, то в качестве типа перебираемых объектов выбран тип object: foreach (object o in list)

            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            
            // Многие коллекции, в том числе и ArrayList, реализуют удаление с помощью методов Remove/RemoveAt. В данном случае мы удаляем первый элемент, передавая в метод RemoveAt индекс удаляемого элемента.

            // удаляем первый элемент
            list.RemoveAt(0);
            // переворачиваем список
            list.Reverse();
            // получение элемента по индексу
            Console.WriteLine(list[0]);
            // перебор значений
            // выводим элементы коллекции на экран только уже через цикл for. 
            // В данном случае с перебором коллекций дело обстоит также, как и с массивами. 
            // число элементов коллекции мы можем получить через свойство Count

            for (int i = 0; i < list.Count; i++)
            {
                // С помощью индексатора мы можем получить по индексу элемент коллекции так же, как и в массивах: object firstObj = list[0];
                Console.WriteLine(list[i]);
            }
 
            Console.ReadLine();
        }
    }
}

```

## Список List<T>
 
Класс List<T> из пространства имен System.Collections.Generic представляет простейший список однотипных объектов.

### Основные методы класса:
- void Add(T item): добавление нового элемента в список
- void AddRange(ICollection collection): добавление в список коллекции или массива
- int BinarySearch(T item): бинарный поиск элемента в списке. Если элемент найден, то метод возвращает индекс этого элемента в коллекции. При этом список должен быть отсортирован.
- int IndexOf(T item): возвращает индекс первого вхождения элемента в списке
- void Insert(int index, T item): вставляет элемент item в списке на позицию index
- bool Remove(T item): удаляет элемент item из списка, и если удаление прошло успешно, то возвращает true
- void RemoveAt(int index): удаление элемента по указанному индексу index
- void Sort(): сортировка списка

### реализация списка:
```cs

using System;
using System.Collections.Generic;
 
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Здесь создаются два списка: один для объектов типа int, а другой - для объектов Person. 

            // В первом случае мы выполняем начальную инициализацию списка: List<int> numbers = new List<int>() { 1, 2, 3, 45 };

            List<int> numbers = new List<int>() { 1, 2, 3, 45 };
            numbers.Add(6); // добавление элемента
 
            numbers.AddRange(new int[] { 7, 8, 9 });
 
            numbers.Insert(0, 666); // вставляем на первое место в списке число 666
 
            numbers.RemoveAt(1); //  удаляем второй элемент
 
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            // Во втором случае мы используем другой конструктор, в который передаем начальную емкость списка: List<Person> people = new List<Person>(3);. 
            // Указание начальной емкости списка (capacity) позволяет в будущем увеличить производительность и уменьшить издержки на выделение памяти при добавлении элементов. 
            // Также начальную емкость можно установить с помощью свойства Capacity, которое имеется у класса List.

            List<Person> people = new List<Person>(3);
            people.Add(new Person() { Name = "Том" });
            people.Add(new Person() { Name = "Билл" });
 
            foreach (Person p in people)
            {
                Console.WriteLine(p.Name);
            }
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}

```

## Двухсвязный список LinkedList<T>
 
Класс LinkedList<T> представляет двухсвязный список, в котором каждый элемент хранит ссылку одновременно на следующий и на предыдущий элемент.

Если в простом списке List<T> каждый элемент представляет объект типа T, то в LinkedList<T> каждый узел представляет объект класса LinkedListNode<T>. 

### Этот класс имеет следующие свойства:
- Value: само значение узла, представленное типом T
- Next: ссылка на следующий элемент типа LinkedListNode<T> в списке. Если следующий элемент отсутствует, то имеет значение null
- Previous: ссылка на предыдущий элемент типа LinkedListNode<T> в списке. Если предыдущий элемент отсутствует, то имеет значение null

Используя методы класса LinkedList<T>, можно обращаться к различным элементам, как в конце, так и в начале списка:
- AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode): вставляет узел newNode в список после узла node.
- AddAfter(LinkedListNode<T> node, T value): вставляет в список новый узел со значением value после узла node.
- AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode): вставляет в список узел newNode перед узлом node.
- AddBefore(LinkedListNode<T> node, T value): вставляет в список новый узел со значением value перед узлом node.
- AddFirst(LinkedListNode<T> node): вставляет новый узел в начало списка
- AddFirst(T value): вставляет новый узел со значением value в начало списка
- AddLast(LinkedListNode<T> node): вставляет новый узел в конец списка
- AddLast(T value): вставляет новый узел со значением value в конец списка
- RemoveFirst(): удаляет первый узел из списка. После этого новым первым узлом становится узел, следующий за удаленным
- RemoveLast(): удаляет последний узел из списка

## двухсвязный список:
```cs
using System;
using System.Collections.Generic;
 
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаются два списка: для чисел и для объектов класса Person. 

            LinkedList<int> numbers = new LinkedList<int>();
 
            numbers.AddLast(1); // вставляем узел со значением 1 на последнее место
            // так как в списке нет узлов, то последнее будет также и первым
            numbers.AddFirst(2); // вставляем узел со значением 2 на первое место
            numbers.AddAfter(numbers.Last, 3); // вставляем после последнего узла новый узел со значением 3
            // теперь у нас список имеет следующую последовательность: 2, 1, 3
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            
            
            
            LinkedList<Person> persons = new LinkedList<Person>();
 
            // добавляем persona в список и получим объект LinkedListNode<Person>, в котором хранится имя Tom
            LinkedListNode<Person> tom = persons.AddLast(new Person() { Name = "Tom" });
            
            // Методы вставки (AddLast, AddFirst) при добавлении в список возвращают ссылку на добавленный элемент LinkedListNode<T> (LinkedListNode<Person>). 
            persons.AddLast(new Person() { Name = "John" });
            persons.AddFirst(new Person() { Name = "Bill" });
            
            // управляя свойствами Previous и Next, мы можем получить ссылки на предыдущий и следующий узлы в списке.

            Console.WriteLine(tom.Previous.Value.Name); // получаем узел перед томом и его значение
            Console.WriteLine(tom.Next.Value.Name); // получаем узел после тома и его значение
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
```

## Очередь Queue<T>
 
Класс Queue<T> представляет обычную очередь, работающую по алгоритму FIFO ("первый вошел - первый вышел").

У класса Queue<T> можно отметить следующие методы:
- Dequeue: извлекает и возвращает первый элемент очереди
- Enqueue: добавляет элемент в конец очереди
- Peek: просто возвращает первый элемент из начала очереди без его удаления

## Применение очереди:

```cs
using System;
using System.Collections.Generic;
 
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>();
 
            numbers.Enqueue(3); // очередь 3
            numbers.Enqueue(5); // очередь 3, 5
            numbers.Enqueue(8); // очередь 3, 5, 8
 
            // получаем первый элемент очереди
            int queueElement = numbers.Dequeue(); //теперь очередь 5, 8
            Console.WriteLine(queueElement);
 
            Queue<Person> persons = new Queue<Person>();
            persons.Enqueue(new Person() { Name = "Tom" });
            persons.Enqueue(new Person() { Name = "Bill" });
            persons.Enqueue(new Person() { Name = "John" });
 
            // получаем первый элемент без его извлечения
            Person pp = persons.Peek();
            Console.WriteLine(pp.Name);
 
             Console.WriteLine("Сейчас в очереди {0} человек", persons.Count);
             
            // теперь в очереди Tom, Bill, John
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }
 
            // Извлекаем первый элемент в очереди - Tom
            Person person = persons.Dequeue(); // теперь в очереди Bill, John
            Console.WriteLine(person.Name);
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
```
## Коллекция Stack<T>
Класс Stack<T> представляет коллекцию, которая использует алгоритм LIFO ("последний вошел - первый вышел"). При такой организации каждый следующий добавленный элемент помещается поверх предыдущего. Извлечение из коллекции происходит в обратном порядке - извлекается тот элемент, который находится выше всех в стеке.
В классе Stack можно выделить два основных метода, которые позволяют управлять элементами:
- Push: добавляет элемент в стек на первое место
- Pop: извлекает и возвращает первый элемент из стека
- Peek: просто возвращает первый элемент из стека без его удаления

```cs
using System;
using System.Collections.Generic;
 
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Stack<int> numbers = new Stack<int>();
 
            numbers.Push(3); // в стеке 3
            numbers.Push(5); // в стеке 5, 3
            numbers.Push(8); // в стеке 8, 5, 3
 
            // так как вверху стека будет находиться число 8, то оно и извлекается
            int stackElement = numbers.Pop(); // в стеке 5, 3
            Console.WriteLine(stackElement);
 
            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person() { Name = "Tom" });
            persons.Push(new Person() { Name = "Bill" });
            persons.Push(new Person() { Name = "John" });
 
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }
 
            // Первый элемент в стеке
            Person person = persons.Pop(); // теперь в стеке Bill, Tom
            Console.WriteLine(person.Name);
 
            Console.ReadLine();
        }
    }
 
    class Person
    {
        public string Name { get; set; }
    }
}
```
## Коллекция Dictionary<T, V>
Словарь хранит объекты, которые представляют пару ключ-значение. Каждый такой объект является объектом структуры KeyValuePair<TKey, TValue>. Благодаря свойствам Key и Value, которые есть у данной структуры, мы можем получить ключ и значение элемента в словаре.

# использование словарей:

```cs

Dictionary<int, string> countries = new Dictionary<int, string>(5);
countries.Add(1, "Russia");
countries.Add(3, "Great Britain");
countries.Add(2, "USA");
countries.Add(4, "France");
countries.Add(5, "China");          
 
foreach (KeyValuePair<int, string> keyValue in countries)
{
    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
}
 
// получение элемента по ключу
string country = countries[4];
// изменение объекта
countries[4] = "Spain";
// удаление по ключу
countries.Remove(2);
```
Класс словарей имеет методы Add и Remove для добавления и удаления элементов. В метод Add передаются два параметра: ключ и значение. Метод Remove удаляет не по индексу, а по ключу.

```cs

Dictionary<char, Person> people = new Dictionary<char, Person>();
people.Add('b', new Person() { Name = "Bill" });
people.Add('t', new Person() { Name = "Tom" }); 
people.Add('j', new Person() { Name = "John" });

// Так как ключами является объекты типа int, а значениями - объекты типа string, то словарь будет хранить объекты KeyValuePair<int, string>. 

// В цикле foreach их можем получить и извлечь из них ключ и значение.

foreach (KeyValuePair<char, Person> keyValue in people)
{
    // keyValue.Value представляет класс Person
    Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name); 
}

// в качестве ключей выступают объекты типа char, а значениями - объекты Person. 
// Используя свойство Keys, мы можем получить ключи словаря, 
// свойство Values хранит все значения в словаре.

// мы можем получить отдельно коллекции ключей и значений словаря:
// перебор ключей
foreach (char c in people.Keys)
{
    Console.WriteLine(c);
}
 
// перебор по значениям
foreach (Person p in people.Values)
{
    Console.WriteLine(p.Name);
}
```

Для добавления необязательно применять метод Add(), можно использовать сокращенный вариант:
```cs
Dictionary<char, Person> people = new Dictionary<char, Person>();
people.Add('b', new Person() { Name = "Bill" });
people['a'] = new Person() { Name = "Alice" };
// Несмотря на то, что изначально в словаре нет ключа 'a' и соответствующего ему элемента, 
// он все равно будет установлен. 
// Если он есть, то элемент по ключу 'a' будет заменен на новый объект new Person() { Name = "Alice" }
```
## Инициализация словарей
```cs
Dictionary<string, string> countries = new Dictionary<string, string>
{
    {"Франция", "Париж"},
    {"Германия", "Берлин"},
    {"Великобритания", "Лондон"}
};
 
foreach(var pair in countries)
    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            
// доступен также еще один способ инициализации:

Dictionary<string, string> countries = new Dictionary<string, string>
{
    ["Франция"]= "Париж",
    ["Германия"]= "Берлин",
    ["Великобритания"]= "Лондон"
};       
```
## Класс ObservableCollection

Класс ObservableCollection по функциональности похож на список List за тем исключением, что позволяет известить внешние объекты о том, что коллекция была изменена.
```cs
using System;

// класс ObservableCollection находится в пространстве имен System.Collections.ObjectModel, кроме того, также понадобятся ряд объектов из пространства System.Collections.Specialized, поэтому в начале подключаем эти пространства имен.
using System.Collections.ObjectModel;
using System.Collections.Specialized;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Класс ObservableCollection определяет событие CollectionChanged, подписавшись на которое, мы можем обработать любые изменения коллекции.

            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User { Name = "Bill"},
                new User { Name = "Tom"},
                new User { Name = "Alice"}
            };
 
            users.CollectionChanged += Users_CollectionChanged;
 
            users.Add(new User { Name = "Bob" });
            users.RemoveAt(1);
            users[0] = new User{ Name = "Anders" };
 
            foreach(User user in users)
            {
                Console.WriteLine(user.Name);
            }
             
            Console.Read();
        }

        // В обработчике этого события Users_CollectionChanged для получения всей информации о событии используется объект NotifyCollectionChangedEventArgs e. 
        // Его свойство Action позволяет узнать характер изменений. Оно хранит одно из значений из перечисления NotifyCollectionChangedAction.
 
        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                // Свойства NewItems и OldItems позволяют получить соответственно добавленные и удаленные объекты. 
                // Таким образом, мы получаем полный контроль над обработкой добавления, удаления и замены объектов в коллекции.

                case NotifyCollectionChangedAction.Add: // если добавление
                    User newUser = e.NewItems[0] as User;
                    Console.WriteLine($"Добавлен новый объект: {newUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    User oldUser = e.OldItems[0] as User;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    User replacedUser = e.OldItems[0] as User;
                    User replacingUser = e.NewItems[0] as User;
                    Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }
        }
    }
 
    class User
    {
        public string Name { get; set; }
    }
}
```

## Интерфейсы IEnumerable и IEnumerator
основной для большинства коллекций является реализация интерфейсов IEnumerable и IEnumerator. Благодаря такой реализации мы можем перебирать объекты в цикле foreach:
```cs
foreach(var item in перечислимый_объект)
{
     
}
```
Перебираемая коллекция должна реализовать интерфейс IEnumerable.

Интерфейс IEnumerable имеет метод, возвращающий ссылку на другой интерфейс - перечислитель:
```cs
public interface IEnumerable
{
    IEnumerator GetEnumerator();
}
```
интерфейс IEnumerator определяет функционал для перебора внутренних объектов в контейнере:
```cs
public interface IEnumerator
{
    // Метод MoveNext() перемещает указатель на текущий элемент на следующую позицию в последовательности. Если последовательность еще не закончилась, то возвращает true. Если же последовательность закончилась, то возвращается false.
    bool MoveNext(); // перемещение на одну позицию вперед в контейнере элементов
    
    // Свойство Current возвращает объект в последовательности, на который указывает указатель.
        object Current {get;}  // текущий элемент в контейнере
    
    // Метод Reset() сбрасывает указатель позиции в начальное положение.
    void Reset(); // перемещение в начало контейнера
}
```

перемещение указателя и получение элементов зависит от реализации интерфейса. В различных реализациях логика может быть построена различным образом.

Например, без использования цикла foreach перебирем коллекцию с помощью интерфейса IEnumerator:
```cs
using System;
using System.Collections;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, 2, 4, 6, 8, 10 };
 
            IEnumerator ie = numbers.GetEnumerator(); // получаем IEnumerator
            while (ie.MoveNext())   // пока не будет возвращено false
            {
                int item = (int)ie.Current;     // берем элемент на текущей позиции
                Console.WriteLine(item);
            }
            ie.Reset(); // сбрасываем указатель в начало массива
            Console.Read();
        }
    }
}
```
## Реализация IEnumerable и IEnumerator
```cs
using System;
using System.Collections;
 
namespace HelloApp
{
    // класс Week, который представляет неделю и хранит все дни недели, реализует интерфейс IEnumerable. 
    class Week : IEnumerable
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", 
                         "Friday", "Saturday", "Sunday" };
 
        // возвращаем в методе GetEnumerator объект IEnumerator для массива.
        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }
            Console.Read();
        }
    }
}
// Благодаря этому мы можем перебрать все дни недели в цикле foreach.
public IEnumerator GetEnumerator()
{
    return days.GetEnumerator();
}

```
для перебора коллекции через foreach в принципе необязательно реализовать интерфейс IEnumerable. Достаточно в классе определить публичный метод GetEnumerator, который бы возвращал объект IEnumerator:

```cs
class Week
{
    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", 
                        "Friday", "Saturday", "Sunday" };
 
    public IEnumerator GetEnumerator()
    {
        return days.GetEnumerator();
    }
}
```
возможно, потребуется задать свою собственную логику перебора объектов. 

## Для этого реализуем интерфейс IEnumerator:
```cs

using System;
using System.Collections;
 
namespace HelloApp
{
    
    class WeekEnumerator : IEnumerator
    {
        string[] days;
        // для хранения текущей позиции определена переменная position. 
        int position = -1;
        // в самом начале (в исходном состоянии) указатель должен указывать на позицию условно перед первым элементом. 
        // Когда будет производиться цикл foreach, то данный цикл вначале вызывает метод MoveNext и фактически перемещает указатель на одну позицию вперед и только затем обращается к свойству Current для получения элемента в текущей позиции.
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }
 
        public bool MoveNext()
        {
            if(position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
 
        public void Reset()
        {
            position = -1;
        }
    }
    // класс Week использует не встроенный перечислитель, а WeekEnumerator, который реализует IEnumerator.
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
 
        public IEnumerator GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }
            Console.Read();
        }
    }
}
```

## обобщенные версии интерфейсов:
```cs
using System;
using System.Collections;
using System.Collections.Generic;
 
namespace HelloApp
{
    class Week
    {
        string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
                            "Friday", "Saturday", "Sunday" };
 
        public IEnumerator<string> GetEnumerator()
        {
            return new WeekEnumerator(days);
        }
    }
    class WeekEnumerator : IEnumerator<string>
    {
        string[] days;
        int position = -1;
        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }
         
        public string Current
        {
            get
            {
                if (position == -1 || position >= days.Length)
                    throw new InvalidOperationException();
                return days[position];
            }
        }
 
        object IEnumerator.Current => throw new NotImplementedException();
         
        public bool MoveNext()
        {
            if(position < days.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
 
        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Week week = new Week();
            foreach(var day in week)
            {
                Console.WriteLine(day);
            }
            Console.Read();
        }
    }
}

```
## Итераторы и оператор yield

Итератор представляет блок кода, который использует оператор yield для перебора набора значений. Данный блок кода может представлять тело метода, оператора или блок get в свойствах.
Итератор использует две специальных инструкции:
1. yield return: определяет возвращаемый элемент
2. yield break: указывает, что последовательность больше не имеет элементов

```cs
using System;
using System.Collections;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // с помощью цикла foreach мы можем перебрать объект Numbers как обычную коллекцию. 
            // При получении каждого элемента в цикле foreach будет срабатывать оператор yield return, который будет возвращать один элемент и запоминать текущую позицию.

            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
 
    class Numbers
    {
        // метод GetEnumerator() представляет итератор. 
        // С помощью оператора yield return возвращается значение (в данном случае квадрат числа).

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < 6; i++)
            {
                yield return i * i;
            }
        }
    }
}
```

пусть у нас есть коллекция Library, которая представляет хранилище книг - объектов Book. 
Используем оператор yield для перебора этой коллекции:

```cs
class Book
{
    public Book(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }
}
 
class Library
{
    private Book[] books;
 
    public Library()
    {
        books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"),
                new Book("Евгений Онегин") };
    }
 
    public int Length
    {
        get { return books.Length; }
    }
    // Метод GetEnumerator() представляет итератор. 
    // когда мы будем осуществлять перебор в объекте Library в цикле foreach, то будет идти обращение к вызову yield return books[i];. 
    // При обращении к оператору yield return будет сохраняться текущее местоположение. 
    // когда метод foreach перейдет к следующей итерации для получения нового объекта, итератор начнет выполнения с этого местоположения.

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < books.Length; i++)
        {
            yield return books[i];
        }
    }
}
```
в основной программе в цикле foreach выполняется перебор, благодаря реализации итератора:
```cs
foreach (Book b in library)
{
    Console.WriteLine(b.Name);
}
```
Хотя при реализации итератора в методе GetEnumerator() применялся перебор массива в цикле for, но это необязательно делать. Мы можем просто определить несколько вызовов оператора yield return:
```cs
IEnumerator IEnumerable.GetEnumerator()
{
    yield return books[0];
    yield return books[1];
    yield return books[2];
}
```
В этом случае при каждом вызове оператора yield return итератор также будет запоминать текущее местоположение и при последующих вызовах начинать с него.

## Именованный итератор
оператор yield можно использовать внутри любого метода, только такой метод должен возвращать объект интерфейса IEnumerable. 
Подобные методы еще называют именованными итераторами.

### Создадим именованный итератор в классе Library:

```cs
class Book
{
    public Book(string name)
    {
        this.Name=name;
    }
    public string Name { get; set; }
}
 
class Library
{
    private Book[] books;
 
    public Library()
    {
        books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"), 
            new Book("Евгений Онегин") };
    }
 
    public int Length
    {
        get { return books.Length; }
    }
    // итератор - метод IEnumerable GetBooks(int max) в качестве параметра принимает количество выводимых объектов. 

    public IEnumerable GetBooks(int max)
    {
        for (int i = 0; i < max; i++)
        {
            // В процессе работы программы может сложиться, что его значение будет больше, чем длина массива books. И чтобы не произошло ошибки, используется оператор yield break. Этот оператор прерывает выполнение итератора. 
            if (i == books.Length)
            {
                yield break;
            }
            else
            {
                yield return books[i];
            }
        }
    }
}
```

### Применение итератора:
```cs
Library library = new Library();

// Вызов library.GetBooks(5) будет возвращать набор из не более чем 5 объектов Book. Но так как у нас всего три таких объекта, то в методе GetBooks после трех операций сработает оператор yield break.

foreach (Book b in library.GetBooks(5))
{
    Console.WriteLine(b.Name);
}
```
