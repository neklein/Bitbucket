using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithGoblins
{
    class Wizard
    {
             //can only use the wand
           
            //casts spells
           
        public int UseSpell (int damage)
        {
            int SpellGives = 3;
            int SpellAttack = SpellGives + damage;
            Console.WriteLine($"The deadly spell strikes dealing {SpellGives} damage!");
            return SpellAttack;
        }

    }
}
