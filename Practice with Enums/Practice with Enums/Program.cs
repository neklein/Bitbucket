using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Goblins g1 = new Goblins();
            g1.Name = "George";
            g1.Level = 12;

            Goblins g2 = new Goblins("Sam");
            g2.Level = 19;

            Goblins g3 = new Goblins(7);
            g3.Name = "Bob";

            Goblins g4 = new Goblins(4, "Tim");

            Console.WriteLine($"{g1.Name} met {g2.Name}, {g3.Name}, and {g4.Name}");--*/


            /*Person p1 = new Person();
            p1.FirstName = "Joe";
            p1.LastName = "Somebody";
            p1.Age = 24;

            Person p2 = new Person()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Age = 25
            };
            Console.WriteLine($"{p1.FirstName} met {p2.FirstName} and found out that {p2.FirstName}'s last name was {p2.LastName}."); --*/


            //Circle C1 = new Circle(5);
            //double NewArea = C1.Area;
            //Console.WriteLine($"The circle has an area of {NewArea}");


            //ConstructorPractice instance = new ConstructorPractice();
            //Console.WriteLine($"Created: {instance.CreateDate}");
            Console.ReadKey();
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
