using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface ITaxRepository
    {
        Tax GetTaxInfo(string stateAbbreviation);
        //save tax info? I think this is bonus
    }
}
