using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_with_Enums
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public enum OrderStatus
    {
        Quoted = 0,
        Purchased,
        Shipped,
        Delivered

    }

    public class Order
    {
        public OrderStatus Status { get; private set; }
        public void AdvanceStatus()
        {
            int status = 3;
            if ((OrderStatus)status == OrderStatus.Delivered)
            {
                Console.WriteLine("The package was delivered!");
            }
                switch (Status)
            {
                case OrderStatus.Quoted:
                    Status = OrderStatus.Purchased;
                    break;
                case OrderStatus.Shipped:
                    Status = OrderStatus.Delivered;
                    break;
                
            }
        }
    }
}
