namespace Project
{
    partial class FBai3
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
            this.cbbR = new System.Windows.Forms.ComboBox();
            this.pnlBai3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cbbR
            // 
            this.cbbR.FormattingEnabled = true;
            this.cbbR.Items.AddRange(new object[] {
            "R=1",
            "R=2",
            "R=3"});
            this.cbbR.Location = new System.Drawing.Point(12, 12);
            this.cbbR.Name = "cbbR";
            this.cbbR.Size = new System.Drawing.Size(74, 21);
            this.cbbR.TabIndex = 22;
            this.cbbR.Text = "R=1";
            this.cbbR.SelectedIndexChanged += new System.EventHandler(this.cbbR_SelectedIndexChanged);
            // 
            // pnlBai3
            // 
            this.pnlBai3.Location = new System.Drawing.Point(12, 51);
            this.pnlBai3.Name = "pnlBai3";
            this.pnlBai3.Size = new System.Drawing.Size(976, 541);
            this.pnlBai3.TabIndex = 23;
            // 
            // FBai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlBai3);
            this.Controls.Add(this.cbbR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FBai3";
            this.Text = "FBai3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbR;
        private System.Windows.Forms.Panel pnlBai3;
    }
}