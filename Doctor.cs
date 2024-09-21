using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Doctor : Users
    {
        public int DoctorID { get; set; }

        public Doctor(int doctorID, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state)
            : base(firstName, lastName, email, phone, streetNumber, street, city, state)
        {
            DoctorID = doctorID;
        }

        public override string ToString()
        {
            return $"Doctor ID: {DoctorID}, {base.ToString()}";
        }

        // Doctor Menu display
        public static void DoctorMenu(string name)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
            
                // Call the display menu header function from Utils.cs
                Utils.DisplayMenuHeader("Doctor Menu");

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
                        // DoctorListDetail();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("List Patients:");
                        // DoctorListPatients();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("List Appointments:");
                        // DoctorListAllAppointments();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Check Particular Patient:");
                        // DoctorCheckPatient();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("List Appointments with Patient:");
                        // DoctorListPatientAppointments();
                        break;
                    case "6":
                        Console.Clear();
                        // Return to login
                        exit = true; 
                        return;
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

