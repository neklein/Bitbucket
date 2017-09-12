using LINQ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {


            while (true)
            {
                int number;
                Console.WriteLine("Enter a number between 1 and 31 for an exercise from 1-31");

                string input = Console.ReadLine();

                if (!(int.TryParse(input, out number)))
                {
                    Console.WriteLine("That is not a valid input. Please enter another number");
                }
                


                switch (number)
                {
                    case 1:
                        Exercise1();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 2:
                        Exercise2();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 3:
                        Exercise3();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 4:
                        Exercise4();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 5:
                        Exercise5();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 6:
                        Exercise6();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 7:
                        Exercise7();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        Exercise8();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 9:
                        Exercise9();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 10:
                        Exercise10();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 11:
                        Exercise11();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 12:
                        Exercise12();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 13:
                        Exercise13();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 14:
                        Exercise14();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 15:
                        Exercise15();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 16:
                        Exercise16();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 17:
                        Exercise17();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 18:
                        Exercise18();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 19:
                        Exercise19();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 20:
                        Exercise20();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 21:
                        Exercise21();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 22:
                        Exercise22();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 23:
                        Exercise23();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 24:
                        Exercise24();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 25:
                        Exercise25();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 26:
                        Exercise26();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 27:
                        Exercise27();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 28:
                        Exercise28();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 29:
                        Exercise29();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 30:
                        Exercise30();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                    case 31:
                        Exercise31();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                        Console.Clear();
                        break;
                }

                //PrintAllProducts();
                //PrintAllCustomers();

                

                Console.WriteLine("Would you like to see another excercise? Press any key to exit or 'y' for another exercise.");
                string playAgain = Console.ReadLine();
                if (playAgain == "y" || playAgain == "Y") continue;
                else break;
            }
        }


        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {

            List<Product> GetProduct = DataLoader.LoadProducts();

            var onlyZero = from number in GetProduct
                           where number.UnitsInStock == 0
                           select number;
            foreach(var product in onlyZero)
            {
                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Category);
                Console.WriteLine(product.UnitPrice);
                Console.WriteLine(product.UnitsInStock);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");

            }



        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var costIsAnIssue = from number in GetProduct
                           where number.UnitsInStock != 0 && number.UnitPrice > 3.00M
                           select number;

            foreach (var product in costIsAnIssue)
            {
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", "Product Name", "ID", "Category", "Price", "Units in Stock");
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", product.ProductName, product.ProductID, product.Category, product.UnitPrice, product.UnitsInStock);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }


        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> GetCustomerInfo = DataLoader.LoadCustomers();

            DataLoader.LoadCustomers();

            var washingtonCustomer = from customer in GetCustomerInfo
                                     where customer.Region == "WA"
                                     select customer;


            foreach (var customer in washingtonCustomer)
            {
                Console.WriteLine("{0, -20} {1, -35} {2, -25} {3, -10}", "Customer ID", "Company Name", "City", "Region");
                Console.WriteLine("{0, -20} {1, -35} {2, -25} {3, -10}", customer.CustomerID, customer.CompanyName, customer.City, customer.Region);
                Console.WriteLine();
                Console.WriteLine("{0, -20} {1, -35} {2, -25} {3, -10}", "Postal Code", "Country", "Phone", "Fax", "Orders");
                Console.WriteLine("{0, -20} {1, -35} {2, -25} {3, -10}", customer.PostalCode, customer.Country, customer.Phone, customer.Fax, customer.Orders);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }


        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> GetProductName = DataLoader.LoadProducts();

            var productName = from product in GetProductName
                              select new 
                              {
                                  ProductName = product.ProductName
                              };

            foreach(var product in productName)
            {
                Console.WriteLine("Product Name");
                Console.WriteLine($"{product.ProductName}");
                Console.WriteLine("~~~~~~~~~~~~~~~");

            }

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCostIncrease = from product in GetProduct
                                      select new
                                      {
                                          UnitPrice = product.UnitPrice + (0.25M * product.UnitPrice),
                                          ProductName = product.ProductName,
                                          ProductID = product.ProductID,
                                          Category = product.Category,
                                          UnitsInStock = product.UnitsInStock
                                      };

            foreach (var product in productCostIncrease)
            {
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", "Product Name", "ID", "Category", "Price", "Units in Stock");
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", product.ProductName, product.ProductID, product.Category, product.UnitPrice, product.UnitsInStock);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> UpperCase = DataLoader.LoadProducts();

            var toUpperCase = from product in UpperCase
                              select new
                              {
                                  ProductName = product.ProductName.ToUpper(),
                                  Category = product.Category.ToUpper()
                              };

            foreach (var product in toUpperCase)
            {
                Console.WriteLine("{0, -35}{1, -20}", "PRODUCT NAME", "CATEGORY");
                Console.WriteLine("{0, -35}{1, -20}", product.ProductName, product.Category);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            bool ReOrder = false;
            List<Product> GetProduct = DataLoader.LoadProducts();

            var getProduct = from product in GetProduct
                             select new
                                      {
                                          UnitPrice = product.UnitPrice,
                                          ProductName = product.ProductName,
                                          ProductID = product.ProductID,
                                          Category = product.Category,
                                          UnitsInStock = product.UnitsInStock
                                          
                                      };

            foreach (var product in getProduct)
            {
                ReOrder = (product.UnitsInStock < 3) ? true : false;

                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -20} {5, -20}", "Product Name", "ID", "Category", "Price", "Units in Stock", "Reorder");
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -20} {5, -20}", product.ProductName, product.ProductID, product.Category, product.UnitPrice, product.UnitsInStock, ReOrder);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }


        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var getProduct = from product in GetProduct
                             select new
                             {
                                 UnitPrice = product.UnitPrice,
                                 ProductName = product.ProductName,
                                 ProductID = product.ProductID,
                                 Category = product.Category,
                                 UnitsInStock = product.UnitsInStock,
                                 StockValue = product.UnitPrice * product.UnitsInStock

                             };

            foreach (var product in getProduct)
            {

                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -20} {5, -20}", "Product Name", "ID", "Category", "Price", "Units in Stock", "Stock Value");
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -20} {5, -20}", product.ProductName, product.ProductID, product.Category, product.UnitPrice, product.UnitsInStock, product.StockValue);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            }


        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] newArray = DataLoader.NumbersA;

            var evenNumbers = from numbers in newArray
                              where numbers % 2 == 0
                              select numbers;

            foreach(var number in evenNumbers)
            {
                Console.Write($"{number}, ");

            }
            Console.WriteLine();

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> GetCustomers = DataLoader.LoadCustomers();

            var ordersLessThan = from customer in GetCustomers
                                 from orders in customer.Orders
                                 where orders.Total < 500.00M
                                 select customer;

            PrintCustomerInformation(ordersLessThan);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] getArrayC = DataLoader.NumbersC;

            var getOdds = (from number in getArrayC
                          where number % 2 == 1
                          select number).ToArray();
            for(int number = 0; number < 3; number++)
            {
                Console.Write($"{getOdds[number]}, ");
            }
            Console.WriteLine();


        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] newArrayB = DataLoader.NumbersB;

            for (int i = 3; i < newArrayB.Length; i++)
            {
                Console.Write($"{newArrayB[i]}, ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> GetCustomerInfo = DataLoader.LoadCustomers();

            DataLoader.LoadCustomers();

            var washingtonCustomer = from customer in GetCustomerInfo
                                     where customer.Region == "WA"
                                     select customer;

            foreach (var customer in washingtonCustomer)
            {
                Console.WriteLine(customer.CompanyName);

                foreach(var order in customer.Orders.OrderByDescending(o => o.OrderDate).Take(1))
                {
                    
                    Console.Write(" - Order Date: {0}", order.OrderDate);
                    break;
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
           int[] GetNumbers = DataLoader.NumbersC;

            foreach (int num in GetNumbers)
            {
                if (num < 6) Console.Write($"{num}, ");
                else if(num >= 6)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] GetNumbers = DataLoader.NumbersC;

            for (int j  = 0; j < GetNumbers.Length; j++)
            {
                if(GetNumbers[j] % 3 == 0)
                {
                    for (int i = j; i < GetNumbers.Length; i++)
                    {
                        Console.Write($"{GetNumbers[i]}, ");
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
         {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productName = from product in GetProduct
                              orderby product.ProductName
                              select product;

            foreach(var product in productName)
            {
                Console.WriteLine(product.ProductName);
            }

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productID = from product in GetProduct
                            orderby product.ProductID
                            select product;

            foreach (var product in productID)
            {
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", "Product Name", "ID", "Category", "Price", "Units in Stock");
                Console.WriteLine("{0, -35} {1, -10} {2, -20} {3, -10} {4, -10}", product.ProductName, product.ProductID, product.Category, product.UnitPrice, product.UnitsInStock);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
        }

            /// <summary>
            /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
            /// </summary>
        static void Exercise18()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategory = from product in GetProduct
                                  orderby product.Category, product.UnitPrice descending
                                  group product by product.Category;

            foreach (var product in productCategory)
            {
                Console.WriteLine(product.Key);
                foreach(var price in product)
                {
                    Console.WriteLine("\t{0}", price.UnitPrice);
                }
                Console.WriteLine();

            }





        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] GetNumbersB = DataLoader.NumbersB;

            var getNumbersBDescending = from num in GetNumbersB
                                        orderby num descending
                                        select num;

            foreach (var num in getNumbersBDescending)
            {
                Console.Write("{0}, ", num);
            }
            
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategory = from product in GetProduct
                                  orderby product.Category, product.ProductName
                                  group product by product.Category;

            foreach (var product in productCategory)
            {
                Console.WriteLine(product.Key);
                foreach (var name in product)
                {
                    Console.WriteLine(name.ProductName);
                }
                Console.WriteLine();


            }
        }

            /// <summary>
            /// Print all Customers with their orders by Year then Month
            /// ex:
            /// 
            /// Joe's Diner
            /// 2015
            ///     1 -  $500.00
            ///     3 -  $750.00
            /// 2016
            ///     2 - $1000.00
            /// </summary>
        static void Exercise21()
        {
            List<Customer> GetCustomer = DataLoader.LoadCustomers();

            var getCustomer = from customer in GetCustomer
                              orderby customer.CompanyName
                              select GetCustomer;

            foreach(var customer in getCustomer)
            {

                foreach(var order in customer)
                {
                    var companyName = order.CompanyName;
                    var tryForDate = order.Orders;
                    Console.WriteLine(companyName);
          
              
                    foreach(var date in tryForDate)
                    {
                        var date1 = date.OrderDate.ToString("yyyy M");
                        var splitString = date1.Split(' ');
                        var year = splitString[0];
                        var month = splitString[1];
                        var price = date.Total;
                        Console.WriteLine("{0}", year);
                        Console.WriteLine("\t{0} - ${1}", month, price);
                    }
                }

            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategories = (from product in GetProduct
                                    orderby product.Category
                                    select product.Category).ToArray();

                for (int i = 1; i < productCategories.Length; i++)
                {
                    if(productCategories[i] != productCategories[i - 1])
                    {
                        Console.WriteLine(productCategories[i]);
                    }
                }

            
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productID = (from product in GetProduct
                             select product.ProductID).ToArray();

            bool isTrue = true;

            if (productID.Length < 789) isTrue = false;

            Console.WriteLine(isTrue);

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var categoryAtZero = (from product in GetProduct
                                 where product.UnitsInStock == 0
                                 orderby product.Category
                                 select product.Category).ToArray();

            for (int i = 1; i < categoryAtZero.Length; i++)
            {
                if(categoryAtZero[i] != categoryAtZero[i - 1])
                Console.WriteLine(categoryAtZero[i]);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var category = from product in GetProduct
                                 group product by product.Category;
            var categoryAtZero = from product in category
                                 where product.All(p => p.UnitsInStock != 0)
                                 select product;

            foreach(var product in categoryAtZero)
            {
                Console.WriteLine(product.Key);

              
            }



            

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] getNumbersA = DataLoader.NumbersA;

            var odds = from num in getNumbersA
                       where num % 2 == 1
                       select num;

            Console.WriteLine(odds.Count());

           
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> GetCustomer = DataLoader.LoadCustomers();

            var customerID = from customer in GetCustomer
                             select new
                             {
                                 CustomerID = customer.CustomerID,
                                 Orders = customer.Orders.Count()


                             };
            foreach(var customer in customerID)
            {
                Console.Write("ID: {0} - Number of Orders: {1}", customer.CustomerID, customer.Orders);
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategories = from product in GetProduct
                                    orderby product.Category, product.ProductName.Count()
                                    group product by product.Category;


            foreach(var product in productCategories)
            {
                int count = 0;
                Console.WriteLine(product.Key);
                foreach(var name in product)
                {
                    count += name.ProductName.Count();
                }
                Console.WriteLine(count);

            }


        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategories = from product in GetProduct
                                    orderby product.Category, product.UnitsInStock
                                    group product by product.Category; 

            foreach (var product in productCategories)
            {
                Console.WriteLine(product.Key);
                foreach (var unit in product)
                {
                    Console.Write("\t{0}", unit.UnitsInStock);
                    Console.WriteLine();
                }
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategories = from product in GetProduct
                                    orderby product.Category, product.UnitPrice
                                    group product by product.Category;


            foreach (var product in productCategories)
            {
                Console.WriteLine(product.Key);
                foreach(var price in product)
                {
                    Console.Write(" - The lowest price item is: {0}", price.UnitPrice);
                    break;

                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> GetProduct = DataLoader.LoadProducts();

            var productCategories = (from product in GetProduct
                                     orderby product.Category
                                     group product by product.Category).OrderBy(unit => unit.Average(p => p.UnitPrice)).Take(3);

            //var orderProductCategories = productCategories.OrderBy(unit => unit.Average(p => p.UnitPrice)).Take(3);

            foreach(var product in productCategories)
            {
                Console.WriteLine(product.Key);

               
            }



           






        }
    }
}
