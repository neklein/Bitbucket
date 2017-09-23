using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Repositories
{
    public class TaxTestRepository : ITaxRepository
    {
        private Tax _tax = new Tax
        {
            StateAbbreviation = "CA",
            StateName = "California",
            TaxRate = 7.52M
        };
        public Tax GetTaxInfo(string stateAbbreviation)
        {
            return _tax;
        }
    }
}
