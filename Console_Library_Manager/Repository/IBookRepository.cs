using Console_Library_Manager.Models;

namespace Console_Library_Manager.Repository;

internal interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book GetByIsbn(string isbn);
    void Add(Book book);
    void Update(Book book);
    bool Delete(string isbn);
}
