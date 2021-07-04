using System;
using System.Linq;

namespace statistik
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split("; ").Select(int.Parse).ToArray();
            int broi = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    broi++;
                }
            }
            Console.WriteLine(broi);

            Console.WriteLine( numbers.Contains(34));
            Console.WriteLine( numbers.Contains(65));

            Console.WriteLine(string.Join(" - ", numbers));

            foreach (var item in numbers)
            {
                Console.Write($"{item}; ");
            }


        }
    }
}
