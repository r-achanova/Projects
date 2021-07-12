using BookShopSchool.Data;
using BookShopSchool.Presentation;
using System;

namespace BookShopSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BookShopSchoolContext();
           // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
