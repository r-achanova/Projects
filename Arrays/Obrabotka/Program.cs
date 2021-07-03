using System;
using System.Linq;

namespace Obrabotka
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine($"Sum= {arr.Sum()}");
            Console.WriteLine($"Average= {arr.Average():f2}");
            Array.Reverse(arr);
            Console.WriteLine(string.Join(" ",arr));

            int br = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if  (arr[i]>=0 && arr[i]<=20)
                {
                    br++;
                }
            }
            Console.WriteLine($"Count={br}");
        }
    }
}
