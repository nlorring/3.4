using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    sealed class DoubleolValueProvider : ValueProvider<double>
    {
        public override double RndCreate()
        {
            double value = Rnd.NextDouble() * 300 - 150;
            return value;

        }
    }
}
