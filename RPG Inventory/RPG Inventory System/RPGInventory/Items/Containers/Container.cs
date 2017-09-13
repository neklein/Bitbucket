using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Containers
{
    public abstract class Container : ItemBase
    {
        //capacity - # of items that can be in the bag
        protected int _capacity;
        protected ItemBase[] _items;
        protected int _currentIndex;

        public Container(int capacity)
        {
            _capacity = capacity;
            _items = new ItemBase[capacity];
            _currentIndex = 0;
        }

        public virtual AddItemStatus AddItem(ItemBase itemToAdd)
        {
            if (_capacity == _currentIndex)
            {
                return AddItemStatus.BagIsFull;
            }
            else
            {
                _items[_currentIndex] = itemToAdd;
                _currentIndex++;
                return AddItemStatus.Success;
            }
        }

        public virtual ItemBase RemoveItem()
        {
            if (_currentIndex == 0)
                return null;
            else
            {
                _currentIndex--;
                ItemBase ItemToReturn = _items[_currentIndex];
                _items[_currentIndex] = null;
                return ItemToReturn;
            }
        }
    }
}
