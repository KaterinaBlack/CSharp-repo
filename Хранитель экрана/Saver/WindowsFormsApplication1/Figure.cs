
using System.Drawing;
namespace WindowsFormsApplication1
{
    public class Figure
    {
        protected Pixel pixel; // начальная координата 
        protected Pixel step;    // смещение по х и у
        protected Pixel depth;
        static Pixel min, max;
        public Color color;

        public Figure (int x, int y, int sx, int sy)
        {
            pixel = new Pixel(x, y);
            step = new Pixel(sx, sy);
        }
        public Figure (Pixel pixel)
        {
            this.pixel = pixel;
            step = new Pixel(3, 5);
            depth = new Pixel(30, 30);
        }

        public Figure(Pixel pixel, Pixel step, Color color)
        {
            this.pixel = pixel;
            this.step = step;
            depth = new Pixel(30, 30);
            this.color = color;
        }

        public Pixel GetPixel()
        {
            return pixel;
        }

        public Pixel GetStep()
        {
            return step;
        }

        public Pixel GetDepth()
        {
            return depth;
        }

        public static void SetBounds (Pixel p0, Pixel p1)
        {
            min = p0;
            max = p1;
        }

        public void SetStep (Pixel s)
        {
            this.step = s;
        }

        public void SetStep(int sx, int sy)
        {
            this.step = new Pixel(sx, sy);
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetDepth (Pixel d)
        {
            this.depth = d;
        }

        public void SetDepth(int dx, int dy)
        {
            this.depth = new Pixel(dx,dy);
        }

        public void Move ()
        {
            pixel.x += step.x;
            pixel.y += step.y;

            if (pixel.x < min.x)
            {
                step.x = -step.x;
                pixel.x = min.x - (pixel.x - min.x);
            }

            if (pixel.y < min.y)
            {
                step.y = -step.y;
                pixel.y = min.y - (pixel.y - min.y);
            }

            int maxdx = max.x - depth.x;
            int maxdy = max.y - depth.y;
            
            if (pixel.x > maxdx)
            {
                step.x = -step.x;
                pixel.x = maxdx - (pixel.x - maxdx);
            }

            if (pixel.y > maxdy)
            {
                step.y = -step.y;
                pixel.y = maxdy - (pixel.y - maxdy);
            }
            
        }
    }
}
