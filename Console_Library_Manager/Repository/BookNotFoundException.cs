namespace Console_Library_Manager.Repository;

internal class BookNotFoundException : Exception
{
    public BookNotFoundException(string mssg) : base(mssg)
    {

    }
}
