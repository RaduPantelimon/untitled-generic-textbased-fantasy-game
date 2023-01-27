﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment
{
    public interface IWieldable
    {
        public double MinDamage { get; }
        public double MaxDamage { get; }

        public DamageTypes DamageType { get; }

        //default implementation!!!
        //If I Hold a Spoon, I might not want my GetDamage to be implemented in the class,
        //and I might just want to see the method only when it is cast to IWieldable
        public Attack GetAttack()
        {
            return new Attack((MaxDamage - MinDamage) / 2);
        }
    }
}
