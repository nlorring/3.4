using ConsoleApp5;
using System.Data.SqlTypes;
using System.Globalization;

namespace _3_4
{
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


            ar = new ArrayBase[] { array, array2 };
            IPrinter[] ip = { array, array2 };
            Console.WriteLine("\nВывод всех массивов:");
            foreach (IPrinter printer in ip)
                printer.Print();





        }
    }
}