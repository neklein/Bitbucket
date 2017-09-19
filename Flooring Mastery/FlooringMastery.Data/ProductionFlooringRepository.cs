using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringMastery.Data
{
    //Reading and writing to Order file
    public class ProductionFlooringRepository
    {
        private string _orders = @"C:\repos\Bitbucket\Data\FlooringMasteryData\OrdersTest_06012013";
        private string _products = @"C:\repos\Bitbucket\Data\FlooringMasteryData\ProductsTest";
        private string _taxes = @"C:\repos\Bitbucket\Data\FlooringMasteryData\TaxesTest";

        public ProductionFlooringRepository(string orders, string products, string taxes)
        {
            _orders = orders;
            _products = products;
            _taxes = taxes;
        }

        Order Order = new Order();

        public List<Order> DisplayOrders()
        {
            List<Order> orders = new List<Order>();

            using(StreamReader sr = new StreamReader(_orders))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();
                    string[] columns = line.Split(',');

                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.State = columns[2];
                    newOrder.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    newOrder.MaterialCost = decimal.Parse(columns[8]);
                    newOrder.LaborCost = decimal.Parse(columns[9]);
                    newOrder.Tax = decimal.Parse(columns[10]);
                    newOrder.Total = decimal.Parse(columns[11]);

                    orders.Add(newOrder);

                }
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            using(StreamWriter sw = new StreamWriter(_orders, true))
            {
                string line = CreateCsvForOrder(order);
                sw.WriteLine(line);
            }
        }

        public void EditOrder(Order order, DateTime orderDate, decimal orderNumber)
        {
            var orders = DisplayOrders();
            orders[int.Parse((orderNumber - 1).ToString())] = order;

            CreateOrderFile(orders);
        }

        public void DeleteOrder(DateTime orderDate, decimal orderNumber)
        {
            var orders = DisplayOrders();
            orders.RemoveAt(int.Parse((orderNumber - 1).ToString()));

            CreateOrderFile(orders);
        }

        public decimal MaterialCost(decimal area, decimal costPerSquareFoot)
        {
            decimal materialCost = area * costPerSquareFoot;
            return materialCost;
            
        }

        public decimal LaborCost (decimal area, decimal laborCostPerSquareFoot)
        {
            decimal laborCost = area * laborCostPerSquareFoot;
            return laborCost;
        }

        public decimal Tax (decimal materialCost, decimal laborCost)
        {
            decimal tax = (materialCost + laborCost); //* (taxRate / 100);
            return tax;
        }

        private string CreateCsvForOrder(Order order)
        {
            return string.Format($"{order.OrderNumber.ToString()},{order.CustomerName},{order.State},{order.TaxRate.ToString()}," +
                $"{order.ProductType},{order.Area.ToString()},{order.CostPerSquareFoot.ToString()},{order.LaborCostPerSquareFoot.ToString()},{order.MaterialCost.ToString()}," +
                $"{order.LaborCost.ToString()},{order.Tax.ToString()},{order.Total.ToString()}");

        }
        private void CreateOrderFile(List<Order> orders)
        {
            if (File.Exists(_orders))
            {
                File.Delete(_orders);
            }

            using(StreamWriter sr = new StreamWriter(_orders))
            {
                foreach(var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }
    }
}
