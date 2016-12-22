using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Cores;

namespace TechHome.Services.Tasks.Tests
{
    [TestClass()]
    public class CLTaskTests
    {
        public void CLTask_IoC_GetInstance()
        {
            var task = IoC.Resolve<ITask>();
            Assert.IsNotNull(task);
        }
    }
}
