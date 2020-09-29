#include "stdafx.h"
#include <fstream>
#include <iostream>
#include <windows.h>
#include <locale>
using namespace std;




void create()
{
	std::cout << "Using only <<F>> and <<B>>" << endl;
	string s;
	cin >> s;
	
	string res;			// K and O
	int max = s.length();
	int center;
	string x;
	for (int i = max-1; i >= 0 ;i--)
	{
		cout << s[i] << "    ";
		center = res.size() - 1 ;

		if (s[i] == 'B')
		{
			res = res + "K";
			for (int j = center; j >= 0; j--)
			{
				x = res[j];
				if (x == "K")
					res = res + "O";
				if (x == "O")
					res = res + "K";
			};
		}
		else
		if (s[i] == 'F')
		{
			res = res + "O";
			for (int j = center; j >= 0; j--)
			{
				x = res[j];
				if (x == "K")
					res = res + "O";
				if (x == "O")
					res = res + "K";
			};
		}
		cout << res << endl;
	}
}

void recreate()
{
	cout << "Using only <<K>> and <<O>>" << endl;
	string s;
	cin >> s;

	string res;			// F and B
	bool t = true;
	int i = (s.length()-1) / 2;
	int last = i;
	if (i % 2 == 0)
	{
		t = false;
		cout <<"ERROR: string is %2" << endl;
	};
	if(t)
		while ((i != 0 || last != 0) && t)
		{
			for (int j = 0; j < i; j++)
			{
				if (s[j] == s[s.length() - j])
					t = false;
			};
			if (t)
			{
				if (s[i] == 'K')
					res = res + "B";
				if (s[i] == 'O')
					res = res + "F";
			}
			last = i;
			i = (i - 1) / 2;
			if (i % 2 == 0 && i != 0)
				t = false;
			cout << res << endl;
		}

	if(!t)
		cout << "ERROR!" << endl;
}





int main()
{
	setlocale(LC_ALL, "Russian");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	std::wcout.imbue(std::locale("rus_rus.866"));
	std::wcin.imbue(std::locale("rus_rus.866"));

	cout << "Write <<A>> or <<B>> for new operation" << endl;
	char operation;
	cin >> operation;
	if (operation == 'A')
	{
		create();
	};

	if (operation == 'B')
	{
		recreate();
	};

	system("Pause");
	return 0;
}

