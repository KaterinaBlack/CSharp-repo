using System;
using System.Drawing;
using System.Windows.Forms;

namespace Resizer
{
    public partial class FormResizer : Form
    {
        Bitmap bmp;
        Bitmap result;
        string text_scale;

        public FormResizer()
        {
            InitializeComponent();
            text_scale = labelScale.Text;
            TextChanges();
        }

        public void LoadPicture(string filename)
        {
            try
            {
                bmp = new Bitmap(Image.FromFile(filename));
                textBoxFileName.Text = filename;
                picture.Image = bmp;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBoxFileName.Text = "";
            }
        }

        public void ResizeNearest()
        {
            float coeff = trackBarScale.Value/100.0f;
            int oldWidth = bmp.Width;
            int oldHeight = bmp.Height;
            int newWidth = Convert.ToInt16(oldWidth *coeff);
            int newHeight = Convert.ToInt16(oldHeight * coeff);

            float coWidth = (float)(oldWidth - 1) / (float)(newWidth - 1);
            float coHeight = (float)(oldHeight - 1) / (float)(newHeight - 1);

            result = new Bitmap(newWidth,newHeight);
            int x0, y0;
            for (int y = 0; y < newHeight; y++)
            {
                y0 = Convert.ToInt16(y * coHeight);
                for (int x = 0; x < newWidth; x++)
                {
                    x0 = Convert.ToInt16(x * coWidth);
                    Color pixel = bmp.GetPixel(x0, y0);
                    result.SetPixel(x, y, pixel);
                }
            }
            picture.Image = result;
        }

        public void ResizeBilinear()
        {
            float coeff = trackBarScale.Value / 100.0f;
            int oldWidth = bmp.Width;
            int oldHeight = bmp.Height;
            int newWidth = Convert.ToInt16(oldWidth * coeff);
            int newHeight = Convert.ToInt16(oldHeight * coeff);

            float coWidth = (float)(oldWidth - 1) / (float)(newWidth - 1);
            float coHeight = (float)(oldHeight - 1) / (float)(newHeight - 1);

            result = new Bitmap(newWidth, newHeight);
            float x, y;
            int x1, y1;
            int x2, y2;
            for (int newY = 0; newY < newHeight; newY++)
            {              
                for (int newX = 0; newX < newWidth; newX++)
                {
                    x = newX * coWidth;
                    y = newY * coHeight;
                    x1 = Convert.ToInt16(Math.Floor(x));
                    y1 = Convert.ToInt16(Math.Floor(y));
                    if (x1 > oldWidth - 2) x1 = oldWidth - 2;
                    if (y1 > oldHeight - 2) y1 = oldHeight - 2;
                    x2 = x1 + 1;
                    y2 = y1 + 1;

                    Color Q11 = bmp.GetPixel(x1, y1);
                    Color Q12 = bmp.GetPixel(x1, y2);
                    Color Q21 = bmp.GetPixel(x2, y1);
                    Color Q22 = bmp.GetPixel(x2, y2);
                    int R = BilinearValue(x, y, x1, y1, x2, y2, Q11.R, Q12.R, Q21.R, Q22.R);
                    int G = BilinearValue(x, y, x1, y1, x2, y2, Q11.G, Q12.G, Q21.G, Q22.G);
                    int B = BilinearValue(x, y, x1, y1, x2, y2, Q11.B, Q12.B, Q21.B, Q22.B);

                    Color pixel = Color.FromArgb(R, G, B);
                    result.SetPixel(newX, newY, pixel);
                }
            }
            picture.Image = result;
        }

        private static int BilinearValue(
            float x, float y, 
            int x1, int y1, int x2, int y2, 
            int Q11, int Q12, int Q21, int Q22)
        {
            int R1, R2;
            int P;

            R1 = Convert.ToInt16((x2 - x) * Q11 + (x - x1) * Q21);
            R2 = Convert.ToInt16((x2 - x) * Q12 + (x - x1) * Q22);
            P = Convert.ToInt16((y2 - y) * R1 + (y - y1) * R2);
            if (P < 0) P = 0;
            if (P > 255) P = 255;
            return P;
        }

        private void buttonOpenPicture_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = openFileDialog.ShowDialog();
            LoadPicture(openFileDialog.FileName);
            
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (comboBoxMethod.SelectedIndex == 0)
                ResizeNearest();
            else
                if (comboBoxMethod.SelectedIndex == 1)
                ResizeBilinear();
        }

        private void trackBarScale_Scroll(object sender, EventArgs e)
        {
            TextChanges();
        }

        private void button_save_Click(object sender, EventArgs e)
        {

            if (picture.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) 
                {
                    try
                    {
                        result.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TextChanges()
        {
            labelScale.Text = text_scale + " " + trackBarScale.Value.ToString() + "%";
        }
    }
}
