using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    sealed class BoolValueProvider : ValueProvider<bool>
    {
        public override bool RndCreate()
        {
            int value = Rnd.Next(0, 2);
            if (value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
