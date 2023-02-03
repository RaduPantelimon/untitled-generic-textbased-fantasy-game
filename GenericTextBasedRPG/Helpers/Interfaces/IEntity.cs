using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Helpers.Interfaces
{
    public interface IEntity: INameable
    {
        public string DisplayStats();
    }
}
