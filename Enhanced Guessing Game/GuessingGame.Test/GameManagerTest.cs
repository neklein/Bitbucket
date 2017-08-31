using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizor.BLL;
namespace Factorizor.Test
{
    [TestFixture]
    public class FactorMaticTests
    {
        [Test]
        public void PerfectNumberTest()
        {
            FactorMatic test = new FactorMatic(6);
            Assert.IsTrue(test.IsPerfect());
            Assert.IsFalse(test.IsPrime());
        }
      
    }
}
