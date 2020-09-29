// lab2.cpp: определяет точку входа для приложения.
//

#include "stdafx.h"
#include "lab2.h"
#include <iostream>
#include <stack>
#include <stdlib.h>
#include <time.h>

using namespace std;

#define MAX_LOADSTRING 100

int count_n = 0;
int count_res = 0;
struct Point
{
	int x;
	int y;
};
Point p0;
Point mas[100];

Point nextToTop(stack<Point>&S)
{
	Point p = S.top();
	S.pop();
	Point res = S.top();
	S.push(p);
	return res;
}
void swap(Point &p1, Point &p2)
{
	Point temp = p1;
	p1 = p2;
	p2 = temp;
}
int dist(Point p1, Point p2)
{
	return (p1.x - p2.x)*(p1.x - p2.x) + (p1.y - p2.y)*(p1.y - p2.y);
}
int orientation(Point p, Point q, Point r)
{
	int val = (q.y - p.y)*(r.x - q.x) - (q.x - p.x)*(r.y - q.y);
	if (val == 0) return 0;
	return (val>0) ? 1 : 2;
}
int compare(const void *vp1, const void *vp2)
{
	Point *p1 = (Point *)vp1;
	Point *p2 = (Point *)vp2;
	int o = orientation(p0, *p1, *p2);
	if (o == 0)
		return (dist(p0, *p2) >= dist(p0, *p1)) ? -1 : 1;
	return (o == 2) ? -1 : 1;
}
stack<Point> Hull(Point points[], int n)
{
	int ymin = points[0].y, min = 0;
	for (int i = 1; i<n; i++)
	{
		int y = points[i].y;
		if ((y<ymin) || (ymin == y && points[i].x<points[min].x))
			ymin = points[i].y, min = i;
	}
	swap(points[0], points[min]);
	p0 = points[0];
	qsort(&points[1], n - 1, sizeof(Point), compare);
	stack<Point> S;
	S.push(points[0]);
	S.push(points[1]);
	S.push(points[2]);
	count_res = count_res + 3;
	for (int i = 2; i < n; i++)
	{
		while (orientation(nextToTop(S), S.top(), points[i]) != 2)
			S.pop();
		S.push(points[i]);
		count_res++;
	}
	return S;
}


// Глобальные переменные:
HINSTANCE hInst;                                // текущий экземпляр
WCHAR szTitle[MAX_LOADSTRING];                  // Текст строки заголовка
WCHAR szWindowClass[MAX_LOADSTRING];            // имя класса главного окна

// Отправить объявления функций, включенных в этот модуль кода:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: разместите код здесь.

    // Инициализация глобальных строк
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_LAB2, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Выполнить инициализацию приложения:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAB2));

    MSG msg;

    // Цикл основного сообщения:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  ФУНКЦИЯ: MyRegisterClass()
//
//  НАЗНАЧЕНИЕ: регистрирует класс окна.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB2));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_LAB2);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   ФУНКЦИЯ: InitInstance(HINSTANCE, int)
//
//   НАЗНАЧЕНИЕ: сохраняет обработку экземпляра и создает главное окно.
//
//   КОММЕНТАРИИ:
//
//        В данной функции дескриптор экземпляра сохраняется в глобальной переменной, а также
//        создается и выводится на экран главное окно программы.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Сохранить дескриптор экземпляра в глобальной переменной

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  ФУНКЦИЯ: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  НАЗНАЧЕНИЕ:  обрабатывает сообщения в главном окне.
//
//  WM_COMMAND — обработать меню приложения
//  WM_PAINT — отрисовать главное окно
//  WM_DESTROY — отправить сообщение о выходе и вернуться
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT messg, 
WPARAM wParam, LPARAM lParam)
{
HDC hdc; //создаём контекст устройства
PAINTSTRUCT ps; //создаём экземпляр структуры графического вывода
HBRUSH hBrush = CreateSolidBrush(RGB(255, 0, 67)); //задаём сплошную кисть, закрашенную цветом RGB
stack<Point> res;

Point t_last;
Point t_now;
//Цикл обработки сообщений
switch(messg)
{

int x,y; //координаты

//Если был щелчок левой или правой кнопкой

case WM_RBUTTONDOWN:
case WM_LBUTTONDOWN:
char *str;
HDC hDC;

hDC=GetDC(hWnd);
SelectObject(hDC, hBrush);
x=LOWORD(lParam); //узнаём координаты
y=HIWORD(lParam);

mas[count_n].x = x;
mas[count_n].y = y;
count_n++;

RECT rect;

GetClientRect(hWnd, &rect);
FillRect(hDC, &rect, (HBRUSH)(COLOR_WINDOW + 1));

ValidateRect(hWnd, NULL);

for (int i = 0; i < count_n; i++)
{
	Ellipse(hDC, mas[i].x - 5, mas[i].y - 5 , mas[i].x + 5 , mas[i].y + 5);
};

	res = Hull(mas, count_n);

	if (size(res) >= 4)
	{
		t_last = res.top();
		MoveToEx(hDC, t_last.x, t_last.y, NULL);
		while (!empty(res))
		{
			t_now = res.top();
			LineTo(hDC, t_now.x, t_now.y);
			res.pop();
		};
		LineTo(hDC, t_last.x, t_last.y);
	};

break;

case WM_DESTROY:
PostQuitMessage(0);
break;

default:
return(DefWindowProc(hWnd, messg, wParam, lParam)); //освобождаем очередь приложения от нераспознаных
}
return 0;
}

INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
