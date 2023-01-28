using Microsoft.VisualBasic;
using RPGUtilities.Creatures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities.Helpers
{
    public class HostileParty<T> : Collection<T> where T: Creature
    {
    }
}
