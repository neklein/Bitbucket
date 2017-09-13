using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items
{
    public abstract class ItemBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public ItemType Type { get; set; }
    }
}
