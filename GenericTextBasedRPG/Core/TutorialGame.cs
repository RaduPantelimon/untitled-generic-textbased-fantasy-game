using GenericRPG.Commands;
using GenericRPG.Core;
using GenericRPG.Creatures;
using GenericRPG.Items.Armor;
using GenericRPG.Items.Weapons;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class TutorialGame : Game,IDisposable
    {
        TextReader Reader { get; }
        TextWriter Writer { get; }

        public TutorialGame(Stream input, Stream output) 
            : base(
                new GameState(new Player()), //Tutorial Games always start with a new player 
                CommandRepository.AvailableCommands, 
                FormattingService.Instance)
        {
            Reader = new StreamReader(input);
            Writer = new StreamWriter(output);

            //In the tutorial, the player can only fight using a generic, hardcoded character
            GameState.Player.Hero = new Fighter(Randomizer.Instance.Next(250, 300), 20)
            {
                Name = Mechanics.Tutorial_HeroName,
                Weapon = new Sword(15, 20), 
                Armor = new Chainmail(0.3)
            };
        }
        
        //if the first level is beat, the Tutorial Game is Won!
        private protected override bool GameWon => GameState.Status.HasFlag(GameplayStatus.LevelWon);

        internal override void StartNextLevel()
        {
            if (IsDisposed) throw new ObjectDisposedException(this.GetType().Name);

            if ((GameState.Status & GameplayStatus.GameOver) != 0) 
                throw new InvalidOperationException(Exceptions.Exception_LevelAlreadyInProgress);

            GameState.CurrentLevel = TutorialLevelFactory.Instance.GetLevel(this);
        }

        internal override string GetUserInput()
        {
            if (IsDisposed) throw new ObjectDisposedException(this.GetType().Name);
            return Reader.ReadLine()!;
        }
        internal override void SendUserMessage(string message, bool flushToStream = true)
        {
            if (IsDisposed) throw new ObjectDisposedException(this.GetType().Name);
            Writer.WriteLine(message);
            Writer.Flush();
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Reader.Dispose();
                    Writer.Dispose();
                }
                IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
