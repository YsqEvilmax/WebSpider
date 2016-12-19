using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TechHome.Services.Pages;

namespace TechHome.Services.Targets
{
    [Serializable]
    public class Page
        : Link
    {
        [XmlIgnore]
        public List<Element> Results { get; private set; }
        [XmlIgnore]
        public string FileName { get { return Name + ".xml"; } }

        public Page()
        {
            Results = new List<Element>();
            SetSource(this);
        }

        public static Page Get(string fileName)
        {
            XmlSerializer<Page> ser = new XmlSerializer<Page>();
            return ser.Deserialize(fileName);
        }

        public void Set()
        {
            string folder = Properties.Settings.Default["PagesFolder"] as string;
            XmlSerializer<Page> ser = new XmlSerializer<Page>();
            ser.Serialize(this, Path.Combine(folder, this.FileName));
        }
    }
}
