using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_rpg
{
    public class Shop
    {
        static int armorMult;
        static int potionCost;
        static int weaponMult;
        static int difMod;
        public static void loadShop(Player p)
        {
            armorMult = 70 * (p.armorValue);
            potionCost = 5 * (p.potion);
            weaponMult = 50 * (p.weaponValue);
            difMod = 250 * (p.mods);
            runShop(p);
        }

        public static void runShop(Player p)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("             Shop            ");
                Console.WriteLine("#############################");
                Console.WriteLine("|  (P)otion:         $", potionCost + "|");
                Console.WriteLine("|  (W)eapon:         $", weaponMult + "|");
                Console.WriteLine("|  (A)rmor:          $", armorMult + "|");
                Console.WriteLine("|  (D)ifficulty Mod: $", difMod + "|");
                Console.WriteLine("#############################");
                Console.ReadKey();
            } 
        }
    }
}
