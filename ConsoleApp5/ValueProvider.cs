using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    abstract class ValueProvider<T>
        where T : IConvertible, IParsable<T>
    {
        public abstract T RndCreate();

        public virtual T UserCreate()
        {
            T value = T.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            return value;

        }

        public static Random Rnd = new Random();
    }
}
