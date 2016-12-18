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

        public void SetOriginSource(string origin)
        {
            foreach(var element in Elements)
            {
                element.OriginSource = origin;
                if(element is Link)
                {
                    (element as Link).SetOriginSource(origin);
                }
            }
        }
    }
}
