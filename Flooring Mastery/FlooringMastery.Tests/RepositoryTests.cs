using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMastery.Data;
using FlooringMastery.Models;
using System.IO;
using FlooringMastery.Data.Repositories;

namespace FlooringMastery.Tests
{
    //added the file path as order dates on two tests. They will not pass.
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
            ProductionFlooringRepository repo = new ProductionFlooringRepository();

            List<Order> orders = repo.DisplayOrders(_filePathOrder);

            Assert.AreEqual(1, orders.Count());

            Order check = orders[0];
            Assert.AreEqual(1, check.OrderNumber);
            Assert.AreEqual("Wise", check.CustomerName);
            Assert.AreEqual("OH", check.OrderTax.StateAbbreviation);
            Assert.AreEqual(6.25M, check.OrderTax.TaxRate);
            Assert.AreEqual("Wood", check.OrderProduct.ProductType);
            Assert.AreEqual(100.00M, check.Area);
            Assert.AreEqual(5.15M, check.OrderProduct.CostPerSquareFoot);
            Assert.AreEqual(4.75M, check.OrderProduct.LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, check.MaterialCost);
            Assert.AreEqual(475.00M, check.LaborCost);
            Assert.AreEqual(61.88M, check.Tax);
            Assert.AreEqual(1051.88M, check.Total);
        }
        [Test]
        public void CanAddOrderToFile()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository();

            Order newOrder = new Order();
            newOrder.OrderTax = new Tax();
            newOrder.OrderProduct = new Products();

            newOrder.OrderDate = "06012013";
            newOrder.OrderNumber = 2;
            newOrder.CustomerName = "Tester";
            newOrder.OrderTax.StateAbbreviation = "CA";
            newOrder.OrderTax.TaxRate = 7.2M;
            newOrder.OrderProduct.ProductType = "Vynil";
            newOrder.Area = 150.00M;
            newOrder.OrderProduct.CostPerSquareFoot = 6M;
            newOrder.OrderProduct.LaborCostPerSquareFoot = 5M;
            newOrder.MaterialCost = 900M;
            newOrder.LaborCost = 750M;
            newOrder.Tax = 118.8M;
            newOrder.Total = 1768.8M;

            repo.AddOrder(newOrder);

            List<Order> orders = repo.DisplayOrders(newOrder.OrderDate);


            Assert.AreEqual(2, orders.Count());

            Order check = orders[1];
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Tester", check.CustomerName);
            Assert.AreEqual("CA", check.OrderTax.StateAbbreviation);
            Assert.AreEqual(7.2M, check.OrderTax.TaxRate);
            Assert.AreEqual("Vynil", check.OrderProduct.ProductType);
            Assert.AreEqual(150.00M, check.Area);
            Assert.AreEqual(6M, check.OrderProduct.CostPerSquareFoot);
            Assert.AreEqual(5M, check.OrderProduct.LaborCostPerSquareFoot);
            Assert.AreEqual(900M, check.MaterialCost);
            Assert.AreEqual(750M, check.LaborCost);
            Assert.AreEqual(118.8M, check.Tax);
            Assert.AreEqual(1768.8M, check.Total);

        }

        [Test]
        public void CanDeleteOrder()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository();
            string orderDate = string.Format($"{(DateTime.Parse("06/01/2013")).ToString():MMddYYY}").Trim(' ');
            repo.DeleteOrder(orderDate,1);

            List<Order> orders = repo.DisplayOrders(orderDate);

            Assert.AreEqual(1, orders.Count);

            Order check = orders[0];
            Assert.AreEqual(2, check.OrderNumber);
            Assert.AreEqual("Steve", check.CustomerName);
            Assert.AreEqual("CA", check.OrderTax.StateAbbreviation);
            Assert.AreEqual(5M, check.OrderTax.TaxRate);
            Assert.AreEqual("Vynil", check.OrderProduct.ProductType);
            Assert.AreEqual(110M, check.Area);
            Assert.AreEqual(6M, check.OrderProduct.CostPerSquareFoot);
            Assert.AreEqual(4M, check.OrderProduct.LaborCostPerSquareFoot);
            Assert.AreEqual(500M, check.MaterialCost);
            Assert.AreEqual(400M, check.LaborCost);
            Assert.AreEqual(50M, check.Tax);
            Assert.AreEqual(950M, check.Total);

        }

        [Test]
        public void CanAccessOrderDate()
        {
            ProductionFlooringRepository repo = new ProductionFlooringRepository();
            List<Order> orders = repo.DisplayOrders("06012013");

            var orderDate = (from order in orders
                             select order.OrderDate).FirstOrDefault();

            Assert.AreEqual(orderDate, "06012013");

        }
    }
}
