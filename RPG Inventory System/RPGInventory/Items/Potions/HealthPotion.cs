using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Potions
{
    public class HealthPotion : ItemBase
    {
        public HealthPotion()
        {
            Name = "Potion of Strong Health";
            Description = "Red liquid that brings great healing";
            Weight = 1;
            Type = ItemType.Potion;
        }
       

    }
}
