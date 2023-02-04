using GenericRPG.Commands;
using GenericRPG.Core;
using GenericRPG.Creatures;
using GenericRPG.Equipment.Armor;
using GenericRPG.Equipment.Weapons;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    //TO DO - USE ENGINE CLASS TO ALSO BUILD A MENU
    public class TutorialGame : Game,IDisposable
    {
        TextReader Reader { get; }
        TextWriter Writer { get; }

        public TutorialGame(Stream input, Stream output) : base(CommandRepository.AvailableCommands, FormattingService.Instance)
        {
            Reader = new StreamReader(input,leaveOpen:true);
            Writer = new StreamWriter(output, leaveOpen: true);

            //In the tutorial, the player can only fight using a generic, hardcoded character
            Player = new Player();
            Player.Hero = new Fighter(Randomizer.Instance.Next(250, 300), 20)
            {
                Name = Mechanics.Tutorial_HeroName,
                Weapon = new Sword(15, 20), 
                Armor = new Chainmail(0.3)
            };
        }
        
        //if the tutorial level is beat, the Tutorial Game is Won!
        public override bool PlayerWon => CurrentLevel?.PlayerWon??false;

        internal override void StartNextLevel()
        {
            if (CurrentLevel is {IsOver: false }) 
                throw new InvalidOperationException(Exceptions.Exception_LevelAlreadyInProgress);

            CurrentLevel = TutorialLevelFactory.Instance.GetLevel(this);
        }

        public override void Dispose()
        {
            Reader.Dispose();
            Writer.Dispose();
        }

        internal override string GetUserInput() => Reader.ReadLine()!;
        internal override void SendUserMessage(string message, bool flushToStream = true)
        {
            Writer.WriteLine(message);
            Writer.Flush();
        }
    }
}
