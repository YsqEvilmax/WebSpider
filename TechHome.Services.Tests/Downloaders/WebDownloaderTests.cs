using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Downloaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Tasks;

namespace TechHome.Services.Downloaders.Tests
{
    [TestClass()]
    public class WebDownloaderTests
    {
        [TestMethod()]
        public void AddTaskTest()
        {
            var downloader = IoC.Resolve<IDownloader>();
            var task = IoC.Resolve<ITask>();
            Assert.IsNotNull(downloader);
            Assert.IsNotNull(task);
        }
    }
}