#include "stdafx.h"
#include <fstream>
#include <iostream>
#include <ctime>
#include <cstdlib>
#include <stdio.h>
#include <iomanip>

#include <thread>
using namespace std;



//функція з умови x*x + y*y
double myfunction(double x0, double y0)
{
	return x0*x0 + y0*y0;
};


int main()
{
	srand(time(NULL));
	int nmax; // кількість ітерацій
	cout << "Write n = ";
	cin >> nmax;

	double result;
	double summ = 0;

	const double x_min = 0.5;
	const double x_max = 1;
	const double y_min = 0;
	const double y_max = x_max * 2 - 1;

	double x_now;
	double y_now;

	double y_h;

	for (int i = 1; i <= nmax; i++)
	{
		//випадкові x,y
		x_now = x_min + (x_max - x_min)*rand() / RAND_MAX;
		y_now = y_min + (y_max- y_min)*rand() / RAND_MAX;

		y_h = x_now * 2 - 1;
		if (y_now > y_min && y_now < y_h)
			summ +=myfunction(x_now,y_now);

	//	cout << i << "  " << x_now << " " << y_now << endl;
	};

	result = summ * (x_max - x_min)*(y_max - y_min) / nmax;
	cout << "Result is " << result << endl;

	system("Pause");
	return 0;
}


