using System;
using System.Drawing;
using System.Windows.Forms;

namespace Resizer
{
    public partial class FormResizer : Form
    {
        Bitmap bmp;
        Bitmap result;
        string text_brightness, text_contrast, text_gamma;

        public FormResizer()
        {
            InitializeComponent();
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
            result = new Bitmap(bmp);
            for (int y = 0; y <bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    result.SetPixel(x, y, pixel);
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
            
        }
    }
}
