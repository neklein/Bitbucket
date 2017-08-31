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
        FactorManager _manager;


        public void PlayGame()
        {
            userNum = ConsoleInput.GetNumberFromUser;
            _manager = new FactorManager();
            _manager.Start(userNum);

            ConsoleOutput.DsiplayFactors(_manager.GetFactors());
            ConsoleOutput.DisplayIsPrime(_manager.GetIsPrime);
            ConsoleOutput.DisplayIsPerfect(_manager.GetIsPerfect);

            ConsoleOutput.DisplayEnd();
        }
    }
}
