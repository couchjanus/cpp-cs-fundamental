# Перегрузка функций

Перегрузка функций обеспечивает механизм создания и выполнения вызовов функций с одним и тем же именем, но с разными параметрами. Это позволяет одной функции работать с несколькими разными типами данных (без необходимости придумывать уникальные имена для каждой из функций).

Перегрузка функций — это возможность определять несколько функций с одним и тем же именем, но с разными параметрами. Например:
```c
int subtract(int a, int b)
{
    return a - b;
}
```
Если нам нужно использовать числа типа с плавающей запятой, эта функция совсем не подходит, так как любые параметры типа double будут конвертироваться в тип int, в результате чего будет теряться дробная часть значений.

Иожем объявить еще одну функцию subtract(), которая принимает параметры типа double:
```c
double subtract(double a, double b)
{
    return a - b;
}

```
Теперь у нас есть две версии функции subtract():
```c

int subtract(int a, int b); // целочисленная версия
double subtract(double a, double b); // версия типа с плавающей запятой

```
Компилятор может определить сам, какую версию subtract() следует вызывать на основе аргументов, используемых в вызове функции. Если параметрами будут переменные типа int, то C++ понимает, что мы хотим вызвать subtract(int, int). Если же мы предоставим два значения типа с плавающей запятой, то C++ поймет, что мы хотим вызвать subtract(double, double). Фактически, мы можем определить столько перегруженных функций subtract(), сколько хотим, до тех пор, пока каждая из них будет иметь свои (уникальные) параметры.

Следовательно, можно определить функцию subtract() и с большим количеством параметров:
```c

int subtract(int a, int b, int c)
{
    return a - b - c;
}

```
Хотя здесь subtract() имеет 3 параметра вместо 2, это не является ошибкой, поскольку эти параметры отличаются от параметров других версий subtract().

## Типы возврата в перегрузке функций

тип возврата функции НЕ учитывается при перегрузке функции. Предположим, что вы хотите написать функцию, которая возвращает рандомное число, но вам нужна одна версия, которая возвращает значение типа int, и вторая — которая возвращает значение типа double. У вас может возникнуть соблазн сделать следующее:
```c

int getRandomValue();
double getRandomValue();

```
Компилятор выдаст ошибку. Эти две функции имеют одинаковые параметры (точнее, они отсутствуют), и, следовательно, второй вызов функции getRandomValue() будет рассматриваться как ошибочное переопределение первого вызова. Имена функций нужно будет изменить.

## Псевдонимы типов в перегрузке функций
Поскольку объявление typedef (псевдонима типа) не создает новый тип данных, то следующие два объявления функции print() считаются идентичными:
```c
typedef char *string;
void print(string value);
void print(char *value);
```
## Вызовы функций

Выполнение вызова перегруженной функции приводит к одному из трех возможных результатов:
1. Совпадение найдено. Вызов разрешен для соответствующей перегруженной функции.
2. Совпадение не найдено. Аргументы не соответствуют любой из перегруженных функций.
3. Найдены несколько совпадений. Аргументы соответствуют более чем одной перегруженной функции.

При компиляции перегруженной функции, C++ выполняет следующие шаги для определения того, какую версию функции следует вызывать:

1. C++ пытается найти точное совпадение. Это тот случай, когда фактический аргумент точно соответствует типу параметра одной из перегруженных функций. Например:
```c

void print(char *value);
void print(int value);
 
print(0); // точное совпадение с print(int)
// Хотя 0 может технически соответствовать и print(char *) (как нулевой указатель), но он точно соответствует print(int). Таким образом, print(int) является лучшим (точным) совпадением.

```
2. Если точного совпадения не найдено, то C++ пытается найти совпадение путем дальнейшего неявного преобразования типов:
- char, unsigned char и short конвертируются в int;
- unsigned short может конвертироваться в int или unsigned int (в зависимости от размера int);
- float конвертируется в double;
- enum конвертируется в int.
```c

void print(char *value);
void print(int value);
 
print('b'); // совпадение с print(int) после неявного преобразования

```
В этом случае, поскольку нет print(char), символ b конвертируется в тип int, который затем уже соответствует print(int).

3. Если неявное преобразование невозможно, то C++ пытается найти соответствие посредством стандартного преобразования. В стандартном преобразовании:
- Любой числовой тип будет соответствовать любому другому числовому типу, включая unsigned (например, int равно float).
- enum соответствует формальному типу числового типа данных (например, enum равно float).
- Ноль соответствует типу указателя и числовому типу (например, 0 как char * или 0 как float).
- Указатель соответствует указателю типа void.
```c

struct Employee; // определение упустим
void print(float value);
void print(Employee value);
 
print('b'); // 'b' конвертируется в соответствие версии print(float)

```
В этом случае, поскольку нет print(char) (точного совпадения) и нет print(int) (совпадения путем неявного преобразования), символ b конвертируется в тип float и сопоставляется с print(float).

все стандартные преобразования считаются равными. Ни одно из них не считается выше остальных по приоритету.

4. C++ пытается найти соответствие путем пользовательского преобразования. классы могут определять преобразования в другие типы данных, которые могут быть неявно применены к объектам этих классов. Например, мы можем создать класс W и в нем определить пользовательское преобразование в тип int:
```c

class W; // с пользовательским преобразованием в тип int
 
void print(float value);
void print(int value);
 
W value; // объявляем переменную value типа класса W
print(value); // value конвертируется в int и, следовательно, соответствует print(int)

```
Хотя value относится к типу класса W, но, поскольку тот имеет пользовательское преобразование в тип int, вызов print(value) соответствует версии print(int).

## Несколько совпадений
Поскольку все стандартные и пользовательские преобразования считаются равными, то, если вызов функции соответствует нескольким кандидатам посредством стандартного или пользовательского преобразования, результатом будет неоднозначное совпадение (т.е. несколько совпадений):
```c

void print(unsigned int value);
void print(float value);
 
print('b');
print(0);
print(3.14159);

```
В случае с print('b') C++ не может найти точного совпадения. Он пытается преобразовать b в тип int, но версии print(int) тоже нет. Используя стандартное преобразование, C++ может преобразовать b как в unsigned int, так и во float. Поскольку все стандартные преобразования считаются равными, то получается два совпадения.

С print(0) всё аналогично. 0 — это int, а версии print(int) нет. Путем стандартного преобразования мы опять получаем два совпадения.

по умолчанию все значения-литералы типа с плавающей запятой относятся к типу double, если у них нет окончания f. print(3.14159) 3.14159 — это значение типа double, а версии print(double) нет. Следовательно, мы получаем ту же ситуацию, что и в предыдущих случаях — неоднозначное совпадение (два варианта).

Неоднозначное совпадение считается ошибкой типа compile-time. Следовательно, оно должно быть устранено до того, как ваша программа скомпилируется. Есть два решения этой проблемы:

1. Просто определить новую перегруженную функцию, которая принимает параметры именно того типа данных, который вы используете в вызове функции. Тогда C++ сможет найти точное совпадение.

2. Явно преобразовать с помощью операторов явного преобразования неоднозначный параметр(ы) в соответствии с типом функции, которую вы хотите вызвать. Например, чтобы вызов print(0) соответствовал print(unsigned int), вам нужно сделать следующее:
```c

print(static_cast<unsigned int>(0)); // произойдет вызов print(unsigned int)

```
## Перегрузка операторов

В языке C++ операторы реализованы в виде функций. Используя перегрузку функции оператора, вы можете определить свои собственные версии операторов, которые будут работать с разными типами данных (включая классы). Использование перегрузки функции для перегрузки оператора называется перегрузкой оператора.
```c

int a = 5;
int b = 6;
std::cout << a + b << '\n';

```
Здесь компилятор использует встроенную версию оператора плюс (+) для целочисленных операндов — эта функция сложит два целочисленных значения (a и b), и возвратит целочисленный результат. 
выражение a + b - вызов функции operator+(a, b) (где operator+ является именем функции).

следующий фрагмент:
```c

double m = 4.0;
double p = 5.0;
std::cout << m + p << '\n';

```
Компилятор также предоставит встроенную версию оператора плюс (+) для операндов типа double. Выражение m + p приведет к вызову функции operator+(m, p), а, благодаря перегрузке оператора, вызовется версия double (вместо версии int).

что произойдет, если мы попытаемся добавить два объекта класса:
```c

Mystring hello = "Hello, ";
Mystring world = "World!";
std::cout << hello + world << '\n';

```
результатом будет ошибка, так как класс Mystring является пользовательским типом данных, а компилятор не имеет встроенной версии operator+() для использования с операндами Mystring. Для того, чтобы сделать то, что мы хотим, нам придется написать свою версию функции operator+() и указать в ней алгоритм работы с операндами типа Mystring.

## Вызов перегруженных операторов
При обработке выражения, содержащего оператор, компилятор использует следующие алгоритмы действий:
- Если все операнды являются фундаментальных типов данных, то вызывать следует встроенные соответствующие версии операторов (если таковые существуют). Если таковых не существует, то компилятор выдаст ошибку.

- Если какой-либо из операндов является пользовательского типа данных (например, объект класса или перечисление), то компилятор будет искать версию оператора, которая работает с таким типом данных. Если компилятор не найдет ничего подходящего, то попытается выполнить конвертацию одного или нескольких операндов пользовательского типа данных в фундаментальные типы данных, чтобы таким образом он мог использовать соответствующий встроенный оператор. Если это не сработает — компилятор выдаст ошибку.

## Ограничения в перегрузке операторов
почти любой существующий оператор в языке C++ может быть перегружен. 
Исключениями являются:
```
- тернарный оператор (?:);
- оператор sizeof;
- оператор разрешения области видимости (::);
- оператор выбора члена (.);
-указатель, как оператор выбора члена (.*).

```
## можно перегрузить только существующие операторы. 
Вы не можете создавать новые или переименовывать существующие. Например, вы не можете создать оператор ** для выполнения операции возведения в степень.

по крайней мере один из операндов перегруженного оператора должен быть пользовательского типа данных. Это означает, что вы не можете перегрузить operator+() для выполнения операции сложения значения типа int со значением типа double. Однако вы можете перегрузить operator+() для выполнения операции сложения значения типа int с объектом класса Mystring.

изначальное количество операндов, поддерживаемых оператором, изменить невозможно. Т.е. с бинарным оператором используются только два операнда, с унарным — только один, с тернарным — только три.

все операторы сохраняют свой приоритет и ассоциативность по умолчанию (независимо от того, для чего они используются), и это не может быть изменено.

В C++ у оператора ^ приоритет ниже, чем у базовых арифметических операторов, и это приведет к некорректной обработке выражений.

В математике операция возведения в степень выполняется до выполнения базовых арифметических операций, поэтому 2 + 5 ^ 2 обрабатывается как 2 + (5 ^ 2) => 2 + 25 => 27. Однако в C++ у базовых арифметических операторов приоритет выше, нежели у оператора ^, поэтому 2 + 5 ^ 2 выполнится как (2 + 5) ^ 2 => 7 ^ 2 => 49.

Вам нужно будет явно заключать в скобки часть с возведением в степень (например, 2 + (5 ^ 2)) каждый раз, когда вы хотите, чтобы она выполнялась первой. Поэтому проводить подобные эксперименты не рекомендуется.

В C++ для возведения в степень используется функция pow() из заголовочного файла cmath. 

При перегрузке операторов старайтесь максимально приближенно сохранять функционал операторов в соответствии с их первоначальными применениями.

## Перегрузка операторов через функции
```c

#include <iostream>
 
class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  int getDollars() const { return m_dollars; }
};
 
// Эта функция не является методом класса Dollars
Dollars operator+(const Dollars &d1, const Dollars &d2)
{
  // Используем конструктор Dollars и operator+(int, int).
    // Здесь нам не нужен прямой доступ к закрытым членам класса Dollars
  return Dollars(d1.getDollars() + d2.getDollars());
}
 
int main()
{
  Dollars dollars1(7);
  Dollars dollars2(9);
  Dollars dollarsSum = dollars1 + dollars2;
  std::cout << "I have " << dollarsSum.getDollars() << " dollars." << std::endl;
 
  return 0;
}

```
обычную функцию достаточно просто определить вне тела класса, без указания дополнительного прототипа функции.
```c

Dollars.h:

class Dollars
{
private:
  int m_dollars;
 
public:
  Dollars(int dollars) { m_dollars = dollars; }
 
  int getDollars() const { return m_dollars; }
};
 
// Указываем прототип operator+(), чтобы иметь возможность использовать перегруженный оператор + в других файлах
Dollars operator+(const Dollars &d1, const Dollars &d2);
Dollars.cpp:

#include "Dollars.h"
 
// Эта функция не является методом класса
Dollars operator+(const Dollars &d1, const Dollars &d2)
{
  // Используем конструктор Dollars и operator+(int, int).
    // Здесь нам не нужен прямой доступ к закрытым членам класса Dollars
  return Dollars(d1.getDollars() + d2.getDollars());
}
main.cpp:

#include <iostream>
#include "Dollars.h"
 
int main()
{
  Dollars dollars1(7);
  Dollars dollars2(9);
  Dollars dollarsSum = dollars1 + dollars2; // без явного указания прототипа operator+() в Dollars.h эта строка не скомпилировалась бы
  std::cout << "I have " << dollarsSum.getDollars() << " dollars." << std::endl;
 
  return 0;
}


```
## Перегрузка операторов через методы класса

### перегрузка оператора +:
```c

#include <iostream>
 
class Dollars
{
private:
    int m_dollars;
 
public:
    Dollars(int dollars) { m_dollars = dollars; }
 
    // Выполняем Dollars + int
    Dollars operator+(int value);
 
    int getDollars() { return m_dollars; }
};
 
// Эта функция является методом класса

Dollars Dollars::operator+(int value)
{
    return Dollars(m_dollars + value);
}
 
int main()
{
  Dollars dollars1(7);
  Dollars dollars2 = dollars1 + 3;
  std::cout << "I have " << dollars2.getDollars() << " dollars.\n";
 
  return 0;
}

```
Операторы присваивания (=), индекса ([]), вызова функции (()) и выбора члена (->) перегружаются через методы класса — это требование языка C++.

## Перегрузка унарных операторов +, — и логического НЕ

унарные операторы плюс (+), минус (-) и логическое НЕ (!) работают с одним операндом. Так как они применяются только к одному объекту, то их перегрузку следует выполнять через методы класса.

## унарный оператор минус (-) для класса Dollars:
```c

#include <iostream>
 
class Dollars
{
private:
    int m_dollars;
 
public:
    Dollars(int dollars) { m_dollars = dollars; }
 
    // Выполняем -Dollars через метод класса
    Dollars operator-() const;
 
    int getDollars() const { return m_dollars; }
};
 
// Эта функция является методом класса!
Dollars Dollars::operator-() const
{
    return Dollars(-m_dollars);
}
 
int main()
{
    const Dollars dollars1(7);
    std::cout << "My debt is " << (-dollars1).getDollars() << " dollars.\n";
 
    return 0;
}
// Перегрузка отрицательного унарного оператора минус (-) осуществляется через метод класса, так как явные параметры в функции перегрузки отсутствуют (только неявный объект, на который указывает скрытый указатель *this). Оператор - возвращает объект Dollars с отрицательным значением m_dollars. Поскольку этот оператор не изменяет объект класса Dollars, то мы можем (и должны) сделать функцию перегрузки константной (чтобы иметь возможность использовать этот оператор и с константными объектами класса Dollars).

```
Определение метода можно записать и внутри класса.

путаницы между отрицательным унарным оператором минус (-) и бинарным оператором минус (-) нет, так как они имеют разное количество параметров.
## оператор !
оператор ! является логическим оператором НЕ, который возвращает true, если результатом выражения является false и возвращает false, если результатом выражения является true. Обычно это применяется к переменным типа bool, чтобы проверить, являются ли они true или нет:
```c

if (!isHappy)
    std::cout << "I am not happy!\n";
else
    std::cout << "I am so happy!\n";

```
В языке С++ значение 0 обозначает false, а любое другое ненулевое значение обозначает true, поэтому, если логический оператор ! применять к целочисленным значениям, то он будет возвращать true, если значением переменной является 0, в противном случае — false.

Следовательно, при работе с классами, оператор ! будет возвращать true, если значением объекта класса является false, 0 или любое другое значение, заданное как дефолтное (по умолчанию) при инициализации, в противном случае — оператор ! будет возвращать false.

Перегрузка унарного оператора минус (−) и оператора логического НЕ (!) для класса Something:
```c

#include <iostream>
 
class Something
{
private:
  double m_a, m_b, m_c;
 
public:
  Something(double a = 0.0, double b = 0.0, double c = 0.0) :
    m_a(a), m_b(b), m_c(c)
  {
  }
 
  // Конвертируем объект класса Something в отрицательный 
  Something operator- () const
  {
    return Something(-m_a, -m_b, -m_c);
  }
 
  // Возвращаем true, если используются значения по умолчанию, в противном случае - false
  bool operator! () const
  {
    return (m_a == 0.0 && m_b == 0.0 && m_c == 0.0);
  }
 
  double getA() { return m_a; }
  double getB() { return m_b; }
  double getC() { return m_c; }
};
 
 
 
int main()
{
  Something something; // используем конструктор по умолчанию со значениями 0.0, 0.0, 0.0
 
  if (!something)
    std::cout << "Something is null.\n";
  else
    std::cout << "Something is not null.\n";
 
  return 0;
}

```
Здесь перегруженный оператор НЕ (!) возвращает true, если в Something используются значения по умолчанию (0.0, 0.0, 0.0).

Результат выполнения программы:

Something is null.

Если же задать любые ненулевые значения для объекта класса Something:

Something something(23.11, 37.1, 20.12);
То результатом будет:

Something is not null.


### Перегрузка унарного оператора плюс (+) для класса Something.

Есть два решения.

1:
```c

Something Something::operator+ () const
{
    return Something(m_a, m_b, m_c);
}

```
2:
```c

Something Something::operator+ () const
{
    return *this;
}

```

## Перегрузка операторов инкремента и декремента
Есть две версии операторов инкремента и декремента: версия префикс (например, ++x, --y) и версия постфикс (например, x++, y--).

Поскольку операторы инкремента и декремента являются унарными и изменяют свои операнды, то перегрузку следует выполнять через методы класса.

### Перегрузка операторов инкремента и декремента версии префикс
Перегрузка операторов инкремента и декремента версии префикс аналогична перегрузке любых других унарных операторов:
```c

#include <iostream>
 
class Number
{
private:
    int m_number;
public:
    Number(int number=0)
        : m_number(number)
    {
    }
 
    Number& operator++();
    Number& operator--();
 
    friend std::ostream& operator<< (std::ostream &out, const Number &n);
};
 
Number& Number::operator++()
{
    // Если значением переменной m_number является 8, то выполняем сброс значения m_number на 0
    if (m_number == 8)
        m_number = 0;
    // В противном случае, просто увеличиваем m_number на единицу
    else
        ++m_number;
 
    return *this;
}
 
Number& Number::operator--()
{
    // Если значением переменной m_number является 0, то присваиваем m_number значение 8
    if (m_number == 0)
        m_number = 8;
    // В противном случае, просто уменьшаем m_number на единицу
    else
        --m_number;
 
    return *this;
}
 
std::ostream& operator<< (std::ostream &out, const Number &n)
{
  out << n.m_number;
  return out;
}
 
int main()
{
    Number number(7);
 
    std::cout << number;
    std::cout << ++number;
    std::cout << ++number;
    std::cout << --number;
    std::cout << --number;
 
    return 0;
}


// Здесь класс Number содержит число от 0 до 8. Мы перегрузили операторы инкремента/декремента таким образом, чтобы они увеличивали/уменьшали m_number в соответствии с заданным диапазоном (если выполняется инкремент и m_number равно 8, то сбрасываем значение m_number на 0; если выполняется декремент и m_number равно 0, то присваиваем значение 8 переменной m_number).

// Результат выполнения программы:

// 78087

// мы возвращаем скрытый указатель *this в функциях перегрузки операторов (т.е. текущий объект класса Number). Таким образом мы можем связать выполнение нескольких операторов в одну «цепочку».


```

### Перегрузка операторов инкремента и декремента версии постфикс

Обычно перегрузка функций осуществляется, если они имеют одно и то же имя, но разное количество и типы параметров. Рассмотрим случай с операторами инкремента/декремента версий префикс/постфикс. Оба имеют одно и то же имя (например, operator++), унарные и принимают один параметр одного и того же типа данных. Как  их различить при перегрузке?

Дело в том, что язык C++ использует фиктивную переменную (или фиктивный параметр) для операторов версии постфикс. Этот фиктивный целочисленный параметр используется только с одной целью: отличить версию постфикс операторов инкремента/декремента от версии префикс. Выполним перегрузку операторов инкремента/декремента версии префикс и постфикс в одном классе:
```c

#include <iostream>
 
class Number
{
private:
    int m_number;
public:
    Number(int number=0)
        : m_number(number)
    {
    }
 
    Number& operator++(); // версия префикс
    Number& operator--(); // версия префикс
 
    Number operator++(int); // версия постфикс
    Number operator--(int); // версия постфикс
 
    friend std::ostream& operator<< (std::ostream &out, const Number &n);
};
 
Number& Number::operator++()
{
    // Если значением переменной m_number является 8, то выполняем сброс значения m_number на 0
    if (m_number == 8)
        m_number = 0;
    // В противном случае, просто увеличиваем m_number на единицу
    else
        ++m_number;
 
    return *this;
}
 
Number& Number::operator--()
{
    // Если значением переменной m_number является 0, то присваиваем m_number значение 8
    if (m_number == 0)
        m_number = 8;
    // В противном случае, просто уменьшаем m_number на единицу
    else
        --m_number;
 
    return *this;
}
 
Number Number::operator++(int)
{
    // Создаем временный объект класса Number с текущим значением переменной m_number
    Number temp(m_number);
 
    // Используем оператор инкремента версии префикс для реализации перегрузки оператора инкремента версии постфикс
    ++(*this); // реализация перегрузки
 
    // Возвращаем временный объект
    return temp;
}
 
Number Number::operator--(int)
{
    // Создаем временный объект класса Number с текущим значением переменной m_number
    Number temp(m_number);
 
    // Используем оператор декремента версии префикс для реализации перегрузки оператора декремента версии постфикс
    --(*this); // реализация перегрузки
 
    // Возвращаем временный объект
    return temp; 
}
 
std::ostream& operator<< (std::ostream &out, const Number &n)
{
  out << n.m_number;
  return out;
}
 
int main()
{
    Number number(6);
 
    std::cout << number;
    std::cout << ++number; // вызывается Number::operator++();
    std::cout << number++; // вызывается Number::operator++(int);
    std::cout << number;
    std::cout << --number; // вызывается Number::operator--();
    std::cout << number--; // вызывается Number::operator--(int);
    std::cout << number;
 
    return 0;
}
Результат выполнения программы:

6778776

```
1. мы отделили версию постфикс от версии префикс использованием целочисленного фиктивного параметра в версии постфикс.

2. поскольку фиктивный параметр не используется в реализации самой перегрузки, то мы даже не предоставляем ему имя. Таким образом, компилятор будет рассматривать эту переменную, как простую заглушку (заполнитель места), и даже не будет предупреждать нас о том, что мы объявили переменную, но никогда её не использовали.

3. операторы версий префикс и постфикс выполняют одно и то же задание: оба увеличивают/уменьшают значение переменной объекта. Разница между ними только в значении, которое они возвращают.

Операторы версии префикс возвращают объект после того, как он был увеличен или уменьшен. В версии постфикс нам нужно возвращать объект до того, как он будет увеличен или уменьшен. Если мы увеличиваем или уменьшаем объект, то мы не можем возвратить его до выполнения инкремента/декремента, так как операция увеличения/уменьшения уже произошла. С другой стороны, если мы возвращаем объект до выполнения инкремента/декремента, то сама операция увеличения/уменьшения объекта не выполнится.

Решением является использование временного объекта с текущим значением переменной-члена. Тогда можно будет увеличить/уменьшить исходный объект, а временный объект возвратить обратно в caller. Таким образом, caller получит копию объекта до того, как фактический объект будет увеличен или уменьшен, и сама операция инкремента/декремента выполнится успешно.

это означает, что возврат значения по ссылке невозможен, так как мы не можем возвратить ссылку на локальную переменную (объект), которая будет уничтожена после завершения выполнения тела функции. Также это означает, что операторы версии постфикс обычно менее эффективны, чем операторы версии префикс, из-за дополнительных расходов ресурсов на создание временного объекта и выполнения возврата по значению вместо возврата по ссылке.
