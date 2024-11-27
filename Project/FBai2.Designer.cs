namespace Project
{
    partial class FBai2
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ptbI4 = new System.Windows.Forms.PictureBox();
            this.ptbI3 = new System.Windows.Forms.PictureBox();
            this.ptbI2 = new System.Windows.Forms.PictureBox();
            this.ptbI1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(809, 393);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "I4: Lọc trung vị I3 với lân cận neighboers 3x3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 398);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "I3: Kernel 7x7, padding = 3 và stride = 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(809, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "I2: Kernel 5x5, padding = 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "I1: Kernel 3x3, padding = 1";
            // 
            // ptbI4
            // 
            this.ptbI4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbI4.Location = new System.Drawing.Point(813, 417);
            this.ptbI4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbI4.Name = "ptbI4";
            this.ptbI4.Size = new System.Drawing.Size(378, 297);
            this.ptbI4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbI4.TabIndex = 14;
            this.ptbI4.TabStop = false;
            // 
            // ptbI3
            // 
            this.ptbI3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbI3.Location = new System.Drawing.Point(145, 417);
            this.ptbI3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbI3.Name = "ptbI3";
            this.ptbI3.Size = new System.Drawing.Size(378, 297);
            this.ptbI3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbI3.TabIndex = 13;
            this.ptbI3.TabStop = false;
            // 
            // ptbI2
            // 
            this.ptbI2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbI2.Location = new System.Drawing.Point(813, 43);
            this.ptbI2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbI2.Name = "ptbI2";
            this.ptbI2.Size = new System.Drawing.Size(378, 297);
            this.ptbI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbI2.TabIndex = 12;
            this.ptbI2.TabStop = false;
            // 
            // ptbI1
            // 
            this.ptbI1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbI1.Location = new System.Drawing.Point(145, 43);
            this.ptbI1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbI1.Name = "ptbI1";
            this.ptbI1.Size = new System.Drawing.Size(378, 297);
            this.ptbI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbI1.TabIndex = 11;
            this.ptbI1.TabStop = false;
            // 
            // FBai2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1333, 738);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptbI4);
            this.Controls.Add(this.ptbI3);
            this.Controls.Add(this.ptbI2);
            this.Controls.Add(this.ptbI1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FBai2";
            this.Text = "FBai2";
            this.Load += new System.EventHandler(this.FBai2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbI4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbI1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ptbI4;
        private System.Windows.Forms.PictureBox ptbI3;
        private System.Windows.Forms.PictureBox ptbI2;
        private System.Windows.Forms.PictureBox ptbI1;
    }
}