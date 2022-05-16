using System.Collections.Generic;
using System.Drawing;
using PlugIn;

namespace Paint
{
    public class Line : Figure
    {
        public Line() : base() { }
        public Line(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
            : base(idx, R, G, B, Rb, Gb, Bb, Width) { }

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
