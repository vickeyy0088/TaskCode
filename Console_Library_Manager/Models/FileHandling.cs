namespace Console_Library_Manager.Models
{
    public class FileHandling
    {
        public static void FileHandler()
        {
            string rootPath = @"C:\Users\HP";
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
        }
    }
}
