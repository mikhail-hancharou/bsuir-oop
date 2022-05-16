using PlugIn;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Paint
{
    class Rect : Figure
    {
        public Rect(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
            : base(idx, R, G, B, Rb, Gb, Bb, Width) { }

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override void Draw(Graphics graphics)
        {
            int SX = Points.ToArray()[0].X;
            int SY = Points.ToArray()[0].Y;
            int LX = Points.ToArray()[^1].X;
            int LY = Points.ToArray()[^1].Y;
            int sX = LX - SX < 0 ? LX : SX;
            int sY = LY - SY < 0 ? LY : SY;
            int widtgh = Math.Abs(LX - SX), height = Math.Abs(LY - SY);

            Points = new List<Point>() { Points.ToArray()[0], Points.ToArray()[^1] };

            Rectangle rect = new Rectangle(sX, sY, widtgh, height);
            graphics.FillRectangle(new SolidBrush(Brush), rect);
            graphics.DrawRectangle(new Pen(Color, Width), rect);
        }
    }
}