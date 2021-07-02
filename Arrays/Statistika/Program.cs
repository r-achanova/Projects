using System;
using System.Linq;
using System.Collections.Generic;

namespace Statistika
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int n = arr.Length;
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            Array.Sort(arr);
            Array.Reverse(arr);
            Array.Copy(arr,arr1,3);
            arr.CopyTo(arr2, arr.Length);
            Console.WriteLine(string.Join("; ", arr));
            Console.WriteLine(string.Join("; ", arr1));
            
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr1.Length);
            Console.WriteLine("Sum="+arr.Sum());
            Console.WriteLine("Min="+arr.Min());
            Console.WriteLine("Max="+arr.Max());
            Console.WriteLine($"Average= {arr.Average():0.00}");
            Console.WriteLine( arr.Contains(3) ); 
            Array.Clear(arr, 0, arr.Length);
             Console.WriteLine(string.Join("; ", arr));
            
        }
    }
}
