using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Paint
{
    class BrokenLine : Figure
    {
        public BrokenLine()
        {
            Id = 3;
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
            graphics.DrawLines(new Pen(Color, Width), points.ToArray());
            Points = points;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }
    }
}