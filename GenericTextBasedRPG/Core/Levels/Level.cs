using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{

    //TO DO: finish this class, add properties for map, quests, etc.
    public abstract class Level : Engine
    {
        internal Level(Game currentGame, List<Command> commands)
            : base(currentGame,commands)
        {
        }
    }
}
