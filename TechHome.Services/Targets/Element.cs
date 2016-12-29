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

        public Element() { }

        public Element(Element e)
        {
            this.Source = e.Source;
            this.Name = e.Name;
            this.Pattern = e.Pattern;
            this.Value = e.Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Element e = obj as Element;
            return this.Name == e.Name &
                this.Pattern == e.Pattern &
                this.Value == e.Value;
        }

        public override int GetHashCode()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
