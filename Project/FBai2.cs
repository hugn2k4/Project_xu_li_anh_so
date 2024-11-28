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
    public partial class FBai2 : Form
    {

        private PictureBox ptbAnhXam;
        public FBai2(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
        }
        private void FBai2_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);

                //Loc anh voi kernel 3x3, padding = 1
                Bitmap I1 = ThuatToanBai2.LocAnh(hinhXam, 3, 1);
                ptbI1.Image = I1;

                //Loc anh voi kernel 5x5, padding = 2
                Bitmap I2 = ThuatToanBai2.LocAnh(hinhXam, 5, 2);
                ptbI2.Image = I2;

                //Loc anh voi kernel 7x7, padding = 3 va stride = 2
                Bitmap I3 = ThuatToanBai2.LocVoiStride(hinhXam, 7, 3, 2);
                ptbI3.Image = I3;

                //Loc trung vi tren anh I3 voi lan can 3x3
                Bitmap I4 = ThuatToanBai2.LocTrungVi(I3, 3);
                ptbI4.Image = I4;
            }
        }
    }
}