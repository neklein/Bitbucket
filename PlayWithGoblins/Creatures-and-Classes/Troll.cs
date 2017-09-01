using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures_and_Classes
{
    public class Troll : CreatureProperties
    {
        public Troll(int startingLevel)
        {
            _level = startingLevel;
        }

        public override void Regen()
        {
            if (_hitPoints < 100)
            {
                base.Regen();

                if (_hitPoints + 3 > 100) _hitPoints = 100;
                else _hitPoints += 3;
            }
        }
    }
}
