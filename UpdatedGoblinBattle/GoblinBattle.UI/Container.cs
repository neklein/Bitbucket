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

        public bool AddItem(ItemBase itemToAdd)
        {
            if (_capacity == _currentIndex)
            {
                return false;
            }
            else
            {
                _items[_currentIndex] = itemToAdd;
                _currentIndex++;
                return true;
            }
        }

        public ItemBase RemoveItem()
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
