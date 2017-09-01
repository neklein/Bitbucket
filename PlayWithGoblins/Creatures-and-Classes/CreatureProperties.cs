using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creatures_and_Classes
{
    public class CreatureProperties
    {
        Stack<Potion> _potions = new Stack<Potion>();

        protected int _hitPoints;

        public void AddHp (int hp)
        {
            if (_hitPoints + hp > 100) _hitPoints = 100;
            else _hitPoints += hp;
        }

        public void AddPotion(Potion p)
        {
            _potions.Push(p);
        }

        public void Drink()
        {
            if (_potions.Peek() != null)
                _potions.Pop().Drink(this);
        }

        public CreatureProperties(int startingLevel)
        {
            _hitPoints = 100;
            _level = startingLevel;
        }

        public virtual void Regen()
        {
            if (_hitPoints < 100)
                _hitPoints++;
        }

        protected int _level;

        public void LevelUp()
        {
            _level++;
        }

        public CreatureProperties() : this(1)
        {
        }

    }
}
