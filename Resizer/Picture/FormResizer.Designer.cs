namespace Resizer
{
    partial class FormResizer
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResizer));
            this.picture = new System.Windows.Forms.PictureBox();
            this.buttonOpenPicture = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_start = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.labelScale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.ImageLocation = "";
            this.picture.Location = new System.Drawing.Point(7, 0);
            this.picture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(581, 396);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // buttonOpenPicture
            // 
            this.buttonOpenPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonOpenPicture.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenPicture.Location = new System.Drawing.Point(595, 0);
            this.buttonOpenPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonOpenPicture.Name = "buttonOpenPicture";
            this.buttonOpenPicture.Size = new System.Drawing.Size(235, 51);
            this.buttonOpenPicture.TabIndex = 1;
            this.buttonOpenPicture.Text = "Выбрать картинку";
            this.buttonOpenPicture.UseVisualStyleBackColor = false;
            this.buttonOpenPicture.Click += new System.EventHandler(this.buttonOpenPicture_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.BackColor = System.Drawing.Color.White;
            this.textBoxFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFileName.Location = new System.Drawing.Point(595, 57);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(235, 27);
            this.textBoxFileName.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.BackColor = System.Drawing.Color.Yellow;
            this.button_start.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(595, 279);
            this.button_start.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(235, 51);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Изменить картинку";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.BackColor = System.Drawing.Color.Gold;
            this.button_save.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Location = new System.Drawing.Point(596, 336);
            this.button_save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(235, 51);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Сохранить картинку";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // trackBarScale
            // 
            this.trackBarScale.LargeChange = 10;
            this.trackBarScale.Location = new System.Drawing.Point(596, 142);
            this.trackBarScale.Maximum = 190;
            this.trackBarScale.Minimum = 10;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(229, 56);
            this.trackBarScale.TabIndex = 10;
            this.trackBarScale.TickFrequency = 10;
            this.trackBarScale.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarScale.Value = 100;
            this.trackBarScale.Scroll += new System.EventHandler(this.trackBarScale_Scroll);
            // 
            // labelScale
            // 
            this.labelScale.Location = new System.Drawing.Point(595, 97);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(230, 33);
            this.labelScale.TabIndex = 11;
            this.labelScale.Text = "Масштаб:";
            this.labelScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormResizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 399);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.trackBarScale);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonOpenPicture);
            this.Controls.Add(this.picture);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormResizer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение размера изображений";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button buttonOpenPicture;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Label labelScale;
    }
}

