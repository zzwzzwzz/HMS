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
                        AddDoctor();
                        break;
                    case "6":
                        AddPatient();
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

        // Method to add a new doctor
        public static void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");

            string firstName = Utils.GetNonNullInput("First Name: ");
            string lastName = Utils.GetNonNullInput("Last Name: ");
            string email = Utils.GetValidEmailInput("Email: ");  // Call GetValidEmailInput
            string phone = Utils.GetValidPhoneInput("Phone: ");  // Call GetValidPhoneInput
            string streetNumber = Utils.GetNonNullInput("Street Number: ");
            string street = Utils.GetNonNullInput("Street: ");
            string city = Utils.GetNonNullInput("City: ");
            string state = Utils.GetNonNullInput("State: ");

            // Write to the DoctorsDetail.txt file
            string doctorDetails = $"{firstName},{lastName},{email},{phone},{streetNumber},{street},{city},{state}";
            File.AppendAllText("DoctorsDetail.txt", doctorDetails + Environment.NewLine);

            Console.WriteLine($"\nDr {firstName} {lastName} added to the system!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        // Method to add a new patient
        public static void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System");

            string firstName = Utils.GetNonNullInput("First Name: ");
            string lastName = Utils.GetNonNullInput("Last Name: ");
            string email = Utils.GetValidEmailInput("Email: ");  // Call GetValidEmailInput
            string phone = Utils.GetValidPhoneInput("Phone: ");  // Call GetValidPhoneInput
            string streetNumber = Utils.GetNonNullInput("Street Number: ");
            string street = Utils.GetNonNullInput("Street: ");
            string city = Utils.GetNonNullInput("City: ");
            string state = Utils.GetNonNullInput("State: ");

            // Write to the PatientsDetail.txt file
            string patientDetails = $"{firstName},{lastName},{email},{phone},{streetNumber},{street},{city},{state}";
            File.AppendAllText("PatientsDetail.txt", patientDetails + Environment.NewLine);

            Console.WriteLine($"\n{firstName} {lastName} added to the system!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}