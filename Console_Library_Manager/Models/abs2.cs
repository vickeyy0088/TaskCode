using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    public class abs2
    {
        public static void NameVoid<T1,T2>(T1 id, T2 name)
        {
            Console.WriteLine($"{id} and {name}");
        }

        public static T Call<T>(T num)
        {
            return num; 
        }
    }
   
}
