using System;
using System.Xml.Serialization;

namespace TechHome.Services.Targets
{
    [Serializable]
    public class Element
    {
        [XmlIgnore]
        public Page Source { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        [XmlIgnore]
        public string Value { get; set; }
    }
}
