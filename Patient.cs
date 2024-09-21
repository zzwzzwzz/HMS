using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Patient : Users
    {
        public int PatientID { get; set; }

        public Patient(int patientID, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state)
            : base(firstName, lastName, email, phone, streetNumber, street, city, state)
        {
            PatientID = patientID;
        }

        public override string ToString()
        {
            return $"Patient ID: {PatientID}, {base.ToString()}";
        }

        // Display patient menu
        public static void PatientMenu(string name) 
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                // Call the display menu header function from Utils.cs
                Utils.DisplayMenuHeader("Patient Menu");

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
                        // MyPatientDetail();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Doctor Details:");
                        // PatientDoctorDetail();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("All Appointments:");
                        // PatientListAppointments();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Book Appointment:");
                        // PatientBookAppointment();
                        break;
                    case "5":
                        Console.Clear();
                        exit = true;
                        return;
                    case "6":
                        // Exit the program
                        Environment.Exit(0);  
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}

