using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using PlugIn;

namespace Paint
{
    public partial class Form1 : Form
    {
        List<string> BuiltIn = new List<string>() { "Line", "Rect", "BrokenLine", "Ellipse", "Polygon" }; 
        bool Painting = false;
        Graphics Graphics;
        List<Figure> Figures; //Figure
        List<Figure> SavedFig;
        Figure Figure; //Figure
        bool ComplexFigure = false;
        Bitmap bmp;
        Figure Repeate;
        Fabric Fabric = new Fabric() { };
        string path = "Figures.json";
        Ser Ser;
        private List<IPlugin> Plugins;

        public Form1()
        {
            InitializeComponent();
            FigureBox.Items.AddRange(new List<string>() { "Line", "Rect", "Ellipse", "BrokenLine", "Polygon"}.ToArray());
            FigureBox.SelectedIndex = 0;
            Figures = new List<Figure>() { };  // new List<Figure>() { };
            SavedFig = new List<Figure>() { };
            Ser = new Ser() { };

            Rectangle rec = Screen.PrimaryScreen.Bounds;
            bmp = new Bitmap(rec.Width, rec.Height);
            Graphics = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Painting = true;
            Figure.Points.Add(new Point(e.X, e.Y));
            Figure.Count = Figure.Count >= 2 ? Figure.Count + 1 : 2;
            //Figure.Count++;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Figures.Add(Figure);
            CheckComplexity();
            //Painting = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Painting)
            {
                Figure.Points.Add(new Point(e.X, e.Y));
                UpdateScreen();
                Figure.Draw(Graphics);
                pictureBox.Refresh();
            }
        }

        public void UpdateScreen()
        {
            Graphics.Clear(Color.White);
            foreach (Figure f in Figures)
            {
                f.Draw(Graphics);
            }

            //Figure.Draw(Graphics);
            //pictureBox.Refresh();
        }

        public void CheckComplexity()
        {
            if (Figure.Id <= 2 || (ComplexFigure && Figure.Id > 2))
            {
                Figures.Add(Figure);
                backBut.Enabled = true;
                Figure = (Figure)Figure.Clone();
                Figure.Points = new List<Point>() { };
                Figure.Count = 0;
                Painting = false;
                ComplexFigure = false;
                RepeatCombo();
            }
        }

        private void RBox_ValueChanged(object sender, EventArgs e)
        {
            Figure.Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value);
        }

        private void GBox_ValueChanged(object sender, EventArgs e)
        {
            RBox_ValueChanged(sender, e);
        }

        private void BBox_ValueChanged(object sender, EventArgs e)
        {
            RBox_ValueChanged(sender, e);
        }

        /*private void LineBut_CheckedChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(0, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = new Line() { Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value),
             //   Width = (int)WidthBox.Value };
        }

        private void RectBut_CheckedChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(1, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = new Rect() { Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value),
            //    Width = (int)WidthBox.Value };
        }

        private void EllipseBut_CheckedChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(2, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = new Ellipse() { Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value),
            //Width = (int)WidthBox.Value };
        }

        private void BrokenBut_CheckedChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(3, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = new BrokenLine() { Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value),
            //    Width = (int)WidthBox.Value };
        }

        private void PolyBut_CheckedChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(4, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value,  (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = new Polygon()
            //{
            //    Color = Color.FromArgb((int)RBox.Value, (int)GBox.Value, (int)BBox.Value),
            //    Width = (int)WidthBox.Value
            //};
        }*/

        private void WidthBox_ValueChanged(object sender, EventArgs e)
        {
            Figure.Width = (int)WidthBox.Value;
        }

        private void RbBox_ValueChanged(object sender, EventArgs e)
        {
            Figure.Brush = Color.FromArgb((int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value);
        }

        private void GbBox_ValueChanged(object sender, EventArgs e)
        {
            RbBox_ValueChanged(sender, e);
        }

        private void BbBox_ValueChanged(object sender, EventArgs e)
        {
            RbBox_ValueChanged(sender, e);
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ComplexFigure = true;
        }

        private void backBut_Click(object sender, EventArgs e)
        {
            SavedFig.Add(Figures.Last());
            retBut.Enabled = true;
            Figures = Figures.GetRange(0, Figures.Count - 1); //.ToArray()[..^1].ToList();
            UpdateScreen();
            pictureBox.Refresh();
            if (Figures.Count == 0)
            {
                backBut.Enabled = false;
            }

            RepeatCombo();
        }

        private void retBut_Click(object sender, EventArgs e)
        {
            Figures.Add(SavedFig.Last());
            backBut.Enabled = true;
            SavedFig = SavedFig.GetRange(0, SavedFig.Count - 1); //.ToArray()[..^1].ToList();
            UpdateScreen();
            pictureBox.Refresh();
            if (SavedFig.Count == 0)
            {
                retBut.Enabled = false;
            }

            RepeatCombo();
        }

        private void RepeatCombo()
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(Figures.ToArray()[..]);
            if (comboBox.Items.Count != 0)
            {
                comboBox.Enabled = true;
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.Enabled = false;
            }
            checkBox.Checked = false;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            RepeateDraw();
        }

        private void XBox_ValueChanged(object sender, EventArgs e)
        {
            RepeateDraw();
        }

        private void YBox_ValueChanged(object sender, EventArgs e)
        {
            RepeateDraw();
        }

        private void RepeateDraw()
        {
            UpdateScreen();
            int id = comboBox.SelectedIndex;
            //Figure temp = (object)Figures.ElementAt(id).Clone();
            Figure temp = (Figure)((Figure)Figures.ElementAt(id)).Clone();
            List<Point> points = new List<Point>(){ };
            if (checkBox.Checked)
            {
                foreach (Point p in temp.Points)
                {
                    points.Add(new Point((int)(p.X + XBox.Value), (int)(p.Y + YBox.Value)));
                }

                temp.Points = points;
                temp.Draw(Graphics);
                Repeate = temp;
            }

            pictureBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Figures.Add(Repeate);
            UpdateScreen();
            pictureBox.Refresh();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            XBox.Value = 0;
            YBox.Value = 0;
            RepeateDraw();
        }

        private void FigureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Figure = Fabric.ReturnFigure(FigureBox.SelectedIndex, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);

            //Figure = Fabric.ReturnFigure(0, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = Fabric.ReturnFigure(1, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = Fabric.ReturnFigure(2, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = Fabric.ReturnFigure(2, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = Fabric.ReturnFigure(3, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
            //Figure = Fabric.ReturnFigure(4, (int)RBox.Value, (int)GBox.Value, (int)BBox.Value, (int)RbBox.Value, (int)GbBox.Value, (int)BbBox.Value, (int)WidthBox.Value);
        }

        private void serBut_Click(object sender, EventArgs e)
        {
            path = fileTextBox.Text;
            Ser.SerFigures(path, Figures, fileTextBox);
        }

        private void DesBut_Click(object sender, EventArgs e)
        {
            path = fileTextBox.Text;
            List<Figure> figs = Ser.DesFigures(path, fileTextBox);
            //if (PlugBut.Enabled && figs.Where(f => f.Id > 4)
            //{

            //}
            Figures.AddRange(figs);
            UpdateScreen();
            RepeatCombo();
            pictureBox.Refresh();
        }

        private List<Figure> LoadPlugins(string path)
        {
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            Plugins = new List<IPlugin>();
            List<Figure> figures = new List<Figure>() { };

            foreach (string pluginPath in pluginFiles)
            {
                Assembly assembly = Assembly.LoadFrom(pluginPath);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(typeof(Figure)) && !BuiltIn.Contains(type.Name))
                    {
                        var NewType = assembly.CreateInstance(type.FullName);
                        if (NewType != null)
                        {
                            Plugins.Add((IPlugin)NewType);
                            figures.Add((Figure)NewType);
                        }
                    }
                } 
            }

            return figures;
        }

        private void AddPluginsItems()
        {
            foreach (IPlugin plugin in this.Plugins)
            {
                if (plugin == null)
                {
                    continue;
                }
                FigureBox.Items.Add(plugin.PluginName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var temp = LoadPlugins(Application.StartupPath);
            Fabric.SetExtensions(temp);
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo f in dir.GetFiles("*.txt"))
            {
                fileComboBox.Items.Add(f.Name);
            }
        }

        private void PlugBut_Click(object sender, EventArgs e)
        {
            AddPluginsItems();
            PlugBut.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            path = fileComboBox.Text;
            fileTextBox.Text = path;
        }
    }
}
