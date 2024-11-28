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

        public class ImageProcessing
        {
            // Loc anh voi kernel va padding
            public static Bitmap LocAnh(Bitmap anh, int kichThuocKernel, int padding)
            {
                int chieuDaiKernel = kichThuocKernel * kichThuocKernel;
                int[,] kernel = new int[kichThuocKernel, kichThuocKernel];

                // Khoi tao kernel mac dinh (kernel don gian)
                for (int i = 0; i < kichThuocKernel; i++)
                {
                    for (int j = 0; j < kichThuocKernel; j++)
                    {
                        kernel[i, j] = 1;  // Dung kernel don gian co gia tri = 1
                    }
                }

                Bitmap anhKetQua = new Bitmap(anh.Width, anh.Height);

                // Ap dung kernel voi padding
                for (int x = padding; x < anh.Width - padding; x++)
                {
                    for (int y = padding; y < anh.Height - padding; y++)
                    {
                        int giaTriMoiPixel = 0;
                        for (int i = 0; i < kichThuocKernel; i++)
                        {
                            for (int j = 0; j < kichThuocKernel; j++)
                            {
                                int pixelX = x + i - padding;
                                int pixelY = y + j - padding;
                                Color pixelColor = anh.GetPixel(pixelX, pixelY);
                                int pixelGrayValue = pixelColor.R; // Vi anh da chuyen sang xam
                                giaTriMoiPixel += pixelGrayValue * kernel[i, j];
                            }
                        }

                        // Tinh gia tri pixel moi
                        giaTriMoiPixel = Math.Min(Math.Max(giaTriMoiPixel / chieuDaiKernel, 0), 255);
                        Color newColor = Color.FromArgb(giaTriMoiPixel, giaTriMoiPixel, giaTriMoiPixel);
                        anhKetQua.SetPixel(x, y, newColor);
                    }
                }

                return anhKetQua;
            }

            // Loc voi stride
            public static Bitmap LocVoiStride(Bitmap anh, int kichThuocKernel, int padding, int stride)
            {
                // Khởi tạo kernel đơn giản với tất cả giá trị = 1
                int[,] kernel = new int[kichThuocKernel, kichThuocKernel];
                for (int i = 0; i < kichThuocKernel; i++)
                {
                    for (int j = 0; j < kichThuocKernel; j++)
                    {
                        kernel[i, j] = 1;  // Kernel don gian co the thay doi theo yeu cau
                    }
                }
                // Thêm padding cho ảnh
                int anhPaddingWidth = anh.Width + 2 * padding;
                int anhPaddingHeight = anh.Height + 2 * padding;
                Bitmap anhPadding = new Bitmap(anhPaddingWidth, anhPaddingHeight);
                for (int x = 0; x < anh.Width; x++)
                {
                    for (int y = 0; y < anh.Height; y++)
                    {
                        Color pixelColor = anh.GetPixel(x, y);
                        anhPadding.SetPixel(x + padding, y + padding, pixelColor);
                    }
                }
                // tính toán chiều dài chiều rộng ảnh mới
                int anhKetQuaWidth = (int)Math.Floor((double)(anh.Width - kichThuocKernel + 2 * padding) / stride) + 1;
                int anhKetQuaHeight = (int)Math.Floor((double)(anh.Height - kichThuocKernel + 2 * padding) / stride) + 1;

                Bitmap anhKetQua = new Bitmap(anhKetQuaWidth, anhKetQuaHeight);

                int halfKernel = kichThuocKernel / 2;

                for (int x = 0; x < anhKetQuaWidth; x++)
                {
                    for (int y = 0; y < anhKetQuaHeight; y++)
                    {
                        // xGoc, yGoc là x,y đang xét tại ảnh đã thêm padding
                        int xGoc = halfKernel + x * stride;
                        int yGoc = halfKernel + y * stride;
                        int giaTriMoiPixel = 0;

                        // Duyệt qua từng pixel trong kernel
                        for (int i = 0; i < kichThuocKernel; i++)
                        {
                            for (int j = 0; j < kichThuocKernel; j++)
                            {
                                int pixelX = xGoc + i - halfKernel;
                                int pixelY = yGoc + j - halfKernel;
                                // trường hợp áp padding không đủ khi hết ảnh
                                if (pixelX >= 0 && pixelX < anhPadding.Width && pixelY >= 0 && pixelY < anhPadding.Height)
                                {
                                    Color pixelColor = anhPadding.GetPixel(pixelX, pixelY);
                                    int pixelGrayValue = pixelColor.R;
                                    giaTriMoiPixel += pixelGrayValue * kernel[i, j];
                                }
                            }
                        }
                        // Đảm bảo giá trị nằm trong phạm vi [0, 255]
                        giaTriMoiPixel = Math.Min(Math.Max(giaTriMoiPixel / (kichThuocKernel * kichThuocKernel), 0), 255);

                        // Tạo màu mới từ giá trị đã tính toán
                        Color newColor = Color.FromArgb(giaTriMoiPixel, giaTriMoiPixel, giaTriMoiPixel);

                        // Set pixel mới vào ảnh kết quả
                        anhKetQua.SetPixel(x, y, newColor);
                    }
                }
                return anhKetQua;
            }

            // Loc trung vi 3x3
            public static Bitmap LocTrungVi(Bitmap anh, int kichThuocLanCan)
            {
                Bitmap anhKetQua = new Bitmap(anh.Width, anh.Height);
                int halfSize = kichThuocLanCan / 2;

                for (int x = halfSize; x < anh.Width - halfSize; x++)
                {
                    for (int y = halfSize; y < anh.Height - halfSize; y++)
                    {
                        // Không lấy giá trị trùng nhau
                        HashSet<int> neighbors = new HashSet<int>();
                        for (int i = -halfSize; i <= halfSize; i++)
                        {
                            for (int j = -halfSize; j <= halfSize; j++)
                            {
                                int pixelX = x + i;
                                int pixelY = y + j;
                                Color pixelColor = anh.GetPixel(pixelX, pixelY);
                                int pixelGrayValue = pixelColor.R;
                                neighbors.Add(pixelGrayValue);
                            }
                        }

                        // Sap xep gia tri pixel va lay gia tri trung vi
                        List<int> uniqueNeighbors = neighbors.ToList();
                        uniqueNeighbors.Sort();
                        int median = uniqueNeighbors[uniqueNeighbors.Count / 2];
                        Color newColor = Color.FromArgb(median, median, median);
                        anhKetQua.SetPixel(x, y, newColor);
                    }
                }
                return anhKetQua;
            }
        }

        private void FBai2_Load(object sender, EventArgs e)
        {
            if (ptbAnhXam.Image != null)
            {
                Bitmap hinhXam = new Bitmap(ptbAnhXam.Image);

                //Loc anh voi kernel 3x3, padding = 1
                Bitmap I1 = ImageProcessing.LocAnh(hinhXam, 3, 1);
                ptbI1.Image = I1;

                //Loc anh voi kernel 5x5, padding = 2
                Bitmap I2 = ImageProcessing.LocAnh(hinhXam, 5, 2);
                ptbI2.Image = I2;

                //Loc anh voi kernel 7x7, padding = 3 va stride = 2
                Bitmap I3 = ImageProcessing.LocVoiStride(hinhXam, 7, 3, 2);
                ptbI3.Image = I3;

                //Loc trung vi tren anh I3 voi lan can 3x3
                Bitmap I4 = ImageProcessing.LocTrungVi(I3, 3);
                ptbI4.Image = I4;
            }

        }
    }

}