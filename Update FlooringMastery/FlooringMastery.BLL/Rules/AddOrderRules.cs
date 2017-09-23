using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.Data.Repositories;

namespace FlooringMastery.BLL.Rules
{
    public class AddOrderRules : IAddOrder
    {
        OrderResponse response = new OrderResponse();
        ProductRepository productRepository = new ProductRepository();
        TaxRepository taxRepository = new TaxRepository();


        public DateTime VerifyOrderDate(string dateTime, OrderResponse response)
        {


            if (DateTime.TryParse(dateTime, out DateTime output) == false)
            {
                Console.WriteLine("That is not a valid date");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            else
            {
                if (output < DateTime.Today)
                {
                    response.Success = false;
                    response.Message = "The order cannot be completed for a date before today.";
                }
                else
                {
                    response.Success = true;
                }
            }
            return output;
        }

        public OrderResponse VerifyOrderState(Order order, OrderResponse response)
        {
            List<Tax> Tax = taxRepository.DisplayTax();

            var verifyState = from tax in Tax
                              where tax.StateAbbreviation == order.OrderTax.StateAbbreviation
                              select new
                              {
                                  StateName = tax.StateName,
                                  TaxRate = tax.TaxRate
                              };
            if (!verifyState.Any())
            {
                response.Success = false;
                response.Message = "That is not a state we service.";
            }
            else
            {
                foreach (var tax in verifyState)
                {
                    order.OrderTax.TaxRate = tax.TaxRate;
                    order.OrderTax.StateName = tax.StateName;
                    Console.WriteLine($"You have selected {tax.StateName}");
                }
                response.Success = true;
            }

            return response;
        }

        public OrderResponse VerifyProduct(Order order, OrderResponse response)
        {
            List<Products> products = productRepository.DisplayProduct();

            var verifyProduct = from product in products
                                where product.ProductType == order.OrderProduct.ProductType
                                select new
                                {
                                    ProductType = product.ProductType,
                                    CostPerSquareFoot = product.CostPerSquareFoot,
                                    LaborCostPerSquareFoot = product.LaborCostPerSquareFoot
                                };
            if (!verifyProduct.Any())
            {
                response.Message = "That is not a product we stock.";
                response.Success = false;
            }
            else
            {
                foreach (var product in verifyProduct)
                {
                    order.OrderProduct.CostPerSquareFoot = product.CostPerSquareFoot;
                    order.OrderProduct.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
                    Console.WriteLine($"You have selected {product.ProductType}");

                }
                response.Success = true;
            }
            return response;
        }
        public OrderResponse VerifyArea(Order order, OrderResponse response)
        {
            if (order.Area < 100)
            {
                response.Success = false;
                response.Message = "The area must be greater than 100.";
            }
            else response.Success = true;

            return response;
        }

        
        public OrderResponse AddOrder(Order order)
        {


            order.MaterialCost = order.OrderProduct.CostPerSquareFoot * order.Area;
            order.LaborCost = order.OrderProduct.LaborCostPerSquareFoot * order.Area;
            order.Tax = (order.MaterialCost + order.LaborCost) * (order.OrderTax.TaxRate / 100);
            order.Total = order.MaterialCost + order.LaborCost + order.Tax;

            response.Order = order;
            response.Success = true;

            return response;
            


        }
    }
}
