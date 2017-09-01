using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.BLL
{
    public class Axe : Weapon
    {
        public override WeaponType MyWeaponType { get { return WeaponType.Axe; } }

        public override int UseWeapon(int axebase)
        {
            int weaponDamage = base.UseWeapon(axebase);
            if (axebase == 1) weaponDamage *= 3;
            return weaponDamage;
        }
    }
}
