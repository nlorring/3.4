using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    sealed class StringValueProvider : ValueProvider<string>
    {
        public override string RndCreate()
        {
            string characters = """qwertyuiop[]\asdfghjkl;'zxcvbnm",./1234567890!@#$%^&*()-=_+`~""";
            string value = "";
            for (int i = 0; i < Rnd.Next(3, 10); i++)
            {
                value += characters[Rnd.Next(characters.Length)];
            }
            return value;

        }

    }
}
