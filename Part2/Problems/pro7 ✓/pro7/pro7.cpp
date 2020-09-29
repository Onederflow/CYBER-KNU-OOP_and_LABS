#include "stdafx.h"
#include <conio.h>
#include <iostream>
#include <ctime>
using namespace std;


struct Node
{
	int data;
	Node *next;
	Node *prev;
};

class  MyList
{
public:
	Node *head = new Node();
	Node *tail = head;


	void Add(int data)
	{
		Node *temp = new Node();
		temp->data = data;
		temp->prev = tail;

		tail->next = temp;
		tail = tail->next;
		if (head->next == NULL)
			head->next = temp;
	}
	void Delete()
	{
		if (head->next != NULL)
		{
			head->next = head->next->next;
			head->prev = NULL;
		}
	}
	void WriteList(Node *now)
	{
		cout << endl;
		Node *temp = now->next;
		while (temp != NULL)
		{
			cout << temp->data << " ";
			temp = temp->next;
		};
		cout << endl;

	}

	void null(Node *&now)
	{
		if (now != NULL)
		{
			null(now->next);
			now = NULL;
		};
	}
	void swap_x(Node *&a1, Node *&a2)
	{

		Node *next_1 = a1->next;
		Node *prev_1 = a1->prev; 
		Node *next_2 = a2->next;
		Node *prev_2 = a2->prev;

		if (a1->prev)
		a1->prev->next = a2;
		if (a1->next)
		a1->next->prev = a2;
		if (a2->prev)
		a2->prev->next = a1;
		if (a2->next)
		a2->next->prev = a1;

		a2->next = next_1;
		a2->prev = prev_1;

		a1->next = next_2;
		a1->prev = prev_2;
	}

	void swap(Node *&lst1, Node *lst2)
	{
		Node *prev1, *prev2, *next1, *next2;
		prev1 = lst1->prev;  // узел предшествующий lst1
		prev2 = lst2->prev;  // узел предшествующий lst2
		next1 = lst1->next; // узел следующий за lst1
		next2 = lst2->next; // узел следующий за lst2
		if (lst2 == next1)  // обмениваютс€ соседние узлы
		{
			lst2->next = lst1;
			lst2->prev = prev1;
			lst1->next = next2;
			lst1->prev = lst2;
			if(next2)
			next2->prev = lst1;
			if (lst1 != head)
				prev1->next = lst2;
		}
		else if (lst1 == next2)  // обмениваютс€ соседние узлы
		{
			lst1->next = lst2;
			lst1->prev = prev2;
			lst2->next = next1;
			lst2->prev = lst1;
			if (next1)
			next1->prev = lst2;
			if (lst2 != head)
				prev2->next = lst1;
		}
		else  // обмениваютс€ отсто€щие узлы
		{
			if (lst1 != head && prev1)  // указатель prev можно установить только дл€ элемента,
				prev1->next = lst2; // не €вл€ющегос€ корневым
			lst2->next = next1;
			if (lst2 != head  && prev2)
				prev2->next = lst1;
			lst1->next = next2;
			lst2->prev = prev1;
			if (next2 != NULL) // указатель next можно установить только дл€ элемента,
				next2->prev = lst1; // не €вл€ющегос€ последним
			lst1->prev = prev2;
			if (next1 != NULL)
				next1->prev = lst2;
		}
	}


	void Insertion_sort(Node *&now)
	{
		Node *temp = now->next;
		while (temp!= NULL)
		{	
			Node *max = temp;
			Node *temp_searsh = temp;
			while (temp_searsh != NULL)
			{
				if (temp_searsh->data > max->data)
					max = temp_searsh;
				temp_searsh = temp_searsh->next;
			};
			if (max != temp)
			{
			//	cout << endl;
			//	cout << temp->data << "		" << max->data << endl;
				swap(temp, max);
			//	cout << temp->data << "		" << max->data << endl;
			//	WriteList(head);
			}
			temp = max->next;
			if (temp == NULL)
				tail = max;
		};
	}
	void Quick_sort(Node *&start, Node *&finish)
	{
		Node *temp_left = start;
		Node *temp_right = finish;

		Node *swap_left;
		Node *swap_right;
		bool t = true;

		if (start != finish && temp_left != NULL && temp_right != NULL)
		{
			while (t && temp_left != NULL && temp_right != NULL)
			{
				swap_left = temp_left;
				swap_right = temp_right;

				if (swap_left->data > swap_right->data)
				{
					if (swap_left->prev == head)
						head->next = swap_right;
					if (swap_right == tail)
						tail = swap_left;

					swap(swap_left, swap_right);
					cout << swap_left->data << "	" << swap_right->data;
					WriteList(head);
				}
				temp_left = swap_left->next;
				if (temp_left != temp_right)
				{
					temp_right = swap_right->prev;
					if (temp_left == temp_right)
						t = false;
				}
				else
					t = false;
			};
			Quick_sort(start, temp_left);
			Quick_sort(temp_right, finish);
		};
	};
	void Quick_sort_x(Node *&start, Node *&finish)
	{

		if(start != NULL && finish != NULL && start != finish)
		{ 
		Node *left = start;
		Node *right = finish;

		while (left!= right && left->prev != right)
		{
			if(left->data < right->data)
			{
				swap(left, right);
				left = right->next;
				right = left->prev;
			}
			else
			{
				left = left->next;
				right = right->prev;
			};
			cout << left->data << " +++ " << right->data << endl;
		}

		WriteList(head);
		if (start != left->next)
			Quick_sort(left,finish);
		if (finish != left)
			Quick_sort(start,left);
	}}

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
	cout << "Press '3' Insertion sort" << endl;
	cout << "Press '4' quick sort" << endl;
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
		List.Add(data);
		List.WriteList(List.head);
	};
	if (num == 2)
	{
		List.Delete();
		List.WriteList(List.head);
	}
	if (num == 3)
	{
		List.Insertion_sort(List.head);
		List.WriteList(List.head);
	};
	if (num == 4)
	{
		List.Insertion_sort(List.head);
		List.WriteList(List.head);
	};
	

	if (num == 5)
	{
		List.null(List.head);
		cout << "all is null" << endl;
	}
	if (num < 0)
	{
		for (int i = 1; i <= -num;i++)
			List.Add(rand() % (1000));
		List.WriteList(List.head);
	};

}
