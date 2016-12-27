using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleModePlayerVsMonster
{
    public class Player
    {
        public static double HP { get; set; }
        public static double MP { get; set; }
        public static int Attack { get; set; }
        public static int SpellPower { get; set; }
        public static int DiamondQuantity { get; set; }
        public static int HPBottleQuantity { get; set; }
        public static int MPBottleQuantity { get; set; }
        public static int PlayerLevel { get; set; }
        public static int Defence { get; set; }
        public static int Morale { get; set; }
        public static int Luck { get; set; }

        public static int CalculateHPorMP()
        {
            int local = 100;
            for (int i = 1; i <= PlayerLevel; i++)
            {
                local = local + 10;
            }
            return local;
        }

        public static int GetMinDamage()
        {
            double value = (double) PlayerLevel - PlayerLevel / 10 * 2;
            return (int) Math.Ceiling(value);
        }
        public static int GetMaxDamage()
        {
            double value = (double)PlayerLevel + PlayerLevel / 10 * 2;
            return (int)Math.Floor(value);
        }
        public static int GetAverageDamage()
        {
            Random rand = new Random();
            return rand.Next(GetMinDamage(), GetMaxDamage() + 1);
        }
    }
}
