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

                double[] histogram = TinhHistogram(hinhXam);
                PointPairList points = ChuyenDoiHistogram(histogram);
                graphH1.GraphPane = BienDoiHistogram(points);
                graphH1.Refresh();

                double[] histogramCanBang = CanBangHistogram(histogram);
                PointPairList pointsH2 = ChuyenDoiHistogram(histogramCanBang);
                graphH2.GraphPane = BienDoiHistogram(pointsH2);
                graphH2.Refresh();

                double[] histogramHieuChinh = HieuChinhHistogram(histogram);
                PointPairList pointsH3 = ChuyenDoiHistogram(histogramHieuChinh);
                graphH3.GraphPane = BienDoiHistogram(pointsH3);
                graphH3.Refresh();
            } 
        }
        public double[] TinhHistogram(Bitmap hinhXam)
        {
            double[] histogram = new double[256];
            for(int x = 0; x < hinhXam.Width; x++)
                for(int y = 0; y < hinhXam.Height; y++)
                {
                    Color color = hinhXam.GetPixel(x, y);
                    byte gray = color.R;
                    histogram[gray]++;
                }
            return histogram;
        }
        public double[] CanBangHistogram(double[] histogram)
        {
            int L = 256; // Tổng số mức xám
            double n = 0;
            int i = 0, j = 0;
            
            foreach (double value in histogram)
            {
                n += value;
            }
            double[] p = new double[L]; // Hàm phân phối tích lũy
            for (i = 0; i < L; i++)
            {
                p[i] = histogram[i]/n;
            }
            for (i = 1; i < L; i++)
            {
                p[i] = p[i - 1] + p[i];
            }
            for (i = 0; i < L; i++)
            {
                p[i] = (int)Math.Round((L - 1) * p[i]);
            }

            double[] canBangHistogram = new double[L];
            for (i = 0; i < L; i++)
            {
                canBangHistogram[(int)p[i]] += histogram[i];
            }
            return canBangHistogram;
        }

        public double[] HieuChinhHistogram(double[] histogram)// hieu chinh thu hep (50,100)
        {
            int L = 256;
            double[] S = new double[L];

            int Smax = 100, Smin = 50, Rmax = 255, Rmin = 0;

            for(int i = 0; i < L; i++)
            {
                S[i] = (int)Math.Round(((Smax - Smin) / (double)(Rmax - Rmin)) * (i - Rmin) + Smin);
            }
            double[] hieuChinhHistogram = new double[L];
            for (int i = 0; i < L; i++)
            {
                hieuChinhHistogram[(int)S[i]] += histogram[i];
            }
            return hieuChinhHistogram;
        }
        PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            PointPairList points = new PointPairList();
            for(int i = 0; i < histogram.Length; i++)
            {
                points.Add(i, histogram[i]);
            }
            return points;
        }
        public GraphPane BienDoiHistogram(PointPairList histogram)
        {
            // Tạo đối tượng GraphPane mới
            GraphPane gp = new GraphPane();

            // Cài đặt tiêu đề của biểu đồ
            gp.Title.Text = @"Biểu đồ Histogram";
            gp.Rect = new Rectangle(0, 0, graphH1.Width, graphH1.Height);
            // Cài đặt các tham số cho trục X
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = 0;
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5;
            gp.XAxis.Scale.MinorStep = 1;

            // Cài đặt các tham số cho trục Y
            double maxPixelCount = histogram.Select(p => p.Y).Max();
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức xám";
            gp.YAxis.Scale.Min = 0;
            gp.YAxis.Scale.Max = maxPixelCount + (maxPixelCount * 0.1); // Tăng giá trị tối đa thêm 10% để có khoảng trống

            // Điều chỉnh MajorStep và MinorStep cho hợp lý, đảm bảo có thể nhìn thấy dữ liệu
            gp.YAxis.Scale.MajorStep = maxPixelCount / 10;
            gp.YAxis.Scale.MinorStep = maxPixelCount / 100;

            // Thêm biểu đồ thanh (Bar chart)
            ZedGraph.BarItem histogramBar = gp.AddBar("Histogram", histogram, Color.OrangeRed);

            // Tùy chỉnh màu của thanh histogram
            histogramBar.Bar.Fill = new Fill(Color.OrangeRed);

            return gp;
        }
    }
}
