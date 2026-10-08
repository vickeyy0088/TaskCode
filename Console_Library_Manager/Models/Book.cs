using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    internal class Book
    {
        public static int TotalBooksCreated { get; private set; }
        private string? _title = string.Empty;
        private int _copiesCount;
        private string _isbn = string.Empty;


        public string Isbn
        {
            get => _isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN cannot be empty or blank.");
                }
                _isbn = value;
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty or blank.");
                }
                _title = value;
            }
        }

        public int CopiesCount
        {
            get { return _copiesCount; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Value must greater then 0.");
                }
                _copiesCount = value;
            }
        }

        public bool IsAvailable => CopiesCount > 0;
        public double Price { get; set; }
        public Author Author { get; set; }

        public Book(string isbn, string title, int copiescount, double price, Author author)
        {
            Isbn = isbn;
            Title = title;
            CopiesCount = copiescount;
            Price = price;
            Author = author;

            TotalBooksCreated++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {Isbn} | Title: {Title}");
            Console.WriteLine($"Copies Available: {CopiesCount} | Status: {(IsAvailable ? "In Stock" : "Out of Stock")}");
            Console.WriteLine($"Price: ${Price:F2}");

            // Uses Safe Navigation (?.) and Null-Coalescing (??)
            Console.WriteLine($"Author: {Author?.GetAuthorDetails() ?? "Unknown / Not Specified"}\n");
        }

    }
}
