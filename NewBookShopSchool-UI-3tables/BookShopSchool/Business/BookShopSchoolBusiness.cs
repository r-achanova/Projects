using BookShopSchool.Data;
using BookShopSchool.Data.Models;

using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShopSchool.Business
{
    public class BookShopSchoolBusiness
    {
        private BookShopSchoolContext bookShopSchoolContext;

        //връща списък с всички книги и автори
        public string GetAllBooksAndAuthors()
        {
            using (bookShopSchoolContext=new BookShopSchoolContext())
            {
                var books = bookShopSchoolContext.Books
                    .Select(b => new
                    {
                        b.Id,
                        b.Name,
                        year=b.PublishedOn.Year,
                        authors = b.AuthorsBooks.Select(ab => new
                        {
                            AuthorFirstName = ab.Author.FirstName,
                            AuthorLastName = ab.Author.LastName
                        }).ToList()
                    }).ToList();
                var sb = new StringBuilder();
                foreach (var book in books)
                {
                    sb.AppendLine($"{book.Id} {book.Name} {book.year}");
                    foreach (var author in book.authors)
                    {
                        sb.AppendLine($"-- {author.AuthorFirstName}  {author.AuthorLastName}");
                    }
                }
                
                return sb.ToString().TrimEnd();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (bookShopSchoolContext = new BookShopSchoolContext())
            {
                return bookShopSchoolContext.Books.ToList();

            }
        }
        public Book GetBook(int id)
        {
            using (bookShopSchoolContext=new BookShopSchoolContext())
            {
                return bookShopSchoolContext.Books.Find(id);
                   
            }
        }

        //добавя книга
        public void AddBook(Book book)
        {
            using (bookShopSchoolContext = new BookShopSchoolContext())
            {
                bookShopSchoolContext.Books.Add(book);
                bookShopSchoolContext.SaveChanges();
               
            }
        }

        //търси автора по име и фамилия, ако го няма - добавя го 
        public void AddAuthor(Author author)
        {
            using (bookShopSchoolContext = new BookShopSchoolContext())
            {
                var item = bookShopSchoolContext.Authors.FirstOrDefault(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
                if (item==null)
                {
                bookShopSchoolContext.Authors.Add(author);
                bookShopSchoolContext.SaveChanges();
                }
             }
        }

        

             //добавя книга и нейните автори
             //проверява и ако авторът го има, не го добавя в авторите, а само че е автор на книгата
             internal void AddBookAndAuthors(Book book, List<Author> authors)
             {
                 using (bookShopSchoolContext = new BookShopSchoolContext())
                 {

                     bookShopSchoolContext.Books.Add(book);
                     bookShopSchoolContext.SaveChanges();
                     AuthorBook authorBook = new AuthorBook();
                     foreach (var author in authors)
                     {
                         var itemAuthor = bookShopSchoolContext.Authors.FirstOrDefault(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
                         if (itemAuthor == null)
                         {
                             bookShopSchoolContext.Authors.Add(author);
                             bookShopSchoolContext.SaveChanges();
                        itemAuthor = bookShopSchoolContext.Authors.OrderBy(a => a.Id).Last();


                    }
                         authorBook.AuthorId = itemAuthor.Id;
                         authorBook.BookId = book.Id;

                         bookShopSchoolContext.AuthorsBooks.Add(authorBook);
                         bookShopSchoolContext.SaveChanges();
                     }

                 }
             }

             
        public void UpdateBook(Book book)
        {
            using (bookShopSchoolContext = new BookShopSchoolContext())
            {
                var item = bookShopSchoolContext.Books.Find(book);
                if (item != null)
                {
                    bookShopSchoolContext.Entry(item).CurrentValues.SetValues(book);
                    bookShopSchoolContext.SaveChanges();
                }
            }
        }

        
        public void DeleteBook(int id)
        {
            var item = bookShopSchoolContext.Books.Find(id);
            if (item != null)
            {
                bookShopSchoolContext.Books.Remove(item);
                bookShopSchoolContext.SaveChanges();
            }
        }
    }
}
