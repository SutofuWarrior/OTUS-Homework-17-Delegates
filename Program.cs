using System;
using System.Collections.Generic;
using System.Text;

namespace OTUS_Homework_17_Delegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Коллекция: {MaxInCollection.GetCollectionString()}");
            var max = MaxInCollection.GetMax();
            Console.WriteLine($"Максимальный элемент коллекции: {max}");

            Console.WriteLine();
            Console.WriteLine(new string('-', 30));

            var iterator = new FileIterator();
            iterator.OnFileFound += Iterator_OnFileFound;

            Console.WriteLine("Начинаем перебор файлов:");
            iterator.IterateFiles(AppDomain.CurrentDomain.BaseDirectory);
            iterator.OnFileFound -= Iterator_OnFileFound;

            Console.ReadLine();
        }

        private static void Iterator_OnFileFound(object sender, EventArgs e)
        {
            Console.WriteLine(((FileArgs)e).FileName);
            Console.Write("Нажмите Y, чтобы остановить перебор >>> ");

            if (Console.ReadKey().Key == ConsoleKey.Y)
                ((FileIterator)sender).CancelSearch = true;
            else
                Console.WriteLine();
        }
    }

    public static class MaxInCollection
    {
        private static readonly List<string> _collection = new() { "abc", "gte", "bhy", "334" };

        public static string GetCollectionString()
            => new StringBuilder().AppendJoin(", ", _collection).ToString();

        public static string GetMax()
            => _collection.GetMax(GetParameter);

        private static float GetParameter(string c) => c == null ? -1 : c[0];
    }
}
