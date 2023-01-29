using GenericRPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class Game
    {
        public Stream InputStream { get; }
        public Stream OutputStream { get; }


        public Game(Stream input, Stream output)
        {
            InputStream = input;
            OutputStream = output; 
        }

        //DUMMY IMPLEMENTATION
        public Level GetNextLevel() => TutorialFactory.Instance.GetLevel(this);
    }
}
