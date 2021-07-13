/*
 * Human.h
 *
 *  Created on: 13 июл. 2021 г.
 *      Author: janus
 */
#include <string>

#ifndef HUMAN_H_
#define HUMAN_H_

class Human {
public:
	std::string name;
    int age;

    Human(std::string n = "", int a = 0);

    std::string getName() const { return name; }
    int getAge() const { return age; }

};

#endif /* HUMAN_H_ */
