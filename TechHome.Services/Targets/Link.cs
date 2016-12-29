using System;
using System.Collections.Generic;
using System.Linq;

namespace TechHome.Services.Targets
{
    [Serializable]
    public class Link
        : Element
    {
        public List<Element> Elements { get; private set; }

        public Link(string uri)
            :this()
        {
            this.Value = uri;
        }
        public Link()
        {
            Elements = new List<Element>();
        }

        public Link(Link e)
            :base(e)
        {
            this.Elements = e.Elements.Select(x=>x).ToList();
        }

        public Uri Uri() { return string.IsNullOrEmpty(Value)?null:new Uri(Value); }

        public void SetSource(Page source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(@"The source of an Element cannot be null!");
            }
            foreach(var element in Elements)
            {
                element.Source = source;
                (element as Link)?.SetSource(source);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Link e = obj as Link;
            return base.Equals(e) &
                Elements.SequenceEqual(e.Elements);
        }
    }
}
