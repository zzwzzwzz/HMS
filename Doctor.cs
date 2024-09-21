using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Doctor
    {
        public static void DoctorMenu(string name)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                 Doctor Menu");
                Console.WriteLine("└-----------------------------------------------┘");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, Dr. {name}!");

                // Display the Doctor Menu details
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Doctor Details:");
                        // Logic for displaying doctor details
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List Patients:");
                        // Logic for listing patients
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("List Appointments:");
                        // Logic for listing appointments
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Check Particular Patient:");
                        // Logic for checking particular patient
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("List Appointments with Patient:");
                        // Logic for listing appointments with a specific patient
                        break;
                    case "6":
                        Console.Clear();
                        // Return to login
                        exit = true; 
                        break;
                    case "7":
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

