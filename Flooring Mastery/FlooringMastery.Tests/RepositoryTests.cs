using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMastery.Data;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private static string _filePathOrder = @"C:\repos\Bitbucket\Data\FlooringMasteryData\OrdersTest_06012013.txt";
        private const string _originalData = @"C:\repos\Bitbucket\Data\FlooringMasteryData\OrdersTestSeed_06012013.txt";

        private static string _filePathProducts = @"C:\repos\Bitbucket\Data\FlooringMasteryData\ProductsTest.txt";
        private static string _filePathTaxes = @"C:\repos\Bitbucket\Data\FlooringMasteryData\TaxesTest.txt";
        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePathOrder))
            {
                File.Delete(_filePathOrder);
            }
            File.Copy(_originalData, _filePathOrder);
        }
        [Test]
        public void CanReadDataFromFile()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository(_filePathOrder, _filePathProducts, _filePathTaxes);

            List<Order> orders = repo.DisplayOrders();

            Assert.AreEqual(1, orders.Count());

            Order check = orders[0];
            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("Wise", check.CustomerName);
            Assert.AreEqual("OH", check.State);
            Assert.AreEqual(6.25M, check.TaxRate);
            Assert.AreEqual("Wood", check.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.88M, check.Tax);
            Assert.AreEqual(1051.88M, check.Total);
        }
        [Test]
        public void CanAddOrderToFile()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository(_filePathOrder, _filePathProducts, _filePathTaxes);

            Order newOrder = new Order();

            newOrder.OrderNumber = 2;
            newOrder.CustomerName = "Tester";
            newOrder.State = "CA";
            newOrder.TaxRate = 7.2M;
            newOrder.ProductType = "Vynil";
            newOrder.Area = 150.00M;
            newOrder.CostPerSquareFoot = 6M;
            newOrder.LaborCostPerSquareFoot = 5M;
            newOrder.MaterialCost = 900M;
            newOrder.LaborCost = 750M;
            newOrder.Tax = 118.8M;
            newOrder.Total = 1768.8M;

            repo.AddOrder(newOrder);

            List<Order> orders = repo.DisplayOrders();


            Assert.AreEqual(2, orders.Count());

            Order check = orders[1];
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Tester", check.CustomerName);
            Assert.AreEqual("CA", check.State);
            Assert.AreEqual(7.2M, check.TaxRate);
            Assert.AreEqual("Vynil", check.ProductType);
            Assert.AreEqual(150.00M, check.Area);
            Assert.AreEqual(6M, check.CostPerSquareFoot);
            Assert.AreEqual(5M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(900M, check.MaterialCost);
            Assert.AreEqual(750M, check.LaborCost);
            Assert.AreEqual(118.8M, check.Tax);
            Assert.AreEqual(1768.8M, check.Total);

        }

        [Test]
        public void CanDeleteOrder()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository(_filePathOrder, _filePathProducts, _filePathTaxes);
            DateTime orderDate = DateTime.Parse("06/01/2013");
            repo.DeleteOrder(orderDate,1);

            List<Order> orders = repo.DisplayOrders();

            Assert.AreEqual(1, orders.Count);

            Order check = orders[0];
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Steve", check.CustomerName);
            Assert.AreEqual("CA", check.State);
            Assert.AreEqual(5M, check.TaxRate);
            Assert.AreEqual("Vynil", check.ProductType);
            Assert.AreEqual(110M, check.Area);
            Assert.AreEqual(6M, check.CostPerSquareFoot);
            Assert.AreEqual(4M, check.LaborCostPerSquareFoot);
            Assert.AreEqual(500M, check.MaterialCost);
            Assert.AreEqual(400M, check.LaborCost);
            Assert.AreEqual(50M, check.Tax);
            Assert.AreEqual(950M, check.Total);

        }
    }
}
