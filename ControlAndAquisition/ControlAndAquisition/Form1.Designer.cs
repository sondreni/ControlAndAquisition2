namespace ControlAndAquisition
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtRefrence = new System.Windows.Forms.TextBox();
            this.txtYY = new System.Windows.Forms.TextBox();
            this.txtuu = new System.Windows.Forms.TextBox();
            this.tmrLoop = new System.Windows.Forms.Timer(this.components);
            this.lblRead1 = new System.Windows.Forms.Label();
            this.lblRead2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(106, 58);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(451, 307);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // txtRefrence
            // 
            this.txtRefrence.Location = new System.Drawing.Point(106, 395);
            this.txtRefrence.Name = "txtRefrence";
            this.txtRefrence.Size = new System.Drawing.Size(100, 20);
            this.txtRefrence.TabIndex = 1;
            this.txtRefrence.Text = "25";
            // 
            // txtYY
            // 
            this.txtYY.Location = new System.Drawing.Point(265, 395);
            this.txtYY.Name = "txtYY";
            this.txtYY.Size = new System.Drawing.Size(100, 20);
            this.txtYY.TabIndex = 2;
            // 
            // txtuu
            // 
            this.txtuu.Location = new System.Drawing.Point(434, 395);
            this.txtuu.Name = "txtuu";
            this.txtuu.Size = new System.Drawing.Size(100, 20);
            this.txtuu.TabIndex = 3;
            // 
            // tmrLoop
            // 
            this.tmrLoop.Enabled = true;
            this.tmrLoop.Tick += new System.EventHandler(this.tmrLoop_Tick);
            // 
            // lblRead1
            // 
            this.lblRead1.AutoSize = true;
            this.lblRead1.Location = new System.Drawing.Point(208, 13);
            this.lblRead1.Name = "lblRead1";
            this.lblRead1.Size = new System.Drawing.Size(35, 13);
            this.lblRead1.TabIndex = 4;
            this.lblRead1.Text = "label1";
            // 
            // lblRead2
            // 
            this.lblRead2.AutoSize = true;
            this.lblRead2.Location = new System.Drawing.Point(301, 13);
            this.lblRead2.Name = "lblRead2";
            this.lblRead2.Size = new System.Drawing.Size(35, 13);
            this.lblRead2.TabIndex = 5;
            this.lblRead2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 458);
            this.Controls.Add(this.lblRead2);
            this.Controls.Add(this.lblRead1);
            this.Controls.Add(this.txtuu);
            this.Controls.Add(this.txtYY);
            this.Controls.Add(this.txtRefrence);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtRefrence;
        private System.Windows.Forms.TextBox txtYY;
        private System.Windows.Forms.TextBox txtuu;
        private System.Windows.Forms.Timer tmrLoop;
        private System.Windows.Forms.Label lblRead1;
        private System.Windows.Forms.Label lblRead2;
    }
}

