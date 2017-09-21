using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringMastery.Data.Repositories
{
    //Reading and writing to Order file
    public class ProductionFlooringRepository
    {
        ProductRepository productRepository = new ProductRepository();
        TaxRepository taxRepository = new TaxRepository();

        Order Order = new Order();

        public List<Order> DisplayOrders(string date)
        {
            List<Order> orders = new List<Order>();
            if(File.Exists("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + date + ".txt"))
            using(StreamReader sr = new StreamReader("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + date + ".txt"))
            {
                sr.ReadLine();

                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();

                    newOrder.OrderTax = new Tax();
                    newOrder.OrderProduct = new Products();
                    string[] columns = line.Split(',');

                    newOrder.OrderDate = date;
                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.OrderTax.StateAbbreviation = columns[2];
                    newOrder.OrderTax.TaxRate = decimal.Parse(columns[3]);
                    newOrder.OrderProduct.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.OrderProduct.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.OrderProduct.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
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

            if (File.Exists("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + order.OrderDate + ".txt"))
            {
                var orders = DisplayOrders(order.OrderDate);
                File.Delete("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + order.OrderDate + ".txt");
                using (StreamWriter sr = new StreamWriter("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + order.OrderDate + ".txt"))
                {
                    sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area," +
                        "CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    foreach (var ord in orders)
                    {
                        sr.WriteLine(CreateCsvForOrder(ord));
                    }

                    var newOrderNumber = (from or in orders
                                          select or.OrderNumber).Max();
                    order.OrderNumber = newOrderNumber + 1;
                    sr.WriteLine(CreateCsvForOrder(order));
                }

            }
            else
            {
                File.Create("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + order.OrderDate + ".txt");
                using (StreamWriter sr = new StreamWriter("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + order.OrderDate + ".txt"))
                {
                    sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area," +
                        "CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                
                    order.OrderNumber = 1;
                    sr.WriteLine(CreateCsvForOrder(order));
                }

            }

        }

        public void EditOrder(Order order, string orderDate, decimal orderNumber)
        {
            var orders = DisplayOrders(orderDate);

            var orderToEdit = (from order1 in orders
                                       where order1.OrderNumber == orderNumber
                                       select orders.IndexOf(order1)).FirstOrDefault();
            orders[orderToEdit] = order;

            CreateOrderFile(orders, orderDate);
        }


        public void DeleteOrder(string orderDate, decimal orderNumber)
        {
            var orders = DisplayOrders(orderDate);

            var orderToDelete = (from order1 in orders
                               where order1.OrderNumber == orderNumber
                               select order1).FirstOrDefault();

            orders.Remove(orderToDelete);

            CreateOrderFile(orders, orderDate);
        }




        private string CreateCsvForOrder(Order order)
        {
            return string.Format($"{order.OrderNumber.ToString()},{order.CustomerName},{order.OrderTax.StateName},{order.OrderTax.TaxRate.ToString()}," +
                $"{order.OrderProduct.ProductType},{order.Area.ToString()},{order.OrderProduct.CostPerSquareFoot.ToString()},{order.OrderProduct.LaborCostPerSquareFoot.ToString()},{order.MaterialCost.ToString()}," +
                $"{order.LaborCost.ToString()},{order.Tax.ToString()},{order.Total.ToString()}");

        }
        private void CreateOrderFile(List<Order> orders, string orderDate)
        {
            if (File.Exists("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + orderDate + ".txt"))
            {
                File.Delete("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + orderDate + ".txt");
            }

            using(StreamWriter sr = new StreamWriter("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + orderDate + ".txt"))
            {
                sr.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area," +
                    "CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach(var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }
    }
}
