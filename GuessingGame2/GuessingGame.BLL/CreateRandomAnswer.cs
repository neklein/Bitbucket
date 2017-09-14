using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.BLL
{
    public class CreateRandomAnswer : IGuessingGame
    {
        public int GetRandomAnswer()
        {
            Random rng = new Random();
            int answer = rng.Next(1, 21);
            return answer;

        }

    }
}
