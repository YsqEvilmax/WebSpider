using System;

namespace TechHome.Services.Targets
{
    [Serializable]
    public class Element
    {
        public string OriginSource { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string Value { get; set; }
    }
}
