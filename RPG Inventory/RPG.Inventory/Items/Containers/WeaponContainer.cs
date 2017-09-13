using RPG.Inventory.Items.Containers.Restrictions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers
{
    public class WeaponContainer : Container
    {
        public WeaponContainer() : base(5)
        {
            Name = "Weapon Container";
            Description = "This container is meant for long thin weapons";
            Type = ItemType.Container;
            Weight = 4;

            AddRestriction(new CapacityRestriction());
            AddRestriction(new ShapeRestriction(ItemShape.LongAndThin));
            AddRestriction(new MaxWeightRestriction(10));
        }
    }
}
