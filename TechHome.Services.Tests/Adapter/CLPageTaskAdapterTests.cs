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
                @"http://t66y.com/htm_data/22/1612/2187375.html");
            var task = new PageCLTaskAdapter().Adapt(page);
            Assert.IsNotNull(task);
            Assert.AreEqual("91轻吻@商务模特系列之美院女孩儿720P完整版.mp4", task.FileName);
            Assert.AreEqual(new Uri(@"http://www.kdw521.com/get_file/3/6159246da3c9c19794de8aa68713fd68/37000/37285/37285.mp4"), task.Uri);
        }

        [TestMethod]
        public void Adapt_FromPages_ToTasks()
        {
            var para = new Dictionary<string, string>() {
                { @"http://t66y.com/htm_data/22/1612/2187375.html", "CLPAge.xml" },
                { @"http://www.baidu.com", "BaiduPage.xml" },
                { @"http://t66y.com/htm_data/22/1612/2185040.html", "CLPAge.xml"}
            };
            var pages = new WebSpiderTests().FetchPages(para);
            var tasks = new PageCLTaskAdapter().Adapt(pages);
            Assert.AreEqual(1, tasks.Count);
        }
    }
}
