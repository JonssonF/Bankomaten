using Bookshelf.Data;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CRUD OPERATIONS... CREATE/READ/UPDATE/DELETE.

            //---------------------------------------------CREATE---------------------------------------------
            //using (var context = new BookShelfContext())
            //{
            //    try
            //    {
            //        var author = new Author
            //        {
            //            FirstName = "Dave",
            //            LastName = "Pelzer",
            //        };

            //        var book = new Book
            //        {
            //            Title = "A boy called It",
            //            Genre = "Biography",
            //            Author = author,
            //        };

            //        context.Authors.Add(author);
            //        context.Books.Add(book);
            //        context.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Something went wrong.");
            //    }
            //}

            //---------------------------------------------READ---------------------------------------------
            using (var context = new BookShelfContext())
            {
                try
                {
                    //LAMDA EXPRESSION
                    var books = context.Books.Include(b => b.Author).ToList();

                    foreach (var book in books)
                    {
                        Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author.FirstName} {book.Author.LastName} \nGenre: {book.Genre}");
                        Console.WriteLine(new string('-', 50));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong.{ex.Message}");
                }
            }

            //---------------------------------------------CREATE MANY---------------------------------------------
            //using (var context = new BookShelfContext())
            //{
            //    try
            //    {
            //        var authors = new List<Author>
            //        {
            //            new Author { FirstName = "J.K.", LastName = "Rowling" },
            //            new Author { FirstName = "George", LastName = "Orwell" },
            //            new Author { FirstName = "J.R.R.", LastName = "Tolkien" },
            //            new Author { FirstName = "Agatha", LastName = "Christie" },
            //            new Author { FirstName = "Stephen", LastName = "King" },
            //            new Author { FirstName = "Jane", LastName = "Austen" },
            //            new Author { FirstName = "Mark", LastName = "Twain" },
            //            new Author { FirstName = "Charles", LastName = "Dickens" },
            //            new Author { FirstName = "Ernest", LastName = "Hemingway" },
            //            new Author { FirstName = "F. Scott", LastName = "Fitzgerald" }
            //        };

            //        context.Authors.AddRange(authors);
            //        context.SaveChanges();

            //        var books = new List<Book>
            //        {
            //            new Book { Title = "Harry Potter and the Chamber of Secrets", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "Harry Potter and the Prisoner of Azkaban", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "Harry Potter and the Goblet of Fire", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "Harry Potter and the Order of the Phoenix", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "Harry Potter and the Half-Blood Prince", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "Harry Potter and the Deathly Hallows", Genre = "Fantasy", AuthorId = authors[0].AuthorId },
            //            new Book { Title = "1984", Genre = "Dystopian", AuthorId = authors[1].AuthorId },
            //            new Book { Title = "Animal Farm", Genre = "Political Satire", AuthorId = authors[1].AuthorId },
            //            new Book { Title = "The Hobbit", Genre = "Fantasy", AuthorId = authors[2].AuthorId },
            //            new Book { Title = "The Lord of the Rings", Genre = "Fantasy", AuthorId = authors[2].AuthorId },
            //            new Book { Title = "Murder on the Orient Express", Genre = "Mystery", AuthorId = authors[3].AuthorId },
            //            new Book { Title = "The Shining", Genre = "Horror", AuthorId = authors[4].AuthorId },
            //            new Book { Title = "Pride and Prejudice", Genre = "Romance", AuthorId = authors[5].AuthorId },
            //            new Book { Title = "Adventures of Huckleberry Finn", Genre = "Adventure", AuthorId = authors[6].AuthorId },
            //            new Book { Title = "A Tale of Two Cities", Genre = "Historical Fiction", AuthorId = authors[7].AuthorId },
            //            new Book { Title = "The Old Man and the Sea", Genre = "Literary Fiction", AuthorId = authors[8].AuthorId },
            //            new Book { Title = "The Great Gatsby", Genre = "Literary Fiction", AuthorId = authors[9].AuthorId }
            //        };

            //        context.Books.AddRange(books);
            //        context.SaveChanges();


            //        Console.WriteLine($"Lists of Authors and Books added to database.\nAuthors: {context.Authors.Count()} \nBooks:{context.Books.Count()}");

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Something went wrong.{ex.Message}");
            //    }
            //}


            //---------------------------------------------DELETE---------------------------------------------
            //using (var context = new BookShelfContext())
            //{
            //    try
            //    {
            //        var book = context.Books.FirstOrDefault(b => b.BookId == 1);


            //        if (book != null)
            //        {
            //            context.Books.Remove(book);
            //            context.SaveChanges();
            //            Console.WriteLine($"The book '{book.Title}' was removed from the database.");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Book was not found.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"An error occured: {ex.Message}");
            //    }
            //}


            //---------------------------------------------DELETE DUPLICATE---------------------------------------------


            //using (var context = new BookShelfContext())
            //{
            //    // Hämta alla författare grupperade efter namn
            //    var duplicateAuthors = context.Books
            //    .AsEnumerable()
            //    .GroupBy(a => new { a.Title})
            //    .SelectMany(g => g.Skip(1)) // Behåller endast en och markerar resten som dubbletter
            //    .ToList();

            //    // Ta bort dubbletter
            //    if (duplicateAuthors.Count != 0)
            //    {
            //        context.Books.RemoveRange(duplicateAuthors);
            //        context.SaveChanges();
            //        Console.WriteLine($"Raderade {duplicateAuthors.Count} dubbletter.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Inga dubbletter hittades.");
            //    }
            //}
        }
    }
}
