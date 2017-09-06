using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Stack<T>
    {
        private T[] _items;
        private int _nextIndex;

        public Stack (int maxItemCount)
        {
            //itialize the array to hold as many items as specified
            _items = new T[maxItemCount];
        }

        public void Push(T item)
        {
            //push the itme on
            _items[_nextIndex] = item;

            //get ready for the next item
            _nextIndex++;
        }

        public T Pop()
        {
            //can't return if we are empty
            if (_nextIndex == 0)
                throw new Exception("No items in the stack!");

            //decrement the index
            _nextIndex--;

            //pull out the item at that index
            T value = _items[_nextIndex];

            //clear the value in the array
            _items[_nextIndex] = default(T);

            //return the item
            return value;
        }
    }
}
