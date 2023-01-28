using Microsoft.VisualBasic;
using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities
{
    public class HostileParty<T> : Collection<T> where T: Creature
    {
        protected override void InsertItem(int index, T enemy)
        {
            //Automatically remove from list when it dies
            enemy.CreatureDied += (object? sender, CreatureDeathEventArgs e) => this.Remove((T)sender!);
            base.InsertItem(index,enemy);
        }
    }
}
