using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Downloaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Tasks;
using TechHome.Cores;

namespace TechHome.Services.Downloaders.Tests
{
    [TestClass()]
    public class WebDownloaderTests
    {
        [TestMethod()]
        public void WebDownloader_IoC_GetInstance()
        {
            var downloader = IoC.Resolve<IDownloader>();
            Assert.IsNotNull(downloader);
        }
        [TestMethod()]
        public void AddTaskTest()
        {
        }
    }
}