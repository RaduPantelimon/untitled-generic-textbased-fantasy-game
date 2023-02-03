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
        //maybe move this to resx
        static readonly int CommandsOnTheSameLine = 3;

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
                    if(InCombat)
                    {
                        SendUserMessage(Messages.Menu_InCombat);
                        SendUserMessage(FormattingService.EntitiesList(CurrentLevel!.CurrentEncounter!,1));
                        SendUserMessage(string.Empty);
                    }
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

            DisplayEndGameResults();
        }

        //USED PRIVATE PROTECTED HERE
        private protected virtual Command GetCommand()
        {
            Command[] eligibleCommands = Commands.Where(x => x.IsValid(this)).ToArray();

            //display valid commands:
            SendUserMessage(Messages.Menu_EligibleCommands);
            int commandIndex = 1;
            foreach (var batch in eligibleCommands.Chunk(CommandsOnTheSameLine)) //TO DO REMOVE HARDCODED PARAMS;
            {
                StringBuilder lineBuilder = new StringBuilder();
                SendUserMessage(FormattingService.NameableItemsList(batch, commandIndex));
                commandIndex+=CommandsOnTheSameLine;
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
            //after attacks, display hero status
            SendUserMessage(string.Empty);
            SendUserMessage(String.Format(Messages.Menu_HeroStatus, FormattingService.EntityStatusMessage(Player!.Hero!)));
        }

        //this could be extended to show score or other features, depending on game mode. levels and other stuff
        private protected virtual void DisplayEndGameResults()
        {
            if (PlayerLost) 
                SendUserMessage(Messages.Menu_PlayerLost);
            else if (PlayerWon)
                SendUserMessage(Messages.Menu_PlayerWon);
            else if (PlayerQuit)
                SendUserMessage(Messages.Menu_PlayerQuit);
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