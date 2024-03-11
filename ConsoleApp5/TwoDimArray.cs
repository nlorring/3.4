using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    sealed class TwoDimArray<T> : ArrayBase, IArrayTwo, IPrinter
        where T : IConvertible, IParsable<T>
    {
        T[,] array;
        int c;
        ValueProvider<T> provider;

        public TwoDimArray(bool user, int n, int c, ValueProvider<T> provider) : base(user, n)
        {
            this.provider = provider;
            this.c = c;
            array = new T[n, c];
            if (user == true)
            {
                UserCreate();
            }
            else
            {
                RndCreate();
            }


        }
        public void Snake()
        {
            T[,] ar = new T[n, c];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (i % 2 == 1)
                        ar[i, j] = array[i, j];
                    else
                        ar[i, j] = array[i, c - 1 - j];
                }
            }
            array = ar;
        }
        public override void UserCreate()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine("Y:" + i + " X:" + j);
                    array[i, j] = provider.UserCreate();
                }
            }
        }
        public override void RndCreate()
        {
            Random rnd = new Random();
            array = new T[n, c];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    array[i, j] = provider.RndCreate();
                }
            }
        }

        public override decimal Average()
        {
            /*int[,] l = array;
            decimal summ = 0;
            decimal sred = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    summ += array[i, j];
                    int len = l.Length;
                    sred = summ / len;
                }
            }
            return Math.Round(sred, 2);*/
            return 0;
        }

        public override void Print()
        {
            Console.WriteLine("Двумерный массив: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public override void Change()
        {
            Snake();
        }

    }
}
