using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person ThatGuy = new Person();
            Tractor ThatTractor = new Tractor();

            Console.WriteLine("What is your name?");
             ThatGuy.Name = Console.ReadLine();
            Console.WriteLine($"Tell us a little about yourself, {ThatGuy.Name}. How old are you?");
            ThatGuy.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("And how much do you weigh?");
            ThatGuy.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("And what do you do for a living?");
            ThatGuy.Profession = Console.ReadLine();

            Console.WriteLine("Ok, let's move on to your tractor! What is its name?");
            ThatTractor.Name = Console.ReadLine();
            Console.WriteLine($"{ThatTractor.Name} is a good one! What is its weight?");
            ThatTractor.Weight = int.Parse(Console.ReadLine());
            Console.WriteLine("What is its horsepower?");
            ThatTractor.Horsepower = int.Parse(Console.ReadLine());
            Console.WriteLine($"Wow! {ThatTractor.Horsepower} horsepower is beast mode! Ok, what is its model?");
            ThatTractor.TractorModel = Console.ReadLine();

            



            Console.WriteLine($"Welcome tractor fans! Today Steve is going show us the dynamite of his {ThatTractor.Weight} pound {ThatTractor.TractorModel}'s {ThatTractor.Horsepower} horsepower. Press any key to continue");
            Console.ReadKey();
            Console.WriteLine($"But first, we need a little bio. Remarkably, {ThatGuy.Name} is a {ThatGuy.Profession} age {ThatGuy.Age} who weighs in at {ThatGuy.Weight} pounds.");
            Console.WriteLine("All right, enough about that. Let's go! ");
            ThatTractor.CommandGo("Go!"); 

            Console.ReadKey();
        }

    }
}
