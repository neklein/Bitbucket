using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractor
{
    public class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("This aint no child's playground! You have to be 18 or older!");
                    return;
                }
                else
                    _age = value;
            }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private string _profession;
        public string Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

    }
}
