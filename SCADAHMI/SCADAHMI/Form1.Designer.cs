namespace SCADAHMI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtValueTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartHMI = new System.Windows.Forms.Button();
            this.tmrHMI = new System.Windows.Forms.Timer(this.components);
            this.btnUpdateLim = new System.Windows.Forms.Button();
            this.txtUpdateSetPoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateSetPoint = new System.Windows.Forms.Button();
            this.txtDAQcon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowAlrmHist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(12, 154);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(677, 291);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // txtValueTemp
            // 
            this.txtValueTemp.AcceptsReturn = true;
            this.txtValueTemp.Location = new System.Drawing.Point(171, 128);
            this.txtValueTemp.Name = "txtValueTemp";
            this.txtValueTemp.Size = new System.Drawing.Size(50, 20);
            this.txtValueTemp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "°C Process Value";
            // 
            // btnStartHMI
            // 
            this.btnStartHMI.Location = new System.Drawing.Point(13, 13);
            this.btnStartHMI.Name = "btnStartHMI";
            this.btnStartHMI.Size = new System.Drawing.Size(82, 23);
            this.btnStartHMI.TabIndex = 5;
            this.btnStartHMI.Text = "Start HMI";
            this.btnStartHMI.UseVisualStyleBackColor = true;
            this.btnStartHMI.Click += new System.EventHandler(this.btnStartHMI_Click);
            // 
            // tmrHMI
            // 
            this.tmrHMI.Interval = 1000;
            this.tmrHMI.Tick += new System.EventHandler(this.tmrHMI_Tick);
            // 
            // btnUpdateLim
            // 
            this.btnUpdateLim.Location = new System.Drawing.Point(101, 13);
            this.btnUpdateLim.Name = "btnUpdateLim";
            this.btnUpdateLim.Size = new System.Drawing.Size(83, 23);
            this.btnUpdateLim.TabIndex = 14;
            this.btnUpdateLim.Text = "Update Limits";
            this.btnUpdateLim.UseVisualStyleBackColor = true;
            this.btnUpdateLim.Click += new System.EventHandler(this.btnUpdateLim_Click);
            // 
            // txtUpdateSetPoint
            // 
            this.txtUpdateSetPoint.Location = new System.Drawing.Point(12, 128);
            this.txtUpdateSetPoint.Name = "txtUpdateSetPoint";
            this.txtUpdateSetPoint.Size = new System.Drawing.Size(69, 20);
            this.txtUpdateSetPoint.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "ºC Set Point";
            // 
            // btnUpdateSetPoint
            // 
            this.btnUpdateSetPoint.Location = new System.Drawing.Point(12, 85);
            this.btnUpdateSetPoint.Name = "btnUpdateSetPoint";
            this.btnUpdateSetPoint.Size = new System.Drawing.Size(69, 37);
            this.btnUpdateSetPoint.TabIndex = 17;
            this.btnUpdateSetPoint.Text = "Update Set Point";
            this.btnUpdateSetPoint.UseVisualStyleBackColor = true;
            this.btnUpdateSetPoint.Click += new System.EventHandler(this.btnUpdateSetPoint_Click);
            // 
            // txtDAQcon
            // 
            this.txtDAQcon.AcceptsReturn = true;
            this.txtDAQcon.Location = new System.Drawing.Point(13, 58);
            this.txtDAQcon.Name = "txtDAQcon";
            this.txtDAQcon.Size = new System.Drawing.Size(208, 20);
            this.txtDAQcon.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "°C Process Value";
            // 
            // btnShowAlrmHist
            // 
            this.btnShowAlrmHist.Location = new System.Drawing.Point(191, 13);
            this.btnShowAlrmHist.Name = "btnShowAlrmHist";
            this.btnShowAlrmHist.Size = new System.Drawing.Size(79, 23);
            this.btnShowAlrmHist.TabIndex = 20;
            this.btnShowAlrmHist.Text = "Alarm History";
            this.btnShowAlrmHist.UseVisualStyleBackColor = true;
            this.btnShowAlrmHist.Click += new System.EventHandler(this.btnShowAlrmHist_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 452);
            this.Controls.Add(this.btnShowAlrmHist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDAQcon);
            this.Controls.Add(this.btnUpdateSetPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUpdateSetPoint);
            this.Controls.Add(this.btnUpdateLim);
            this.Controls.Add(this.btnStartHMI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValueTemp);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartHMI;
        private System.Windows.Forms.TextBox txtValueTemp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer tmrHMI;
        private System.Windows.Forms.Button btnUpdateLim;
        private System.Windows.Forms.TextBox txtUpdateSetPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateSetPoint;
        private System.Windows.Forms.TextBox txtDAQcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowAlrmHist;
    }
}

