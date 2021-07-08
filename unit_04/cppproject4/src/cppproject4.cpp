//============================================================================
// Name        : cppproject4.cpp
// Author      : Janus
// Version     :
// Copyright   : Your copyright notice
// Description : Hello World in C++, Ansi-style
//============================================================================

#include <iostream>

using namespace std;
struct DateStruct
{
    int day; // открыто по умолчанию, доступ имеет любой объект
    int month; // открыто по умолчанию, доступ имеет любой объект
    int year; // открыто по умолчанию, доступ имеет любой объект
};
void print(DateStruct &date)
{
    std::cout << date.day<< "/" << date.month << "/" << date.year;
}

class DateClass
{
//	   int m_day; // закрыто по умолчанию, доступ имеют только другие члены класса
//	   int m_month; // закрыто по умолчанию, доступ имеют только другие члены класса
//	   int m_year; // закрыто по умолчанию, доступ имеют только другие члены класса
public:
    int m_day;
    int m_month;
    int m_year;

public:
    void setDate(int day, int month, int year) // открыто, доступ имеет любой объект
    {
        // Метод setDate() имеет доступ к закрытым членам класса, так как сам является членом класса
        m_day = day;
        m_month = month;
        m_year = year;
    }

    void print()
    {
        std::cout << m_day << "/" << m_month << "/" << m_year;
    }

    void copyFrom(const DateClass &b)
      {
        // Мы имеем прямой доступ к закрытым членам объекта b
        m_day = b.m_day;
        m_month = b.m_month;
        m_year = b.m_year;
      }

public:
    int getDay() { return m_day; } // геттер для day
    void setDay(int day) { m_day = day; } // сеттер для day

    int getMonth() { return m_month; } // геттер для month
    void setMonth(int month) { m_month = month; } // сеттер для month

    int getYear() { return m_year; } // геттер для year
    void setYear(int year) { m_year = year; } // сеттер для year
};

class Employee
{
public:
    std::string m_name;
    int m_id;
    double m_wage;

    // Метод вывода информации о работнике на экран
    void print()
    {
        std::cout << "Name: " << m_name <<
                "\nId: " << m_id <<
                "\nWage: $" << m_wage << '\n';
    }
};

class MyString
{
//    char *m_string; // динамически выделяем строку
//    int m_length; // используем переменную для отслеживания длины строки

private:
    char *m_string; // динамически выделяем строку
    int m_length; // используем переменную для отслеживания длины строки

public:
    int getLength() { return m_length; } // функция доступа для получения значения m_length
};

class IntArray
{

private:
    int m_array[10]; // пользователь не имеет прямого доступа к этому члену

public:
    void setValue(int index, int value)
    {
        // Если индекс недействителен, то не делаем ничего
        if (index < 0 || index >= 10)
            return;

        m_array[index] = value;
    }
};

class Values
{
public:
    int m_number1;
    int m_number2;
    int m_number3;
public:
    void setNumber1(int number) { m_number1 = number; }
    int getNumber1() { return m_number1; }
};

class Boo
{
public:
    int m_a;
    int m_b;
};

class Fraction
{
private:
    int m_numerator;
    int m_denominator;

public:
    Fraction() // конструктор по умолчанию
    {
         m_numerator = 0;
         m_denominator = 1;
    }

    int getNumerator() { return m_numerator; }
    int getDenominator() { return m_denominator; }
    double getValue() { return static_cast<double>(m_numerator) / m_denominator; }
};

class Fraction1
{
private:
    int m_numerator;
    int m_denominator;

public:
    Fraction1() // конструктор по умолчанию
    {
         m_numerator = 0;
         m_denominator = 1;
    }

    // Конструктор с двумя параметрами, один из которых имеет значение по умолчанию
    Fraction1(int numerator, int denominator=1)
    {
//        assert(denominator != 0);
        m_numerator = numerator;
        m_denominator = denominator;
    }

    int getNumerator() { return m_numerator; }
    int getDenominator() { return m_denominator; }
    double getValue() { return static_cast<double>(m_numerator) / m_denominator; }
};

int main() {
    DateStruct today { 12, 11, 2018}; // используем uniform-инициализацию

    today.day = 18; // используем оператор выбора члена для выбора члена структуры
    print(today);

    today.day = 12;
    today.month = 11;
    today.year = 2018;

    DateClass toDay { 12, 11, 2018 };

    toDay.m_day = 18; // используем оператор выбора членов для выбора переменной-члена m_day объекта today класса DateClass
    toDay.print(); // используем оператор выбора членов для вызова метода print() объекта today класса DateClass

    DateClass copy;
    copy.copyFrom(toDay); // ок, так как copyFrom() имеет спецификатор доступа public
    copy.print();

    // Определяем двух работников
    Employee john { "John", 5, 30.00 };
    Employee max { "Max", 6, 32.75 };

    // Выводим информацию о работниках на экран
    john.print();
    std::cout<<std::endl;
    max.print();

    Values value;
    value.m_number1 = 7;
    std::cout << value.m_number1 << '\n';

    value.setNumber1(7);
    std::cout << value.getNumber1() << '\n';


	cout << "!!!Hello World!!!" << endl; // prints !!!Hello World!!!

    Boo boo1 = { 7, 8 }; // список инициализаторов
    Boo boo2 { 9, 10 }; // uniform-инициализация (C++11)

    Fraction drob; // так как нет никаких аргументов, то вызывается конструктор по умолчанию Fraction()
    std::cout << drob.getNumerator() << "/" << drob.getDenominator() << '\n';

    int a(7); // прямая инициализация
    Fraction1 drob1(4, 5); // инициализируем напрямую, вызывается конструктор Fraction(int, int)

//    int a { 7 }; // uniform-инициализация
//    Fraction1 drob2 {4, 5}; // uniform-инициализация, вызывается конструктор Fraction(int, int)

	return 0;
}
