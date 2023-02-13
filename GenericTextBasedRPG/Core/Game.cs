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
    public abstract partial class Game: IDisposable
    {
        static readonly int CommandsOnTheSameLine = int.Parse(Messages.Menu_CommandsOnTheSameLine);

        private protected IReadOnlyList<Command> Commands { get; }
        internal GameState GameState { get; }  
        internal FormattingService FormattingService { get; set; }

        private protected abstract bool WinCondition { get; }
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

            while ((GameplayStatus.GameOver & GameState.Status) == 0) //While game not finished
            {
                try
                {
                    PreCommandLogic(); //redefine logic depending on specific of the subclass
                    Command command = GetCommand();
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
            switch (GameState.Status)
            {
                case GameplayStatus.InCombat:
                    PreCommand_InCombat();
                    break;
                case GameplayStatus.Idle:
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

            switch (GameState.Status)
            {
                case GameplayStatus.InCombat:
                    PostCommand_InCombat(commandResult);
                    break;
                case GameplayStatus.Idle:
                    PostCommand_Idle(commandResult);
                    break;
                //ADD MORE STATES HERE, AS NEW FEATURES/BEHAVIOURS ARE ADDED
            }

            if (WinCondition) GameState.PlayerWon(); //after each command, at the end, we check the win condition
        }

        private protected virtual void PostCommand_Idle(CommandResult commandResult) { }
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
            if (GameState.Status == GameplayStatus.Defeat) 
                SendUserMessage(Messages.Menu_PlayerLost);
            else if (GameState.Status == GameplayStatus.GameWon)
                SendUserMessage(Messages.Menu_PlayerWon);
            else if (GameState.Status == GameplayStatus.Quit)
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