using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Pages;
using TechHome.Services.Targets;

namespace TechHome.Services.Targets.Tests
{
    [TestClass()]
    public class PageTests
    {
        [TestMethod()]
        public void Page_Constructor_ResultNotNull()
        {
            Page page1 = new Page();
            Assert.IsNotNull(page1.Results);
            Page page2 = Page.Get("BaiduPage.xml");
            Assert.IsNotNull(page2.Results);
        }
        [TestMethod()]
        public void Get_PageTemplateName_PageInstance()
        {
            Page page = Page.Get("BaiduPage.xml");
            Assert.IsNotNull(page);
            Assert.AreEqual("BaiduPage", page.Name);
            Assert.IsTrue(page.Elements.All(x => x.Source == page));
        }
    }
}
