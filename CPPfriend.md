# Дружественные функции и классы
 
Дружественная функция — это функция, которая имеет доступ к закрытым членам класса - переменным и функциям, которые имеют спецификатор private, как если бы она сама была членом этого класса. Во всех других отношениях дружественная функция является обычной функцией. Ею может быть, как обычная функция, так и метод другого класса. Для объявления дружественной функции используется ключевое слово friend перед прототипом функции, которую вы хотите сделать дружественной классу. Неважно, объявляете ли вы её в public- или в private-зоне класса:
```c

class Anything
{
private:
    int m_value;
public:
    Anything() { m_value = 0; } 
    void add(int value) { m_value += value; }
 
    // Делаем функцию reset() дружественной классу Anything
    friend void reset(Anything &anything);
};
 
// Функция reset() является другом класса Anything
void reset(Anything &anything)
{
    // И мы имеем доступ к закрытым членам объектов класса Anything
    anything.m_value = 0;
}
 
int main()
{
    Anything one;
    one.add(4); // добавляем 4 к m_value
    reset(one); // сбрасываем m_value в 0
 
    return 0;
}

```
Здесь мы объявили функцию reset(), которая принимает объект класса Anything и устанавливает m_value значение 0. Поскольку reset() не является членом класса Anything, то в обычной ситуации функция reset() не имела бы доступ к закрытым членам Anything. Однако, поскольку эта функция является дружественной классу Anything, она имеет доступ к закрытым членам Anything.
```c

// мы должны передавать объект Anything в функцию reset() в качестве параметра. 
// Это связано с тем, что функция reset() не является методом класса. 
// Она не имеет указателя *this и, кроме как передачи объекта, она не сможет взаимодействовать с классом.


class Something
{
private:
    int m_value;
public:
    Something(int value) { m_value = value; }
    friend bool isEqual(const Something &value1, const Something &value2);
};
 
bool isEqual(const Something &value1, const Something &value2)
{
    return (value1.m_value == value2.m_value);
}

```
мы объявили функцию isEqual() дружественной классу Something. Функция isEqual() принимает в качестве параметров два объекта класса Something. Поскольку isEqual() является другом класса Something, то функция имеет доступ ко всем закрытым членам объектов класса Something. Функция isEqual() сравнивает значения переменных-членов двух объектов и возвращает true, если они равны.

У класса Auto определены приватные закрытые переменные name и price. Также в классе объявлены две дружественные функции: drive и setPrice. Обе этих функции принимают в качестве параметра ссылку на объект Auto.

```c

#include <iostream>
#include <string>  
 
class Auto
{
    friend void drive(Auto &);
    friend void setPrice(Auto &, int price);
public:
    Auto(std::string autoName, int autoPrice) 
    { 
        name = autoName; 
        price = autoPrice;
    }
    std::string getName(){ return name; }
    int getPrice() { return price; }
 
private:
    std::string name;   // название автомобиля
    int price;  // цена автомобиля
};
 
void drive(Auto &a) 
{ 
    std::cout << a.name << " is driven" << std::endl;
}
void setPrice(Auto &a, int price)
{
    if (price > 0) 
        a.price = price;
}
 
int main()
{
    Auto tesla("Tesla", 5000);
    drive(tesla);
    std::cout << tesla.getName() << " : " << tesla.getPrice() << std::endl;
    setPrice(tesla, 8000);
    std::cout << tesla.getName() << " : " << tesla.getPrice() << std::endl;
 
    return 0;
}

```
Когда мы объявляем дружественные функции, то мы говорим компилятору, что это друзья класса и они имеют доступ ко всем членам этого класса, в том числе закрытым. При этом для дружественных функций не важно, определяются они под спецификатором public или private. Для них это не имеет значения.

Определение этих функций производится вне класса. И поскольку эти функции являются дружественными, то внутри этих функций мы можем через переданную ссылку Auto обратиться ко всем его закрытым переменным.

## Дружественные функции и несколько классов
Функция может быть другом сразу для нескольких классов, например:

```c

#include <iostream>
 
class Wet;
 
class Temperature
{
private:
    int m_temp;
public:
    Temperature(int temp=0) { m_temp = temp; }
 
    friend void outWeather(const Temperature &temperature, const Wet &humidity);
};
 
class Wet
{
private:
    int m_wet;
public:
    Humidity(int wet=0) { m_wet = wet; }
 
    friend void outWeather(const Temperature &temperature, const Wet &wet);
};
 
void outWeather(const Temperature &temperature, const Wet &wet)
{
    std::cout << "The temperature is " << temperature.m_temp <<
       " and the wet is " << wet.m_wet << '\n';
}
 
int main()
{
    Temperature temp(15);
    Wet wet(11);
 
    outWeather(temp, wet);
 
    return 0;
}

// поскольку функция outWeather() является другом для обоих классов, то она имеет доступ к закрытым членам обоих классов. 

```
class Wet; 
Это прототип класса, который сообщает компилятору, что мы определим класс Wet чуть позже. Без этой строчки компилятор выдал бы ошибку, что не знает, что такое Wet при анализе прототипа дружественной функции outWeather() внутри класса Temperature. Прототипы классов выполняют ту же роль, что и прототипы функций: они сообщают компилятору об объектах, которые позднее будут определены, но которые сейчас нужно использовать. Однако, в отличие от функций, классы не имеют типа возврата или параметров, поэтому их прототипы предельно лаконичны: ключевое слово class + имя класса + ; (например, class Anything;).


## Определение дружественных функций в классе
Дружественные функции могут определяться в другом классе. 

## определим класс Person, который использует объект Auto:
```c

#include <iostream>
#include <string> 
 
class Auto;
 
class Person
{
public:
    Person(std::string n)
    {
        name = n;
    }
    void drive(Auto &a);
    void setPrice(Auto &a, int price);
 
private:
    std::string name;
};
 
class Auto
{
    friend void Person::drive(Auto &);
    friend void Person::setPrice(Auto &, int price);
public:
    Auto(std::string autoName, int autoPrice)
    {
        name = autoName;
        price = autoPrice;
    }
    std::string getName() { return name; }
    int getPrice() { return price; }
 
private:
    std::string name;   // название автомобиля
    int price;  // цена автомобиля
};
 
void Person::drive(Auto &a)
{
    std::cout << name << " drives " << a.name << std::endl;
}
void Person::setPrice(Auto &a, int price)
{
    if (price > 0)
        a.price = price;
}
 
int main()
{
    Auto tesla("Tesla", 5000);
    Person tom("Tom");
    tom.drive(tesla);
    tom.setPrice(tesla, 8000);
    std::cout << tesla.getName() << " : " << tesla.getPrice() << std::endl;
 
    return 0;
}

```

Две функции из класса Person принимают ссылку на объект Auto:
```c

void drive(Auto &a);
void setPrice(Auto &a, int price);

```

Класс Auto определяет дружественные функции с той же сигнатурой:
```c

friend void Person::drive(Auto &);
friend void Person::setPrice(Auto &, int price);

```
Поскольку данные функции определены в классе Person, то названия этих функций предваряется префиксом "Person::".

И поскольку в этих функциях предполагается использовать объект Auto, то ко времени определения этих функций все члены объекта Auto должны быть известны, поэтому определения функций находятся не в самом классе Person, а после класса Auto. И так как эти функции определены в классе Auto как дружественные, мы можем обратиться в этих функциях к закрытым членам класса Auto.

## Дружественные классы
Один класс может быть дружественным другому классу. Это откроет всем членам первого класса доступ к закрытым членам второго класса:

```c
// определить дружественным весь класс Person:
#include <iostream>
#include <string> 
 
class Auto;
 
class Person
{
public:
    Person(std::string n)
    {
        name = n;
    }
    void drive(Auto &a);
    void setPrice(Auto &a, int price);
 
private:
    std::string name;
};
 
class Auto
{
    friend class Person;
public:
    Auto(std::string autoName, int autoPrice)
    {
        name = autoName;
        price = autoPrice;
    }
    std::string getName() { return name; }
    int getPrice() { return price; }
 
private:
    std::string name;   // название автомобиля
    int price;  // цена автомобиля
};
 
void Person::drive(Auto &a)
{
    std::cout << name << " drives " << a.name << std::endl;
}
void Person::setPrice(Auto &a, int price)
{
    if (price > 0)
        a.price = price;
}
 
int main()
{
    Auto tesla("Tesla", 5000);
    Person tom("Tom");
    tom.drive(tesla);
    tom.setPrice(tesla, 8000);
    std::cout << tesla.getName() << " : " << tesla.getPrice() << std::endl;
 
    return 0;
}

```
в классе Auto определение дружественных функций было заменено определением дружественного класса:
```c
friend class Person;
```

класс Person - это друг класса Auto, поэтому объекты Person могут обращаться к приватным переменным класса Auto. После этого в классе Person можно обращаться к закрытым членам класса Auto из любых функций.

```c

#include <iostream>
 
class Values
{
private:
    int m_intValue;
    double m_dValue;
public:
    Values(int intValue, double dValue)
    {
        m_intValue = intValue;
        m_dValue = dValue;
    }
 
    // Делаем класс Display другом класса Values
    friend class Display;
};
 
class Display
{
private:
    bool m_displayIntFirst;
 
public:
    Display(bool displayIntFirst) { m_displayIntFirst = displayIntFirst; }
 
    void displayItem(Values &value)
    {
        if (m_displayIntFirst)
            std::cout << value.m_intValue << " " << value.m_dValue << '\n';
        else // или сначала выводим double
            std::cout << value.m_dValue << " " << value.m_intValue << '\n';
    }
};
 
int main()
{
    Values value(7, 8.4);
    Display display(false);
 
    display.displayItem(value);
 
    return 0;
}
// Поскольку класс Display является другом класса Values, то любой из членов Display имеет доступ к private-членам Values.

// если Display является другом Values, Display не имеет прямой доступ к указателю *this объектов Values.

// если Display является другом Values, это не означает, что Values также является другом Display. Если вы хотите сделать оба класса дружественными, то каждый из них должен указать в качестве друга противоположный класс. 

// если класс A является другом B, а B является другом C, то это не означает, что A является другом C.

// Будьте внимательны при использовании дружественных функций и классов, поскольку это может нарушать принципы инкапсуляции. Если детали одного класса изменятся, то детали класса-друга также будут вынуждены измениться. Следовательно, ограничивайте количество и использование дружественных функций и классов.

```

## Дружественные методы
Вместо того, чтобы делать дружественным целый класс, мы можем сделать дружественными только определенные методы класса. Их объявление аналогично объявлениям обычных дружественных функций, за исключением имени метода с префиксом имяКласса:: в начале (например, Display::displayItem()).

Переделаем наш предыдущий пример, чтобы метод Display::displayItem() был дружественным классу Values:
```c

class Display; // предварительное объявление класса Display
 
class Values
{
private:
    int m_intValue;
    double m_dValue;
public:
    Values(int intValue, double dValue)
    {
        m_intValue = intValue;
        m_dValue = dValue;
    }
 
    // Делаем метод Display::displayItem() другом класса Values
    friend void Display::displayItem(Values& value); // ошибка: Values не видит полного определения класса Display
};
 
class Display
{
private:
    bool m_displayIntFirst;
 
public:
    Display(bool displayIntFirst) { m_displayIntFirst = displayIntFirst; }
 
    void displayItem(Values &value)
    {
        if (m_displayIntFirst)
            std::cout << value.m_intValue << " " << value.m_dValue << '\n';
        else // или выводим сначала double
            std::cout << value.m_dValue << " " << value.m_intValue << '\n';
    }
};

```
Чтобы сделать метод дружественным классу, компилятор должен увидеть полное определение класса, в котором дружественный метод определяется (а не только лишь его прототип). Поскольку компилятор, прочёсывая последовательно строчки кода не увидел полного определения класса Display, но успел увидеть прототип его метода, то он выдаст ошибку в строке определения этого метода дружественным классу Values.

Можно попытаться переместить определение класса Display выше определения класса Values:
```c


class Display
{
private:
    bool m_displayIntFirst;
 
public:
    Display(bool displayIntFirst) { m_displayIntFirst = displayIntFirst; }
 
    void displayItem(Values &value) // ошибка: Компилятор не знает, что такое Values
    {
        if (m_displayIntFirst)
            std::cout << value.m_intValue << " " << value.m_dValue << '\n';
        else // или выводим сначала double
            std::cout << value.m_dValue << " " << value.m_intValue << '\n';
    }
};
 
class Values
{
private:
    int m_intValue;
    double m_dValue;
public:
    Values(int intValue, double dValue)
    {
        m_intValue = intValue;
        m_dValue = dValue;
    }
 
    // Делаем метод Display::displayItem() другом класса Values
    friend void Display::displayItem(Values& value);
};

```
Поскольку метод Display::displayItem() использует ссылку на объект класса Values в качестве параметра, а мы только что перенесли определение Display выше определения Values, то компилятор будет жаловаться, что он не знает, что такое Values.

### это можно решить:
```c

// для класса Values используем предварительное объявление.

// переносим определение метода Display::displayItem() за пределы класса Display и размещаем его после полного определения класса Values.

#include <iostream>
 
class Values; // предварительное объявление класса Values
 
class Display
{
private:
    bool m_displayIntFirst;
 
public:
    Display(bool displayIntFirst) { m_displayIntFirst = displayIntFirst; }
    
    void displayItem(Values &value); // предварительное объявление, приведенное выше, требуется для этой строки
};
 
class Values // полное определение класса Values
{
private:
    int m_intValue;
    double m_dValue;
public:
    Values(int intValue, double dValue)
    {
        m_intValue = intValue;
        m_dValue = dValue;
    }
 
    // Делаем метод Display::displayItem() другом класса Values
    friend void Display::displayItem(Values& value);
};
 
// Теперь мы можем определить метод Display::displayItem(), которому требуется увидеть полное определение класса Values
void Display::displayItem(Values &value)
{
    if (m_displayIntFirst)
        std::cout << value.m_intValue << " " << value.m_dValue << '\n';
    else // или выводим сначала double
        std::cout << value.m_dValue << " " << value.m_intValue << '\n';
}
 
int main()
{
    Values value(7, 8.4);
    Display display(false);
 
    display.displayItem(value);
 
    return 0;
}

```
Лучшим решением было бы поместить каждое определение класса в отдельный заголовочный файл с определениями методов в соответствующих файлах .cpp. Таким образом, все определения классов стали бы видны сразу во всех файлах .cpp

Дружественная функция/класс — это функция/класс, которая имеет доступ к закрытым членам другого класса, как если бы она сама была членом этого класса. Это позволяет функции/классу работать в тесном контакте с другим классом, не заставляя другой класс делать открытыми свои закрытые члены.

## Перегрузка операторов через дружественные функции
### Арифметические операторы

```c
// Арифметические операторы плюс (+), минус (-), умножение (*) и деление (/) являются одними из наиболее используемых операторов в языке C++. Все они являются бинарными, то есть работают только с двумя операндами.

class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
  int getDollars() const { return m_dollars; }
};
```
Перегрузим оператор плюс (+) для выполнения операции сложения двух объектов класса Dollars:
```c
#include <iostream>
 
class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  // Выполняем Dollars + Dollars через дружественную функцию
  friend Dollars operator+(const Dollars &d1, const Dollars &d2);
 
  int getDollars() const { return m_dollars; }
};

 
// Эта функция не является методом класса!
Dollars operator+(const Dollars &d1, const Dollars &d2)
{
  // Используем конструктор Dollars и operator+(int, int).
  // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
  return Dollars(d1.m_dollars + d2.m_dollars);
}

//    объявили дружественную функцию operator+();
//    задали в качестве параметров два операнда, с которыми хотим работать — два объекта класса Dollars;
//    указали соответствующий тип возврата — Dollars;
//    записали реализацию операции сложения.

int main()
{
  Dollars dollars1(7);
  Dollars dollars2(9);
  Dollars dollarsSum = dollars1 + dollars2;
  std::cout << "I have " << dollarsSum.getDollars() << " dollars." << std::endl;
 
  return 0;
}
```
Для выполнения операции сложения двух объектов класса Dollars нам нужно добавить к переменной-члену m_dollars первого объекта m_dollars второго объекта. Поскольку наша перегруженная функция operator+() является дружественной классу Dollars, то мы можем напрямую обращаться к закрытому члену m_dollars. Кроме того, поскольку m_dollars является целочисленным значением, а C++ знает, как добавлять целочисленные значения, то компилятор будет использовать встроенную версию operator+() для работы с типом int, поэтому мы можем просто указать оператор + в нашей операции сложения двух объектов класса Dollars.

## Перегрузка оператора минус (−) аналогична:
```c

#include <iostream>
 
class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  // Выполняем Dollars + Dollars через дружественную функцию
  friend Dollars operator+(const Dollars &d1, const Dollars &d2);
 
  // Выполняем Dollars - Dollars через дружественную функцию
  friend Dollars operator-(const Dollars &d1, const Dollars &d2);
 
  int getDollars() const { return m_dollars; }
};
 
// Примечание: Эта функция не является методом класса!
Dollars operator+(const Dollars &d1, const Dollars &d2)
{
  // Используем конструктор Dollars и operator+(int, int).
  // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
  return Dollars(d1.m_dollars + d2.m_dollars);
}
 
// Примечание: Эта функция не является методом класса!
Dollars operator-(const Dollars &d1, const Dollars &d2)
{
  // Используем конструктор Dollars и operator-(int, int).
  // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
  return Dollars(d1.m_dollars - d2.m_dollars);
}
 
int main()
{
  Dollars dollars1(5);
  Dollars dollars2(3);
  Dollars dollarsSum = dollars1 - dollars2;
  std::cout << "I have " << dollarsSum.getDollars() << " dollars." << std::endl;
 
  return 0;
}
// Перегрузки оператора умножения (*) и оператора деления (/) аналогичны, только вместо знака минус указываете * или /.

```

## Дружественные функции могут быть определены внутри класса

Несмотря на то, что дружественные функции не являются членами класса, они по-прежнему могут быть определены внутри класса, если это необходимо:
```c

#include <iostream>
 
class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  // Выполняем Dollars + Dollars через дружественную функцию.
    // Эта функция не рассматривается как метод класса, хотя она и определена внутри класса
  friend Dollars operator+(const Dollars &d1, const Dollars &d2)
  {
    // Используем конструктор Dollars и operator+(int, int).
    // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
    return Dollars(d1.m_dollars + d2.m_dollars);
  }
 
  int getDollars() const { return m_dollars; }
};
 
int main()
{
  Dollars dollars1(7);
  Dollars dollars2(9);
  Dollars dollarsSum = dollars1 + dollars2;
  std::cout << "I have " << dollarsSum.getDollars() << " dollars." << std::endl;
 
  return 0;
}

```
Не рекомендуется так делать, поскольку нетривиальные определения функций лучше записывать в отдельном файле .cpp вне тела класса.

## Перегрузка операторов с операндами разных типов

Один оператор может работать с операндами разных типов. Например, мы можем добавить Dollars(5) к числу 5 для получения результата Dollars(10).

Когда C++ обрабатывает выражение a + b, то a становится первым параметром, а b — вторым параметром. Когда a и b одного и того же типа данных, то не имеет значения, пишете ли вы a + b или b + a — в любом случае вызывается одна и та же версия operator+(). Однако, если операнды разных типов, то a + b — это уже не то же самое, что b + a.

Например, Dollars(5) + 5 приведет к вызову operator+(Dollars, int), а 5 + Dollars(5) приведет к вызову operator+(int, Dollars). Следовательно, всякий раз, при перегрузке бинарных операторов для работы с операндами разных типов, нужно писать две функции — по одной на каждый случай:
```c

#include <iostream>
 
class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  // Выполняем Dollars + int через дружественную функцию
  friend Dollars operator+(const Dollars &d1, int value);
 
  // Выполняем int + Dollars через дружественную функцию
  friend Dollars operator+(int value, const Dollars &d1);
 
 
  int getDollars() { return m_dollars; }
};
 
// Примечание: Эта функция не является методом класса!
Dollars operator+(const Dollars &d1, int value)
{
  // Используем конструктор Dollars и operator+(int, int).
  // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
  return Dollars(d1.m_dollars + value);
}
 
// Примечание: Эта функция не является методом класса!
Dollars operator+(int value, const Dollars &d1)
{
  // Используем конструктор Dollars и operator+(int, int).
  // Мы имеем доступ к закрытому члену m_dollars, поскольку эта функция является дружественной классу Dollars
  return Dollars(d1.m_dollars + value);
}
 
int main()
{
  Dollars d1 = Dollars(5) + 5;
  Dollars d2 = 5 + Dollars(5);
 
  std::cout << "I have " << d1.getDollars() << " dollars." << std::endl;
  std::cout << "I have " << d2.getDollars() << " dollars." << std::endl;
 
  return 0;
}

```
Обе перегруженные функции имеют одну и ту же реализацию — это потому, что они выполняют одно и то же, но просто принимают параметры в разном порядке.

```c

#include <iostream>
 
class Values
{
private:
  int m_min; // минимальное значение, которое мы обнаружили до сих пор
  int m_max; // максимальное значение, которое мы обнаружили до сих пор
 
public:
  Values(int min, int max)
  {
    m_min = min;
    m_max = max;
  }
 
  int getMin() { return m_min; }
  int getMax() { return m_max; }
 
  friend Values operator+(const Values &v1, const Values &v2);
  friend Values operator+(const Values &v, int value);
  friend Values operator+(int value, const Values &v);
};
 
Values operator+(const Values &v1, const Values &v2)
{
  // Определяем минимальное значение между v1 и v2
  int min = v1.m_min < v2.m_min ? v1.m_min : v2.m_min;
 
  // Определяем максимальное значение между v1 и v2
  int max = v1.m_max > v2.m_max ? v1.m_max : v2.m_max;
 
  return Values(min, max);
}
 
Values operator+(const Values &v, int value)
{
  // Определяем минимальное значение между v и value
  int min = v.m_min < value ? v.m_min : value;
 
  // Определяем максимальное значение между v и value
  int max = v.m_max > value ? v.m_max : value;
 
  return Values(min, max);
}
 
Values operator+(int value, const Values &v)
{
  // Вызываем operator+(Values, int)
  return v + value;
}
 
int main()
{
  Values v1(11, 14);
  Values v2(7, 10);
  Values v3(4, 13);
 
  Values vFinal = v1 + v2 + 6 + 9 + v3 + 17;
 
  std::cout << "Result: (" << vFinal.getMin() << ", " << vFinal.getMax() << ")\n";
 
  return 0;
}

```
Класс Values отслеживает минимальное и максимальное значения. Мы перегрузили оператор плюс (+) 3 раза для выполнения операции сравнения двух объектов класса Values и операции сложения целочисленного значения с объектом класса Values. Мы получили минимальное и максимальное значения из всех, которые указали в vFinal. 


## Перегрузка операторов ввода и вывода

Для классов с множеством переменных-членов, выводить в консоль каждую переменную по отдельности может быть утомительно:
```c

class Point
{
private:
    double m_x, m_y, m_z;
 
public:
    Point(double x=0.0, double y=0.0, double z=0.0): m_x(x), m_y(y), m_z(z)
    {
    }
 
    double getX() { return m_x; }
    double getY() { return m_y; }
    double getZ() { return m_z; }
};

```
Если вы захотите вывести объект этого класса на экран, то вам нужно будет сделать:
```c

Point point(3.0, 4.0, 5.0);
std::cout << "Point(" << point.getX() << ", " <<
    point.getY() << ", " <<
    point.getZ() << ")";

```

проще написать отдельную функцию для вывода:
```c

class Point
{
private:
    double m_x, m_y, m_z;
 
public:
    Point(double x=0.0, double y=0.0, double z=0.0): m_x(x), m_y(y), m_z(z)
    {
    }
 
    double getX() { return m_x; }
    double getY() { return m_y; }
    double getZ() { return m_z; }
 
    void print()
    {
        std::cout << "Point(" << m_x << ", " << m_y << ", " << m_z << ")";
    }
};

```
Поскольку метод print() имеет тип void, то его нельзя вызывать в середине стейтмента вывода. Вместо этого стейтмент вывода придется разбить на несколько частей (строк):
```c

int main()
{
    Point point(3.0, 4.0, 5.0);
 
    std::cout << "My point is: ";
    point.print();
    std::cout << " in Cartesian space.\n";
}

```
А вот если бы мы могли просто написать:
```c

Point point(3.0, 4.0, 5.0);
cout << "My point is: " << point << " in Cartesian space.\n";

```

## Реализация перегрузки оператора <<
Перегрузка оператора вывода << аналогична перегрузке оператора + (оба являются бинарными операторами), за исключением того, что их типы различны.

```c
// класс Point с перегруженным оператором <<:
#include <iostream>
 
class Point
{
private:
    double m_x, m_y, m_z;
 
public:
    Point(double x=0.0, double y=0.0, double z=0.0): m_x(x), m_y(y), m_z(z)
    {
    }
 
    friend std::ostream& operator<< (std::ostream &out, const Point &point);
};
 
std::ostream& operator<< (std::ostream &out, const Point &point)
{
    // Поскольку operator<< является другом класса Point, то мы имеем прямой доступ к членам Point
    out << "Point(" << point.m_x << ", " << point.m_y << ", " << point.m_z << ")";
 
    return out;
}
 
int main()
{
    Point point1(5.0, 6.0, 7.0);
 
    std::cout << point1;
 
    return 0;
}

```
Возвращая параметр out в качестве возвращаемого значения выражения (std::cout << point) мы возвращаем std::cout, и вторая часть нашего выражения обрабатывается как std::cout << std::endl;

Каждый раз, когда мы хотим, чтобы наши перегруженные бинарные операторы были связаны таким образом, то левый операнд обязательно должен быть возвращен (по ссылке). Возврат левого параметра по ссылке в этом случае работает, так как он передается в функцию самим вызовом этой функции, и должен оставаться даже после выполнения и возврата этой функции. Таким образом, мы можем не беспокоиться о том, что ссылаемся на что-то, что выйдет из области видимости и уничтожится после выполнения функции:
```c

#include <iostream>
 
class Point
{
private:
    double m_x, m_y, m_z;
 
public:
    Point(double x=0.0, double y=0.0, double z=0.0): m_x(x), m_y(y), m_z(z)
    {
    }
 
    friend std::ostream& operator<< (std::ostream &out, const Point &point);
};
 
std::ostream& operator<< (std::ostream &out, const Point &point)
{
    // Поскольку operator<< является другом класса Point, то мы имеем прямой доступ к членам Point
    out << "Point(" << point.m_x << ", " << point.m_y << ", " << point.m_z << ")";
 
    return out;
}
 
int main()
{
    Point point1(3.0, 4.7, 5.0);
    Point point2(9.0, 10.5, 11.0);
 
    std::cout << point1 << " " << point2 << '\n';
 
    return 0;
}

```
### Перегрузка оператора ввода >>

Всё почти так же, как и с оператором вывода, но std::cin является объектом типа std::istream. 

класс Point с перегруженным оператором ввода >>:
```c

#include <iostream>
 
class Point
{
private:
    double m_x, m_y, m_z;
 
public:
    Point(double x=0.0, double y=0.0, double z=0.0): m_x(x), m_y(y), m_z(z)
    {
    }
 
    friend std::ostream& operator<< (std::ostream &out, const Point &point);
    friend std::istream& operator>> (std::istream &in, Point &point);
};
 
std::ostream& operator<< (std::ostream &out, const Point &point)
{
    // Поскольку operator<< является другом класса Point, то мы имеем прямой доступ к членам Point
    out << "Point(" << point.m_x << ", " << point.m_y << ", " << point.m_z << ")";
 
    return out;
}
 
std::istream& operator>> (std::istream &in, Point &point)
{
    // Поскольку operator>> является другом класса Point, то мы имеем прямой доступ к членам Point.
    // Обратите внимание, параметр point (объект класса Point) должен быть неконстантным, чтобы мы имели возможность изменить члены класса
    in >> point.m_x;
    in >> point.m_y;
    in >> point.m_z;
 
    return in;
}

```
пример программы с использованием как перегруженного оператора <<, так и оператора >>:
```c

int main()
{
    std::cout << "Enter a point: \n";
 
    Point point;
    std::cin >> point;
 
    std::cout << "You entered: " << point << '\n';
 
    return 0;
}

```

Перегрузка операторов << и >> намного упрощает процесс вывода класса на экран и получение пользовательского ввода с записью в класс.

В большинстве случаев язык C++ позволяет выбирать самостоятельно способ перегрузки операторов.

Но при работе с бинарными операторами, которые не изменяют левый операнд (например, operator+()), обычно используется перегрузка через обычную или дружественную функцию, поскольку такая перегрузка работает для всех типов данных параметров (даже если левый операнд не является объектом класса или является объектом класса, который изменить нельзя). Перегрузка через обычную/дружественную функцию имеет дополнительное преимущество «симметрии», так как все операнды становятся явными параметрами (а не как у перегрузки через метод класса, когда левый операнд становится неявным объектом, на который указывает указатель this).

При работе с бинарными операторами, которые изменяют левый операнд (например, operator+=()), обычно используется перегрузка через методы класса. В этих случаях левым операндом всегда является объект класса, на который указывает скрытый указатель this.

Унарные операторы обычно тоже перегружаются через методы класса, так как в таком случае параметры не используются вообще.

Поэтому:

   Для операторов присваивания (=), индекса ([]), вызова функции (()) или выбора члена (->) используйте перегрузку через методы класса.

   Для унарных операторов используйте перегрузку через методы класса.

   Для перегрузки бинарных операторов, которые изменяют левый операнд (например, operator+=()) используйте перегрузку через методы класса, если это возможно.

   Для перегрузки бинарных операторов, которые не изменяют левый операнд (например, operator+()) используйте перегрузку через обычные/дружественные функции.


## Перегрузка операторов сравнения

Принципы перегрузки операторов сравнения те же, что и в перегрузке других операторов. Поскольку все операторы сравнения являются бинарными и не изменяют свои левые операнды, то выполнять перегрузку следует через дружественные функции.

перегрузим оператор равенства == и оператор неравенства != для класса Car:
```c

#include <iostream>
#include <string>
 
class Car
{
private:
    std::string m_company;
    std::string m_model;
 
public:
    Car(std::string company, std::string model)
        : m_company(company), m_model(model)
    {
    }
 
    friend bool operator== (const Car &c1, const Car &c2);
    friend bool operator!= (const Car &c1, const Car &c2);
};
 
bool operator== (const Car &c1, const Car &c2)
{
    return (c1.m_company == c2.m_company &&
            c1.m_model== c2.m_model);
}
 
bool operator!= (const Car &c1, const Car &c2)
{
    return !(c1== c2);
}
 
int main()
{
    Car mustang("Ford", "Mustang");
    Car logan("Renault", "Logan");
 
    if (mustang == logan)
        std::cout << "Mustang and Logan are the same.\n";
 
    if (mustang != logan)
        std::cout << "Mustang and Logan are not the same.\n";
 
    return 0;
}

```
Поскольку результат выполнения оператора != является прямо противоположным результату выполнения оператора ==, то мы определили оператор !=, используя уже перегруженный оператор ==.

Не перегружайте операторы, которые являются бесполезными для вашего класса.

Некоторые классы-контейнеры Стандартной библиотеки C++ требуют перегрузки оператора <, чтобы они могли сохранять отсортированные элементы.

Перегрузим операторы сравнения >, <, >= и <=:
```c

#include <iostream>
 
class Dollars
{
private:
    int m_dollars;
 
public:
    Dollars(int dollars) { m_dollars = dollars; }
 
    friend bool operator> (const Dollars &d1, const Dollars &d2);
    friend bool operator<= (const Dollars &d1, const Dollars &d2);
 
    friend bool operator< (const Dollars &d1, const Dollars &d2);
    friend bool operator>= (const Dollars &d1, const Dollars &d2);
};
 
bool operator> (const Dollars &d1, const Dollars &d2)
{
    return d1.m_dollars > d2.m_dollars;
}
 
bool operator>= (const Dollars &d1, const Dollars &d2)
{
    return d1.m_dollars >= d2.m_dollars;
}
 
bool operator< (const Dollars &d1, const Dollars &d2)
{
    return d1.m_dollars < d2.m_dollars;
}
 
bool operator<= (const Dollars &d1, const Dollars &d2)
{
    return d1.m_dollars <= d2.m_dollars;
}
 
int main()
{
    Dollars ten(10);
    Dollars seven(7);
 
    if (ten > seven)
        std::cout << "Ten dollars are greater than seven dollars.\n";
    if (ten >= seven)
        std::cout << "Ten dollars are greater than or equal to seven dollars.\n";
    if (ten < seven)
        std::cout << "Seven dollars are greater than ten dollars.\n";
    if (ten <= seven)
        std::cout << "Seven dollars are greater than or equal to ten dollars.\n";
 
    return 0;
}

```
операторы > и <= являются логическими противоположностями, поэтому один из них можно определить через второй. Та же ситуация и с < и >=. 