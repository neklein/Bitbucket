using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repositories
{
    public class TaxRepository
    {
        private string _filePath = @"C:\repos\Bitbucket\Data\FlooringMasteryData\Data\Taxes.txt";
        List<Tax> List = new List<Tax>();

        public List<Tax> DisplayTax()
        {
            using(StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Tax newTax = new Tax();
                    string[] columns = line.Split(',');

                    newTax.StateAbbreviation = columns[0];
                    newTax.TaxRate = decimal.Parse(columns[1]);

                    List.Add(newTax);
                }
            }
            return List;
        }


    }
}
