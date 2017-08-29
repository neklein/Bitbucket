using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithGoblins
{
    class Weapons
    {
        public Random _increaseattack = new Random();
        public WeaponType WType { get; set; }
        public string WeaponName { get; set; }
        public int BaseAttack { get; set; }

        public int UseWeapon(int charDamage)
        {
            charDamage = charDamage + BaseAttack;
            if (WType == WeaponType.Wand)
            {
                charDamage = _increaseattack.Next(1, 10) + BaseAttack;
            }
            if(WType == WeaponType.Staff)
            {
                charDamage = _increaseattack.Next(1, 3) + BaseAttack;
            }
            return charDamage;
        }
        



        
    }
}
