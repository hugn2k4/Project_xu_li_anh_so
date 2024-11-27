using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Project
{
    public partial class FBai3_1 : Form
    {
        private PictureBox ptbAnhXam;
        public FBai3_1(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
        }

        private void FBai3_1_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);

                Bitmap lbpAnhPadding0 = ThuatToan.ChuyenDoiLBPVoiR1(hinhXam, padding: 0);
                ptbPadding0.Image = lbpAnhPadding0;

                double[] histogramPadding0 = ThuatToan.TinhHistogram(lbpAnhPadding0);

                PointPairList points = ThuatToan.ChuyenDoiHistogram(histogramPadding0);
                graphPadding0.GraphPane = ThuatToan.BienDoiHistogram(points, graphPadding0);
                graphPadding0.Refresh();

                double[] histogramPadding0CanBang = ThuatToan.CanBangHistogram(histogramPadding0);
                PointPairList pointsH2 = ThuatToan.ChuyenDoiHistogram(histogramPadding0CanBang);
                graphPadding0CanBang.GraphPane = ThuatToan.BienDoiHistogram(pointsH2, graphPadding0CanBang);
                graphPadding0CanBang.Refresh();

                Bitmap lbpAnhPadding1 = ThuatToan.ChuyenDoiLBPVoiR1(hinhXam, padding: 1);
                ptbPadding1.Image = lbpAnhPadding1;

                double[] histogramPadding1 = ThuatToan.TinhHistogram(lbpAnhPadding1);
                PointPairList pointsH3 = ThuatToan.ChuyenDoiHistogram(histogramPadding1);
                graphPadding1.GraphPane = ThuatToan.BienDoiHistogram(pointsH3, graphPadding1);
                graphPadding1.Refresh();

                double[] histogramPadding1CanBang = ThuatToan.CanBangHistogram(histogramPadding1);
                PointPairList pointsH4 = ThuatToan.ChuyenDoiHistogram(histogramPadding1CanBang);
                graphPadding1CanBang.GraphPane = ThuatToan.BienDoiHistogram(pointsH4, graphPadding1CanBang);
                graphPadding1CanBang.Refresh();
            }
        }
        
    }
}