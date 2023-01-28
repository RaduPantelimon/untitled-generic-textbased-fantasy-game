using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{
    public class Player
    {

        public Humanoid? Hero { get; internal set; }
        public double Gold { get; internal set; }
        
        internal Player()
        {

        }
    }
}
