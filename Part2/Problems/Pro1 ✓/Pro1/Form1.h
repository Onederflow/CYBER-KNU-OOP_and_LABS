#pragma once
#include "Form1.cpp"
#include<iostream>
#include<algorithm>
#include<fstream>
#include<vector>
#include <set>

int count_point;
spoint point[200];

int temp_x1;
int temp_x2;
int temp_y1;
int temp_y2;

bool click = false;

bool usd[200];

namespace CppCLR_WinformsProjekt {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace	System::Drawing::Drawing2D;
	using namespace std;

	/// <summary>
	/// Zusammenfassung für Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Konstruktorcode hier hinzufügen.
			//
		}

	protected:
		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::PictureBox^  pictureBox;
	private: System::Windows::Forms::Button^  Go;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  button1;
	protected:

	private:
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		void InitializeComponent(void)
		{
			this->pictureBox = (gcnew System::Windows::Forms::PictureBox());
			this->Go = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->button1 = (gcnew System::Windows::Forms::Button());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox))->BeginInit();
			this->SuspendLayout();
			// 
			// pictureBox
			// 
			this->pictureBox->BackColor = System::Drawing::Color::White;
			this->pictureBox->Location = System::Drawing::Point(12, 12);
			this->pictureBox->Name = L"pictureBox";
			this->pictureBox->Size = System::Drawing::Size(700, 450);
			this->pictureBox->TabIndex = 0;
			this->pictureBox->TabStop = false;
			this->pictureBox->MouseDown += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox_MouseDown);
			this->pictureBox->MouseMove += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox_MouseMove);
			this->pictureBox->MouseUp += gcnew System::Windows::Forms::MouseEventHandler(this, &Form1::pictureBox_MouseUp);
			// 
			// Go
			// 
			this->Go->Font = (gcnew System::Drawing::Font(L"Monotype Corsiva", 15.75F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)),
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->Go->Location = System::Drawing::Point(730, 12);
			this->Go->Name = L"Go";
			this->Go->Size = System::Drawing::Size(147, 45);
			this->Go->TabIndex = 1;
			this->Go->Text = L"Ðåçóëüòàò";
			this->Go->UseVisualStyleBackColor = true;
			this->Go->Click += gcnew System::EventHandler(this, &Form1::Go_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(787, 142);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(35, 13);
			this->label1->TabIndex = 2;
			this->label1->Text = L"label1";
			// 
			// button1
			// 
			this->button1->Font = (gcnew System::Drawing::Font(L"Monotype Corsiva", 15.75F, static_cast<System::Drawing::FontStyle>((System::Drawing::FontStyle::Bold | System::Drawing::FontStyle::Italic)),
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->button1->Location = System::Drawing::Point(730, 63);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(147, 45);
			this->button1->TabIndex = 3;
			this->button1->Text = L"Î÷èñòèòè";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(889, 481);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->Go);
			this->Controls->Add(this->pictureBox);
			this->DoubleBuffered = true;
			this->ForeColor = System::Drawing::Color::Blue;
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

		void new_rectangle(int num)
		{
			point[count_point].x = temp_x1;
			point[count_point].y = temp_y1;
			point[count_point].adjacent[0] = count_point + 1;
			point[count_point].adjacent[1] = count_point + 3;

			point[count_point + 1].x = temp_x2;
			point[count_point + 1].y = temp_y1;
			point[count_point + 1].adjacent[0] = count_point;
			point[count_point + 1].adjacent[1] = count_point + 2;

			point[count_point + 2].x = temp_x2;
			point[count_point + 2].y = temp_y2;
			point[count_point + 2].adjacent[0] = count_point + 1;
			point[count_point + 2].adjacent[1] = count_point + 3;

			point[count_point + 3].x = temp_x1;
			point[count_point + 3].y = temp_y2;
			point[count_point + 3].adjacent[0] = count_point;
			point[count_point + 3].adjacent[1] = count_point + 2;
		}
		void draw_all()
		{
			Graphics^ tgr = this->pictureBox->CreateGraphics();
			tgr->Clear(Color::White);

			HatchBrush^ myBrush = gcnew HatchBrush(HatchStyle::Percent90, Color::Orange, Color::White);
			SolidBrush^ myBrusht = gcnew SolidBrush(Color::Black);
			System::Drawing::Pen^ myPen = gcnew Pen(Brushes::DeepSkyBlue);



			for (int i = 0; i < count_point + 4; i++)
				for (int j = 0; j < 4; j++)
				{
					if (point[i].adjacent[j] > i)
					{
						tgr->DrawLine(myPen, point[i].x, point[i].y, point[point[i].adjacent[j]].x, point[point[i].adjacent[j]].y);
					}

				};

			for (int i = 0; i < count_point + 4; i++)
			{
				tgr->DrawEllipse(myPen, point[i].x - 5, point[i].y - 5, 10,10);
			}
		}
		void swipe(int &x1, int &x2)
		{
			int temp;
			temp = x1;
			x1 = x2;
			x2 = temp;
		}
		void check_new_point(int p1, int p2, int p3, int p4)
		{
			bool t = true;
			int x = 0;
			int y = 0;
			if (point[p1].x == point[p2].x && point[p3].y == point[p4].y)
			{
				if (point[p2].y < point[p1].y)
					swipe(p1, p2);
				if (point[p4].x < point[p3].x)
					swipe(p3, p4);
				if (point[p3].y > point[p1].y && point[p3].y < point[p2].y && point[p1].x > point[p3].x && point[p1].x < point[p4].x)
				{
					x = point[p1].x;
					y = point[p3].y;
				}
			};

			if (point[p1].y == point[p2].y && point[p3].x == point[p4].x)
			{
				if (point[p2].x < point[p1].x)
					swipe(p1, p2);
				if (point[p4].y < point[p3].y)
					swipe(p3, p4);
				if (point[p3].x > point[p1].x && point[p3].x < point[p2].x && point[p1].y > point[p3].y && point[p1].y < point[p4].y)
				{
					x = point[p3].x;
					y = point[p1].y;
				};
			};

			if (x != 0 && y != 0)
			{
				point[count_point].x = x;
				point[count_point].y = y;

				point[count_point].adjacent[0] = p1;
				point[count_point].adjacent[1] = p2;
				point[count_point].adjacent[2] = p3;
				point[count_point].adjacent[3] = p4;

				for (int i = 0; i < 4; i++)
				{
					if (point[p1].adjacent[i] == p2)
					{
						point[p1].adjacent[i] = count_point;
					};
					if (point[p2].adjacent[i] == p1)
					{
						point[p2].adjacent[i] = count_point;
					};
					if (point[p3].adjacent[i] == p4)
					{
						point[p3].adjacent[i] = count_point;
					};
					if (point[p4].adjacent[i] == p3)
					{
						point[p4].adjacent[i] = count_point;
					};

				}
				count_point++;
			}

		}
		void other_points()
		{
			for (int i = 0; i < count_point+1;i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (point[i].adjacent[j] != 0)
					{
						for (int k = i + 4; k < count_point+1; k++)
						{
							for (int m = 0; m < 4; m++)
							{
								if (point[i].x != 0 && point[point[i].adjacent[j]].x != 0 && point[k].x != 0 && point[point[k].adjacent[m]].x != 0)
									check_new_point(i, point[i].adjacent[j], k, point[k].adjacent[m]);
							};
						};
					};
				};
			};

		}


		void dfs(int cur)
		{
			usd[cur] = true;
			for (int i = 0;i < 4;i++)
			{
				int nxt = point[cur].adjacent[i];
				if (!usd[nxt] && nxt != 0)
					dfs(nxt);
			}
		}
		int connected_components_amount_dfs() {
			int cnt = 0;

			for(int i = 0;i < count_point ; i++)
				usd[i] = false;

			for (int i = 1; i < count_point; i++){
				if (!usd[i]) {
					dfs(i);
					cnt++;
				}
			}
			return cnt;
		}

		int count_lines()
		{
			int res = 0;
				for (int i = 0;i < count_point; i++)
					for (int j = 0; j < 4; j++)
						if(point[i].adjacent[j] !=0 && point[i].adjacent[j] > i)
						{
							res++;
						}
			return res;
		};


	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
		count_point = 1;

	}


	private: System::Void pictureBox_MouseDown(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		temp_x1 = e->X;
		temp_y1 = e->Y;
		temp_x2 = e->X;
		temp_y2 = e->Y;
		new_rectangle(count_point);
		draw_all();
		click = true;
	}
	private: System::Void pictureBox_MouseMove(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		if (click)
		{
			temp_x2 = e->X;
			temp_y2 = e->Y;
			new_rectangle(count_point);
			draw_all();
		};
	}
	private: System::Void pictureBox_MouseUp(System::Object^  sender, System::Windows::Forms::MouseEventArgs^  e) {
		temp_x2 = e->X;
		temp_y2 = e->Y;
		new_rectangle(count_point);
		draw_all();
		count_point = count_point + 4;
		click = false;
	}
	private: System::Void Go_Click(System::Object^  sender, System::EventArgs^  e) {
		other_points();
		draw_all();
		String ^s;

		s = System::Convert::ToString(2 + connected_components_amount_dfs() + count_lines() - count_point);
		label1->Text = s;


	}
private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) 
{
	for (int i = 0; i < 200; i++)
	{
		point[i].x = 0;
		point[i].y = 0;
		for (int j = 0;j < 4;j++)
		{
			point[i].adjacent[j] = 0;
		};

	count_point = 1;
	draw_all();

		String ^s;
		s = System::Convert::ToString("new");
		label1->Text = s;
	};




}
};
}
