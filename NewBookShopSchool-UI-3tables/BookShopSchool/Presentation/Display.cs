using BookShopSchool.Business;
using BookShopSchool.Data.Models;
using System;
using System.Collections.Generic;


namespace BookShopSchool.Presentation
{
  public  class Display
    {
        private int closeOperationId = 6;
        private BookShopSchoolBusiness bookShopSchoolBusiness = new BookShopSchoolBusiness();
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add new book");
            Console.WriteLine("3. Update book");
            Console.WriteLine("4. Fetch book by ID");
            Console.WriteLine("5. Delete book by ID");
            Console.WriteLine("6. Exit");
          
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAllBooksAndAuthors(); break;
                    case 2: AddBookWithAuthors(); break;
                    case 3: UpdateBook(); break;
                    case 4: FetchBook(); break;
                    case 5: DeleteBook(); break;
                    
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void DeleteBook()
        {
            throw new NotImplementedException();
        }

        private void FetchBook()
        {
            throw new NotImplementedException();
        }

        private void UpdateBook()
        {
            throw new NotImplementedException();
        }

        private void AddBookWithAuthors()
        {
            Book book = new Book();
            Console.WriteLine("Enter Title: ");
            book.Name = Console.ReadLine();
            Console.WriteLine("Enter Genre /1-Biography  2-Business 3-Science/: ");
            book.Genre = (Data.Models.Enum.Genre)int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Price: ");
            book.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Pages: ");
            book.Pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PublishedOn in format MM/DD/YYYY: ");
            book.PublishedOn = DateTime.Parse( Console.ReadLine());
            
            var authors = new List<Author>(); 
            
            string ans = "Y";
            while (ans == "y" || ans == "Y")
            {
                Author author = new Author();
                Console.WriteLine("Enter author's First Name: ");
                author.FirstName = Console.ReadLine();
                Console.WriteLine("Enter author's Last Name: ");
                author.LastName = Console.ReadLine();
                authors.Add(author);
                Console.WriteLine("Another author (y/n):");
                ans = Console.ReadLine();
            }
            foreach (var item in authors)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
           bookShopSchoolBusiness.AddBookAndAuthors(book, authors);


        }

        private void ListAllBooks()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 17) + "Books" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            var books = bookShopSchoolBusiness.GetAllBooks();
            foreach (var item in books)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", 
                    item.Id, item.Name, item.Genre, item.Price, item.Pages, item.PublishedOn.Year);
            }
        }

        private void ListAllBooksAndAuthors()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 17) + "Books" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            var books = bookShopSchoolBusiness.GetAllBooksAndAuthors();
            Console.WriteLine(books);
        }
    }
}
