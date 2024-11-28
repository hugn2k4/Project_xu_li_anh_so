
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Project
{
    internal class ThuatToan
    {
        // Chuyen doi anh xam
        public static Bitmap ConvertToGrayscale(Bitmap original)
        {
            // Tạo một đối tượng Bitmap mới để lưu ảnh xám
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            // Duyệt qua từng pixel của ảnh
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Lấy màu của pixel tại (x, y)
                    Color pixelColor = original.GetPixel(x, y);

                    // Tính toán độ sáng của pixel (theo công thức chuyển đổi RGB thành grayscale)
                    int grayValue = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    // Tạo màu xám mới và gán vào pixel
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscale.SetPixel(x, y, grayColor);
                }
            }

            return grayscale;
        }
        public static Bitmap ConvertToGrayscale_Update(Bitmap original)
        {
            // Tạo một đối tượng Bitmap mới để lưu ảnh xám
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            // Sử dụng LockBits để tăng tốc việc thay đổi các pixel
            Rectangle rect = new Rectangle(0, 0, original.Width, original.Height);
            System.Drawing.Imaging.BitmapData data = original.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, original.PixelFormat);
            System.Drawing.Imaging.BitmapData grayData = grayscale.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, original.PixelFormat);

            IntPtr ptr = data.Scan0;
            IntPtr grayPtr = grayData.Scan0;

            int bytes = Math.Abs(data.Stride) * original.Height;
            byte[] rgbValues = new byte[bytes];
            byte[] grayValues = new byte[bytes];

            // Đọc tất cả pixel trong ảnh gốc
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Chuyển đổi RGB thành grayscale
            if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                for (int i = 0; i < rgbValues.Length; i += 3) // RGB có 3 kênh
                {
                    byte r = rgbValues[i + 2];
                    byte g = rgbValues[i + 1];
                    byte b = rgbValues[i];

                    // Tính toán độ sáng của pixel (theo công thức chuyển đổi RGB thành grayscale)
                    byte grayValue = (byte)(0.299 * r + 0.587 * g + 0.114 * b);

                    // Gán giá trị xám vào mảng
                    grayValues[i] = grayValue;       // Blue
                    grayValues[i + 1] = grayValue;   // Green
                    grayValues[i + 2] = grayValue;   // Red
                }
            }
            else if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                for (int i = 0; i < rgbValues.Length; i += 4) // ARGB có 4 kênh
                {
                    byte a = rgbValues[i + 3];
                    byte r = rgbValues[i + 2];
                    byte g = rgbValues[i + 1];
                    byte b = rgbValues[i];

                    // Tính toán độ sáng của pixel (theo công thức chuyển đổi RGB thành grayscale)
                    byte grayValue = (byte)(0.299 * r + 0.587 * g + 0.114 * b);

                    // Gán giá trị xám vào mảng
                    grayValues[i] = grayValue;       // Blue
                    grayValues[i + 1] = grayValue;   // Green
                    grayValues[i + 2] = grayValue;   // Red
                    grayValues[i + 3] = a;           // Alpha (không thay đổi)
                }
            }

            // Sao chép mảng pixel xám vào Bitmap
            System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, grayPtr, bytes);

            // Unlock các bitmap sau khi xử lý xong
            original.UnlockBits(data);
            grayscale.UnlockBits(grayData);

            return grayscale;
        }
        // Histogram
        public static double[] TinhHistogram(Bitmap hinhXam)
        {
            double[] histogram = new double[256];
            for (int x = 0; x < hinhXam.Width; x++)
                for (int y = 0; y < hinhXam.Height; y++)
                {
                    Color color = hinhXam.GetPixel(x, y);
                    byte gray = color.R;
                    histogram[gray]++;
                }
            return histogram;
        }
        public static PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            PointPairList points = new PointPairList();
            for (int i = 0; i < histogram.Length; i++)
            {
                points.Add(i, histogram[i]);
            }
            return points;
        }
        // Bieu dien bieu do
        public static GraphPane BienDoiHistogram(PointPairList histogram, ZedGraphControl graphH)
        {
            // Tạo đối tượng GraphPane mới
            GraphPane gp = new GraphPane();

            // Cài đặt tiêu đề của biểu đồ
            gp.Title.Text = @"Biểu đồ Histogram";
            gp.Rect = new Rectangle(0, 0, graphH.Width, graphH.Height);
            // Cài đặt các tham số cho trục X
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = -5;
            gp.XAxis.Scale.Max = 260;
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
        public static GraphPane BienDoiHistogramKetHop(PointPairList histogram, ZedGraphControl graphH, int xmax)
        {
            // Tạo đối tượng GraphPane mới
            GraphPane gp = new GraphPane();

            // Cài đặt tiêu đề của biểu đồ
            gp.Title.Text = @"Biểu đồ Histogram";
            gp.Rect = new Rectangle(0, 0, graphH.Width, graphH.Height);
            // Cài đặt các tham số cho trục X
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = -5;
            gp.XAxis.Scale.Max = xmax;
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
        // Bai 1
        public static double[] CanBangHistogram(double[] histogram)
        {
            int L = histogram.Length;
            double n = 0;
            int i = 0;

            foreach (double value in histogram)
            {
                n += value;
            }
            double[] p = new double[L]; // Hàm phân phối tích lũy
            for (i = 0; i < L; i++)
            {
                p[i] = histogram[i] / n;
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

        public static double[] HieuChinhHistogram(double[] histogram)// hieu chinh thu hep (50,100)
        {
            int L = 256;
            double[] S = new double[L];

            int Smax = 100, Smin = 50, Rmax = 255, Rmin = 0;

            for (int i = 0; i < L; i++)
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
        // Bai 3-1
        public static Bitmap ChuyenDoiLBPVoiR1(Bitmap anhXam, int padding)
        {
            int width = anhXam.Width;
            int height = anhXam.Height;
            Bitmap lbpImage = new Bitmap(width, height);
            for (int y = 1 - padding; y < height - 1 + padding; y++)
            {
                for (int x = 1 - padding; x < width - 1 + padding; x++)
                {
                    int diemTrungTam = anhXam.GetPixel(x, y).R;
                    int lbpValue = 0;

                    int[] neighbors = new int[8]
                    {
                        GetGrayValue(anhXam, x + 1, y),
                        GetGrayValue(anhXam, x + 1, y + 1),
                        GetGrayValue(anhXam, x, y + 1),
                        GetGrayValue(anhXam, x - 1, y + 1),
                        GetGrayValue(anhXam, x - 1, y),
                        GetGrayValue(anhXam, x - 1, y - 1),
                        GetGrayValue(anhXam, x, y - 1),
                        GetGrayValue(anhXam, x + 1, y - 1),
                    };
                    for (int i = 0; i < 8; i++)
                    {
                        if (neighbors[i] >= diemTrungTam)
                        {
                            lbpValue += (1 << i);
                        }
                    }
                    lbpImage.SetPixel(x, y, Color.FromArgb(lbpValue, lbpValue, lbpValue));
                }
            }
            return lbpImage;
        }

        //Bai 3-2
        public static void ChuyenDoiLBPVoiR2(Bitmap anhXam, int padding, Bitmap anh1, Bitmap anh2)
        {
            // xem lại phần này, xem xong xoá comment này, comment lại cho t nha
            int width = anhXam.Width;
            int height = anhXam.Height;

            for (int y = 2 - padding; y < height - 2 + padding; y++)
            {
                for (int x = 2 - padding; x < width - 2 + padding; x++)
                {
                    int diemTrungTam = anhXam.GetPixel(x, y).R;
                    int lbpValue1 = 0;
                    int lbpValue2 = 0;

                    // Các điểm lân cận cho mỗi hướng, bán kính R = 2
                    int[] neighbors1 = new int[8]
                    {
                        GetGrayValue(anhXam, x + 2, y), 
                        GetGrayValue(anhXam, x + 2, y + 1),
                        GetGrayValue(anhXam, x + 2, y + 2),
                        GetGrayValue(anhXam, x + 1, y + 2),
                        GetGrayValue(anhXam, x, y + 2),
                        GetGrayValue(anhXam, x - 1, y + 2),
                        GetGrayValue(anhXam, x - 2, y + 2),
                        GetGrayValue(anhXam, x - 2, y + 1),
                    };

                    int[] neighbors2 = new int[8]
                    {
                        GetGrayValue(anhXam, x - 2, y),
                        GetGrayValue(anhXam, x - 2, y - 1),
                        GetGrayValue(anhXam, x - 2, y - 2),
                        GetGrayValue(anhXam, x - 1, y - 2),
                        GetGrayValue(anhXam, x, y - 2), 
                        GetGrayValue(anhXam, x + 1, y - 2),
                        GetGrayValue(anhXam, x + 2, y - 2),
                        GetGrayValue(anhXam, x + 2, y - 1),
                    };
                    // Tính toán giá trị LBP cho từng nhóm
                    for (int i = 0; i < 8; i++)
                    {
                        if (neighbors1[i] >= diemTrungTam)
                        {
                            lbpValue1 += (1 << i);
                        }
                        if (neighbors2[i] >= diemTrungTam)
                        {
                            lbpValue2 += (1 << i);
                        }
                    }

                    // Đặt giá trị LBP vào từng ảnh đầu ra
                    anh1.SetPixel(x, y, Color.FromArgb(lbpValue1, lbpValue1, lbpValue1));
                    anh2.SetPixel(x, y, Color.FromArgb(lbpValue2, lbpValue2, lbpValue2));
                }
            }
        }

        // Bai 3-3
        public static void ChuyenDoiLBPVoiR3(Bitmap anhXam, int padding, Bitmap anh1, Bitmap anh2, Bitmap anh3)
        {
            int width = anhXam.Width;
            int height = anhXam.Height;
            for (int y = 3 - padding; y < height - 3 + padding; y++)
            {
                for (int x = 3 - padding; x < width - 3 + padding; x++)
                {
                    int diemTrungTam = anhXam.GetPixel(x, y).R;
                    int lbpValue1 = 0;
                    int lbpValue2 = 0;
                    int lbpValue3 = 0;

                    int[] neighbors1 = new int[8]
                    {
                        GetGrayValue(anhXam, x + 3, y),
                        GetGrayValue(anhXam, x + 3, y + 1),
                        GetGrayValue(anhXam, x + 3, y + 2),
                        GetGrayValue(anhXam, x + 3, y + 3),
                        GetGrayValue(anhXam, x + 2, y + 3),
                        GetGrayValue(anhXam, x + 1, y + 3),
                        GetGrayValue(anhXam, x, y +3),
                        GetGrayValue(anhXam, x - 1, y + 3),
                    };

                    int[] neighbors2 = new int[8]
                    {
                        GetGrayValue(anhXam, x - 2, y + 3),
                        GetGrayValue(anhXam, x - 3, y + 3),
                        GetGrayValue(anhXam, x - 3, y + 2),
                        GetGrayValue(anhXam, x - 3, y + 1),
                        GetGrayValue(anhXam, x - 3, y),
                        GetGrayValue(anhXam, x - 3, y - 1),
                        GetGrayValue(anhXam, x - 3, y - 2),
                        GetGrayValue(anhXam, x - 3, y - 3),
                    };

                    int[] neighbors3 = new int[8]
                    {
                        GetGrayValue(anhXam, x - 2, y - 3),
                        GetGrayValue(anhXam, x - 1, y - 3),
                        GetGrayValue(anhXam, x, y - 3),
                        GetGrayValue(anhXam, x + 1, y - 3),
                        GetGrayValue(anhXam, x + 2, y - 3),
                        GetGrayValue(anhXam, x + 3, y - 3),
                        GetGrayValue(anhXam, x + 3, y - 2),
                        GetGrayValue(anhXam, x + 3, y - 1),
                    };
                    for (int i = 0; i < 8; i++)
                    {
                        if (neighbors1[i] >= diemTrungTam)
                        {
                            lbpValue1 += (1 << i);
                        }
                        if (neighbors2[i] >= diemTrungTam)
                        {
                            lbpValue2 += (1 << i);
                        }
                        if (neighbors3[i] >= diemTrungTam)
                        {
                            lbpValue3 += (1 << i);
                        }
                    }
                    anh1.SetPixel(x, y, Color.FromArgb(lbpValue1, lbpValue1, lbpValue1));
                    anh2.SetPixel(x, y, Color.FromArgb(lbpValue2, lbpValue2, lbpValue2));
                    anh3.SetPixel(x, y, Color.FromArgb(lbpValue3, lbpValue3, lbpValue3));
                }
            }
        }
        public static double[] TinhHistogramKetHop(List<Bitmap> danhSachAnh)
        {
            List<double[]> danhSachHistogram = new List<double[]>();

            foreach (Bitmap anhXam in danhSachAnh)
            {
                danhSachHistogram.Add(ThuatToan.TinhHistogram(anhXam));
            }

            int soLuongHistogram = danhSachHistogram.Count;
            double[] histogramKetHop = new double[256 * soLuongHistogram];

            for (int i = 0; i < soLuongHistogram; i++)
            {
                double[] histogram = danhSachHistogram[i];
                for (int j = 0; j < histogram.Length; j++)
                {
                    histogramKetHop[i * 256 + j] = histogram[j];
                }
            }
            return histogramKetHop;
        }
        public static double[] TinhHistogramTongHop(List<Bitmap> danhSachAnh)
        {
            double[] histogramTongHop = new double[256];

            foreach (Bitmap anhXam in danhSachAnh)
            {
                double[] histogram = ThuatToan.TinhHistogram(anhXam);

                for (int i = 0; i < histogramTongHop.Length; i++)
                {
                    histogramTongHop[i] += histogram[i];
                }
            }
            return histogramTongHop;
        }

        private static int GetGrayValue(Bitmap image, int x, int y)
        {
            if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
            {
                return 0;
            }
            return image.GetPixel(x, y).R;
        }
    }
}
