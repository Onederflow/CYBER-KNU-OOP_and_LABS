#include "stdafx.h"
#include <conio.h>
#include <iostream>
#include <ctime>
using namespace std;


struct Node
{
	int data;
	Node *next;
};

class  MyList
{
public:
	Node *head = NULL;
	Node *L1;
	Node *L2;


	void AddNode(Node *&now,int data)
	{
		if (now == NULL)
		{
			now = new Node();
			now->data = data;
		}
		else
		{
			AddNode(now->next, data);
		};
	}
	void AddNode(Node *&now, Node *temp)
	{
		if (now == NULL)
		{
			now = temp;
		}
		else
		{
			AddNode(now->next, temp);
		};

	}
	void WriteList(Node *now)
	{
		if (now == head)
		{
			cout << "List : ";
		};
		if (now != NULL)
		{
			cout << now->data << "  ";
			WriteList(now->next);
		}
		else
			cout << endl;
	}
	void DeleteNode(Node *&now, int data)
	{
		if (now != NULL && now == head)
		{
			if (now->data == data)
				now = now->next;
		};

		if (now->next != NULL)
		{
			if (now->next->data == data)
			{
				now->next = now->next->next;
				cout << data << " is deleted!" << endl;
			}
			else
			{
			DeleteNode(now->next, data);
			};
		};
		if (now == NULL)
			cout << "End." << endl;
	}
	void InsertNode(Node *&now, int data, int after)
	{
		if (now == NULL && now == head)
		{
			now->data = data;
		}
		else
			if (now->next != NULL)
			{
				if (now->data == after)
				{
					Node *Temp = now->next;
					now->next = new Node();
					now->next->data = data;
					now->next->next = Temp;
					Temp = NULL;
					cout << data << " is added!" << endl;
				}
				else
				{
					InsertNode(now->next, data , after);
				};
			};
		if (now == NULL)
			cout << "End." << endl;
	}
	void To_other(Node *now,int N)
	{
		Node *temp = NULL;
		if (now != NULL)
		{
			if (now->next != NULL)
				temp = now->next;
			now->next = NULL;
			if (now->data > N)
				AddNode(L1, now);
			else
				AddNode(L2, now);
			To_other(temp, N);
		}
	}
	void Null_Node(Node *&now)
	{
		if (now != NULL)
		{
			Null_Node(now->next);
			now = NULL;
		};
	}

};


bool Main_all();
void Comands(int num);

MyList List;
int main()
{
	srand(time(0));
	while (Main_all())
	{
		system("Pause");
	}
    return 0;
}

bool Main_all()
{
	bool working = true;
	int num;
	cout << endl;
	cout << "Press '1' to add node" << endl;
	cout << "Press '2' to delete node" << endl;
	cout << "Press '3' to insert" << endl;
	cout << "Press '4' to add list ->L1,L2" << endl;
	cout << "Press '5' to NULL" << endl;
	cout << "print n < 0 to generation (-n) new random items" << endl;
	cout << "Press '0' to quite" << endl;
	cin >> num;
	Comands(num);
	if (num == 0)
		working = false;
	return working;
}
void Comands(int num)
{
	if (num == 1)
	{
		cout << "Write data: ";
		int data;
		cin >> data;
		List.AddNode(List.head, data);
		List.WriteList(List.head);
	};
	if (num == 2)
	{
		cout << "Write data: ";
		int data;
		cin >> data;
		List.DeleteNode(List.head, data);
		List.WriteList(List.head);
	}
	if (num == 3)
	{
		cout << "Write data: ";
		int data;
		cin >> data;

		cout << "Write after: ";
		int after;
		cin >> after;

		List.InsertNode(List.head, data, after);
		List.WriteList(List.head);
	}
	if (num == 4)
	{
		List.Null_Node(List.L1);
		List.Null_Node(List.L2);

		cout << "Write N: ";
		int n;
		cin >> n;

		cout << "main ";
		List.WriteList(List.head);

		List.To_other(List.head, n);

		cout << "L1 ";
		List.WriteList(List.L1);
		cout << "L2 ";
		List.WriteList(List.L2);

		List.Null_Node(List.head);
	}
	if (num == 5)
	{
		List.Null_Node(List.head);
		List.Null_Node(List.L1);
		List.Null_Node(List.L2);
		cout << "all is null" << endl;
	}
	if (num < 0 )
	{
		for (int i = 1; i <= -num;i++)
			List.AddNode(List.head, rand() % (1000));
		List.WriteList(List.head);
	};

}