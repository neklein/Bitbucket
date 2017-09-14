using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    public class GameManager 
    {

        private IGuessingGame _chooser;
        int initialAnswer;


        public GameManager(IGuessingGame answer)
        {

            _chooser = answer;

            initialAnswer = _chooser.GetRandomAnswer();

        }

        private bool IsValidGuess(int guess)
        {
            if (guess >= 1 && guess <= 20)
                return true;
            else
                return false;
        }


        public GuessResult ProcessGuess(int guess)
        {
            if (!IsValidGuess(guess))
                return GuessResult.Invalid;

            if (guess < initialAnswer)
                return GuessResult.Higher;
            else if (guess > initialAnswer)
                return GuessResult.Lower;
            else
                return GuessResult.Victory;
        }

    }
}
