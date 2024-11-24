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
            showFormInPanel(new FBai2());
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            showFormInPanel(new FBai3());
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
                        ptbAnh.Image = Image.FromFile(openFileDialog.FileName);
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
            ptbAnhXam.Image = ConvertToGrayscale_Update((Bitmap)ptbAnh.Image);
        }
        private Bitmap ConvertToGrayscale(Bitmap original)
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
        private Bitmap ConvertToGrayscale_Update(Bitmap original)
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
    }
}
