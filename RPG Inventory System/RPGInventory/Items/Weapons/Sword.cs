using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Weapons
{
    public class Sword :ItemBase
    {
        public Sword()
        {
            Name = "A Wooden Sword";
            Description = "It's wooden";
            Weight = 4;
            Type = ItemType.Weapon;
        }
    }
}
