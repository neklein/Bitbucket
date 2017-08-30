using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    public class GameManager
    {
        private int _answer;

        private bool IsValidGuess (int guess)
        {
            if (guess >= 1 && guess <= 20)
                return true;
            else
                return false;
            
        }
        private void CreateRandomAnswer()
        {
            Random _rng = new Random();
            _answer = _rng.Next(1, 21);
        }
        public GuessResult ProcessGuess(int guess)
        {
            if (!IsValidGuess(guess))
                return GuessResult.Invalid;
            
            if (guess < _answer)
                return GuessResult.TooLow;
            else if (guess > _answer)
                return GuessResult.TooHigh;
            else
                return GuessResult.Correct;
        }

        public void Start()
        {
            CreateRandomAnswer();
        }

        public void Start (int fixedAnswer)
        {
            _answer = fixedAnswer;
        }
    }
}
