namespace BK2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxG = new TextBox();
            textBoxP = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            out1 = new Label();
            out2 = new Label();
            out3 = new Label();
            out4 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Расход сырья";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 35);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Давление";
            // 
            // textBoxG
            // 
            textBoxG.Location = new Point(100, 6);
            textBoxG.Name = "textBoxG";
            textBoxG.Size = new Size(100, 23);
            textBoxG.TabIndex = 2;
            // 
            // textBoxP
            // 
            textBoxP.Location = new Point(100, 32);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(100, 23);
            textBoxP.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(out1);
            groupBox1.Location = new Point(12, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(550, 100);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Конструкция 1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(out2);
            groupBox2.Location = new Point(12, 189);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(550, 100);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Конструкция 2";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(out3);
            groupBox3.Location = new Point(12, 295);
            groupBox3.Name = "groupBox3";
            groupBox3.RightToLeft = RightToLeft.No;
            groupBox3.Size = new Size(550, 100);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Конструкция 3";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(out4);
            groupBox4.Location = new Point(12, 401);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(550, 100);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Конструкция 4";
            // 
            // out1
            // 
            out1.AutoSize = true;
            out1.Location = new Point(6, 19);
            out1.Name = "out1";
            out1.Size = new Size(19, 15);
            out1.TabIndex = 0;
            out1.Text = "11";
            // 
            // out2
            // 
            out2.AutoSize = true;
            out2.Location = new Point(6, 19);
            out2.Name = "out2";
            out2.Size = new Size(19, 15);
            out2.TabIndex = 1;
            out2.Text = "11";
            // 
            // out3
            // 
            out3.AutoSize = true;
            out3.Location = new Point(6, 19);
            out3.Name = "out3";
            out3.Size = new Size(19, 15);
            out3.TabIndex = 2;
            out3.Text = "11";
            // 
            // out4
            // 
            out4.AutoSize = true;
            out4.Location = new Point(6, 19);
            out4.Name = "out4";
            out4.Size = new Size(19, 15);
            out4.TabIndex = 3;
            out4.Text = "11";
            // 
            // button1
            // 
            button1.Location = new Point(12, 507);
            button1.Name = "button1";
            button1.Size = new Size(550, 23);
            button1.TabIndex = 8;
            button1.Text = "Рассчёт";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 579);
            Controls.Add(button1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(textBoxP);
            Controls.Add(textBoxG);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxG;
        private TextBox textBoxP;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label out1;
        private Label out2;
        private Label out3;
        private Label out4;
        private Button button1;
    }
}
