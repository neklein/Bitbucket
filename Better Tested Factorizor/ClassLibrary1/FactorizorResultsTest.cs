using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizor.BLL;

namespace ClassLibrary1
{
    [TestFixture]
    public class FactorizorResultsTest
    {
        [TestCase(5, new [] {1,5})]
        [TestCase(10, new [] {1, 2, 5, 10})]
        [TestCase(20, new[] {1, 2, 4, 5, 10, 20})]
        public void CheckForFactorsTest(int x, int[] expected)
        {
            
            FactorizorResults FactorsInstance = new FactorizorResults();
            int[] actual = FactorsInstance.PrintFactors(x);

            Assert.AreEqual(expected, actual);


        }

        [TestCase (5, 1)]
        [TestCase (6, 6)]
        [TestCase (10, 8)]
        [TestCase (20, 22)]
        public void CheckForPerfect(int x, int expected)
        {
            FactorizorResults PerfectInstance = new FactorizorResults();
            int actual = PerfectInstance.PerfectNumber(x);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, 0)]
        [TestCase(6, 2)]
        [TestCase(7, 0)]
        [TestCase(10, 2)]
        [TestCase(20, 4)]
        public void CheckForPrime(int x, int expected)
        {
            FactorizorResults PrimeInstance = new FactorizorResults();
            int actual = PrimeInstance.IsPrimeNumber(x);

            Assert.AreEqual(expected, actual);
        }
    }
    
}
