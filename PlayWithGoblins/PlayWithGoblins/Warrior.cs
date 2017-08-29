using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithGoblins
{
    class Warrior
    {
        public int AttackAttack(int damage)
        {
            int RageAttack = 3;
            int TotalAttack = RageAttack + damage;
            return TotalAttack;
        }
    }
}
