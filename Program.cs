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
        public class MyList<T>
        {
            private T[] items;
            private int count;

            public MyList()
            {
                items = new T[4];
                count = 0;
            }

            // Add item to the list
            public void Add(T item)
            {
                if (count == items.Length)
                {
                    Array.Resize(ref items, items.Length * 2);
                }
                items[count++] = item;
            }

            // Exist method
            public bool Exist(Predicate<T> match)
            {
                return FindIndex(match) != -1;
            }

            // Find method
            public T Find(Predicate<T> match)
            {
                int index = FindIndex(match);
                return index != -1 ? items[index] : default(T);
            }

            // Find All method
            public MyList<T> FindAll(Predicate<T> match)
            {
                MyList<T> result = new MyList<T>();
                foreach (var item in items)
                {
                    if (match(item))
                    {
                        result.Add(item);
                    }
                }
                return result;
            }

            // Find index method
            public int FindIndex(Predicate<T> match)
            {
                for (int i = 0; i < count; i++)
                {
                    if (match(items[i]))
                    {
                        return i;
                    }
                }
                return -1;
            }

            // Find Last method
            public T FindLast(Predicate<T> match)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    if (match(items[i]))
                    {
                        return items[i];
                    }
                }
                return default(T);
            }

            // Find Last Index method
            public int FindLastIndex(Predicate<T> match)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    if (match(items[i]))
                    {
                        return i;
                    }
                }
                return -1;
            }

            // ForEach method
            public void ForEach(Action<T> action)
            {
                foreach (var item in items)
                {
                    if (item != null) // Only execute the action if the item is not null
                    {
                        action(item);
                    }
                }
            }

            // TrueForAll method
            public bool TrueForAll(Predicate<T> match)
            {
                foreach (var item in items)
                {
                    if (item != null && !match(item))
                    {
                        return false;
                    }
                }
                return true;
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
                #region Part02
                //MyList<int> myList = new MyList<int>();
                //myList.Add(1);
                //myList.Add(2);
                //myList.Add(3);
                //myList.Add(4);

                //// Example usage
                //Console.WriteLine("Exists (greater than 2): " + myList.Exist(x => x > 2));
                //Console.WriteLine("Find (greater than 2): " + myList.Find(x => x > 2));
                //Console.WriteLine("FindAll (even numbers): " + string.Join(", ", myList.FindAll(x => x % 2 == 0)));
                //Console.WriteLine("FindIndex (even number): " + myList.FindIndex(x => x % 2 == 0));
                //Console.WriteLine("FindLast (even number): " + myList.FindLast(x => x % 2 == 0));
                //Console.WriteLine("FindLastIndex (even number): " + myList.FindLastIndex(x => x % 2 == 0));

                //Console.WriteLine("ForEach (print items):");
                //myList.ForEach(x => Console.WriteLine(x));

                //Console.WriteLine("TrueForAll (greater than 0): " + myList.TrueForAll(x => x > 0)); 
                #endregion
            }
        }
    }
}

