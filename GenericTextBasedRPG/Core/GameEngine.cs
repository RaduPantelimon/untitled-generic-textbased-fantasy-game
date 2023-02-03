using GenericRPG.Combat;
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
        internal FormattingService FormattingService { get; set; }
        
        public bool Started { get; private protected set; }
        public bool PlayerQuit { get; private protected set; }
        public bool PlayerWon { get; private protected set; }
        public virtual bool PlayerLost => !(Player?.Hero?.IsAlive ?? true);
        public virtual bool IsOver => PlayerQuit || PlayerLost || PlayerWon;
        public virtual bool InCombat => CurrentLevel is { CurrentEncounter: { Count: > 0 } };

        public Player? Player { get; private protected set; }
        public Level? CurrentLevel { get; private protected set; }


        protected internal abstract string GetUserInput();
        protected internal abstract void SendUserMessage(string message, bool flushToStream = true);

        internal abstract void StartNextLevel();

        //TO DO BUILD AN INTERFACE FOR COMMANDS
        internal GameEngine( List<Command> commands, FormattingService formattingService)
        {
            Commands = commands;
            FormattingService = formattingService;
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
                finally
                {
                    SendUserMessage(string.Empty);
                }
            }
        }

        //USED PRIVATE PROTECTED HERE
        private protected virtual Command GetCommand()
        {

            Command[] eligibleCommands = Commands.Where(x => x.IsValid(this)).ToArray();

            //display valid commands:
            SendUserMessage(Messages.Menu_EligibleCommands);
            foreach (var batch in eligibleCommands.Select((x, i) => i+1 + ". " + x.ToString()).Chunk(3)) //TO DO REMOVE HARDCODED PARAMS;
            {
                StringBuilder lineBuilder = new StringBuilder();
                for(int i=0;i<batch.Length;i++)
                {
                    lineBuilder.Append(String.Format("{0, 15}", batch[i]));
                    lineBuilder.Append(Messages.Command_Separator);
                }
                SendUserMessage(lineBuilder.ToString());
            }

            //retrieve response and interpret characters
            try
            {
                string userInput = GetUserInput();
                return eligibleCommands[int.Parse(userInput) -1].Clone();
            }
            catch (Exception ex)
            {
                throw new InvalidCommandException(Exceptions.Exception_InvalidInputCommand, ex);
            }
        }

        private protected virtual void PostCommandLogic()
        {
            //if in combat, mobs attack Player after each action
            if (!InCombat) return;
            SendUserMessage(string.Empty);
            foreach (var enemy in CurrentLevel!.CurrentEncounter!)
            {
                AttackResult result = enemy.DoDamage(Player!.Hero!);
                SendUserMessage(FormattingService.AttackedByMessage(result));
            }
        }

        internal virtual void Start()
        {
            if (Started || IsOver) throw new InvalidOperationException();
            Started = true;
        }

        internal virtual void Quit()
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