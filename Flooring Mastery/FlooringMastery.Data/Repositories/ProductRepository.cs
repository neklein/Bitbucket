using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repositories
{
    public class ProductRepository
    {
        private string _products = @"C:\repos\Bitbucket\Data\FlooringMasteryData\Products.txt";
        List<Products> product = new List<Products>();

        public List<Products> DisplayProduct()
        {
            using (StreamReader sr = new StreamReader(_products))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Products newProduct = new Products();

                    string[] columns = line.Split(',');
                    newProduct.ProductType = columns[0];
                    newProduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                    newProduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    product.Add(newProduct);
                }
            }
            return product;
        }




    }
}
