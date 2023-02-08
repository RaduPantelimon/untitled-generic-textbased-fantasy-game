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

    //TO DO REPLACE STARTED AND QUIT PROPERTIES WITH STATE ENUM
    public abstract partial class Game: IDisposable
    {
        //maybe move this to resx
        static readonly int CommandsOnTheSameLine = 3;

        private protected IReadOnlyList<Command> Commands { get; }
        internal GameState GameState { get; }  

        internal FormattingService FormattingService { get; set; }

        public bool PlayerQuit { get; private protected set; }

        private protected abstract bool GameWon { get; }

        public bool IsDisposed { get; private protected set; }

        internal abstract string GetUserInput();
        internal abstract void SendUserMessage(string message, bool flushToStream = true);

        internal abstract void StartNextLevel();

        //TO DO BUILD AN INTERFACE FOR COMMANDS?
        internal Game(GameState gameState, List<Command> commands, FormattingService formattingService)
        {
            GameState = gameState;
            Commands = commands;
            FormattingService = formattingService;
        }

        public void Play()
        {
            if (IsDisposed) throw new ObjectDisposedException(this.GetType().Name);
            Command? command = null;

            while ((PlayerStatus.GameOver & GameState.Status) == 0)
            {
                try
                {
                    if((PlayerStatus.InCombat & GameState.Status) != 0)
                    {
                        SendUserMessage(Messages.Menu_InCombat);
                        SendUserMessage(FormattingService.EntitiesList(GameState.CurrentLevel!.CurrentEncounter!,1));
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
            if ((PlayerStatus.InCombat & GameState.Status) == 0) return;
            SendUserMessage(string.Empty);
            foreach (var enemy in GameState.CurrentLevel!.CurrentEncounter!)
            {
                AttackResult result = enemy.DoDamage(GameState.Player!.Hero!);
                SendUserMessage(FormattingService.AttackedByMessage(result));
            }
            //after attacks, display hero status
            SendUserMessage(string.Empty);
            SendUserMessage(String.Format(Messages.Menu_HeroStatus, FormattingService.EntityStatusMessage(GameState.Player!.Hero!)));
        }

        //this could be extended to show score or other features, depending on game mode. levels and other stuff
        private protected virtual void DisplayEndGameResults()
        {
            //(PlayerStatus.InCombat & GameState.Status) == 0
            if ((GameState.Status & PlayerStatus.Defeat) != 0) 
                SendUserMessage(Messages.Menu_PlayerLost);
            else if ((GameState.Status & PlayerStatus.GameWon) != 0)
                SendUserMessage(Messages.Menu_PlayerWon);
            else if ((GameState.Status & PlayerStatus.Quit) != 0)
                SendUserMessage(Messages.Menu_PlayerQuit);
        }

        internal virtual void Quit()
        {
            if (IsDisposed) throw new ObjectDisposedException(this.GetType().Name);
            GameState.Quit();
        }

        public void Dispose()
        {
            ///BASIC EMPTY IMPLEMENTATION
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            IsDisposed = true;
        }

        ~Game()
        {
            Dispose(false);
        }
    }
}