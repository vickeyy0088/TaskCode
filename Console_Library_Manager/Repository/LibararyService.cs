using Console_Library_Manager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Repository
{
    internal class LibararyService
    {
        private readonly IBookRepository repo;
        public LibararyService(IBookRepository Repo)
        {
            repo = Repo;
        }

        public void RegisterNewBook(string isbn, string title,int copiesCount, double price, Author author)
        {
            var Book = new Book(isbn, title, copiesCount, price, author);
            repo.Add(Book);
            Console.WriteLine($"{isbn} | {title} | {copiesCount} | {price} | {author?.FullName ?? "Unknown"}");
        }

        public void GetAllBooks()
        {
            Console.WriteLine();
            Console.WriteLine("==== All Books ====");
            try
            {
                foreach (var b in repo.GetAll())
                {
                    Console.WriteLine($"{b.Isbn} | {b.Title} | Copies: {b.CopiesCount} | Price: ${b.Price} | Author: {b.Author?.FullName ?? "Unknown"}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error");
             }
        }
    }
}
