using static Delegate.Program;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System;

namespace Delegate
{
    internal class Program
    {

        public class Book
        {
            public string ISBN { get; set; }
            public string Title { get; set; }
            public string[] Author { get; set; }
            public DateTime PublicationDate { get; set; }
            public decimal[] Price { get; set; }

            public Book(string iSBN, string title, string[] author, DateTime publicationDate, decimal[] price)
            {
                ISBN = iSBN;
                Title = title;
                Author = author;
                PublicationDate = publicationDate;
                Price = price;
            }



            public override string ToString()
            {
                return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Author)}, " +
                       $"Publication Date: {PublicationDate.ToShortDateString()}, Prices: {string.Join(", ", Price)}";

            }
        }

        public class BookFunction
        {
            // Using user-defined delegate
            public delegate string BookPropertyDelegate(Book b);

            public static string GetTitle(Book b)
            {
                return b.Title;
            }

            public static string GetAuthor(Book b)
            {
                return string.Join(", ", b.Author);
            }

            public static string GetPrice(Book b)
            {
                return string.Join(", ", b.Price);
            }
            static void Main(string[] args)
            {
                #region Part01
                //Book book = new Book("123-456-789", "Sample Book", new[] { "Author1", "Author2" }, DateTime.Now, new[] { 19.99m, 29.99m });

                //BookFunction.BookPropertyDelegate titleDelegate = BookFunction.GetTitle;
                //Console.WriteLine("Title using user-defined delegate: " + titleDelegate(book));

                //Func<Book, string> authorFunc = BookFunction.GetAuthor;
                //Console.WriteLine("Author using built-in delegate: " + authorFunc(book));

                //Func<Book, string> isbnFunc = delegate (Book b) { return b.ISBN; };
                //Console.WriteLine("ISBN using anonymous method: " + isbnFunc(book));

                //Func<Book, string> publicationDateFunc = b => b.PublicationDate.ToShortDateString();
                //Console.WriteLine("Publication Date using lambda expression: " + publicationDateFunc(book)); 
                #endregion
            }
        }
    }
}

