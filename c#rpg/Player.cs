using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_rpg
{
    public class Player
    {
        Random rand;

        public string Name = "";
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int weaponValue = 1;
        public int potion = 5;

        public int mods = 0;

        public int getHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
        public int getPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 2);
            return rand.Next(lower, upper);
        }
    }
}
