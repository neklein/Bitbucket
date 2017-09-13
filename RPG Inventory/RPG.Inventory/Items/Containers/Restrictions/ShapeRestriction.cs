using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Items.Containers.Restrictions
{
    class ShapeRestriction : IItemRestriction
    {
        private ItemShape _shapeToRestrict;

        public ShapeRestriction(ItemShape shapeToRestrict)
        {
            _shapeToRestrict = shapeToRestrict;
        }
        public AddItemStatus AddItem(Item itemToAdd, Container container)
        {
            if (itemToAdd.Shape != _shapeToRestrict)
            {
                return AddItemStatus.ItemWrongShape;
            }
            else
            {
                return AddItemStatus.Ok;
            }

        }
    }
}
