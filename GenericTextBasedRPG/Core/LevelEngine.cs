using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Engine
{
    public class LevelEngine
    {

        TextReader Reader { get; }
        TextWriter Writer { get; }

        internal LevelEngine(Stream input, Stream output)
        {
            Reader = new StreamReader(input);
            Writer = new StreamWriter(output);


        }



        public virtual void PlayGame()
        {

        }

        protected virtual void DetectCommand()
        {

        }


        protected virtual void ExecuteCommand()
        {

        }



    }
}
