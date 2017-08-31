using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class GameFlow
    {
        FactorizorResults _displayresults = new FactorizorResults();



        public void StartFactorizor()
        {

            ConsoleOutput.DisplayWelcome();

            int SomeInt;
            int[] factor;


            while(true)
            {
                SomeInt = ConsoleInput.GetIntFromUser();

                
               factor = _displayresults.PrintFactors(SomeInt);
                _displayresults.PerfectNumber(SomeInt);
                _displayresults.IsPrimeNumber(SomeInt);
                Console.ReadKey();
                break;

            } 
        }
    }
}
