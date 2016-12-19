using System;
using System.Collections.Generic;

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

        public Uri Uri() { return new Uri(Value); }

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
    }
}
