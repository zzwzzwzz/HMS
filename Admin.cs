using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Admin
    {
        public static void AdminMenu(string name)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                 Administrator Menu");
                Console.WriteLine("└-----------------------------------------------┘");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, Admin - {name}!");

                // Display the Admin Menu details
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List all doctors");
                Console.WriteLine("2. Check doctor details");
                Console.WriteLine("3. List all patients");
                Console.WriteLine("4. Check patient details");
                Console.WriteLine("5. Add doctor");
                Console.WriteLine("6. Add patient");
                Console.WriteLine("7. Logout");
                Console.WriteLine("8. Exit");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("List All Doctors:");
                        // Logic to list all doctors
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Check Doctor Details:");
                        // Logic to check doctor details
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("List All Patients:");
                        // Logic to list all patients
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Check Patient Details:");
                        // Logic to check patient details
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Add Doctor:");
                        // Logic to add a new doctor
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Add Patient:");
                        // Logic to add a new patient
                        break;
                    case "7":
                        exit = true; // Logout and return to the login screen
                        break;
                    case "8":
                        Environment.Exit(0);  // Exit the program
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
