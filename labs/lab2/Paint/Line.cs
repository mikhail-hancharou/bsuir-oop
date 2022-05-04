using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Paint
{
    public class Line : Figure
    {
        public Line()
        {
            Id = 0;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override void Draw(Graphics graphics)
        {
            Points = new List<Point>() { Points.ToArray()[0], Points.ToArray()[^1] };
            //graphics.DrawLine(new Pen(Color, Width), startX, startY, initX, initY);
            graphics.DrawLine(new Pen(Color, Width), Points.ToArray()[0], Points.ToArray()[^1]);
        }
    }
}
