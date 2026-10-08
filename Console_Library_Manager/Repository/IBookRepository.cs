using Console_Library_Manager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Repository
{
    internal interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetByIsbn(string isbn);
        void Add(Book book);
        void Update(Book book);
        bool Delete(string isbn);
    }
}
