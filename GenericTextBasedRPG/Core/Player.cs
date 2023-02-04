using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public class Player
    {
        //a normal game would have a lot more stuff here
        public Humanoid? Hero { get; internal set; }
        public double Gold { get; internal set; }
        
        internal Player()
        {

        }
        
    }
}
