using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechHome.Services.Downloaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHome.Services.Tasks;

namespace TechHome.Services.Targets.Tests
{
    [TestClass()]
    public class LinkTests
        : CopyEqualTests<Link>
    {
        [TestInitialize()]
        public void Initialize()
        {
            var addr = @"http://google.co.nz";
            _e1 = new Link(addr);
            _e2 = new Link(_e1);
        }

        [TestMethod()]
        public void Link_Constructor_ElementsNotEmpty()
        {
            Link link = new Link();
            Assert.IsNotNull(link);
            Assert.IsNotNull(link.Elements);
        }

        [TestMethod()]
        public void Link_Constructor_SetDefaultValue()
        {
            var addr = @"http://google.co.nz";
            Link link = new Link(addr);
            Assert.AreEqual(link.Value, addr);
        }

        [TestMethod()]
        public void Uri_Get_UriWithValue()
        {
            var addr = @"http://google.co.nz";
            Link link = new Link(addr);
            Assert.AreEqual(link.Uri(), new Uri(addr));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetSource_NullSource_Exception()
        {
            Link link = new Link();
            link.SetSource(null);
        }

        [TestMethod()]
        public void SetSource_Source_ElementsWithSameSource()
        {
            Link link = new Link();
            link.Elements.Add(new Element());
            link.Elements.Add(new Element());
            link.Elements.Add(new Link());
            link.Elements.Add(new Link());
            Page page = new Page();
            link.SetSource(page);

            Action<Element> assertSub = null;
            assertSub = (x) =>
            {
                Assert.AreSame(page, x.Source);
                (x as Link)?.Elements.ForEach(assertSub);
            };
            link.Elements.ForEach(assertSub);
        }
    }
}
