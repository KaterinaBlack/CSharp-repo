using System;
using System.Drawing;
using System.Windows.Forms;

namespace Picture
{
    public partial class FormPicture : Form
    {
        Bitmap bmp;
        Bitmap result;
        string text_brightness, text_contrast, text_gamma;

        public FormPicture()
        {
            InitializeComponent();
            text_brightness = labelBrightness.Text;
            text_contrast = labelContrast.Text;
            text_gamma = labelGamma.Text;
            TextChanges();
            comboCorrection.SelectedIndex = 0;
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

        public void ChangePicture()
        {
            result = new Bitmap(bmp);
            bool is_grey = checkBoxGreyscale.Checked;
            int brightness = trackBarBrightness.Value;
            int contrast = trackBarContrast.Value;
            int correction = comboCorrection.SelectedIndex;
            int gamma = trackBarGamma.Value;
            for (int y = 0; y <bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    if (is_grey)
                        pixel = ChangeGrayscale(pixel);
                    if (brightness != 0)
                        pixel = ChangeBrightness(pixel, brightness);
                    if(contrast != 0)
                        pixel = ChangeContrast(pixel, contrast);
                    switch(correction)
                    {
                        case 0: break;                      // линейная коррекция
                        case 1:  pixel = ChangeCorrection(pixel, CorrectionBySin );                   // sinus
                            break;
                        case 2: pixel = ChangeCorrection(pixel, CorrectionByExp);                            //exp
                            break;
                        case 3: pixel = ChangeCorrection(pixel, CorrectionByLog);                            // log
                            break;
                    }
                    if (gamma != 100)
                        pixel = ChangeGamma(pixel,gamma);
                    result.SetPixel(x, y, pixel);
                }
            picture.Image = result;
        }

        private Color ChangeGamma(Color pixel, int gamma)
        {
            double g = gamma / 100d;
            return Color.FromArgb(ChangeGamma(pixel.R, g), ChangeGamma(pixel.G, g), ChangeGamma(pixel.B, g));
        }

        private int ChangeGamma(int color, double gamma)
        {
            double result = Math.Pow(color / 255d, gamma) * 255;
            if (result > 255) result = 255;
            return Convert.ToInt16(result);
        }

        delegate int CorrectionFunction(int color);
        double correctionK = 8 * Math.Log(2) / 255d;
        private Color ChangeCorrection(Color pixel, CorrectionFunction fn)
        {
            return Color.FromArgb(fn(pixel.R), fn(pixel.G), fn(pixel.B));
        }

        int CorrectionBySin(int color)
        {
            if (color > 255) color = 255;
            if (color < 0) color = 0;
            double result = (255 / 2d) * Math.Sin(Math.PI / 255 * color - Math.PI / 2) + (255 / 2d);
            if (result > 255) result = 255;
            if (result < 0) result = 0;
            return Convert.ToInt16(result);
        }
        int CorrectionByExp (int color)
        {
            if (color > 255) color = 255;
            if (color < 0) color = 0;
            double result = Math.Exp(correctionK * color) - 1;
            if (result > 255) result = 255;
            if (result < 0) result = 0;
            return Convert.ToInt16(result);
        }
        int CorrectionByLog(int color)
        {
            if (color > 255) color = 255;
            if (color < 0) color = 0;
            double result = Math.Log(color + 1) / correctionK;
            if (result > 255) result = 255;
            if (result < 0) result = 0;
            return Convert.ToInt16(result);
        }
        private Color ChangeContrast(Color pixel, int value)
        {
            float procent = value / 100f;
            return Color.FromArgb(
                ChangeContrast(pixel.R, procent),
                ChangeContrast(pixel.G, procent),
                ChangeContrast(pixel.B, procent));
        }

        private int ChangeContrast(int color, float procent)
        {
            int result;
            if (procent < 0)
                result = Convert.ToInt16(color + procent * (color - 128));
            else
                result = Convert.ToInt16(128 + (color - 128) / (1 - procent));
            if (result > 255) result = 255;
            if (result < 0) result = 0;
            return result;
        }

        private Color ChangeBrightness(Color pixel, int value)
        {
            float procent = value / 100f;
            return Color.FromArgb(
                ChangeBrightness(pixel.R, procent),
                ChangeBrightness(pixel.G, procent),
                ChangeBrightness(pixel.B, procent));
        }

        private int ChangeBrightness(int color, float procent)
        {
            int result = Convert.ToInt16(color + procent * 128);
            if (result > 255) result = 255;
            if (result < 0) result = 0;
            return result;
        }

        private Color ChangeGrayscale(Color pixel)
        {
            int average = (pixel.R + pixel.G + pixel.B + 1) / 3;
            return Color.FromArgb(average, average, average);
        }

        private void buttonOpenPicture_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = openFileDialog.ShowDialog();
            LoadPicture(openFileDialog.FileName);
            
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            ChangePicture();
        }

        private void trackBarBrightness_ValueChanged(object sender, EventArgs e)
        {
            TextChanges();
        }

        private void trackBarContrast_ValueChanged(object sender, EventArgs e)
        {
            TextChanges();
        }

        private void trackBarGamma_ValueChanged(object sender, EventArgs e)
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
            labelBrightness.Text = text_brightness + " " + trackBarBrightness.Value + "%";
            labelContrast.Text = text_contrast + " " + trackBarContrast.Value + "%";
            labelGamma.Text = text_gamma + " " + trackBarGamma.Value + "%";
        }
    }
}
