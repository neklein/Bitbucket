using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class OrderResponse : Response
    {
        public Order Order { get; set; }
        //Old
        //public decimal MaterialCost(decimal area, decimal costPerSquareFoot)
        //{
        //    decimal materialCost = area * costPerSquareFoot;
        //    return materialCost;

        //}

        //public decimal LaborCost(decimal area, decimal laborCostPerSquareFoot)
        //{
        //    decimal laborCost = area * laborCostPerSquareFoot;
        //    return laborCost;
        //}

        //public decimal Tax(decimal materialCost, decimal laborCost, decimal taxRate)
        //{
        //    decimal tax = (materialCost + laborCost) * (taxRate / 100);
        //    return tax;
        //}
        //public decimal Total(decimal materialCost, decimal laborCost, decimal tax)
        //{
        //    decimal total = materialCost + laborCost + tax;
        //    return total;
        //}


    }
}
