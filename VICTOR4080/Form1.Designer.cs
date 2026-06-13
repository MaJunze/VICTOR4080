namespace VICTOR4080
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            panel1 = new Panel();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel3 = new Panel();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            comboBox9 = new ComboBox();
            comboBox8 = new ComboBox();
            comboBox7 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button3 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            button7 = new Button();
            panel6 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            button9 = new Button();
            button8 = new Button();
            panel8 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(998, 538);
            formsPlot1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(formsPlot1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 540);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(1017, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(235, 87);
            panel2.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button2.Location = new Point(117, 49);
            button2.Name = "button2";
            button2.Size = new Size(112, 32);
            button2.TabIndex = 3;
            button2.TabStop = false;
            button2.Text = "连接设备";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button1.Location = new Point(3, 49);
            button1.Name = "button1";
            button1.Size = new Size(112, 32);
            button1.TabIndex = 2;
            button1.TabStop = false;
            button1.Text = "刷新串口";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(117, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(112, 29);
            comboBox1.TabIndex = 1;
            comboBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 0;
            label1.Text = "选择串口:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(1017, 105);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 198);
            panel3.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft YaHei UI", 15.75F);
            label11.Location = new Point(62, 154);
            label11.Name = "label11";
            label11.Size = new Size(86, 28);
            label11.TabIndex = 9;
            label11.Text = "-67.890";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft YaHei UI", 15.75F);
            label10.Location = new Point(10, 154);
            label10.Name = "label10";
            label10.Size = new Size(36, 28);
            label10.TabIndex = 8;
            label10.Text = "θ: ";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft YaHei UI", 15.75F);
            label9.Location = new Point(62, 116);
            label9.Name = "label9";
            label9.Size = new Size(77, 28);
            label9.TabIndex = 7;
            label9.Text = "123.45";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 15.75F);
            label8.Location = new Point(10, 116);
            label8.Name = "label8";
            label8.Size = new Size(46, 28);
            label8.TabIndex = 6;
            label8.Text = "Zs: ";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft YaHei UI", 12F);
            label7.Location = new Point(117, 79);
            label7.Name = "label7";
            label7.Size = new Size(86, 21);
            label7.TabIndex = 5;
            label7.Text = "偏置: 0mV";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 12F);
            label6.Location = new Point(117, 44);
            label6.Name = "label6";
            label6.Size = new Size(113, 21);
            label6.TabIndex = 4;
            label6.Text = "电平: 1000mV";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft YaHei UI", 12F);
            label5.Location = new Point(117, 9);
            label5.Name = "label5";
            label5.Size = new Size(108, 21);
            label5.TabIndex = 3;
            label5.Text = "频率: 100KHz";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.Location = new Point(3, 79);
            label4.Name = "label4";
            label4.Size = new Size(83, 21);
            label4.TabIndex = 2;
            label4.Text = "速度: 慢速";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(3, 44);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 1;
            label3.Text = "量程: 自动";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 0;
            label2.Text = "功能: Zs-θ";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(comboBox9);
            panel4.Controls.Add(comboBox8);
            panel4.Controls.Add(comboBox7);
            panel4.Controls.Add(comboBox6);
            panel4.Controls.Add(comboBox5);
            panel4.Controls.Add(comboBox4);
            panel4.Controls.Add(comboBox3);
            panel4.Controls.Add(comboBox2);
            panel4.Controls.Add(label19);
            panel4.Controls.Add(label18);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Location = new Point(1017, 309);
            panel4.Name = "panel4";
            panel4.Size = new Size(235, 299);
            panel4.TabIndex = 4;
            // 
            // comboBox9
            // 
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox9.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox9.FormattingEnabled = true;
            comboBox9.Location = new Point(115, 260);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(112, 29);
            comboBox9.TabIndex = 16;
            comboBox9.TabStop = false;
            comboBox9.SelectionChangeCommitted += comboBox9_SelectionChangeCommitted;
            // 
            // comboBox8
            // 
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox8.FormattingEnabled = true;
            comboBox8.Location = new Point(115, 225);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new Size(112, 29);
            comboBox8.TabIndex = 15;
            comboBox8.TabStop = false;
            comboBox8.SelectionChangeCommitted += comboBox8_SelectionChangeCommitted;
            // 
            // comboBox7
            // 
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox7.FormattingEnabled = true;
            comboBox7.Location = new Point(115, 190);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(112, 29);
            comboBox7.TabIndex = 14;
            comboBox7.TabStop = false;
            comboBox7.SelectionChangeCommitted += comboBox7_SelectionChangeCommitted;
            // 
            // comboBox6
            // 
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(115, 155);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(112, 29);
            comboBox6.TabIndex = 13;
            comboBox6.TabStop = false;
            comboBox6.SelectionChangeCommitted += comboBox6_SelectionChangeCommitted;
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(115, 120);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(112, 29);
            comboBox5.TabIndex = 12;
            comboBox5.TabStop = false;
            comboBox5.SelectionChangeCommitted += comboBox5_SelectionChangeCommitted;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(115, 85);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(112, 29);
            comboBox4.TabIndex = 11;
            comboBox4.TabStop = false;
            comboBox4.SelectionChangeCommitted += comboBox4_SelectionChangeCommitted;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(115, 50);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(112, 29);
            comboBox3.TabIndex = 10;
            comboBox3.TabStop = false;
            comboBox3.SelectionChangeCommitted += comboBox3_SelectionChangeCommitted;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Microsoft YaHei UI", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(115, 15);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(112, 29);
            comboBox2.TabIndex = 9;
            comboBox2.TabStop = false;
            comboBox2.SelectionChangeCommitted += comboBox2_SelectionChangeCommitted;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label19.Location = new Point(10, 260);
            label19.Name = "label19";
            label19.Size = new Size(99, 25);
            label19.TabIndex = 8;
            label19.Text = "电压偏置: ";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label18.Location = new Point(10, 225);
            label18.Name = "label18";
            label18.Size = new Size(99, 25);
            label18.TabIndex = 7;
            label18.Text = "激励电压: ";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label17.Location = new Point(10, 190);
            label17.Name = "label17";
            label17.Size = new Size(99, 25);
            label17.TabIndex = 6;
            label17.Text = "激励频率: ";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label16.Location = new Point(10, 155);
            label16.Name = "label16";
            label16.Size = new Size(99, 25);
            label16.TabIndex = 5;
            label16.Text = "采样速度: ";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label15.Location = new Point(10, 120);
            label15.Name = "label15";
            label15.Size = new Size(99, 25);
            label15.TabIndex = 4;
            label15.Text = "量程选择: ";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label14.Location = new Point(10, 85);
            label14.Name = "label14";
            label14.Size = new Size(99, 25);
            label14.TabIndex = 3;
            label14.Text = "串联并联: ";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label13.Location = new Point(10, 50);
            label13.Name = "label13";
            label13.Size = new Size(99, 25);
            label13.TabIndex = 2;
            label13.Text = "第二测量: ";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label12.Location = new Point(10, 15);
            label12.Name = "label12";
            label12.Size = new Size(99, 25);
            label12.TabIndex = 1;
            label12.Text = "第一测量: ";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button3.Location = new Point(3, 9);
            button3.Name = "button3";
            button3.Size = new Size(96, 32);
            button3.TabIndex = 4;
            button3.TabStop = false;
            button3.Text = "清除图表";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button6.Location = new Point(207, 9);
            button6.Name = "button6";
            button6.Size = new Size(96, 32);
            button6.TabIndex = 7;
            button6.TabStop = false;
            button6.Text = "滚动刷新";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.White;
            button5.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button5.Location = new Point(105, 9);
            button5.Name = "button5";
            button5.Size = new Size(96, 32);
            button5.TabIndex = 6;
            button5.TabStop = false;
            button5.Text = "单屏刷新";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkSeaGreen;
            button4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button4.Location = new Point(3, 9);
            button4.Name = "button4";
            button4.Size = new Size(96, 32);
            button4.TabIndex = 5;
            button4.TabStop = false;
            button4.Text = "全部波形";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // timer2
            // 
            timer2.Interval = 50;
            timer2.Tick += timer2_Tick;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button7.Location = new Point(309, 9);
            button7.Name = "button7";
            button7.Size = new Size(96, 32);
            button7.TabIndex = 5;
            button7.TabStop = false;
            button7.Text = "暂停刷新";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(button6);
            panel6.Controls.Add(button7);
            panel6.Controls.Add(button4);
            panel6.Controls.Add(button5);
            panel6.Location = new Point(123, 558);
            panel6.Name = "panel6";
            panel6.Size = new Size(411, 50);
            panel6.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(button3);
            panel5.Location = new Point(12, 558);
            panel5.Name = "panel5";
            panel5.Size = new Size(105, 50);
            panel5.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(button9);
            panel7.Controls.Add(button8);
            panel7.Location = new Point(540, 558);
            panel7.Name = "panel7";
            panel7.Size = new Size(206, 50);
            panel7.TabIndex = 9;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button9.Location = new Point(105, 9);
            button9.Name = "button9";
            button9.Size = new Size(96, 32);
            button9.TabIndex = 7;
            button9.TabStop = false;
            button9.Text = "我存哪了";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button8.Location = new Point(3, 9);
            button8.Name = "button8";
            button8.Size = new Size(96, 32);
            button8.TabIndex = 6;
            button8.TabStop = false;
            button8.Text = "导出数据";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Location = new Point(752, 558);
            panel8.Name = "panel8";
            panel8.Size = new Size(260, 50);
            panel8.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 619);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "VICTOR4080";
            FormClosing += Form1_FormClosing;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private ComboBox comboBox1;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private Label label12;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private ComboBox comboBox9;
        private ComboBox comboBox8;
        private ComboBox comboBox7;
        private ComboBox comboBox6;
        private ComboBox comboBox5;
        private ComboBox comboBox4;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private System.Windows.Forms.Timer timer1;
        private Button button4;
        private Button button3;
        private Button button5;
        private System.Windows.Forms.Timer timer2;
        private Button button6;
        private Button button7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel7;
        private Button button9;
        private Button button8;
        private Panel panel8;
    }
}
