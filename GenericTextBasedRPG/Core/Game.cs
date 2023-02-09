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
                    PreCommandLogic(); //redefine logic depending on specific of the subclass
                    command = GetCommand();
                    CommandResult result = command.Execute(this);
                    PostCommandLogic(result); //redefine logic depending on specific of the subclass
                }
                catch (InvalidCommandException ex)
                {
                    SendUserMessage(String.Format(Messages.Command_InvalidCommand, ex.Message));//log problem to user
                }
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

        //more logic can be added here, depending on the
        private void PreCommandLogic()
        {
            //This is a tad convoluted, but I just wanted to build a switch for a Flags Enum
            //WARNING: the order of the States might matter when we add more features
            foreach (PlayerStatus possibleState in Enum.GetValues(typeof(PlayerStatus))) 
                if (GameState.Status.HasFlag(possibleState))
                    switch (possibleState)
                    {
                        case PlayerStatus.InCombat:
                            PreCommand_InCombat();
                            break;
                        case PlayerStatus.Idle:
                            PreCommand_Idle();
                            break;
                        //ADD MORE STATES HERE, IF NEEDED AS NEW FEATURES/BEHAVIOURS ARE ADDED
                    }
        }

        private protected virtual void PreCommand_Idle() { }
        private protected virtual void PreCommand_InCombat()
        {
            SendUserMessage(Messages.Menu_InCombat);
            SendUserMessage(FormattingService.EntitiesList(GameState.CurrentLevel!.CurrentEncounter!, 1));
            SendUserMessage(string.Empty);
        }

        private void PostCommandLogic(CommandResult commandResult)
        {
            if (commandResult.Status == CommandStatus.Failed)
                SendUserMessage(FormattingService.CommandResultMessage(commandResult));

            //if in combat, mobs attack Player after each action
            foreach (PlayerStatus possibleState in Enum.GetValues(typeof(PlayerStatus)))
                if (GameState.Status.HasFlag(possibleState))
                    switch (possibleState)
                    {
                        case PlayerStatus.InCombat:
                            PostCommand_InCombat(commandResult);
                            break;
                        case PlayerStatus.Idle:
                            PreCommand_Idle();
                            break;
                        //ADD MORE STATES HERE, AS NEW FEATURES/BEHAVIOURS ARE ADDED
                    }
        }

        private protected virtual void PreCommand_Idle(CommandResult commandResult) { }
        private protected virtual void PostCommand_InCombat(CommandResult commandResult)
        {
            if (commandResult.Status == CommandStatus.Failed) return; //we do not attack if 

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

        internal void Quit()
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