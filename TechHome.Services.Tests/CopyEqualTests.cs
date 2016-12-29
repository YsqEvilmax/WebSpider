using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHome.Services.Targets.Tests
{
    [TestClass]
    public class CopyEqualTests<T>
        where T: new()
    {
        protected T _e1, _e2;

        [TestMethod()]
        public void Constructor_Copy()
        {
            Assert.IsNotNull(_e2);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.AreEqual(_e1, _e2);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.AreNotEqual(_e1.GetHashCode(),
                _e2.GetHashCode());
        }
    }
}