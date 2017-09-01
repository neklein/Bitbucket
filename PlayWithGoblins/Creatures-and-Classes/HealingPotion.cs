using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures_and_Classes
{
    public class HealingPotion : Potion
    {
        public override void Drink(CreatureProperties drinker)
        {
            Console.WriteLine("The healing potion works!");
            drinker.AddHp(5);
        }

        
    }
}
