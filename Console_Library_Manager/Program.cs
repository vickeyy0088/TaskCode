
using Console_Library_Manager;
using Console_Library_Manager.Models;
using Console_Library_Manager.Repository;

//Author auth = new Author("Vickey", "Indian");
//Console.WriteLine(auth.GetAuthorDetails());

//--------------------------------------------------------

//Book book = new Book("B0001", "Begin with You", 2, 3000, auth);
//book.DisplayInfo();

////-------------------------------------------------------

//Console.WriteLine("--- Testing Invalid Empty Title ---");
//try
//{
//    Book invalidBook1 = new Book("", 3, 20.00, auth);
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Caught Error: {ex.Message}\n");
//}

//Console.WriteLine("--- Negative Copy Count ---");
//try
//{
//    Book invalidBook1 = new Book("Slow Motion", -5, 54, auth);
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Caught Error: {ex.Message}");
//}

//------------------- Value Type, and Reference Type (Struct & Class)-------------------------------
// Struct (Value Type)
//Demo D1 = new Demo();
//D1.X = 1;
//Demo D2 = D1;
//D2.X= 2;
//Console.WriteLine(D1.X);
//Console.WriteLine(D2.X);

//// Class (Reference Type)
//Example ex1= new Example();
//ex1.name = "Vickey";
//Example ex2 = ex1;
//ex2.name = "Rahul";
//Console.WriteLine(ex1.name);
//Console.WriteLine(ex2.name);


//------------------- Console Library App v1  (3.1 to 3.5)-------------------------------------------------------

internal class Program
{
    private static List<Book> library = new List<Book>();

    private static void Main(string[] args)
    {
        SeedData();

        bool running = true;

        while (running)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("-------------- Console Library App v1 -------------------");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. Add a New Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option (1-5): ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    ListBooks();
                    break;

                case "2":
                    AddBooks();
                    break;

                case "3":
                    DeleteBook();
                    break;

                case "4":
                    UpdateBook();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nExiting program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option! Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void ListBooks()
    {
        Console.Clear();
        Console.WriteLine("------ Book Details ------------");

        if (library.Count == 0)
        {
            Console.WriteLine("No books found in the library.");
        }
        else
        {
            for (int i = 0; i < library.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                library[i].DisplayInfo();
            }
        }

        Pause();
    }

    private static void AddBooks()
    {
        Console.Clear();
        Console.WriteLine("--------- Add Book ------------");

        Console.WriteLine("Enter Isbn of Book");
        string Isbn = Console.ReadLine();

        Console.WriteLine("Enter Title of Book");
        string bookTitle = Console.ReadLine();

        int copyCount = ReadInt("Enter Copies Count:");
        double price = ReadDouble("Enter Book price");

        Console.WriteLine("Enter Author Name");
        string authorName = Console.ReadLine()?.Trim();

        Console.WriteLine("Enter Author Nationality");
        string authorNationality = Console.ReadLine()?.Trim();

        Author newAuth = new Author(authorName, authorNationality);

        Book newBook = new Book(
            Isbn,
            bookTitle,
            copyCount,
            price,
            newAuth
        );

        library.Add(newBook);

        Console.WriteLine("\nBook added successfully!");

        Pause();
    }

    private static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("--------- Delete Book ------------");

        Console.Write("Enter ISBN of book to delete: ");
        string isbn = Console.ReadLine()?.Trim();

        Book book = library.FirstOrDefault(b => b.Isbn == isbn);

        if (book == null)
        {
            Console.WriteLine("\nBook not found!");
        }
        else
        {
            library.Remove(book);
            Console.WriteLine("\nBook deleted successfully!");
        }

        Pause();
    }

    private static void UpdateBook()
    {
        Console.Clear();
        Console.WriteLine("--------- Update Book ------------");

        Console.Write("Enter ISBN of book to update: ");
        string isbn = Console.ReadLine()?.Trim();

        Book book = library.FirstOrDefault(b => b.Isbn == isbn);

        if (book == null)
        {
            Console.WriteLine("\nBook not found!");
            Pause();
            return;
        }

        Console.WriteLine("\nEnter new book details:");

        Console.Write("Enter Title: ");
        book.Title = Console.ReadLine();

        book.CopiesCount = ReadInt("Enter Copies Count:");

        book.Price = ReadDouble("Enter Book Price:");

        Console.Write("Enter Author Name: ");
        string authorName = Console.ReadLine()?.Trim();

        Console.Write("Enter Author Nationality: ");
        string authorNationality = Console.ReadLine()?.Trim();

        book.Author = new Author(authorName, authorNationality);

        Console.WriteLine("\nBook updated successfully!");

        Pause();
    }

    private static void SeedData()
    {
        Author a1 = new Author("Robert C. Martin", "American");
        Author a2 = new Author("Jon Skeet", "British");

        library.Add(
            new Book("L001", "Clean Code", 5, 45.99, a1)
        );

        library.Add(
            new Book("L002", "C# in Depth", 3, 39.99, a2)
        );
    }

    private static int ReadInt(string s)
    {
        int num;

        Console.WriteLine(s);

        while (!int.TryParse(Console.ReadLine()?.Trim(), out num))
        {
            Console.WriteLine("Invalid number! Please try again.");
            Console.Write($"{s} \n");
        }

        return num;
    }

    private static double ReadDouble(string s)
    {
        double num;

        Console.WriteLine(s);

        while (!double.TryParse(Console.ReadLine()?.Trim(), out num))
        {
            Console.WriteLine("Invalid Price! Please try again.");
            Console.Write($"{s} \n");
        }

        return num;
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}

//---------------------------- Person, Member, Librarian (4.1) ------------------------------------------------------------------

//Member M1 = new Member(1, "Vickey", "vickey@gmail.com", 3);
//Librarian L1 = new Librarian(1, "Arun Jha", "arun@gmail.com", "L01", "Morning");

//M1.DisplayInfo();
//M1.BookBorrow();
//M1.BookBorrow();
//M1.BookBorrow();
//M1.DisplayInfo();

//L1.DisplayInfo();
//L1.ProcessReturn(M1);


//---------------------------- Book (with DI / without DI) (4.2) ------------------------------------------------------------------

// without DI(New implementation)-------------------------------------------
//IBookRepository bookRepo = new InMemoryBookRepository();

//Author author1 = new Author("Robert C. Martin", "robert@unclebob.com");
//Author author2 = new Author("Erich Gamma", "erich@designpatterns.com");

//Console.WriteLine("=== 1. ADDING BOOKS ===");

//Book book1 = new Book("L001", "Clean Code", 5, 45.99, author1);
//Book book2 = new Book("L002", "Design Patterns", 2, 55.50, author2);
//// Add
//bookRepo.Add(book1);
//bookRepo.Add(book2);
//Console.WriteLine("Books added successfully!\n");

//// getAll
//IEnumerable<Book> allBooks = bookRepo.GetAll();
//foreach (var b in allBooks)
//{
//    b.DisplayInfo();
//}

//// GetByIsbn
//string searchIsbn = "L001";

//Book foundBook = bookRepo.GetByIsbn(searchIsbn);

//// Update
//if (foundBook != null)
//{
//    foundBook.CopiesCount = 10; // Copies update kar di
//    foundBook.Price = 39.99;    // Price update kar diya
//    bookRepo.Update(foundBook);

//    Console.WriteLine("Updated details for Clean Code:");
//    Book updatedBook = bookRepo.GetByIsbn(searchIsbn);
//    updatedBook.DisplayInfo();
//}

//// Delete
//bool isDeleted = bookRepo.Delete("L001");
//Console.WriteLine($"deleted: {isDeleted}\n");

//Console.WriteLine("=== REMAINING BOOKS IN REPOSITORY ===");
//foreach (var b in bookRepo.GetAll())
//{
//    b.DisplayInfo();
//}

// with DI -------------------------------------------------------------------

//IBookRepository bookRepo = new InMemoryBookRepository();

//LibararyService ls = new LibararyService(bookRepo);

//Author author1 = new Author("Robert C. Martin", "robert@unclebob.com");
//Author author2 = new Author("Erich Gamma", "erich@designpatterns.com");

//ls.RegisterNewBook("L001", "Never Ending", 4, 34.2, author1);
//ls.RegisterNewBook("L002", "Better Ending", 5, 44.2, author2);
//ls.RegisterNewBook("L003", "Worst Ending", 6, 54.2, author1);

//ls.GetAllBooks();


//------------ SRP (4.4) ------------------------------------------------------------------
//Not follow SRP
//InvoiceManager.CalculateTotal(23, 4);
//InvoiceManager.SaveToDatabase(45);
//InvoiceManager.SendEmailNotification("vickey@gmail.com", 001);

//Console.WriteLine();

//// Follow SRP
//Total.CalculateTotal(23, 4);
//SaveDB.SaveToDatabase(45);
//SendEmail.SendEmailNotification("vickey@gmail.com", 001);


// ======================= Generics Collection ===========================================
//Dictionary<string, int> scores = new()
//{
//    ["Alice"] = 95,
//    ["Bob"] = 87,
//    ["Carol"] = 92
//};

//foreach (var (name, score) in scores)
//{
//    Console.WriteLine($"{name}: {score}");
//}

// List, Dictionary, Hashset (generic)
//GenericCollection.UseList();
//Console.WriteLine();
//GenericCollection.UseDictionary();
//Console.WriteLine();
//GenericCollection.UseHashSet();


// ------------------- Linq 10 questions ------------------------------------
//LinqQueries.Method();