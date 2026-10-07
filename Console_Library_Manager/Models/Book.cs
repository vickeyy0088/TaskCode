using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    internal class Book
    {
        public static int TotalBooksCreated { get; private set; }
        private string _title = string.Empty;
        private int _copiesCount;

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

        public double Price { get; set; }
        public Author Author { get; set; }

        public Book(string title, int copiescount, double price, Author author)
        {
            Title = title;
            CopiesCount = copiescount;
            Price = price;
            Author = author;

            TotalBooksCreated++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Copies: {CopiesCount} | Price: ${Price}");
            Console.WriteLine($"Author: {Author.GetAuthorDetails()}\n");
        }
    }
}
