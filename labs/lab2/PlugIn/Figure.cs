using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PlugIn
{
    public class Figure : ICloneable
    {
        public int Id;
        public virtual object Clone() { return new object(); } //abstract
        public int R;
        public int G;
        public int B;
        public int Width;
        public List<Point> Points = new List<Point>() { };
        public int Count = 0;

        public int Rb;
        public int Gb;
        public int Bb;
        public Figure() { }

        public Figure(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
        {
            Color = Color.FromArgb(R, G, B);
            Brush = Color.FromArgb(Rb, Gb, Bb);
            this.Width = Width;
            Id = idx;
        }

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
        public virtual void Draw(Graphics graphics) { } //abstract
    }
}
