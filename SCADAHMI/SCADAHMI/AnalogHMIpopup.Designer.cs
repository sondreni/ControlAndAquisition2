namespace SCADAHMI
{
    partial class AnalogHMIpopup
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtValueTemp = new System.Windows.Forms.TextBox();
            this.tmrAnalogHMIpopup = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLLActive = new System.Windows.Forms.CheckBox();
            this.chkLActive = new System.Windows.Forms.CheckBox();
            this.chkHActive = new System.Windows.Forms.CheckBox();
            this.chkHHActive = new System.Windows.Forms.CheckBox();
            this.btnAckLLAlrm = new System.Windows.Forms.Button();
            this.btnAckLAlrm = new System.Windows.Forms.Button();
            this.btnAckHAlrm = new System.Windows.Forms.Button();
            this.btnAckHHAlrm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdateLim = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLLLim = new System.Windows.Forms.TextBox();
            this.txtLLim = new System.Windows.Forms.TextBox();
            this.txtHLim = new System.Windows.Forms.TextBox();
            this.txtHHLim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 179);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(370, 169);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // txtValueTemp
            // 
            this.txtValueTemp.Location = new System.Drawing.Point(194, 153);
            this.txtValueTemp.Name = "txtValueTemp";
            this.txtValueTemp.Size = new System.Drawing.Size(100, 20);
            this.txtValueTemp.TabIndex = 1;
            // 
            // tmrAnalogHMIpopup
            // 
            this.tmrAnalogHMIpopup.Tick += new System.EventHandler(this.tmrAnalogHMIpopup_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PV";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkLLActive);
            this.groupBox1.Controls.Add(this.chkLActive);
            this.groupBox1.Controls.Add(this.chkHActive);
            this.groupBox1.Controls.Add(this.chkHHActive);
            this.groupBox1.Controls.Add(this.btnAckLLAlrm);
            this.groupBox1.Controls.Add(this.btnAckLAlrm);
            this.groupBox1.Controls.Add(this.btnAckHAlrm);
            this.groupBox1.Controls.Add(this.btnAckHHAlrm);
            this.groupBox1.Location = new System.Drawing.Point(194, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 135);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acknowledge Alarms";
            // 
            // chkLLActive
            // 
            this.chkLLActive.AutoSize = true;
            this.chkLLActive.Enabled = false;
            this.chkLLActive.Location = new System.Drawing.Point(129, 103);
            this.chkLLActive.Name = "chkLLActive";
            this.chkLLActive.Size = new System.Drawing.Size(56, 17);
            this.chkLLActive.TabIndex = 13;
            this.chkLLActive.Text = "Active";
            this.chkLLActive.UseVisualStyleBackColor = true;
            // 
            // chkLActive
            // 
            this.chkLActive.AutoSize = true;
            this.chkLActive.Enabled = false;
            this.chkLActive.Location = new System.Drawing.Point(129, 76);
            this.chkLActive.Name = "chkLActive";
            this.chkLActive.Size = new System.Drawing.Size(56, 17);
            this.chkLActive.TabIndex = 12;
            this.chkLActive.Text = "Active";
            this.chkLActive.UseVisualStyleBackColor = true;
            // 
            // chkHActive
            // 
            this.chkHActive.AutoSize = true;
            this.chkHActive.Enabled = false;
            this.chkHActive.Location = new System.Drawing.Point(129, 49);
            this.chkHActive.Name = "chkHActive";
            this.chkHActive.Size = new System.Drawing.Size(56, 17);
            this.chkHActive.TabIndex = 11;
            this.chkHActive.Text = "Active";
            this.chkHActive.UseVisualStyleBackColor = true;
            // 
            // chkHHActive
            // 
            this.chkHHActive.AutoSize = true;
            this.chkHHActive.Enabled = false;
            this.chkHHActive.Location = new System.Drawing.Point(129, 22);
            this.chkHHActive.Name = "chkHHActive";
            this.chkHHActive.Size = new System.Drawing.Size(56, 17);
            this.chkHHActive.TabIndex = 10;
            this.chkHHActive.Text = "Active";
            this.chkHHActive.UseVisualStyleBackColor = true;
            // 
            // btnAckLLAlrm
            // 
            this.btnAckLLAlrm.Location = new System.Drawing.Point(6, 100);
            this.btnAckLLAlrm.Name = "btnAckLLAlrm";
            this.btnAckLLAlrm.Size = new System.Drawing.Size(117, 21);
            this.btnAckLLAlrm.TabIndex = 9;
            this.btnAckLLAlrm.Text = "Low Low Alarm";
            this.btnAckLLAlrm.UseVisualStyleBackColor = true;
            // 
            // btnAckLAlrm
            // 
            this.btnAckLAlrm.Location = new System.Drawing.Point(6, 73);
            this.btnAckLAlrm.Name = "btnAckLAlrm";
            this.btnAckLAlrm.Size = new System.Drawing.Size(117, 21);
            this.btnAckLAlrm.TabIndex = 8;
            this.btnAckLAlrm.Text = "Low Alarm";
            this.btnAckLAlrm.UseVisualStyleBackColor = true;
            // 
            // btnAckHAlrm
            // 
            this.btnAckHAlrm.Location = new System.Drawing.Point(6, 46);
            this.btnAckHAlrm.Name = "btnAckHAlrm";
            this.btnAckHAlrm.Size = new System.Drawing.Size(117, 21);
            this.btnAckHAlrm.TabIndex = 7;
            this.btnAckHAlrm.Text = "High Alarm";
            this.btnAckHAlrm.UseVisualStyleBackColor = true;
            // 
            // btnAckHHAlrm
            // 
            this.btnAckHHAlrm.Location = new System.Drawing.Point(6, 19);
            this.btnAckHHAlrm.Name = "btnAckHHAlrm";
            this.btnAckHHAlrm.Size = new System.Drawing.Size(117, 21);
            this.btnAckHHAlrm.TabIndex = 6;
            this.btnAckHHAlrm.Text = "High High Alarm";
            this.btnAckHHAlrm.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateLim);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLLLim);
            this.groupBox2.Controls.Add(this.txtLLim);
            this.groupBox2.Controls.Add(this.txtHLim);
            this.groupBox2.Controls.Add(this.txtHHLim);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 159);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limits";
            // 
            // btnUpdateLim
            // 
            this.btnUpdateLim.Location = new System.Drawing.Point(6, 129);
            this.btnUpdateLim.Name = "btnUpdateLim";
            this.btnUpdateLim.Size = new System.Drawing.Size(83, 23);
            this.btnUpdateLim.TabIndex = 15;
            this.btnUpdateLim.Text = "Update Limits";
            this.btnUpdateLim.UseVisualStyleBackColor = true;
            this.btnUpdateLim.Click += new System.EventHandler(this.btnUpdateLim_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Low Low";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Low";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "High";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "High High";
            // 
            // txtLLLim
            // 
            this.txtLLLim.Location = new System.Drawing.Point(6, 103);
            this.txtLLLim.Name = "txtLLLim";
            this.txtLLLim.Size = new System.Drawing.Size(56, 20);
            this.txtLLLim.TabIndex = 3;
            this.txtLLLim.Text = "20";
            // 
            // txtLLim
            // 
            this.txtLLim.Location = new System.Drawing.Point(6, 76);
            this.txtLLim.Name = "txtLLim";
            this.txtLLim.Size = new System.Drawing.Size(56, 20);
            this.txtLLim.TabIndex = 2;
            this.txtLLim.Text = "22";
            // 
            // txtHLim
            // 
            this.txtHLim.Location = new System.Drawing.Point(6, 49);
            this.txtHLim.Name = "txtHLim";
            this.txtHLim.Size = new System.Drawing.Size(56, 20);
            this.txtHLim.TabIndex = 1;
            this.txtHLim.Text = "28";
            // 
            // txtHHLim
            // 
            this.txtHHLim.AcceptsReturn = true;
            this.txtHHLim.Location = new System.Drawing.Point(6, 22);
            this.txtHHLim.Name = "txtHHLim";
            this.txtHHLim.Size = new System.Drawing.Size(56, 20);
            this.txtHHLim.TabIndex = 0;
            this.txtHHLim.Text = "30";
            // 
            // AnalogHMIpopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValueTemp);
            this.Controls.Add(this.chart1);
            this.Name = "AnalogHMIpopup";
            this.Text = "AnalogHMIpopup";
            this.Load += new System.EventHandler(this.AnalogHMIpopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtValueTemp;
        private System.Windows.Forms.Timer tmrAnalogHMIpopup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLLActive;
        private System.Windows.Forms.CheckBox chkLActive;
        private System.Windows.Forms.CheckBox chkHActive;
        private System.Windows.Forms.CheckBox chkHHActive;
        private System.Windows.Forms.Button btnAckLLAlrm;
        private System.Windows.Forms.Button btnAckLAlrm;
        private System.Windows.Forms.Button btnAckHAlrm;
        private System.Windows.Forms.Button btnAckHHAlrm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateLim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLLLim;
        private System.Windows.Forms.TextBox txtLLim;
        private System.Windows.Forms.TextBox txtHLim;
        private System.Windows.Forms.TextBox txtHHLim;
    }
}