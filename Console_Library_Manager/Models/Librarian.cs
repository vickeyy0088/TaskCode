using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{
    public class Librarian : Person
    {
        public string EmployeeId { get; set; }
        public string Shift { get; set; }
        public Librarian(int id, string name, string email, string employeeid, string shift) : base(id, name, email)
        {
            EmployeeId = employeeid;
            Shift = shift;
        }

        public override string Role() => "Librarian";

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Role: {Role()} | EmployeeId: {EmployeeId} | Shift: {Shift}\n");
        }

        public void ProcessReturn(Member member)
        {
            Console.WriteLine($"Librarian {Name} processed a return for member {member.Name}.\n");
        }
    }
}
