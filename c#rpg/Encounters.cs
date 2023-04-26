using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_rpg
{
    class Encounters
    {
        static Random rand = new Random();
        //Encounter Generic

        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door, grab a rusty metal sword and charge at your captor.");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Human rogue", 1, 4);
        }

        public static void BasicEncounter() 
        {
            Console.Clear();
            Console.WriteLine("You turn a corner and you see a large beast...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void wizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("The door slowly creeks open as you peer into the dark room. You see a tall man with a long");
            Console.WriteLine("beard looking at a large tome.");
            Console.ReadKey();
            Combat(false, "Dark Wizard", 4, 6);
        }

        //Encounter tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0, 2)) 
            {
                case 0:
                    BasicEncounter();
                    break;
                case 1:
                    wizardEncounter();
                    break;
            }
        }


        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random) 
            {
                n = GetName();
                p = Program.currentPlayer.getPower();
                h = Program.currentPlayer.getHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("#######################");
                Console.WriteLine("|  (A)ttack (D)efend  |");
                Console.WriteLine("|    (R)un  (H)eal    |");
                Console.WriteLine("#######################");
                Console.WriteLine("   Potions: " + Program.currentPlayer.potion + "   ");
                Console.WriteLine("   Health: " + Program.currentPlayer.health + "   ");
                String Temp1 = Console.ReadLine();
                if(Temp1.ToLower() == "a" || Temp1.ToLower() == "attack") 
                {
                    Console.WriteLine("The enemy prepares to attack. You surge forward, your sword dancing in your hand.");
                    Console.WriteLine("As you pass, The "+n+" strikes you back.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);
                    Console.WriteLine("You lose "+ damage + " health and deal "+ attack +" damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (Temp1.ToLower() == "d" || Temp1.ToLower() == "defend")
                {
                    Console.WriteLine("The enemy prepares to attack. You ready your sword in a defensive stance.");
                    Console.WriteLine("As you pass, The " + n + " strikes you back.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) / 2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (Temp1.ToLower() == "r" || Temp1.ToLower() == "run")
                {
                    if (rand.Next(0, 2) == 0)
                    { 
                        Console.WriteLine("You sprint away from the "+n+". It's strike catches you and sends you to the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the "+n+" and escape.");
                        Console.ReadKey();
                        Shop.loadShop(Program.currentPlayer);
                    }
                }
                else if (Temp1.ToLower() == "h" || Temp1.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You feel around in your bag, before realising you don't have any potions left.");
                        Console.WriteLine("The "+n+" strikes you swiftly.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health and are unable to heal.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and pull out a glowing white flask.");
                        Console.WriteLine("You take a long drink of the viscous liquid.");
                        int healed = 5;
                        Console.WriteLine("You gain " + healed + " health.");
                        Program.currentPlayer.health += healed;
                        Program.currentPlayer.potion -= 1;
                        Console.WriteLine("As you are occupied , the " + n + " strikes you swiftly.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        Console.WriteLine("You lose " + damage + " health.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    Console.ReadKey();
                }
                if (Program.currentPlayer.health < 0 )
                {
                    // death
                    Console.WriteLine("As the " + n + " stands menacingly over you and comes to strike, you have been slain by the " + n + ".");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
                if (h < 0)
                {
                    break;
                }
            }
            int c = rand.Next(10, 51);
            Console.WriteLine("As you stand victorious over the "+n+", its body dissolves into $"+c+ ".");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
        public static string GetName() 
        { 
            switch(rand.Next(0,4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
            }
            return "Human Rogue";
        }

    }
}
