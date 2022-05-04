using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Paint
{
    abstract public class Figure : ICloneable
    {
        public int Id;
        public abstract object Clone();
        private int R;
        private int G;
        private int B;
        public int initX;
        public int initY;
        public int startX;
        public int startY;
        public int Width;
        public List<Point> Points = new List<Point>() { };
        public int Count = 0;

        public Color Color
        {
            get => Color.FromArgb(R, G, B);
            set
            {
                R = value.R;
                G = value.G;
                B = value.B;
            }
        }

        private int Rb;
        private int Gb;
        private int Bb;
        public Color Brush
        {
            get => Color.FromArgb(Rb, Gb, Bb);
            set
            {
                Rb = value.R;
                Gb = value.G;
                Bb = value.B;
            }
        }
        public abstract void Draw(Graphics graphics);
    }
}
