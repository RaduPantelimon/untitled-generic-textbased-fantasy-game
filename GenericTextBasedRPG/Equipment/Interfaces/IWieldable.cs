using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment
{
    public interface IWieldable
    {
        public double MinAttack { get; protected set; }
        public double MaxAttack { get; protected set; }

        //default implementation!!!
        public double GetDamage()
        {
            return (MaxAttack - MinAttack) / 2;
        }
    }
}
