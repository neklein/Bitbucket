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
    public class EditOrderRules : IEditOrder
    {
        ProductRepository productRepository = new ProductRepository();
        TaxRepository taxRepository = new TaxRepository();

        public OrderLookupResponse VerifyArea(Order order, OrderLookupResponse response)
        {
            if (order.Area < 100)
            {
                response.Success = false;
                response.Message = "The area must be greater than 100.";
            }
            else response.Success = true;

            return response;

        }

        public DateTime VerifyOrderDate(string dateTime, OrderLookupResponse response)
        {

            if (!DateTime.TryParse(dateTime, out DateTime output))
            {
                Console.WriteLine("That is not a valid date");
                response.Success = false;
            }
            else
                response.Success = true;
            return output;
        }

        public OrderLookupResponse VerifyOrderState(Order order, string orderState, OrderLookupResponse response)
        {
            List<Tax> Tax = taxRepository.DisplayTax();

            var verifyState = from tax in Tax
                              where tax.StateAbbreviation == orderState
                              select new
                              {
                                  StateAbbreviation = tax.StateAbbreviation,
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
                    order.OrderTax.StateAbbreviation = tax.StateAbbreviation;
                }
                response.Success = true;
            }

            return response;

        }

        public OrderLookupResponse VerifyProduct(Order order, string orderProduct, OrderLookupResponse response)
        {
            List<Products> products = productRepository.DisplayProduct();

            var verifyProduct = from product in products
                                where product.ProductType == orderProduct
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
                    order.OrderProduct.ProductType = product.ProductType;
                    order.OrderProduct.CostPerSquareFoot = product.CostPerSquareFoot;
                    order.OrderProduct.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;

                }
                response.Success = true;
            }
            return response;
        }

        public OrderLookupResponse EditOrder(OrderLookupResponse response, Order order)
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
