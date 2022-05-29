using PlugIn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Paint
{
    public class Fabric
    {
        private List<Figure> Extensions = new List<Figure>() { };

        public Figure ReturnFigure(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
        {
            switch (idx)
            {
                case 0:
                    return new Line(idx, R, G, B, Rb, Gb, Bb, Width);
                case 1:
                    return new Rect(idx, R, G, B, Rb, Gb, Bb, Width);
                case 2:
                    return new Ellipse(idx, R, G, B, Rb, Gb, Bb, Width);
                case 3:
                    return new BrokenLine(idx, R, G, B, Rb, Gb, Bb, Width);
                case 4:
                    return new Polygon(idx, R, G, B, Rb, Gb, Bb, Width);
                default:
                    return CheckOtherTypes(idx, R, G, B, Rb, Gb, Bb, Width);
            }
        }

        public void SetExtensions(List<Figure> figures)
        {
            Extensions.AddRange(figures);
        }

        private Figure CheckOtherTypes(int idx, int R, int G, int B, int Rb, int Gb, int Bb, int Width)
        {
            foreach (Figure f in Extensions)
            {
                if (f.Id == idx)
                {
                    var temp = f.Clone() as Figure;
                    temp.Id = idx;
                    temp.R = R;
                    temp.G = G;
                    temp.B = B;
                    temp.Rb = Rb;
                    temp.Gb = Gb;
                    temp.Bb = Bb;
                    temp.Width = Width;
                    return temp;
                }
            }

            return new Figure(0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
