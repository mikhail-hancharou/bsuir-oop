using PlugIn;
using System.Collections.Generic;
using System.Drawing;

namespace PluginOne
{
    class Trapez : Figure, IPlugin
    {
        public Trapez(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
            : base(idx, R, G, B, Rb, Gb, Bb, Width) { }

        public Trapez()
        {
            Id = 5;
        }
        public string PluginName { get; } = "Trapez";

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override void Draw(Graphics graphics)
        {
            List<Point> points = new List<Point>() { };
            bool flag = false;
            if (Count > 3)
            {
                points.AddRange(Points.ToArray()[..4]);
                flag = true;
            }
            else
            {
                points.AddRange(Points.ToArray()[..(Count - 1)]);
                points.Add(Points.ToArray()[^1]);
            }

            Point p = points[1];
            p.Y = points[0].Y;
            points.RemoveAt(1);
            points.Insert(1, p);
            if (Count == 3 || flag)
            {
                p = points[2];
                p.X = points[1].X - points[2].X + points[0].X;
                points.Insert(3, p);
            }

            graphics.FillPolygon(new SolidBrush(Brush), points.ToArray());
            graphics.DrawPolygon(new Pen(Color, Width), points.ToArray());
            Points = points;
        }
    }
}
