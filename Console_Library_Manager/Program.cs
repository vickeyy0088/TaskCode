
using Console_Library_Manager;
using Console_Library_Manager.Models;

//Author auth = new Author("Vickey", "Indian");
//Console.WriteLine(auth.GetAuthorDetails());

//--------------------------------------------------------

//Book book = new Book("Begin with You", 2, 3000, auth);
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


//------------------- Console Library App v1 -------------------------------------------------------

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
            Console.WriteLine("3. Exit");
            Console.Write("\nSelect an option (1-3): ");

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
            for(int i=0; i<library.Count; i++)
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

        Console.WriteLine("Enter Title of Book");
        string bookTitle = Console.ReadLine();

        int copyCount = ReadInt("Enter Copies Count:");
        double price = ReadDouble("Enter Book price");

        Console.WriteLine("Enter Author Name");
        string authorName = Console.ReadLine()?.Trim();

        Console.WriteLine("Enter Author Nationality");
        string authorNationality = Console.ReadLine()?.Trim();

        Author newAuth = new Author(authorName, authorNationality);
        Book newBook = new Book(bookTitle, copyCount, price, newAuth);

        library.Add(newBook);
        Console.WriteLine("\nBook added successfully!");

        Pause();
    }

    private static void SeedData()
    {
        Author a1 = new Author("Robert C. Martin", "American");
        Author a2 = new Author("Jon Skeet", "British");

        library.Add(new Book("Clean Code", 5, 45.99, a1));
        library.Add(new Book("C# in Depth", 3, 39.99, a2));
    }

    private static int ReadInt(string s)
    {
        int num;
        Console.WriteLine(s);
        while(!int.TryParse(Console.ReadLine()?.Trim(), out num))
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
        while(!double.TryParse(Console.ReadLine()?.Trim(), out num))
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