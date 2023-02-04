using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG.Helpers
{
    public static class Utils
    {
        //basic example of extensions
        public static string ToFormattedString(this DamageTypes damageType)
        {
            if (damageType == DamageTypes.Normal) return damageType.ToString();

            return String.Join("/", GetFlags(damageType, true)).ToLower();
        }

        public static IEnumerable<Enum> GetFlags(this Enum e, bool excludeDefault = true)
        {
            if(excludeDefault) return Enum.GetValues(e.GetType()).Cast<Enum>()
                    .Where(flag => e.HasFlag(flag) && Convert.ToDecimal(flag) != 0);

            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
        }
    }
}
