using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    sealed class IntValueProvider : ValueProvider<int>
    {
        public override int RndCreate()
        {
            int value = Rnd.Next(-150, 150);
            return value;
        }
    }
}
