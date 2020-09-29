namespace Lab5A_RecruitsTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRotation = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRotation
            // 
            this.buttonRotation.Location = new System.Drawing.Point(12, 12);
            this.buttonRotation.Name = "buttonRotation";
            this.buttonRotation.Size = new System.Drawing.Size(116, 23);
            this.buttonRotation.TabIndex = 0;
            this.buttonRotation.Text = "Left or Right";
            this.buttonRotation.UseVisualStyleBackColor = true;
            this.buttonRotation.Click += new System.EventHandler(this.ButtonRotation_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(164, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(268, 12);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCount.TabIndex = 3;
            this.numericUpDownCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownCount.ValueChanged += new System.EventHandler(this.NumericUpDownCount_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GrayText;
            this.pictureBox1.Location = new System.Drawing.Point(2, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1050, 417);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(479, 12);
            this.trackBarSpeed.Maximum = 100;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(291, 45);
            this.trackBarSpeed.TabIndex = 5;
            this.trackBarSpeed.Value = 25;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.TrackBarSpeed_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 492);
            this.Controls.Add(this.trackBarSpeed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDownCount);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonRotation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRotation;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBarSpeed;
    }
}

