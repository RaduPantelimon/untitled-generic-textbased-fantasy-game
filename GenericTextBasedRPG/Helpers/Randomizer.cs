using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRPG
{
    //Singleton in current thread
    public class Randomizer
    {
        private static ThreadLocal<Randomizer> instances = new ThreadLocal<Randomizer>(() => new Randomizer());

        public static Randomizer Instance => instances.Value!;

        public Random Random { get; }

        private Randomizer()
        {
            //TO DO - add optional seed parameter
            Random = new Random();
        }

        public int ThrowDice() => Random.Next(1, 7);
        public int Next (int min, int max) => Random.Next(min,max);
        public double RandomPercentage() => Random.NextDouble();
    }
}
