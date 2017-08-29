using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractor
{
    public class Tractor
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _weight;
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value < 1000)
                {
                    Console.WriteLine("Are you bringing a kid's toy to a man's battleground?");
                    return;
                }
                else
                    _weight = value;
            }
        }

        private int _horsepower;
        public int Horsepower
        {
            get { return _horsepower; }
            set { _horsepower = value; }
        }

        private string _tractorModel;
        public string TractorModel
        {
            get { return _tractorModel; }
            set { _tractorModel = value; }
        }

        public void CommandGo(string Accelerates)
        {
            string Acceleration = Accelerates;
            Console.WriteLine($"Steve hits the gas at the sound of {Acceleration}!");
            Console.ReadKey();

        }

    }
}
