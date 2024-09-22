using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public static class Receptionist
    {
        // Receptionist Menu
        public static void ReceptionistMenu(string name)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                // Call the display menu header function from Utils.cs
                Utils.DisplayMenuHeader("Receptionist Menu");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, Receptionist - {name}!");

                // Display the Receptionist Menu details
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List all appointments");
                Console.WriteLine("2. Delete appointment by ID");
                Console.WriteLine("3. Logout");
                Console.WriteLine("4. Exit\n");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ListAllAppointments();
                        break;
                    case "2":
                        Console.Clear();
                        DeleteAppointmentByID();
                        break;
                    case "3":
                        // Logout and return to the login screen
                        return;
                    case "4":
                        Environment.Exit(0);  // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Case 1: List all appointments
        public static void ListAllAppointments()
        {
            Console.Clear();
            Utils.DisplayMenuHeader("All Appointments");

            string appointmentFilePath = @"Appointments.txt";
            if (!File.Exists(appointmentFilePath))
            {
                Console.WriteLine("\nNo appointments found.");
                Console.ReadKey();
                return;
            }

            string[] appointmentLines = File.ReadAllLines(appointmentFilePath);
            Console.WriteLine("\n{0,-15} | {1,-20} | {2,-20} | {3,-30}", "Appointment ID", "Doctor Name", "Patient Name", "Description");
            Console.WriteLine(new string('-', 85));

            foreach (var line in appointmentLines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    // Get patient and doctor details
                    string patientId = parts[1];
                    string doctorId = parts[2];

                    Patient? patient = Utils.GetPatientDetailsById(patientId);
                    Doctor? doctor = Utils.GetDoctorDetailsById(doctorId);

                    if (patient != null && doctor != null)
                    {
                        Console.WriteLine("{0,-15} | {1,-20} | {2,-20} | {3,-30}", parts[0], doctor.FirstName + " " + doctor.LastName, patient.FirstName + " " + patient.LastName, parts[3]);
                    }
                }
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Case 2: Delete appointment by ID
        public static void DeleteAppointmentByID()
        {
            Console.Clear();
            Utils.DisplayMenuHeader("Delete Appointment");

            // Prompt for Appointment ID
            Console.Write("\nEnter the Appointment ID to delete: ");
            string? input = Console.ReadLine();

            // Validate input
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int appointmentID))
            {
                Console.WriteLine("Invalid Appointment ID. Press any key to return to the menu...");
                Console.ReadKey();
                return;
            }

            string appointmentFilePath = @"Appointments.txt";
            if (!File.Exists(appointmentFilePath))
            {
                Console.WriteLine("\nNo appointments found.");
                Console.ReadKey();
                return;
            }

            // Read the appointments file
            List<string> appointmentLines = new(File.ReadAllLines(appointmentFilePath));

            // Try to find and remove the appointment
            bool appointmentFound = false;
            for (int i = 0; i < appointmentLines.Count; i++)
            {
                var parts = appointmentLines[i].Split(',');
                if (parts.Length == 4 && int.Parse(parts[0]) == appointmentID)
                {
                    appointmentLines.RemoveAt(i); // Remove the matching line
                    appointmentFound = true;
                    break;
                }
            }

            // If appointment found, update the file
            if (appointmentFound)
            {
                File.WriteAllLines(appointmentFilePath, appointmentLines);
                Console.WriteLine("\nAppointment ID {0} has been deleted successfully.", appointmentID);
            }
            else
            {
                Console.WriteLine("\nAppointment ID {0} not found.", appointmentID);
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}

