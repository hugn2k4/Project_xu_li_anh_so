namespace Project
{
    partial class FBai1
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
            this.graphH1 = new ZedGraph.ZedGraphControl();
            this.graphH2 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.graphHieuChinhH2 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // graphH1
            // 
            this.graphH1.Location = new System.Drawing.Point(32, 34);
            this.graphH1.Name = "graphH1";
            this.graphH1.ScrollGrace = 0D;
            this.graphH1.ScrollMaxX = 0D;
            this.graphH1.ScrollMaxY = 0D;
            this.graphH1.ScrollMaxY2 = 0D;
            this.graphH1.ScrollMinX = 0D;
            this.graphH1.ScrollMinY = 0D;
            this.graphH1.ScrollMinY2 = 0D;
            this.graphH1.Size = new System.Drawing.Size(421, 233);
            this.graphH1.TabIndex = 0;
            this.graphH1.UseExtendedPrintDialog = true;
            // 
            // graphH2
            // 
            this.graphH2.Location = new System.Drawing.Point(510, 34);
            this.graphH2.Name = "graphH2";
            this.graphH2.ScrollGrace = 0D;
            this.graphH2.ScrollMaxX = 0D;
            this.graphH2.ScrollMaxY = 0D;
            this.graphH2.ScrollMaxY2 = 0D;
            this.graphH2.ScrollMinX = 0D;
            this.graphH2.ScrollMinY = 0D;
            this.graphH2.ScrollMinY2 = 0D;
            this.graphH2.Size = new System.Drawing.Size(421, 233);
            this.graphH2.TabIndex = 2;
            this.graphH2.UseExtendedPrintDialog = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Histogram của I (H1)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Histogram cân bằng của I (H2)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hiệu chỉnh thu hẹp H2 trong khoảng(50,100)";
            // 
            // graphHieuChinhH2
            // 
            this.graphHieuChinhH2.Location = new System.Drawing.Point(264, 316);
            this.graphHieuChinhH2.Name = "graphHieuChinhH2";
            this.graphHieuChinhH2.ScrollGrace = 0D;
            this.graphHieuChinhH2.ScrollMaxX = 0D;
            this.graphHieuChinhH2.ScrollMaxY = 0D;
            this.graphHieuChinhH2.ScrollMaxY2 = 0D;
            this.graphHieuChinhH2.ScrollMinX = 0D;
            this.graphHieuChinhH2.ScrollMinY = 0D;
            this.graphHieuChinhH2.ScrollMinY2 = 0D;
            this.graphHieuChinhH2.Size = new System.Drawing.Size(421, 233);
            this.graphHieuChinhH2.TabIndex = 1;
            this.graphHieuChinhH2.UseExtendedPrintDialog = true;
            // 
            // FBai1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graphH2);
            this.Controls.Add(this.graphHieuChinhH2);
            this.Controls.Add(this.graphH1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FBai1";
            this.Text = "FBai1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graphH1;
        private ZedGraph.ZedGraphControl graphH2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ZedGraph.ZedGraphControl graphHieuChinhH2;
    }
}