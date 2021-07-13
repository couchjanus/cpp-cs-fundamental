//============================================================================
// Name        : cppunit06.cpp
// Author      : Janus
// Version     :
// Copyright   : Your copyright notice
// Description : Hello World in C++, Ansi-style
//============================================================================

#include <iostream>
#include "Student.cpp"
#include "Employee.cpp"

//Класс Child состоит из двух частей: часть Parent и часть Child. Когда C++ создает объекты дочерних классов, то он делает это поэтапно. Сначала создается самый верхний класс иерархии (родитель). Затем создается дочерний класс, который идет следующим по порядку, и так до тех пор, пока не будет создан последний класс (тот, который находится в самом низу иерархии).

//Поэтому, при создании объекта класса Child, сначала создается часть Parent класса Child (с использованием конструктора по умолчанию класса Parent) и после создается вторая часть Child (с использованием конструктора по умолчанию класса Child).

class Parent
{
public:
    int m_id;

    Parent(int id=0)
        : m_id(id)
    {
        std::cout << "Parent\n";
    }

    int getId() const { return m_id; }
};

class Child: public Parent
{
public:
    double m_value;

    Child(double value=0.0)
        : m_value(value)
    {
        std::cout << "Child\n";
    }

    double getValue() const { return m_value; }
};


class A
{
public:
    A()
    {
        std::cout << "A\n";
    }
};

class B: public A
{
public:
    B()
    {
        std::cout << "B\n";
    }
};

class C: public B
{
public:
    C()
    {
        std::cout << "C\n";
    }
};

class D: public C
{
public:
    D()
    {
        std::cout << "D\n";
    }
};

using namespace std;

int main() {
	// Создаем нового student
	Student anton;
	// Присваиваем ему имя (мы можем делать это напрямую, так как m_name является public)
	anton.name = "Anton";
	// Выводим имя student
	std::cout << anton.getName() << '\n'; // используем метод getName(),
	// который мы унаследовали от класса Human

	Employee ivan(350, 787);
	ivan.name = "Ivan"; // мы можем это сделать, так как m_name является public

	ivan.printNameAndWage();

    std::cout << "Instantiating Parent:\n";
//    Parent dParent;

    std::cout << "Instantiating Child:\n";
//    Child dChild;

    std::cout << "Constructing A: \n";
//    A cA;

    std::cout << "Constructing B: \n";
//    B cB;

    std::cout << "Constructing C: \n";
//    C cC;

    std::cout << "Constructing D: \n";
//    D cD;

	return 0;
}
