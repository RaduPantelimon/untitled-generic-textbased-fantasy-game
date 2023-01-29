using GenericRPG.Core;
using GenericRPG.Creatures;
using GenericRPG.Equipment.Armor;
using GenericRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    //TO DO - USE ENGINE CLASS TO ALSO BUILD A MENU
    public class Game
    {
        public Stream InputStream { get; }
        public Stream OutputStream { get; }

        public Player Player { get;}

        public Game(Stream input, Stream output)
        {
            InputStream = input;
            OutputStream = output; 

            //TO DO - MOVE PLAYER CREATION AND CHARACTER CUSTOMIZATION OUTSIDE OF CONSTRUCTOR
            Player = new Player();
            Player.Hero = new Fighter(Randomizer.Instance.Next(250, 300), 20)
                                        { Weapon = new Sword(15, 20), 
                                          Armor = new Chainmail(0.3) };
        }

        //DUMMY IMPLEMENTATION
        public Level GetNextLevel() => TutorialFactory.Instance.GetLevel(this);
    }
}
