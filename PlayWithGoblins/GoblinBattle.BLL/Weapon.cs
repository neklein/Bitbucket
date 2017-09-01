using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.BLL
{
    public abstract class Weapon
    {
        public abstract WeaponType MyWeaponType { get; }
        public int BaseAttack { get; set; }

        public virtual int UseWeapon(int charDamage)
        {
            return charDamage + BaseAttack;
        }
        public Random _increaseattack = new Random();
        public string WeaponName { get; set; }


    }
}
