using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Person(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name = {Name}, Id = {Id}, Email = {Email}");
        }

        public abstract string Role();
    }
}
