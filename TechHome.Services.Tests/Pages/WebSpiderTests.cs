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
            var page = FetchPage("CLPage.xml", @"http://t66y.com/htm_data/22/1612/2187375.html");
            Assert.AreEqual("91轻吻@商务模特系列之美院女孩儿720P完整版",
                page.Results.Find(x => x.Name.Equals("title")).Value);
            Assert.AreEqual("http://www.kdw521.com/get_file/3/6159246da3c9c19794de8aa68713fd68/37000/37285/37285.mp4",
                page.Results.Find(x => x.Name.Equals("movie")).Value);
        }

        [TestMethod()]
        public void FetchData_MixedPages_GetResults()
        {
            var para = new Dictionary<string, string>() {
                { @"http://t66y.com/htm_data/22/1612/2187375.html", "CLPAge.xml" },
                { @"http://www.baidu.com", "BaiduPage.xml" },
                { @"http://t66y.com/htm_data/22/1612/2185040.html", "CLPAge.xml"}
            };
            var pages = FetchPages(para);
            Assert.AreEqual(3, pages.Count);
        }

        public Page FetchPage(string template, string url)
        {
            WebSpider spider = new WebSpider();
            var page = Page.Get(template);
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
                    var page = Page.Get(x.Value);
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
