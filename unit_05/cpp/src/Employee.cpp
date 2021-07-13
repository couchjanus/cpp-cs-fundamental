/*
 * Employee.cpp
 *
 *  Created on: 13 июл. 2021 г.
 *      Author: janus
 */
#include <iostream>

#include "Human.h"

class Employee: public Human
{
public:
    int salary;
    long employeeID;

    Employee(int wage = 0, long id = 0)
        : salary(wage), employeeID(id)
    {
    }

    void printNameAndWage() const
    {
        std::cout << name << ": " << salary << '\n';
    }
};
