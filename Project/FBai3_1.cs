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

                Bitmap lbpImage = ComputeLBP(hinhXam, padding: 1); // Change padding to 0 or 1
                ptbPadding0.Image = lbpImage;
            }
        }
        
        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayImage = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = original.GetPixel(x, y);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    grayImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return grayImage;
        }

        private Bitmap ComputeLBP(Bitmap grayImage, int padding)
        {
            int width = grayImage.Width;
            int height = grayImage.Height;

            Bitmap lbpImage = new Bitmap(width, height);

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int centerPixel = grayImage.GetPixel(x, y).R;
                    int lbpValue = 0;

                    // Neighborhood pixels (clockwise starting from top-left)
                    int[] neighbors = new int[8]
                    {
                        GetGrayValue(grayImage, x - 1, y - 1, padding),
                        GetGrayValue(grayImage, x, y - 1, padding),
                        GetGrayValue(grayImage, x + 1, y - 1, padding),
                        GetGrayValue(grayImage, x + 1, y, padding),
                        GetGrayValue(grayImage, x + 1, y + 1, padding),
                        GetGrayValue(grayImage, x, y + 1, padding),
                        GetGrayValue(grayImage, x - 1, y + 1, padding),
                        GetGrayValue(grayImage, x - 1, y, padding)
                    };

                    // Compute LBP value
                    for (int i = 0; i < 8; i++)
                    {
                        if (neighbors[i] >= centerPixel)
                        {
                            lbpValue += (1 << i);
                        }
                    }

                    // Assign LBP value to pixel
                    lbpImage.SetPixel(x, y, Color.FromArgb(lbpValue, lbpValue, lbpValue));
                }
            }

            return lbpImage;
        }

        private int GetGrayValue(Bitmap image, int x, int y, int padding)
        {
            if (x < 0 || y < 0 || x >= image.Width || y >= image.Height)
            {
                return padding == 0 ? 0 : 255; // Padding mode
            }
            return image.GetPixel(x, y).R;
        }
    }
}