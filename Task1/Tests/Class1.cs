using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Class1
    {
        [TestFixture]
        public class TestLogging
        {
            [Test]
            public void Add()
            {
        
                Assert.That(3, Is.EqualTo(3));
            }
        }
    }
}
