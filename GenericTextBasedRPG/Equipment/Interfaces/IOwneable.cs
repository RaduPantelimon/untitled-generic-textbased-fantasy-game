using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Equipment.Interfaces
{
    internal interface IOwneable
    {
        public Creature Owner { get; set; }
    }
}
