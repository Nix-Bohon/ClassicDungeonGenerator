using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using ClassicDungeonGenerator.Models;
using ClassicDungeonGenerator.Factories;

namespace ClassicDungeonGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            DungeonLevelCreator c = new DungeonLevelCreator();
            DungeonLevel l = c.GenerateLevel();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer i = new System.Xml.Serialization.XmlSerializer(typeof(DungeonLevel));
            i.Serialize(sw, l);
            sw.ToString();
        }
    }
}
