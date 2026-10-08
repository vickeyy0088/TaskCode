using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Library_Manager.Models
{

    // SRP Breaks
    public class InvoiceManager
    {
        public static double CalculateTotal(double price, double tax)
        {
            return price + (price * tax);
        }

        public static void SaveToDatabase<T>(T value)
        {
            Console.WriteLine($"Saving invoice {value} to database...");
        }

        public static void SendEmailNotification(string email, int id)
        {
            Console.WriteLine($"Sending invoice {id} email to {email}...");
        }
    }

    // SRP Implement

    public class Total
    {
        public static double CalculateTotal(double price, double tax)
        {
            return price + (price * tax);
        }
    }

    public class SaveDB
    {
        public static void SaveToDatabase<T>(T value)
        {
            Console.WriteLine($"Saving invoice {value} to database...");
        }
    }

    public class SendEmail
    {
        public static void SendEmailNotification(string email, int id)
        {
            Console.WriteLine($"Sending invoice {id} email to {email}...");
        }
    }
}
