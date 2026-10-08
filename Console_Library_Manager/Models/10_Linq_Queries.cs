using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{

    class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
    public class LinqQueries
    {
       public static void Method()
        {
            List<Books> books = new List<Books>
            {
            new Books { Id = 1, Title = "C# Basics", Author = "John", Category = "Programming", Price = 500 },
            new Books { Id = 2, Title = "ASP.NET Core", Author = "David", Category = "Programming", Price = 700 },
            new Books { Id = 3, Title = "Clean Code", Author = "Robert", Category = "Programming", Price = 800 },
            new Books { Id = 4, Title = "The Alchemist", Author = "Paulo", Category = "Fiction", Price = 400 },
            new Books { Id = 5, Title = "Harry Potter", Author = "J.K. Rowling", Category = "Fiction", Price = 600 },
            new Books { Id = 6, Title = "Atomic Habits", Author = "James Clear", Category = "Self Help", Price = 550 }
            };

            // 1
            var greaterthan500 = books.Where(x => x.Price > 500).ToList();
            foreach(var book in greaterthan500)
            {
                Console.Write($"{book.Category} ");
            }

            Console.WriteLine();

            // 2
            var getOnlyTitle = books.Select(x=>x.Title).ToList();
            foreach (var book in getOnlyTitle)
            {
                Console.Write($"{book} ");
            }

            // 3. OrderBy()
            var query3 = books
                .OrderBy(b => b.Price);

            foreach (var book in query3)
            {
                Console.WriteLine(book.Title + " - " + book.Price);
            }

            // 4. OrderByDescending()
            var query4 = books
                .OrderByDescending(b => b.Price);

            foreach (var book in query4)
            {
                Console.WriteLine(book.Title + " - " + book.Price);
            }

            // 5. GroupBy()
            var query5 = books
                .GroupBy(b => b.Category);

            foreach (var group in query5)
            {
                Console.WriteLine("Category: " + group.Key);

                foreach (var book in group)
                {
                    Console.WriteLine("  " + book.Title);
                }
            }

            // 6. FirstOrDefault()
            var query6 = books
                .FirstOrDefault(b => b.Price > 750);

            if (query6 != null)
            {
                Console.WriteLine(query6.Title);
            }

            // 7. Any()
            bool query7 = books
                .Any(b => b.Category == "Programming");

            Console.WriteLine(query7);

            // 8. Count()
            int query8 = books
                .Count(b => b.Price > 500);

            Console.WriteLine(query8);

            // 9. Sum()
            double query9 = books
                .Sum(b => b.Price);

            Console.WriteLine(query9);

            // 10. Where + OrderBy + Select
            var query10 = books
                .Where(b => b.Category == "Programming")
                .OrderBy(b => b.Price)
                .Select(b => b.Title);

            foreach (var title in query10)
            {
                Console.WriteLine(title);
            }
        }
    }
}
