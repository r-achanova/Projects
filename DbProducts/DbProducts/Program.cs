using DbProducts.Data;
using DbProducts.Presentation;
using System;

namespace DbProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductContext db = new ProductContext();
            db.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
