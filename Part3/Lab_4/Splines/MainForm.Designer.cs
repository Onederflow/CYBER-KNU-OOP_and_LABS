namespace Splines
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_graphics = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_menu.SuspendLayout();
            this.panel_graphics.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel_menu.Controls.Add(this.button3);
            this.panel_menu.Controls.Add(this.button2);
            this.panel_menu.Controls.Add(this.button1);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_menu.Location = new System.Drawing.Point(800, 0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(200, 600);
            this.panel_menu.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 73);
            this.button2.TabIndex = 5;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_graphics
            // 
            this.panel_graphics.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_graphics.Controls.Add(this.pictureBox1);
            this.panel_graphics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_graphics.Location = new System.Drawing.Point(0, 0);
            this.panel_graphics.Name = "panel_graphics";
            this.panel_graphics.Size = new System.Drawing.Size(800, 600);
            this.panel_graphics.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(108, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 50);
            this.button3.TabIndex = 6;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel_graphics);
            this.Controls.Add(this.panel_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_menu.ResumeLayout(false);
            this.panel_graphics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_graphics;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

