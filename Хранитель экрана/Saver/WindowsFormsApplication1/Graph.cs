using System.Drawing;

namespace WindowsFormsApplication1
{
    class Graph
    {
        public Bitmap bmp { get; private set; }
        Graphics graph;

        Pen penBack;
        Pen penFore;
        Color colorBack;
        Color colorFore;

        public Graph(int width, int height)
        {
            bmp = new Bitmap(width, height);
            graph = Graphics.FromImage(bmp);
            InitPens();
        }

        public Graph(int width, int height, Color back, Color fore)
            : this (width, height)
        {
            colorBack = back;
            colorFore = fore;
            InitPens();     
        }

        public void InitPens()
        {
            penBack = new Pen(colorBack, 3.0f);
            graph.Clear(colorBack);
            penFore = new Pen(colorFore,3.0f);
        }

        public void SetForeColor(Color color)
        {
            colorFore = color;
            penFore = new Pen(color);
        }

        public void SetBackColor(Color color)
        {
            colorBack = color;
            penBack = new Pen(color);
        }

        public void DrawCircle(Pixel p, Pixel d)
        {
            graph.DrawEllipse(penFore, p.x, p.y, d.x, d.y);
        }

        public void EraseCircle(Pixel p, Pixel d)
        {
            graph.DrawEllipse(penBack, p.x, p.y, d.x, d.y);
        }

        public void DrawLine(Pixel a, Pixel b)
        {
            graph.DrawLine(penFore, a.x, a.y, b.x, b.y);
        }

        public void EraseLine(Pixel a, Pixel b)
        {
            graph.DrawLine(penBack, a.x, a.y, b.x, b.y);
        }

        public void Draw (Figure f)
        {
            DrawCircle(f.GetPixel(), f.GetDepth());
        }

        public void Erase(Figure f)
        {
            EraseCircle(f.GetPixel(), f.GetDepth());
        }

        public void Draw(Figure f, Color color)
        {
            DrawCircle(f.GetPixel(), f.GetDepth(), color);
        }

        public void DrawCircle(Pixel p, Pixel d, Color color)
        {
            graph.DrawEllipse(new Pen(color, 3.0f), p.x, p.y, d.x, d.y);
        }
      
        public void Draw(Polygone polygone, Pen pen)
        {
            Figure f1 = null;
            foreach (Figure f2 in polygone.list)
            {
                if (f1 != null)
                    DrawLine(pen, f1.GetPixel(), f2.GetPixel());
                f1 = f2;
            }
            if (polygone.list.Count > 2)
                DrawLine(pen,
                    polygone.list[0].GetPixel(),
                    polygone.list[polygone.list.Count - 1].GetPixel());
        }

        public void DrawDiferentColors(Polygone polygone)
        {
            Figure f1 = null;
            foreach (Figure f2 in polygone.list)
            {
                if (f1 != null)
                    DrawLine(new Pen(f1.color,2.0f), f1.GetPixel(), f2.GetPixel());
                f1 = f2;
            }
            if (polygone.list.Count > 2)
                DrawLine(new Pen(polygone.list[0].color, 2.0f),
                    polygone.list[0].GetPixel(),
                    polygone.list[polygone.list.Count - 1].GetPixel());
        }

        public void DrawLine(Pen pen, Pixel a, Pixel b)
        {
            graph.DrawLine(pen, a.x, a.y, b.x, b.y);
        }

        public void Draw(Polygone polygone)
        {
            Draw(polygone, penFore);
        }
        public void Erase(Polygone polygone)
        {
            Draw(polygone, penBack);
        }

        public void DrawColors(Polygone polygone)
        {
            DrawDiferentColors(polygone);
        }

        public void Clear()
        {
            graph.Clear(colorBack);
        }
    }
}
