using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public interface IFactorizor
    {
        int PrintFactors(int number);

        void PerfectNumber(int number);

        void IsPrimeNumber(int number);
        

    }
}
