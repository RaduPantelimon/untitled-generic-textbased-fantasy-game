using Microsoft.VisualBasic;
using GenericRPG.Creatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public class HostileParty<T> : Collection<T> where T: Creature
    {
        protected override void InsertItem(int index, T enemy)
        {
            //Automatically remove from list when it dies
            enemy.CreatureDied += (object? sender, DeathEventArgs e) => this.Remove((T)sender!);
            base.InsertItem(index,enemy);
        }
    }
}
