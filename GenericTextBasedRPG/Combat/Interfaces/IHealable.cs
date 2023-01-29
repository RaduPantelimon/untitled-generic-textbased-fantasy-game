using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    public interface IHealable
    {
        public void RestoreHealth(double health);
    }
}
