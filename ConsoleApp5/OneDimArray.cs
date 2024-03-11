using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class OneDimArray<T> : ArrayBase, IArrayOne, IPrinter
        where T : IConvertible, IParsable<T>, IEquatable<T>
    {
        T[] array;
        ValueProvider<T> provider;


        public OneDimArray(bool user, int n, ValueProvider<T> provider) : base(user, n)
        {
            this.provider = provider;

            if (user == true)
            {
                UserCreate();
            }
            else
            {
                RndCreate();
            }


        }

        public override void UserCreate()
        {
            array = new T[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите элемент {i + 1}");
                array[i] = provider.UserCreate();
            }
        }
        public override void RndCreate()
        {
            Random rnd = new Random();
            array = new T[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = provider.RndCreate();
            }
        }

        public void DeleteAbs()
        {
            /*int n = array.Length;
            int[] d = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(array[i]) <= 100)
                {
                    d.SetValue(array[i], i);

                }
            }

            array = d;*/
        }

        public void DeleteSame()
        {
            int n = array.Length;
            T[] res = new T[n];
            int k = 0;
            bool f;

            foreach (T i in array)
            {
                f = true;
                for (int j = 0; j < k; j++)
                {
                    if (i.Equals(res[j]))
                    {
                        f = false;
                    }
                }
                if (f)
                {
                    res[k] = i;
                    k += 1;
                }
            }
            array = res;
        }
        public override decimal Average()
        {
            /*int[] l = array;
            decimal summ = 0;
            decimal sred = 0;
            for (int i = 0; i < l.Length; i++)
            {
                summ += array[i];
                int len = l.Length;
                sred = summ / len;
            }

            return Math.Round(sred, 2);*/
            return 0;
        }

        public override void Print()
        {
            Console.WriteLine("Одномерный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
        public override void Change()
        {
            DeleteSame();
            DeleteAbs();
        }
    }
}
