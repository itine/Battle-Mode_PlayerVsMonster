using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleModePlayerVsMonster
{
    public class Player
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public int Attack { get; set; }
        public int SpellPower { get; set; }
        public int DiamondQuantity { get; set; }
        public int HPBottleQuantity { get; set; }
        public int MPBottleQuantity { get; set; }
        public int PlayerLevel { get; set; }
        public int Defence { get; set; }

        public static int CalculateHP(int level)
        {
            
        }
    }
}
