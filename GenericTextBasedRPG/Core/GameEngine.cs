using GenericRPG.Commands;
using GenericRPG.Core;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Core
{

    //TO DO REPLACE STARTED AND QUIT WITH STATE ENUM
    public abstract class GameEngine: IDisposable
    {

        private protected IReadOnlyList<Command> Commands { get; } 
        public bool Started { get; private protected set; }
        public bool PlayerQuit { get; private protected set; }

        public Player? Player { get; private protected set;}

        public Level? CurrentLevel { get; private protected set; }
        
        public virtual bool PlayerLost => !(Player?.Hero?.IsAlive ?? true);
        public virtual bool IsOver => PlayerQuit || PlayerLost;

        protected internal abstract string GetUserInput();
        protected internal abstract void   SendUserMessage(string message);

        internal abstract Level StartNextLevel();

        //TO DO BUILD AN INTERFACE FOR COMMANDS
        internal GameEngine( List<Command> commands)
        {
            Commands = commands;
        }

        public void Play()
        {
            Command? command = null;

            while (!IsOver)
            {
                try
                {
                    command = GetCommand();
                    command.Execute(this);
                    //redefine logic depending on specific of the subclass
                    PostCommandLogic();
                }
                catch (InvalidCommandException ex)
                {
                    //log problem to user
                    SendUserMessage(String.Format(Messages.Command_InvalidCommand, ex.Message));
                }
                catch { throw; }


            }
        }

        //USED PRIVATE PROTECTED HERE
        private protected virtual Command GetCommand()
        {

            Command[] eligibleCommands = Commands.Where(x => x.IsValid(this)).ToArray();

            //display valid commands:
            SendUserMessage(Messages.Menu_EligibleCommands);
            foreach (var batch in eligibleCommands.Select((x, i) => i + ". " + x.ToString()).Chunk(3)) //TO DO REMOVE HARDCODED PARAMS;
            {
                StringBuilder lineBuilder = new StringBuilder();
                for(int i=0;i<batch.Length;i++)
                {
                    lineBuilder.Append(String.Format("{0, 15}", batch[i]));
                    if(i<batch.Length-1) lineBuilder.Append(" | ");
                }
                SendUserMessage(lineBuilder.ToString()); //not ok to send partial output - TO DO: FIX THIS
            }

            //retrieve response and interpret characters
            try
            {
                return eligibleCommands[int.Parse(GetUserInput())].Clone();
            }
            catch (Exception ex)
            {
                throw new InvalidCommandException(Exceptions.Exception_InvalidInputCommand, ex);
            }
        }

        public virtual void PostCommandLogic()
        {
            //if in combat, attack Player after each action
            if (CurrentLevel?.CurrentEncounter?.Count == 0 ) return;

            foreach(var enemy in CurrentLevel!.CurrentEncounter!)
                enemy.DoDamage(Player!.Hero!);

        }

        public virtual void Start()
        {
            if (Started || IsOver) throw new InvalidOperationException();
            Started = true;
        }

        public virtual void Quit()
        {
            if (!Started) throw new InvalidOperationException();
            PlayerQuit = true;
        }

        public virtual void Dispose()
        {
            ///BASIC EMPTY IMPLEMENTATION
        }

    }
}