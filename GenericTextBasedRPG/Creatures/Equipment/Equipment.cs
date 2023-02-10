using GenericRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Creatures
{
    //this can be expanded to contain multiple armor slots, etc.
    public class Equipment
    {
        public IWieldable? Weapon { get; internal set; }
        public IWearable? Armor { get; internal set; }
    }
}
