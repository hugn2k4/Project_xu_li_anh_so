using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class FBai3 : Form
    {
        private PictureBox ptbAnhXam;
        FBai3_1 fBai3_1;
        FBai3_2 fBai3_2;
        FBai3_3 fBai3_3;
        public FBai3(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
            fBai3_1 = new FBai3_1(ptbAnhXam);
            fBai3_2 = new FBai3_2(ptbAnhXam);
            fBai3_3 = new FBai3_3(ptbAnhXam);
            showFormInPanel(fBai3_1);
        }
        private void showFormInPanel(Form form)
        {
            pnlBai3.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlBai3.Controls.Add(form);
            form.Show();
        }
        private void cbbR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbbR.SelectedItem.ToString();
            if(selectedItem.Contains("1"))
            {
                showFormInPanel(fBai3_1);
            }
            else if (selectedItem.Contains("2"))
            {
                showFormInPanel(fBai3_2);
            }
            else if (selectedItem.Contains("3"))
            {
                showFormInPanel(fBai3_3);
            }
        }
    }
}
