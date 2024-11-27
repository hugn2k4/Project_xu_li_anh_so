using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Project
{
    public partial class FBai1 : Form
    {
        private PictureBox ptbAnhXam;
        public FBai1(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
        }

        private void FBai1_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);

                double[] histogram = ThuatToan.TinhHistogram(hinhXam);
                PointPairList points = ThuatToan.ChuyenDoiHistogram(histogram);
                graphH1.GraphPane = ThuatToan.BienDoiHistogram(points, graphH1);
                graphH1.Refresh();

                double[] histogramCanBang = ThuatToan.CanBangHistogram(histogram);
                PointPairList pointsH2 = ThuatToan.ChuyenDoiHistogram(histogramCanBang);
                graphH2.GraphPane = ThuatToan.BienDoiHistogram(pointsH2, graphH2);
                graphH2.Refresh();

                double[] histogramHieuChinh = ThuatToan.HieuChinhHistogram(histogram);
                PointPairList pointsH3 = ThuatToan.ChuyenDoiHistogram(histogramHieuChinh);
                graphH3.GraphPane = ThuatToan.BienDoiHistogram(pointsH3, graphH3);
                graphH3.Refresh();
            } 
        }
    }
}
