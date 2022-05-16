using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PlugIn;

namespace Paint
{
    public class Ser
    {
        public Ser() { }

        public void SerFigures(string fileName, List<object> Figures)
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
                Console.WriteLine(e.Message);
            }
        }

        public List<object> DesFigures(string fileName)
        {
            //List<Figure> Figures = new List<Figure>() { };
            List<Object> objects = new List<object>() { };

            string[] json = File.ReadAllLines(fileName);
            foreach (string line in json)
            {
                objects.Add(JsonConvert.DeserializeObject(line, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All }));
            }
            return objects;
        }
    }
}
