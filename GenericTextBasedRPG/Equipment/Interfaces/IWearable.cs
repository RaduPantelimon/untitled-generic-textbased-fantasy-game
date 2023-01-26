using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment
{
    public interface IWearable
    {
        //default implementation!!!
        public double MitigateAttack(double damage) => damage;
    }
}
