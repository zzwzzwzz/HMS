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
        public static void DoctorMenu(Doctor currentDoctor)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
            
                // Call the display menu header function from Utils.cs
                Utils.DisplayMenuHeader("Doctor Menu");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, Dr. {currentDoctor.FirstName} {currentDoctor.LastName}!");

                // Display the Doctor Menu details
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List doctor details");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. List appointments");
                Console.WriteLine("4. Check particular patient");
                Console.WriteLine("5. List appointments with patient");
                Console.WriteLine("6. Logout");
                Console.WriteLine("7. Exit\n");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DoctorListDetail(currentDoctor);
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
            }
        }

        public static void DoctorListDetail(Doctor currentDoctor)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("My Details");

            // Display the doctor details in the required format
            Console.WriteLine("\nDoctor Details:\n");
            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Name", "Email Address", "Phone", "Address");
            Console.WriteLine(new string('-', 110)); // Divider line
            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                currentDoctor.FirstName + " " + currentDoctor.LastName,
                currentDoctor.Email,
                currentDoctor.Phone,
                currentDoctor.StreetNumber + " " + currentDoctor.Street + ", " + currentDoctor.City + ", " + currentDoctor.State);

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

    }
}

