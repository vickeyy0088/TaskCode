using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    public class Member : Person
    {
        public int MaxBookAllowed { get; set; }
        public int BorrowCount { get; set; }
        public Member(int id, string name, string email, int maxBookAllowed) : base(id, name, email)
        {
            MaxBookAllowed = maxBookAllowed;
            BorrowCount = 1;
        }

        public override string Role() => "Library Member";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Role: {Role()} | Borrowed: {BorrowCount}/{MaxBookAllowed}\n");
        }

        public void BookBorrow()
        {
            if (BorrowCount >= MaxBookAllowed)
            {
                Console.WriteLine("You can't borrow any more books\n");
            }
            else
            {
                BorrowCount++;
                Console.WriteLine("You successfully borrowed new book\n");
            }
        }
    }
}
