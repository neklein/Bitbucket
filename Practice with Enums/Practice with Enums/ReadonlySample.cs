using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class ReadonlySample
    {
        private readonly int _oneChanceToSet;

        public ReadonlySample(int value)
        {
            _oneChanceToSet = value;
        }

        public void ThisWontWork()
        {
            //_oneChanceToSet = 5;
        }
    }
}
