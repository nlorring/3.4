using System.Data.SqlTypes;
using System.Globalization;

namespace _3_4
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
    abstract class ArrayBase : IBaseArray, IPrinter
    {
        protected bool user;//способ ввода
        protected int n;

        public ArrayBase(bool user, int n)
        {
            this.user = user;
            this.n = n;
        }


        public abstract void UserCreate();
        public abstract void RndCreate();


        public abstract decimal Average();

        public abstract void Print();

        public abstract void Change();
    }

    sealed class IntValueProvider : ValueProvider<int>
    {
        public override int RndCreate()
        {
            int value = Rnd.Next(-150, 150);
            return value;
        }
    }
    sealed class BoolValueProvider : ValueProvider<bool>
    {
        public override bool RndCreate()
        {
            int value = Rnd.Next(0, 2);
            if(value == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    sealed class DoubleolValueProvider : ValueProvider<double>
    {
        public override double RndCreate()
        {
            double value = Rnd.NextDouble() * 300 - 150;
            return value;
            
        }
    }
    sealed class StringValueProvider : ValueProvider<string>
    {
        public override string RndCreate()
        {
            string characters = """qwertyuiop[]\asdfghjkl;'zxcvbnm",./1234567890!@#$%^&*()-=_+`~""";
            string value = "";
            for(int i  = 0; i < Rnd.Next(3, 10); i++)
            {
                value += characters[Rnd.Next(characters.Length)];
            }
            return value;
            
        }
        
    }
    public interface IArrayOne
    {
        void DeleteAbs();
        void DeleteSame();
    }
    public interface IArrayTwo
    {
        void Snake();

    }
    public interface IBaseArray
    {
        void UserCreate();
        void RndCreate();
        decimal Average();

        void Change();
    }
    public interface IPrinter
    {
        void Print();
    }
    internal class OneDimArray<T>: ArrayBase, IArrayOne, IPrinter
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
    internal class Program
    {

        static void Main(string[] args)
        {
            ValueProvider<int> provider = new IntValueProvider();
            ArrayBase[] ar;
            Console.WriteLine("Напишите true если хотите ввод с клавиатуры, если хотите с помощью рандома, напишите false");
            bool user = bool.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество элементов в одномерной массиве");
            int n = int.Parse(Console.ReadLine());
            OneDimArray<int> array = new OneDimArray<int>(user, n, provider);
            Console.WriteLine("Введите количество строк в двухмерном массиве");
            int n2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов в двухмерном массиве");
            int c = int.Parse(Console.ReadLine());
            TwoDimArray<int> array2 = new TwoDimArray<int>(user, n2, c, provider);
            

            ar = new ArrayBase[] { array, array2 } ;
            IPrinter[] ip = { array, array2 };
            Console.WriteLine("\nВывод всех массивов:");
            foreach (IPrinter printer in ip)
                printer.Print();

            



        }
    }
}