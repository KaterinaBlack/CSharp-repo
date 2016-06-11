using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MindCounter
{
    public partial class Form1 : Form
    {
        int count;
        int min = 1;
        int max = 10;
        int count_max = 3;
        Random rnd = new Random();
        string result;
        string mode = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Start("plus");
        }

        private void Start(string my_mode)
        {
            mode = my_mode;
            buttonPlus.Visible = false;
            buttonMinus.Visible = false;
            buttonMult.Visible = false;
            buttonDivs.Visible = false;
            progress.Visible = true;
            labelTask.Enabled = true;
            textBoxAnswer.Enabled = true;
            textBoxAnswer.Text = "";
            progress.Minimum = 0;
            progress.Maximum = count_max;
            progress.Value = 0;
            count = 0;
            Think();

        }

        private void Think()
        {
            int a, b;
            a = rnd.Next(min, max + 1);
            b = rnd.Next(min, max + 1);
            labelTask.Text = a.ToString() + " + " + b.ToString() + " = ";
            result = (a + b).ToString();
            count++;
        }

        private void GameWin()
        {
            MessageBox.Show("Поздравляем, вы победили!!! Ура!!!");
            textBoxAnswer.Text = result;
            Done();
        }

        private void Done()
        {
            buttonPlus.Visible = true;
            buttonMinus.Visible = true;
            buttonMult.Visible = true;
            buttonDivs.Visible = true;
            progress.Visible = false;
            labelTask.Enabled = false;
            textBoxAnswer.Enabled = false;
            buttonPlus.Focus();
        }

        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBoxAnswer.Text == result)
                {
                    textBoxAnswer.Text = "";
                    progress.Value = count;
                    if (count == count_max)
                        GameWin();
                    else
                        Think();
                }
                else
                    Gameover();
            }
        }

        private void Gameover()
        {
            textBoxAnswer.Text = result;
            Done();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Start("minus");
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            Start("mult");
        }

        private void buttonDivs_Click(object sender, EventArgs e)
        {
            Start("divs");
        }
    }
}
