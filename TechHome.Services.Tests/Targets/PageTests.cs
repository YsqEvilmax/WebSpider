using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Pages;
using TechHome.Services.Targets;
using System.Xml.Serialization;

namespace TechHome.Services.Targets.Tests
{
    [TestClass()]
    public class PageTests
        : CopyEqualTests<Page>
    {
        private class TestPair
        {
            public string Content { get; set; }
            public Page Page { get; set; }
        }

        private List<TestPair> _tests = new List<TestPair>();

        [TestInitialize()]
        public void Initialize()
        {
            _e1 = Page.GetFromFile("BaiduPage.xml");
            _e2 = Page.GetFromFile("BaiduPage.xml");

            var files = Directory.Exists("Pages") ? Directory.GetFiles("Pages").ToList() : null;
            XmlSerializer serializer = new XmlSerializer(typeof(Page));
            _tests = files?.Select(x =>
            {
                return new TestPair
                {
                    Content = File.ReadAllText(x)
                };
            }).ToList();
            _tests.ForEach(x =>
            {
                x.Page = serializer.Deserialize(new StringReader(x.Content)) as Page;
                x.Page?.SetSource(x.Page);
            });
        }

        [TestMethod()]
        public void Page_Constructor_ResultNotNull()
        {
            Page page = new Page();
            Assert.IsNotNull(page.Results);
        }

        [TestMethod()]
        public void GetFromFile_PageTemplateName_PageInstance()
        {
            _tests.ForEach(x => {
                Page page = Page.GetFromFile(x.Page.FileName);
                Assert.IsNotNull(page);
                Assert.AreEqual(x.Page, page);
            });
        }

        [TestMethod()]
        public void GetFromString_PageTemplateName_PageInstance()
        {
            _tests.ForEach(x => {
                Page page = Page.GetFromString(x.Content);
                Assert.IsNotNull(page);
                Assert.AreEqual(x.Page, page);
            });
        }
    }
}
