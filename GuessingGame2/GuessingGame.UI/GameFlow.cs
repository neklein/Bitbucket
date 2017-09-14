using GuessingGame.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI
{
    public class GameFlow
    {
        private static IGuessingGame _chooseAnswer = new CreateRandomAnswer();
        
        GameManager _manager = new GameManager(_chooseAnswer);

        public void PlayGame()
        {
            
            ConsoleOutput.DisplayTitle();
            
            GuessResult result;
            int guess;

            do
            {
                guess = ConsoleInput.GetGuessFromUser();
                result = _manager.ProcessGuess(guess);
                ConsoleOutput.DisplayGuessMessage(result);
            } while (result != GuessResult.Victory);
        }

    }
}
