
namespace IOTBox_desktop_App
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.uname_txt = new System.Windows.Forms.TextBox();
            this.pw_txt = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtMessageToSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.temp_lbl = new System.Windows.Forms.Label();
            this.hum_lbl = new System.Windows.Forms.Label();
            this.gas_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // uname_txt
            // 
            this.uname_txt.Location = new System.Drawing.Point(227, 51);
            this.uname_txt.Name = "uname_txt";
            this.uname_txt.Size = new System.Drawing.Size(100, 22);
            this.uname_txt.TabIndex = 0;
            this.uname_txt.TextChanged += new System.EventHandler(this.uname_txt_TextChanged);
            // 
            // pw_txt
            // 
            this.pw_txt.Location = new System.Drawing.Point(227, 80);
            this.pw_txt.Name = "pw_txt";
            this.pw_txt.Size = new System.Drawing.Size(100, 22);
            this.pw_txt.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(325, 132);
            this.listBox1.TabIndex = 2;
            // 
            // txtMessageToSend
            // 
            this.txtMessageToSend.Location = new System.Drawing.Point(12, 255);
            this.txtMessageToSend.Name = "txtMessageToSend";
            this.txtMessageToSend.Size = new System.Drawing.Size(100, 22);
            this.txtMessageToSend.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Publish";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 287);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 30);
            this.button4.TabIndex = 9;
            this.button4.Text = "Relay 1 ON";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(166, 287);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(171, 30);
            this.button5.TabIndex = 10;
            this.button5.Text = "Relay 1 OFF";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(166, 251);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(171, 30);
            this.button6.TabIndex = 11;
            this.button6.Text = "Irsend";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 323);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(148, 30);
            this.button7.TabIndex = 12;
            this.button7.Text = "Relay 2 ON";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(166, 323);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(171, 30);
            this.button8.TabIndex = 13;
            this.button8.Text = "Relay 2 OFF";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(166, 358);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(171, 30);
            this.button9.TabIndex = 15;
            this.button9.Text = "Relay 3 OFF";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 358);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(148, 30);
            this.button10.TabIndex = 14;
            this.button10.Text = "Relay 3 ON";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(166, 394);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(171, 30);
            this.button11.TabIndex = 17;
            this.button11.Text = "Relay 4 OFF";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 394);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(148, 30);
            this.button12.TabIndex = 16;
            this.button12.Text = "Relay 4 ON";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(343, 12);
            this.chart1.Name = "chart1";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series10.Legend = "Legend1";
            series10.Name = "Temp";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series11.Legend = "Legend1";
            series11.Name = "Hum";
            this.chart1.Series.Add(series10);
            this.chart1.Series.Add(series11);
            this.chart1.Size = new System.Drawing.Size(374, 205);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(343, 223);
            this.chart2.Name = "chart2";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Gas";
            this.chart2.Series.Add(series12);
            this.chart2.Size = new System.Drawing.Size(374, 205);
            this.chart2.TabIndex = 19;
            this.chart2.Text = "chart2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Address";
            // 
            // temp_lbl
            // 
            this.temp_lbl.AutoSize = true;
            this.temp_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.temp_lbl.Location = new System.Drawing.Point(623, 78);
            this.temp_lbl.Name = "temp_lbl";
            this.temp_lbl.Size = new System.Drawing.Size(39, 17);
            this.temp_lbl.TabIndex = 22;
            this.temp_lbl.Text = "temp";
            // 
            // hum_lbl
            // 
            this.hum_lbl.AutoSize = true;
            this.hum_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hum_lbl.Location = new System.Drawing.Point(623, 113);
            this.hum_lbl.Name = "hum_lbl";
            this.hum_lbl.Size = new System.Drawing.Size(35, 17);
            this.hum_lbl.TabIndex = 23;
            this.hum_lbl.Text = "hum";
            // 
            // gas_lbl
            // 
            this.gas_lbl.AutoSize = true;
            this.gas_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gas_lbl.Location = new System.Drawing.Point(623, 264);
            this.gas_lbl.Name = "gas_lbl";
            this.gas_lbl.Size = new System.Drawing.Size(31, 17);
            this.gas_lbl.TabIndex = 24;
            this.gas_lbl.Text = "gas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(668, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "°C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(668, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(668, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "PPM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 430);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gas_lbl);
            this.Controls.Add(this.hum_lbl);
            this.Controls.Add(this.temp_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessageToSend);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pw_txt);
            this.Controls.Add(this.uname_txt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uname_txt;
        private System.Windows.Forms.TextBox pw_txt;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtMessageToSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label temp_lbl;
        private System.Windows.Forms.Label hum_lbl;
        private System.Windows.Forms.Label gas_lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

