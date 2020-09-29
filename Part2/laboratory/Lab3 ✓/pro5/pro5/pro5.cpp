#include "stdafx.h"
#include <fstream>
#include <iostream>
#include <ctime>
#include <cstdlib>
#include <stdio.h>
#include <iomanip>

#include <thread>
using namespace std;

const int nmax = 20;
int Delta[nmax];
struct  matrix
{
	int a[nmax][nmax];
	int N;
};

matrix mymatrix;

matrix getmatrix()
{
	matrix res;
	int i, j;

	cout << "Write N =  ";
	cin >> res.N;
	cout << "--------------------------------------------" << endl;


	for (i = 1; i <= res.N; i++)
	{
		cout << i << ") ";
		for (j = 1; j <= res.N + 1; j++)
		{
			if (j <= res.N)
			{
				cout << "a " << i << "/" << j << " =  ";
				cin >> res.a[i][j];
			}
			else
			{
				cout << "b " << i << " =  ";
				cin >> res.a[i][j];
			}
		};
	};
	cout << "--------------------------------------------" << endl;
	cout << endl;
	return res;
}
matrix getrandmatrix()
{
	matrix res;
	int i, j;

	cout << "Write N =  ";
	cin >> res.N;
	cout << "--------------------------------------------" << endl;


	for (i = 1; i <= res.N; i++)
	{
		for (j = 1; j <= res.N + 1; j++)
		{
			res.a[i][j] = rand() % 10 - 5;
		};
	};


	cout << "--------------------------------------------" << endl;
	cout << endl;
	return res;
}

void printx(matrix now)
{
	int i, j;

	for (i = 1; i <= now.N; i++)
	{
		cout << i << ")   ";
		for (j = 1; j <= now.N + 1; j++)
		{
			if (j <= now.N)
			{
				if (j != 1)
					if (now.a[i][j] > 0)
						cout << "+";

				cout << now.a[i][j];
				cout << "*x" << j << " ";
			}
			else
			{
				cout << "  =  " << now.a[i][j];
			}
		};
		cout << endl;
	};
	cout << "--------------------------------------------" << endl;
	cout << endl;
}
void printmatrix(matrix now)
{
	int i, j;

	for (i = 1; i <= now.N; i++)
	{
		cout << "( ";
		for (j = 1; j <= now.N + 1; j++)
		{
			if (j <= now.N)
			{
				cout << now.a[i][j] << "  ";
			}
			else
			{

				cout << "  |  " << now.a[i][j];
			}
		};
		cout << " )" << endl;
	};
	cout << "--------------------------------------------" << endl;
	cout << endl;
}

matrix getnew(matrix now, int sign)
{
	matrix res;
	int i, j;
	int wight = 0;


	res.N = now.N - 1;

	for (i = 1; i <= now.N; i++)
		if (i != sign)
		{
			wight++;
			for (j = 1; j <= now.N - 1; j++)
			{
				res.a[wight][j] = now.a[i][j + 1];
			};
		};
	return res;
}

int recsumm(matrix now)
{
	int res = 0;
	int i;
	if (now.N > 1)
		for (i = 1; i <= now.N; i++)
		{
			res += pow(-1, 1 + i) * now.a[i][1] * recsumm(getnew(now, i));
		}
	else
	{
		if (now.N == 1)
			res = now.a[1][1];
	};

	return res;
}

void isthr(matrix now, int i)
{
int res = recsumm(now);
Delta[i] = res;
};


void Kramer(matrix now)
{
	float X[nmax];
	int i, j;
	matrix temp = now;

	thread thr[nmax + 2];
	thr[1] = thread(isthr,temp,0);
	for (i = 1; i <= now.N; i++)
	{
		temp = now;
		for (j = 1;j <= now.N; j++)
			temp.a[j][i] = temp.a[j][temp.N + 1];
		thr[i+1] = thread(isthr, temp, i);
	};

	bool t = true;
	while(t)
	{ 
		t = false;
		for (i = 1; i < now.N + 2; i++)
			if (thr[i].joinable())
			{
				thr[i].join();
				t = true;
				cout << i - 1 << ": " << Delta[i -1 ] << endl;
			};
	};
	for ( i = 1; i < now.N +1 ; i++)
	{
		//cout << i << ": " << Delta[i] << endl;
		if (Delta[0] != 0)
			X[i] = float(Delta[i]) / float(Delta[0]);
	};


	if (Delta[0] == 0)
		cout << "Error !!!" << endl;
	else
		for (i = 1; i <= now.N; i++)
		{
			cout << endl << "x " << i << "  = ";
			cout.setf(ios::fixed);
			cout << setprecision(5) << X[i];
		}
	cout << endl << "end" << endl;
};

int main()
{
	srand(time(NULL));
	mymatrix = getrandmatrix();
	printx(mymatrix);
	printmatrix(mymatrix);
	Kramer(mymatrix);
	system("Pause");
	return 0;
}

