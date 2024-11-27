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
    public partial class FBai3_3 : Form
    {
        private PictureBox ptbAnhXam;
        public FBai3_3(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
        }

        private void FBai3_3_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);
                Bai3_3Padding0(hinhXam);
                Bai3_3Padding1(hinhXam);
            }
        }
        public void Bai3_3Padding0(Bitmap hinhXam)
        {
            Bitmap lbpAnh1Padding0 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh2Padding0 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh3Padding0 = new Bitmap(hinhXam.Width, hinhXam.Height);

            ThuatToan.ChuyenDoiLBPVoiR3(hinhXam, 0, lbpAnh1Padding0, lbpAnh2Padding0, lbpAnh3Padding0);
            List<Bitmap> danhSachAnh = new List<Bitmap> { lbpAnh1Padding0, lbpAnh2Padding0, lbpAnh3Padding0 };

            ptbPadding01.Image = lbpAnh1Padding0;
            ptbPadding02.Image = lbpAnh2Padding0;
            ptbPadding03.Image = lbpAnh3Padding0;

            double[] histogramKetHopPadding0 = ThuatToan.TinhHistogramKetHop(danhSachAnh);

            PointPairList pointsKetHop0 = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding0);
            graphPadding0KetHop.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop0, graphPadding0KetHop, 770);
            graphPadding0KetHop.Refresh();

            double[] histogramKetHopPadding0CanBang = ThuatToan.CanBangHistogram(histogramKetHopPadding0);
            PointPairList pointsKetHop0CanBang = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding0CanBang);
            graphPadding0KetHopCanBang.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop0CanBang, graphPadding0KetHopCanBang, 770);
            graphPadding0KetHopCanBang.Refresh();

            double[] histogramTonngHopPadding0 = ThuatToan.TinhHistogramTongHop(danhSachAnh);

            PointPairList pointsTongHop0 = ThuatToan.ChuyenDoiHistogram(histogramTonngHopPadding0);
            graphPadding0TongHop.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop0, graphPadding0TongHop);
            graphPadding0TongHop.Refresh();

            double[] histogramTongHopPadding0CanBang = ThuatToan.CanBangHistogram(histogramTonngHopPadding0);
            PointPairList pointsTongHop0CanBang = ThuatToan.ChuyenDoiHistogram(histogramTongHopPadding0CanBang);
            graphPadding0TongHopCanBang.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop0CanBang, graphPadding0TongHopCanBang);
            graphPadding0TongHopCanBang.Refresh();
        }
        public void Bai3_3Padding1(Bitmap hinhXam)
        {
            Bitmap lbpAnh1Padding1 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh2Padding1 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh3Padding1 = new Bitmap(hinhXam.Width, hinhXam.Height);

            ThuatToan.ChuyenDoiLBPVoiR3(hinhXam, 1, lbpAnh1Padding1, lbpAnh2Padding1, lbpAnh3Padding1);
            List<Bitmap> danhSachAnh = new List<Bitmap> { lbpAnh1Padding1, lbpAnh2Padding1, lbpAnh3Padding1 };

            ptbPadding11.Image = lbpAnh1Padding1;
            ptbPadding12.Image = lbpAnh2Padding1;
            ptbPadding13.Image = lbpAnh3Padding1;

            double[] histogramKetHopPadding1 = ThuatToan.TinhHistogramKetHop(danhSachAnh);

            PointPairList pointsKetHop1 = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding1);
            graphPadding1KetHop.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop1, graphPadding1KetHop, 770);
            graphPadding1KetHop.Refresh();

            double[] histogramKetHopPadding1CanBang = ThuatToan.CanBangHistogram(histogramKetHopPadding1);
            PointPairList pointsKetHop1CanBang = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding1CanBang);
            graphPadding1KetHopCanBang.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop1CanBang, graphPadding1KetHopCanBang, 770);
            graphPadding1KetHopCanBang.Refresh();

            double[] histogramTonngHopPadding1 = ThuatToan.TinhHistogramTongHop(danhSachAnh);

            PointPairList pointsTongHop1 = ThuatToan.ChuyenDoiHistogram(histogramTonngHopPadding1);
            graphPadding1TongHop.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop1, graphPadding1TongHop);
            graphPadding1TongHop.Refresh();

            double[] histogramTongHopPadding1CanBang = ThuatToan.CanBangHistogram(histogramTonngHopPadding1);
            PointPairList pointsTongHop1CanBang = ThuatToan.ChuyenDoiHistogram(histogramTongHopPadding1CanBang);
            graphPadding1TongHopCanBang.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop1CanBang, graphPadding1TongHopCanBang);
            graphPadding1TongHopCanBang.Refresh();
        }
    }
}
