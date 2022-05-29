using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using PlugIn;

namespace Paint
{
    public class Ser
    {
        public Ser() { }

        public void SerFigures(string fileName, List<Figure> Figures, TextBox tb)
        {
            try
            {
                StringBuilder sb = new StringBuilder() { };
                foreach (Figure f in Figures)
                { 
                    sb.AppendLine(JsonConvert.SerializeObject(f, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
                }    
                File.WriteAllText(fileName, sb.ToString());
            }
            catch (Exception e)
            {
                tb.Text = "No such file";
                Console.WriteLine(e.Message);
            }
        }

        public List<Figure> DesFigures(string fileName, TextBox tb)
        {
            List<Figure> Figures = new List<Figure>() { };

            try
            {
                string[] json = File.ReadAllLines(fileName);
                foreach (string line in json)
                {
                    Figures.Add((Figure)JsonConvert.DeserializeObject(line, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
                }
            }
            catch
            {
                tb.Text = "No such file";
            }
            
            return Figures;
        }
    }
}
