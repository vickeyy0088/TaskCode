namespace Console_Library_Manager.Models
{
    public class HttpClient_Async_Task
    {
        public static async Task Getdata()
        {
            var client = new HttpClient();
            string[] urls = new string[]
            {
                "https://jsonplaceholder.typicode.com/posts/1",
                "https://jsonplaceholder.typicode.com/posts/2",
                "https://jsonplaceholder.typicode.com/posts/3"
            };

            Task<string>[] tasks = new Task<string>[urls.Length];
            for (int i = 0; i < urls.Length; i++)
            {
                tasks[i] = client.GetStringAsync(urls[i]);
            }
            var result = Task.WhenAll(tasks);
            Console.WriteLine("All tasks completed.", result);
        }
    }
}
