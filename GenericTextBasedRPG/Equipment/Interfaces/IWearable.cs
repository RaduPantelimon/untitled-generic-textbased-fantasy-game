using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment
{
    public interface IWearable
    {
        //good armor might convert a slashing attack into a blunt one
        //default implementation leaves the attack unchanged
        //could also be a good approach if we ever implement layered armor (Decorator pattern :P)
        public Attack MitigateAttack(Attack attack) => attack;
    }
}
