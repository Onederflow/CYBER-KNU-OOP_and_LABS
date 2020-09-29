#include "MyForm.h"

using namespace System;
using namespace System::Windows::Forms;


struct Node
{
	int data;
	Node *left;
	Node *right;
	int left_height;
	int right_height;
};

void add_node(Node *now, Node *last, int data)
{
	if (now == NULL)
	{
		now = new Node();
		now->data = data;
		now->left = NULL;
		now->right = NULL;
		now->left_height = 0;
		now->right_height = 0;
		if (last != NULL)
		{
			if (last->data > data)
				last->left = now;
			else
				last->right = now;
		};
	}
	else
	{
		if (now->data > data)
			add_node(now->left, now, data);
		else
			add_node(now->right, now, data);
	};
}

Node *head;

[STAThread]
void Main(array<String^>^ args)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	MyForm::MyForm form;
	Application::Run(%form);
}
