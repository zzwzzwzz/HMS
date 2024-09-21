using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Patient
    {
        public static void PatientMenu(string name) 
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                 Patient Menu");
                Console.WriteLine("└-----------------------------------------------┘");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, {name}!");

                // Display the Patient Menu detail
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Exit to login");
                Console.WriteLine("6. Exit System");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Patient Details:");
                        // Logic for displaying patient details
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Doctor Details:");
                        // Logic for displaying doctor details
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("All Appointments:");
                        // Logic for listing appointments
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Book Appointment:");
                        // Logic for booking appointments
                        break;
                    case "5":
                        Console.Clear();
                        exit = true;
                        break;
                    case "6":
                        // Exit the program
                        Environment.Exit(0);  
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}

