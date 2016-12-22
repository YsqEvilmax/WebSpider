using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Targets;

namespace TechHome.Services.Pages.Tests
{
    [TestClass()]
    public class WebSpiderTests
    {
        [TestMethod()]
        public void WebSpider_Constructor_PagesNotNull()
        {
            WebSpider spider = new WebSpider();
            Assert.IsNotNull(spider.Pages);
        }

        [TestMethod()]
        public void FetchData_BaiduPage_GetResult()
        {
            WebSpider spider = new WebSpider();
            var page = Page.Get("BaiduPage.xml");
            page.Value = @"http://www.baidu.com";
            spider.FetchData(page);
            Assert.IsTrue(spider.Pages.All(x => x.Results.All(y => y is Element)));
            Assert.IsTrue(spider.Pages.All(x => x.Results.All(y => !string.IsNullOrEmpty(y.Value))));
        }
    }
}
