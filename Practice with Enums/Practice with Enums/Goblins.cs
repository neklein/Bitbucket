using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Goblins
    {
        public int Level { get; set; }
        public string Name { get; set; }

        public Goblins() :this(1, "Generic Goblin")
        {

        }

        public Goblins(string name) : this(1, name)
        {

        }

        public Goblins(int level) : this(level, "Generic Goblin")
        {

        }

        public Goblins(int level, string name)
        {
            Level = level;
            Name = name;
        }



    }
}
