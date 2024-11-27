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
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            showFormInPanel(new FBai1(ptbAnhXam));
        }
        private void showFormInPanel(Form form)
        {
            pnlBaiTap.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlBaiTap.Controls.Add(form);
            form.Show();
        }
        private void btnBai1_Click(object sender, EventArgs e)
        {
            showFormInPanel(new FBai1(ptbAnhXam));
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            showFormInPanel(new FBai2(ptbAnhXam));
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            showFormInPanel(new FBai3(ptbAnhXam));
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn một ảnh để hiển thị";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image image = Image.FromFile(openFileDialog.FileName);
                        ptbAnh.Image = image;
                        BtnConvertToGray_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnConvertToGray_Click(object sender, EventArgs e)
        {
            ptbAnhXam.Image = ThuatToan.ConvertToGrayscale_Update((Bitmap)ptbAnh.Image);
        }
        
    }
}
