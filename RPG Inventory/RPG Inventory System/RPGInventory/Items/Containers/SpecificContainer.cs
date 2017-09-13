using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Containers
{
    public class SpecificContainer : Container
    {
        private ItemType _requiredType;
        public SpecificContainer(int capacity, ItemType requiredType) : base(capacity)
        {
            _requiredType = requiredType;
        }

        public override AddItemStatus AddItem(ItemBase itemToAdd)
        {
            if(itemToAdd.Type == _requiredType)
            {
                return base.AddItem(itemToAdd);
            }
            return AddItemStatus.ItemNotRightType;
        }
    }
}
