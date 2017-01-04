using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypeLite;

namespace TechHome.Webs.WebSpider.Models
{
    [TsClass(Module = "Models")]
    public class WebTask
    {
        public string Url { get; set; }
        public string Template { get; set; }
    }
}