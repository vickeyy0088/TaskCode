using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager
{
    internal class GenericCollection
    {
        public static void UseList()
        {
            List<int> list = new List<int>();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach (int i in list)
            {
                Console.WriteLine($"{i}");
            }
        }

        public static void UseDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "Vickey";
            dict[2] = "Puneet";
            dict[3] = "Ravi";
            dict[4] = "Aakash";

            foreach(var (key, value) in dict)
            {
                Console.WriteLine($"{key} : {value}");
            }
        }

        public static void UseHashSet()
        {
            HashSet<string> cities = new HashSet<string>();

            cities.Add("Delhi");
            cities.Add("Mumbai");
            cities.Add("Delhi"); // Duplicate will not be added

            foreach (string city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
