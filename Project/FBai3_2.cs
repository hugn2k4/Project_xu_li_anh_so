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
    // xem lại form này, xem xong comment xoá comment này, commment lại cho t
    public partial class FBai3_2 : Form
    {
        PictureBox ptbAnhXam;
        public FBai3_2(PictureBox ptbAnhXam)
        {
            InitializeComponent();
            this.ptbAnhXam = ptbAnhXam;
        }

        private void FBai3_2_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);
                Bai3_2Padding0(hinhXam);
                Bai3_2Padding1(hinhXam);
            }
        }

        public void Bai3_2Padding0(Bitmap hinhXam)
        {
            Bitmap lbpAnh1Padding0 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh2Padding0 = new Bitmap(hinhXam.Width, hinhXam.Height);

            ThuatToanBai3.ChuyenDoiLBPVoiR2(hinhXam, 0, lbpAnh1Padding0, lbpAnh2Padding0);
            List<Bitmap> danhSachAnh = new List<Bitmap> { lbpAnh1Padding0, lbpAnh2Padding0 };

            ptbPadding01.Image = lbpAnh1Padding0;
            ptbPadding02.Image = lbpAnh2Padding0;

            double[] histogramKetHopPadding0 = ThuatToanBai3.TinhHistogramKetHop(danhSachAnh);

            PointPairList pointsKetHop0 = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding0);
            graphPadding0KetHop.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop0, graphPadding0KetHop, 520);
            graphPadding0KetHop.Refresh();

            double[] histogramKetHopPadding0CanBang = ThuatToan.CanBangHistogram(histogramKetHopPadding0);
            PointPairList pointsKetHop0CanBang = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding0CanBang);
            graphPadding0KetHopCanBang.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop0CanBang, graphPadding0KetHopCanBang, 520);
            graphPadding0KetHopCanBang.Refresh();

            double[] histogramTonngHopPadding0 = ThuatToanBai3.TinhHistogramTongHop(danhSachAnh);

            PointPairList pointsTongHop0 = ThuatToan.ChuyenDoiHistogram(histogramTonngHopPadding0);
            graphPadding0TongHop.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop0, graphPadding0TongHop);
            graphPadding0TongHop.Refresh();

            double[] histogramTongHopPadding0CanBang = ThuatToan.CanBangHistogram(histogramTonngHopPadding0);
            PointPairList pointsTongHop0CanBang = ThuatToan.ChuyenDoiHistogram(histogramTongHopPadding0CanBang);
            graphPadding0TongHopCanBang.GraphPane = ThuatToan.BienDoiHistogram(pointsTongHop0CanBang, graphPadding0TongHopCanBang);
            graphPadding0TongHopCanBang.Refresh();
        }

        public void Bai3_2Padding1(Bitmap hinhXam)
        {
            Bitmap lbpAnh1Padding1 = new Bitmap(hinhXam.Width, hinhXam.Height);
            Bitmap lbpAnh2Padding1 = new Bitmap(hinhXam.Width, hinhXam.Height);

            ThuatToanBai3.ChuyenDoiLBPVoiR2(hinhXam, 1, lbpAnh1Padding1, lbpAnh2Padding1);
            List<Bitmap> danhSachAnh = new List<Bitmap> { lbpAnh1Padding1, lbpAnh2Padding1};

            ptbPadding11.Image = lbpAnh1Padding1;
            ptbPadding12.Image = lbpAnh2Padding1;

            double[] histogramKetHopPadding1 = ThuatToanBai3.TinhHistogramKetHop(danhSachAnh);

            PointPairList pointsKetHop1 = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding1);
            graphPadding1KetHop.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop1, graphPadding1KetHop, 520);
            graphPadding1KetHop.Refresh();

            double[] histogramKetHopPadding1CanBang = ThuatToan.CanBangHistogram(histogramKetHopPadding1);
            PointPairList pointsKetHop1CanBang = ThuatToan.ChuyenDoiHistogram(histogramKetHopPadding1CanBang);
            graphPadding1KetHopCanBang.GraphPane = ThuatToan.BienDoiHistogramKetHop(pointsKetHop1CanBang, graphPadding1KetHopCanBang, 520);
            graphPadding1KetHopCanBang.Refresh();

            double[] histogramTonngHopPadding1 = ThuatToanBai3.TinhHistogramTongHop(danhSachAnh);

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
