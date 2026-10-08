using Console_Library_Manager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Repository
{
    internal class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();
        public void Add(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            _books.Add(book);
        }

        public bool Delete(string isbn)
        {
            var book = _books.FirstOrDefault(b => b.Isbn == isbn);

            if (book == null)
                return false;

            _books.Remove(book);
            return true;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.ToList();
        }

        public Book GetByIsbn(string isbn)
        {
            return _books.FirstOrDefault(b => b.Isbn.Equals(isbn));
        }

        public void Update(Book book)
        {
            var _existing = GetByIsbn(book.Isbn);
            if(_existing != null)
            {
                _existing.Title = book.Title;
                _existing.Author = book.Author;
                _existing.Price = book.Price;
                _existing.CopiesCount = book.CopiesCount;
            }
        }
    }
}
