//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BattleModePlayerVsMonster.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Units
    {
        public int idUnit { get; set; }
        public int attack { get; set; }
        public int hp { get; set; }
        public int defence { get; set; }
        public int speed { get; set; }
        //public string unitName { get; set; }
        //public Nullable<int> currentLeftBox { get; set; }
        //public Nullable<int> currentRightBox { get; set; }
        //public Nullable<double> monstersRemainingOnLeft { get; set; }
        //public Nullable<double> monstersRemainingOnRight { get; set; }
        public string classOfMonster { get; set; }
        public Nullable<int> monsterSize { get; set; }
        public Nullable<int> minDamage { get; set; }
        public Nullable<int> maxDamage { get; set; }
        public int averageDamage { get; set; }
    }
}