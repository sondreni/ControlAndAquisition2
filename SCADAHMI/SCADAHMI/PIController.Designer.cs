namespace SCADAHMI
{
    partial class PIController
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
            this.btnUpdateSetPoint = new System.Windows.Forms.Button();
            this.txtUpdateSetPoint = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tmrControllerPopup = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnUpdateSetPoint
            // 
            this.btnUpdateSetPoint.Location = new System.Drawing.Point(12, 12);
            this.btnUpdateSetPoint.Name = "btnUpdateSetPoint";
            this.btnUpdateSetPoint.Size = new System.Drawing.Size(69, 37);
            this.btnUpdateSetPoint.TabIndex = 18;
            this.btnUpdateSetPoint.Text = "Update Set Point";
            this.btnUpdateSetPoint.UseVisualStyleBackColor = true;
            this.btnUpdateSetPoint.Click += new System.EventHandler(this.btnUpdateSetPoint_Click_1);
            // 
            // txtUpdateSetPoint
            // 
            this.txtUpdateSetPoint.Location = new System.Drawing.Point(12, 55);
            this.txtUpdateSetPoint.Name = "txtUpdateSetPoint";
            this.txtUpdateSetPoint.Size = new System.Drawing.Size(39, 20);
            this.txtUpdateSetPoint.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "°C Set Point";
            // 
            // PIController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 90);
            this.Controls.Add(this.txtUpdateSetPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdateSetPoint);
            this.Name = "PIController";
            this.Text = "PIController";
            this.Load += new System.EventHandler(this.PIController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateSetPoint;
        private System.Windows.Forms.TextBox txtUpdateSetPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tmrControllerPopup;
    }
}