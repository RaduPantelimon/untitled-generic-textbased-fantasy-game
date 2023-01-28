using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Core
{

    //TO DO: finish this class, add properties for map, quests, etc.
    public abstract class Level : Engine
    {
        internal Level(Stream input, Stream output, List<Command> commands)
            : base(input, output, commands)
        {
        }
    }
}
