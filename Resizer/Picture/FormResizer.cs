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

        public void ChangePicture()
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
