using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{
    public abstract class Engine:IDisposable
    {

        private protected TextReader Reader { get; }
        private protected TextWriter Writer { get; }

        public Player? Player { get; internal set; }

        private protected IReadOnlyList<Command> Commands { get; init; }

        public bool Started { get; private protected set; }
        public bool Quit { get; private protected set; }
        
        public abstract bool PlayerWon { get; }
        public virtual bool IsOver => Quit;



        internal Engine(Stream input, Stream output, List<Command> commands): this(commands)
        {
            Reader = new StreamReader(input); //,leaveOpen: true);
            Writer = new StreamWriter(output);//,leaveOpen: true);
        }
        private protected Engine(List<Command> commands) => Commands = commands;

        public void Play()
        {
            Command? command = null;

            while(! IsOver)
            {
                try
                {
                    command = GetCommand();
                    command.Execute(this);
                }
                catch(InvalidCommandException ex)
                {
                    //log problem to user
                    Writer.WriteLine(Messages.Command_InvalidCommand, ex.Message);
                }
                catch { throw; }
                
                
            }
        }

        //USED PRIVATE PROTECTED HERE
        private protected virtual Command GetCommand()
        {
            
            Command[] eligibleCommands = Commands.Where(x => x.IsValid(this)).ToArray();

            //display valid commands:
            Writer.WriteLine(Messages.Menu_EligibleCommands);
            foreach(var batch in eligibleCommands.Select((x,i) => i+ ". " + x).Chunk(3)) //TO DO REMOVE HARDCODED PARAMS;
                Console.WriteLine(String.Format("{0, 15} | {1, 15} | {2, 15}", batch.ToArray()));


            //retrieve response and interpret characters
            try
            {
                return eligibleCommands[int.Parse(Reader.ReadLine()!)].Clone();
            }
            catch(Exception ex)
            {
                throw new InvalidCommandException(Exceptions.Exception_InvalidInputCommand, ex);
            }
        }

        

        public void Dispose()
        {
            Reader.Dispose();
            Writer.Dispose();
        }

    }
}
