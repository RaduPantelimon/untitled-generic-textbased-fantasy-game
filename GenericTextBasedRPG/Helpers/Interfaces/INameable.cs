using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    //interface used for entities that need to be displayed to the user
    public interface INameable
    {
        public string? Name { get; }
    }
}
