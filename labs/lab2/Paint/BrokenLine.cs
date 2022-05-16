using PlugIn;
using System.Collections.Generic;
using System.Drawing;

namespace Paint
{
    class BrokenLine : Figure
    {
        public BrokenLine(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
            : base(idx, R, G, B, Rb, Gb, Bb, Width) { }

        public override void Draw(Graphics graphics)
        {
            List<Point> points = new List<Point>() { };
            int temp = Count - 1;
            foreach (Point p in Points)
            {
                if (temp != 0)
                {
                    points.Add(p);
                    temp--;
                }
                else
                {
                    break;
                }
            }
            points.Add(Points.ToArray()[^1]);
            graphics.DrawLines(new Pen(Color, Width), points.ToArray());
            Points = points;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}