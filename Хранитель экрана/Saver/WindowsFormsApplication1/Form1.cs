using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public struct Pixel
    {
        public int x;
        public int y;

        public Pixel (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class FormSaver : Form
    {
        Graph graph;
        Polygone p;
        static Random rnd = new Random();
        Color[] colors;

        public FormSaver()
        {
            InitializeComponent();
            InitGraph();
            InitFigures();
            timer.Enabled = true;
        }
        
        private void InitGraph()
        {
            InitColors();
            graph = new Graph(picture.Width, picture.Height, colors[11], colors[rnd.Next(0, 10)]);
        }

        private void InitFigures()
        {
            Figure.SetBounds(new Pixel(0, 0), new Pixel(graph.bmp.Width, graph.bmp.Height));
            p = new Polygone();
            for (int i = 0; i < rnd.Next(5,15); i++)
                p.AddFigure(new Figure(rnd.Next(0,graph.bmp.Width),rnd.Next(0,graph.bmp.Height),rnd.Next(1,10),rnd.Next(1,10)));
           SetColorsPolygone(p);
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            graph.Clear();
            graph.Erase(p);
            p.Move();
            graph.DrawColors(p);
            picture.Image = graph.bmp;
        }       

        private void InitColors()
        {
            colors = new Color[12];
            colors[0] = Color.Blue;
            colors[1] = Color.Red;
            colors[2] = Color.Yellow;
            colors[3] = Color.Lime;
            colors[4] = Color.Pink;
            colors[5] = Color.Purple;
            colors[6] = Color.Silver;
            colors[7] = Color.Violet;
            colors[8] = Color.Green;
            colors[9] = Color.LightSkyBlue;
            colors[10] = Color.White;
            colors[11] = Color.Black;
        }

        private void SetColorsPolygone(Polygone polygone)
        {
            foreach (Figure f in polygone.list)
            {
                f.SetColor(colors[rnd.Next(0, 10)]);
            }
        }
        private void picture_MouseClick(object sender, MouseEventArgs e)
        {
            p.AddFigure(new Figure(e.X, e.Y, rnd.Next(1, 10), rnd.Next(1, 10)));
            graph.Clear();

        }

    }
}
