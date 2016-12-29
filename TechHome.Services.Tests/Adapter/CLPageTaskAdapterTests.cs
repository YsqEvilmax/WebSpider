using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Pages;
using TechHome.Services.Targets;
using TechHome.Services.Adapters;
using TechHome.Services.Pages.Tests;
using System.Collections.Generic;

namespace TechHome.Services.Adapter.Tests
{
    [TestClass]
    public class CLPageTaskAdapterTests
    {
        [TestMethod]
        public void Adapt_FromPage_ToTask()
        {
            var page = new WebSpiderTests().FetchPage("CLPage.xml", 
                @"http://t66y.com/htm_data/22/1612/2196077.html");
            var task = new PageCLTaskAdapter().Adapt(page);
            Assert.IsNotNull(task);
            Assert.AreEqual("HEY-0652-美人姊妹極上味道前篇-小野麻里_1.mp4", task.FileName);
            Assert.AreEqual(new Uri(@"http://www.kedou1.com/get_file/3/8567e15df01575700cdbdfdf537b6263/37000/37455/37455.mp4"), task.Uri);
        }

        [TestMethod]
        public void Adapt_FromPages_ToTasks()
        {
            var para = new Dictionary<string, string>() {
                { @"http://t66y.com/htm_data/22/1612/2196077.html", "CLPage.xml" },
                { @"http://www.baidu.com", "BaiduPage.xml" },
                { @"http://t66y.com/htm_data/22/1612/2185040.html", "CLPage.xml"}
            };
            var pages = new WebSpiderTests().FetchPages(para);
            var tasks = new PageCLTaskAdapter().Adapt(pages);
            Assert.IsTrue(tasks.Count > 0);
        }
    }
}
