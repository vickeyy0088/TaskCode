using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Console_Library_Manager.Models
{
    internal class Author
    {
        [Required]
        public string FullName { get; set; }
        public string Nationality { get; set; }

        public Author(string fullName, string nationality)
        {
            FullName = fullName;
            Nationality = nationality;
        }

        public string GetAuthorDetails()
        {
            return $"{FullName} ({Nationality})\n";
        }
    }

}
