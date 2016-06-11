namespace MindCounter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelTask = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMult = new System.Windows.Forms.Button();
            this.buttonDivs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTask
            // 
            this.labelTask.BackColor = System.Drawing.Color.White;
            this.labelTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTask.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTask.Location = new System.Drawing.Point(12, 9);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(470, 124);
            this.labelTask.TabIndex = 0;
            this.labelTask.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAnswer.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAnswer.Location = new System.Drawing.Point(488, 8);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(272, 124);
            this.textBoxAnswer.TabIndex = 1;
            this.textBoxAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAnswer_KeyDown);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlus.Location = new System.Drawing.Point(12, 164);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(181, 75);
            this.buttonPlus.TabIndex = 2;
            this.buttonPlus.Text = "Сложение";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 164);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(748, 75);
            this.progress.TabIndex = 3;
            this.progress.Visible = false;
            // 
            // buttonMinus
            // 
            this.buttonMinus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinus.Location = new System.Drawing.Point(199, 164);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(181, 75);
            this.buttonMinus.TabIndex = 4;
            this.buttonMinus.Text = "Вычитание";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonMult
            // 
            this.buttonMult.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMult.Location = new System.Drawing.Point(386, 164);
            this.buttonMult.Name = "buttonMult";
            this.buttonMult.Size = new System.Drawing.Size(181, 75);
            this.buttonMult.TabIndex = 5;
            this.buttonMult.Text = "Умножение";
            this.buttonMult.UseVisualStyleBackColor = true;
            this.buttonMult.Click += new System.EventHandler(this.buttonMult_Click);
            // 
            // buttonDivs
            // 
            this.buttonDivs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDivs.Location = new System.Drawing.Point(579, 164);
            this.buttonDivs.Name = "buttonDivs";
            this.buttonDivs.Size = new System.Drawing.Size(181, 75);
            this.buttonDivs.TabIndex = 6;
            this.buttonDivs.Text = "Деление";
            this.buttonDivs.UseVisualStyleBackColor = true;
            this.buttonDivs.Click += new System.EventHandler(this.buttonDivs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 278);
            this.Controls.Add(this.buttonDivs);
            this.Controls.Add(this.buttonMult);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Устный счет";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTask;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonMult;
        private System.Windows.Forms.Button buttonDivs;
    }
}

