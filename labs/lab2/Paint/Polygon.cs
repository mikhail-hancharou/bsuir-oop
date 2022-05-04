using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Paint
{
    public class Polygon : Figure
    {
        public Polygon()
        {
            Id = 4;
        }

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
            graphics.FillPolygon(new SolidBrush(Brush), points.ToArray());
            graphics.DrawPolygon(new Pen(Color, Width), points.ToArray());
            Points = points;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}
