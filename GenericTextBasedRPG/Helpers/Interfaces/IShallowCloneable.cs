using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGUtilities
{

    public interface IShallowCloneable<T>
    {
        T Clone();
    }
}
