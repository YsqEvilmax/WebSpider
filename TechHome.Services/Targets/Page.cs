using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using TechHome.Cores;
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
        }

        public Page(Page e)
            :base(e)
        {
            this.Results = e.Results.Select(x=>x).ToList();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Page e = obj as Page;
            return base.Equals(obj) &
                Results.SequenceEqual(e.Results);
        }

        public static Page GetFromFile(string fileName)
        {
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
            string folder = Properties.Settings.Default["PagesFolder"] as string;
            string content = File.ReadAllText(Path.Combine(binPath, folder, fileName));
            return GetFromString(content);
        }

        public static Page GetFromString(string content)
        {
            XmlSerializer<Page> ser = new XmlSerializer<Page>();
            Page page = ser.Deserialize(content);
            page.SetSource(page);
            return page;
        }

        public void SetToFile()
        {
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "");
            string folder = Properties.Settings.Default["PagesFolder"] as string;
            string content = SetToString();
            File.WriteAllText(Path.Combine(binPath, folder, this.FileName), content);
        }

        public string SetToString()
        {
            XmlSerializer<Page> ser = new XmlSerializer<Page>();
            return ser.Serialize(this);
        }
    }
}
