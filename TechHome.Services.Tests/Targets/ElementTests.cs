using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHome.Services.Targets.Tests
{
    [TestClass()]
    public class ElementTests
        : CopyEqualTests<Element>
    {
        [TestInitialize()]
        public void Initialize()
        {
            _e1 = new Element()
            {
                Source = null,
                Name = "test",
                Pattern = "test",
                Value = "test"
            };
            _e2 = new Element(_e1);
        }
    }
}