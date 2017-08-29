using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithGoblins
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin aGoblin = new Goblin();
            Goblin bGoblin = new Goblin();

            aGoblin.HitPoints = 20;
            aGoblin.Name = "Grendall";
            aGoblin.MyWeapon = new Weapons();
            aGoblin.MyWeapon.WeaponName = "TomCleaver";
            aGoblin.MyWeapon.WType = WeaponType.Axe;
            aGoblin.MyWeapon.BaseAttack = 4;
            aGoblin.MyClass2 = new Warrior();


            

            bGoblin.HitPoints = 20;
            bGoblin.Name = "Kowlin";
            bGoblin.MyWeapon = new Weapons();
            bGoblin.MyWeapon.WeaponName = "Destroyer";
            bGoblin.MyWeapon.WType = WeaponType.Wand;
            bGoblin.MyWeapon.BaseAttack = 1;
            bGoblin.MyClass1 = new Wizard();


            int whoseTurn = 1;

            while (!aGoblin.IsDead && !bGoblin.IsDead)
            {
                if (whoseTurn == 1)
                {
                    aGoblin.Attack(bGoblin);
                    whoseTurn = 2;
                }
                else
                {
                    bGoblin.Attack(aGoblin);
                    whoseTurn = 1;
                }
            }
            Console.WriteLine("The battle is done!");
            Console.ReadKey();
        }

    }

    class Goblin
    {
        //can hold an axe or a short sword
        //fields
        
        
        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                if (value < 0)
                    return;
                else
                    _hitPoints = value;
            }
        }

        public Weapons MyWeapon { get; set; }

        public Wizard MyClass1 { get; set; }
        public Warrior MyClass2 { get; set; }

        private string _name;
        private bool _isDead;
        private static Random _rng = new Random();

        //methods
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsDead
        {
            get { return _isDead; }
            private set { _isDead = value; }
        }

        private static Random AddToAttack = new Random();
        public void WarCry(int AddDamage)
        {
           int _addtoattack = AddToAttack.Next(1, 7);
            if (_addtoattack == 3 || _addtoattack == 6)
            {
                Console.WriteLine($"{Name} utters a ferocious war cry filling it with rage and adding +1 to damage!");
                AddDamage++;
            }
            else
            {
                Console.WriteLine($"{Name}'s shout sounded strangely empty and the battle continues as normal");
            }
            
        }

        public void Attack(Goblin target)
        {
            
            int damage = _rng.Next(5);
            int totalDamage = MyWeapon.UseWeapon(damage);

            //WarCry is not adding to damage for some reason?
            WarCry(totalDamage);
            
            
               if (M == 1)
                MyClass1.UseSpell(totalDamage);
                MyClass2.AttackAttack(totalDamage);
            Console.WriteLine($"{Name} attacks {target.Name} for {totalDamage} damage!");
            target.Hit(totalDamage);

        }
        public void Hit (int damage)
        {
            //give a chance to dodge
            bool DidDodge = _rng.Next(0, 2) == 0?false:true;
            if (DidDodge == true)
            {
                Console.WriteLine($"{Name} receives no damage. They dodged the blow with their catlike reflexes! They have {_hitPoints} health.");
                if (_hitPoints <= 0)
                {
                    Console.WriteLine($"{Name} has died!");
                    _isDead = true;
                }
            }
            else
            {
                _hitPoints -= damage;
                Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");
                if (_hitPoints <= 0)
                {
                    Console.WriteLine($"{Name} has died!");
                    _isDead = true;
                }
            }

            

        }

    }

}
