using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public Tax OrderTax { get; set; }
        public Products OrderProduct { get; set; }
        public decimal Area { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string OrderDate { get; set; }

    }
}
