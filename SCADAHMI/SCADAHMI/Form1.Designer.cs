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
            this.txtValueTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartHMI = new System.Windows.Forms.Button();
            this.tmrHMI = new System.Windows.Forms.Timer(this.components);
            this.txtSetPoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnShowAlrmHist = new System.Windows.Forms.Button();
            this.btnOpenAnalogHMI = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpnController = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtU = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtValueTemp
            // 
            this.txtValueTemp.AcceptsReturn = true;
            this.txtValueTemp.Location = new System.Drawing.Point(25, 62);
            this.txtValueTemp.Name = "txtValueTemp";
            this.txtValueTemp.Size = new System.Drawing.Size(37, 20);
            this.txtValueTemp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "°C Process Value";
            // 
            // btnStartHMI
            // 
            this.btnStartHMI.Location = new System.Drawing.Point(12, 13);
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
            // txtSetPoint
            // 
            this.txtSetPoint.Location = new System.Drawing.Point(10, 62);
            this.txtSetPoint.Name = "txtSetPoint";
            this.txtSetPoint.Size = new System.Drawing.Size(39, 20);
            this.txtSetPoint.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "°C Set Point";
            // 
            // btnShowAlrmHist
            // 
            this.btnShowAlrmHist.Location = new System.Drawing.Point(101, 13);
            this.btnShowAlrmHist.Name = "btnShowAlrmHist";
            this.btnShowAlrmHist.Size = new System.Drawing.Size(79, 23);
            this.btnShowAlrmHist.TabIndex = 20;
            this.btnShowAlrmHist.Text = "Alarm History";
            this.btnShowAlrmHist.UseVisualStyleBackColor = true;
            this.btnShowAlrmHist.Click += new System.EventHandler(this.btnShowAlrmHist_Click);
            // 
            // btnOpenAnalogHMI
            // 
            this.btnOpenAnalogHMI.Location = new System.Drawing.Point(25, 23);
            this.btnOpenAnalogHMI.Name = "btnOpenAnalogHMI";
            this.btnOpenAnalogHMI.Size = new System.Drawing.Size(65, 35);
            this.btnOpenAnalogHMI.TabIndex = 21;
            this.btnOpenAnalogHMI.Text = "Open TT01";
            this.btnOpenAnalogHMI.UseVisualStyleBackColor = true;
            this.btnOpenAnalogHMI.Click += new System.EventHandler(this.btnOpenAnalogHMI_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpnController);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtU);
            this.groupBox1.Controls.Add(this.txtSetPoint);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(101, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 120);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller";
            // 
            // btnOpnController
            // 
            this.btnOpnController.Location = new System.Drawing.Point(10, 19);
            this.btnOpnController.Name = "btnOpnController";
            this.btnOpnController.Size = new System.Drawing.Size(75, 39);
            this.btnOpnController.TabIndex = 22;
            this.btnOpnController.Text = "Open Controller";
            this.btnOpnController.UseVisualStyleBackColor = true;
            this.btnOpnController.Click += new System.EventHandler(this.btnOpnController_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Volt Gain";
            // 
            // txtU
            // 
            this.txtU.Location = new System.Drawing.Point(10, 88);
            this.txtU.Name = "txtU";
            this.txtU.Size = new System.Drawing.Size(39, 20);
            this.txtU.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnOpenAnalogHMI);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtValueTemp);
            this.groupBox2.Location = new System.Drawing.Point(243, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 120);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Process";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 174);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShowAlrmHist);
            this.Controls.Add(this.btnStartHMI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartHMI;
        private System.Windows.Forms.TextBox txtValueTemp;
        private System.Windows.Forms.Timer tmrHMI;
        private System.Windows.Forms.TextBox txtSetPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnShowAlrmHist;
        private System.Windows.Forms.Button btnOpenAnalogHMI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtU;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpnController;
        private System.Windows.Forms.Label label1;
    }
}

