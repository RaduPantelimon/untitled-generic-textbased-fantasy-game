﻿using GenericRPG.Commands;
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
    public class Game : Engine,IDisposable
    {
        //TO DO MOVE THESE IN THE GAME CLASS
        TextReader Reader { get; }
        TextWriter Writer { get; }

        public Game(Stream input, Stream output) : base(CommandRepository.AvailableCommands)
        {
            Reader = new StreamReader(input,leaveOpen:true);
            Writer = new StreamWriter(input, leaveOpen: true);

            //TO DO - MOVE PLAYER CREATION AND CHARACTER CUSTOMIZATION OUTSIDE OF CONSTRUCTOR
            Player = new Player();
            Player.Hero = new Fighter(Randomizer.Instance.Next(250, 300), 20)
                                        { Weapon = new Sword(15, 20), 
                                          Armor = new Chainmail(0.3) };
        }

        //DUMMY IMPLEMENTATION
        public Level GetNextLevel()
        {
            if (CurrentLevel is {IsOver: true }) throw new InvalidOperationException(Exceptions.Exception_LevelAlreadyInProgress);
         
            return TutorialFactory.Instance.GetLevel(this);
        }

        public override void Dispose()
        {
            Reader.Dispose();
            Writer.Dispose();

            base.Dispose();
        }

        protected internal override string GetUserInput() => Reader.ReadLine()!;
        protected internal override void SendUserMessage(string message) => Writer.WriteLine(message);
    }
}
