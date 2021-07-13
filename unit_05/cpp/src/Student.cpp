/*
 * Student.cpp
 *
 *  Created on: 13 июл. 2021 г.
 *      Author: janus
 */

#include "Human.h"

class Student: public Human {
public:
	double rateAverage;
	    int rate;

	    Student(double average = 0.0, int r = 0)
	       : rateAverage(average), rate(r)
	    {
	    }
};
