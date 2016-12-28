using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Webs.Areas.WebSpider.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Webs.Areas.WebSpider.Models;

namespace TechHome.Webs.Areas.WebSpider.Controllers.Tests
{
    [TestClass()]
    public class WebTasksControllerTests
    {
        [TestMethod()]
        public void Fetch_WebTasks_CLTasks()
        {
            var tasks = new List<WebTask>()
            {
                new WebTask(){Url=@"http://t66y.com/htm_data/22/1612/2196077.html", Template="CLPage.xml"},
                new WebTask(){Url=@"http://www.baidu.com", Template="BaiduPage.xml" },
                new WebTask(){Url=@"http://t66y.com/htm_data/22/1612/2185040.html", Template="CLPage.xml"}
            };
            WebTasksController controller = new WebTasksController();
            var result = controller.Fetch(tasks);
            Assert.AreEqual(1, result.ToList().Count);
        }
    }
}