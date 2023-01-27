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
        public Attack MitigateAttack(Attack attack);
    }
}
