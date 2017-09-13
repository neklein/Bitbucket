using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Items.Containers
{
    public class WetPaperSack : WeightRestrictedContainer
    {
        public WetPaperSack() : base(8, 3)
        {
            Name = "Wet Paper Sack";
            Weight = 1;
            Type = ItemType.Container;
        }
    }
}
