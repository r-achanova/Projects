using System;
using System.Linq;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            Array.Sort(words);
            Console.WriteLine(string.Join("; ",words));
            Array.Clear(words, 1, words.Length-2);
            Console.WriteLine(string.Join(";",words));
        }
    }
}
