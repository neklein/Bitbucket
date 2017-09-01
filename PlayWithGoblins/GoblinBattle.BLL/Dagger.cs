using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.BLL
{
    public class Dagger : Weapon
    {
        public override WeaponType MyWeaponType { get { return WeaponType.Dagger; } }

        public override int UseWeapon(int charDamage)
        {
            if (charDamage < 2)
                return base.UseWeapon(charDamage);
            else return charDamage * 3;
        }
    }

}
