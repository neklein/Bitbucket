using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Armor
{
    public class BreastPlate : Item
    {
        public BreastPlate()
        {
            Name = "Breastplate of protection";
            Description = "This piece of armor protects your chest from danger";
            Weight = 2;
            Type = ItemType.Armor;
            Shape = ItemShape.Rectangular;
        }
        
    }
}
