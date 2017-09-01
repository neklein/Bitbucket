using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures_and_Classes
{
    public class Monster_Generator
    {
        private static Random _rng = new Random();

        public static CreatureProperties GenerateMonster()
        {
            switch (_rng.Next(1, 4))
            {
                case 1:
                    return new Goblin(1);
                case 2:
                    return new Ogre(1);
                default:
                    return new Hydra(1);

            }
        }
    }
}
