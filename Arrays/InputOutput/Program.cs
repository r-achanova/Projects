using System;
using System.Linq;

namespace InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //int[] arr= new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(arr[i]+" ");
            //}

            //Console.WriteLine(string.Join(" ",arr));

            //int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            string[] names = Console.ReadLine().Split().ToArray();

            Console.WriteLine(string.Join(" => ",names));



        }
    }
    
}
