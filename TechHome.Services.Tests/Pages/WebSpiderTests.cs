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
            var page = FetchPage("BaiduPage.xml", @"http://www.baidu.com");
            Assert.AreEqual("百度一下",
                page.Results.Find(x => x.Name.Equals("search")).Value);
        }

        [TestMethod()]
        public void FetchData_CLPage_GetResult()
        {
            var page = FetchPage("CLPage.xml", @"http://t66y.com/htm_data/22/1612/2196077.html");
            Assert.AreEqual("HEY-0652-美人姊妹極上味道前篇-小野麻里_1",
                page.Results.Find(x => x.Name.Equals("title")).Value);
            Assert.AreEqual("http://www.kedou1.com/get_file/3/8567e15df01575700cdbdfdf537b6263/37000/37455/37455.mp4",
                page.Results.Find(x => x.Name.Equals("movie")).Value);
        }

        [TestMethod()]
        public void FetchData_MixedPages_GetResults()
        {
            var para = new Dictionary<string, string>() {
                { @"http://t66y.com/htm_data/22/1612/2196077.html", "CLPAge.xml" },
                { @"http://www.baidu.com", "BaiduPage.xml" },
                { @"http://t66y.com/htm_data/22/1612/2185040.html", "CLPAge.xml"}
            };
            var pages = FetchPages(para);
            Assert.AreEqual(para.Count, pages.Count);
        }

        public Page FetchPage(string template, string url)
        {
            WebSpider spider = new WebSpider();
            var page = Page.GetFromFile(template);
            page.Value = url;
            spider.FetchData(page);
            ValidatePages(spider.Pages);
            return spider.Pages.Find(x => x.Value.Equals(url));
        }

        public List<Page> FetchPages(Dictionary<string, string> para)
        {
            WebSpider spider = new WebSpider();
            var pages = para.Select(
                x => {
                    var page = Page.GetFromFile(x.Value);
                    page.Value = x.Key;
                    return page;
                }).ToList();
            foreach (var page in pages)
            {
                spider.FetchData(page);
            }
            ValidatePages(spider.Pages);
            return spider.Pages;
        }

        private void ValidatePages(List<Page> pages)
        {
            Assert.IsTrue(pages.All(x => x.Results.All(y => y is Element)));
            Assert.IsTrue(pages.All(x => x.Results.All(y => !string.IsNullOrEmpty(y.Value))));
        }
    }
}
