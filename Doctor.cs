using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Doctor(int doctorID, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state) : Users(firstName, lastName, email, phone, streetNumber, street, city, state)
    {
        public int DoctorID { get; set; } = doctorID;

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
                        DoctorListDetail(currentDoctor);  // Lists the current doctor's details
                        break;
                    case "2":
                        Console.Clear();
                        DoctorListPatients(currentDoctor);  // Lists all patients assigned to the doctor
                        break;
                    case "3":
                        Console.Clear();
                        DoctorListAllAppointments(currentDoctor);  // Lists all appointments involving the doctor
                        break;
                    case "4":
                        Console.Clear();
                        DoctorCheckPatient(currentDoctor);  // Checks a specific patient by ID
                        break;
                    case "5":
                        Console.Clear();
                        DoctorListAppointmentsWithPatient(currentDoctor);  // Lists appointments with a specific patient
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

        // Case 1 function to list current login doctor detail
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

        // Case 2 function: Doctor lists all the patients assigned to them using Appointments.txt
        public static void DoctorListPatients(Doctor currentDoctor)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("My Patients");

            Console.WriteLine($"Patients assigned to Dr. {currentDoctor.FirstName} {currentDoctor.LastName}:\n");

            // Set headers with fixed-width formatting
            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Patient", "Email Address", "Phone", "Address");
            Console.WriteLine(new string('-', 110)); // Divider line

            // First, retrieve all patients linked to this doctor from Appointments.txt
            string appointmentFilePath = @"Appointments.txt";
            HashSet<string> patientIds = [];

            if (File.Exists(appointmentFilePath))
            {
                string[] appointmentLines = File.ReadAllLines(appointmentFilePath);
                foreach (var line in appointmentLines)
                {
                    var parts = line.Split(',');

                    // If the appointment contains the current doctor's ID, capture the patient's ID
                    if (parts.Length == 4 && parts[2] == currentDoctor.DoctorID.ToString())
                    {
                        patientIds.Add(parts[1]);  // Add PatientID to the HashSet
                    }
                }
            }

            // Now, use the captured PatientIDs to retrieve and display details from PatientsDetail.txt
            string patientFilePath = @"PatientsDetail.txt";
            if (File.Exists(patientFilePath))
            {
                string[] patientLines = File.ReadAllLines(patientFilePath);
                bool patientFound = false;

                foreach (var line in patientLines)
                {
                    var parts = line.Split(',');

                    if (parts.Length == 9 && patientIds.Contains(parts[0]))  // Check if the patient is in the captured list
                    {
                        // Print the patient details
                        Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                            parts[1] + " " + parts[2],  // Patient's Name
                            parts[3],  // Email
                            parts[4],  // Phone
                            parts[5] + " " + parts[6] + ", " + parts[7] + ", " + parts[8]);  // Address
                        patientFound = true;
                    }
                }

                if (!patientFound)
                {
                    Console.WriteLine("\nNo patients assigned to you.");
                }
            }
            else
            {
                Console.WriteLine("\nNo patients found in the system.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Case 3 list all appoiintments related to current doctor
        public static void DoctorListAllAppointments(Doctor currentDoctor)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("All Appointments");

            // Display all appointments for this doctor
            string appointmentFilePath = @"Appointments.txt";
            if (File.Exists(appointmentFilePath))
            {
                string[] appointmentLines = File.ReadAllLines(appointmentFilePath);
                Console.WriteLine("\n{0,-20} | {1,-20} | {2,-40}", "Doctor", "Patient", "Description");
                Console.WriteLine(new string('-', 80));  // Divider line

                foreach (var line in appointmentLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4 && parts[2] == currentDoctor.DoctorID.ToString())
                    {
                        Patient? patient = Utils.GetPatientDetailsById(parts[1]);  // Load the patient by ID
                        if (patient != null)
                        {
                            Console.WriteLine("{0,-20} | {1,-20} | {2,-40}",
                                currentDoctor.FirstName + " " + currentDoctor.LastName,
                                patient.FirstName + " " + patient.LastName,
                                parts[3]);  // Description
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo appointments found.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Case 4 Doctor check particular patient through ID
        public static void DoctorCheckPatient(Doctor currentDoctor)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("Check Patient Details");

            Console.Write("\nEnter the ID of the patient to check: ");
            string? inputID = Console.ReadLine();

            // Ensure that inputID is not null or empty before calling the method
            if (string.IsNullOrEmpty(inputID))
            {
                Console.WriteLine("The patient ID cannot be empty. Please enter a valid ID.");
                return;  // Or re-prompt the user to enter a valid ID
            }

            // Validate the patient ID
            Patient? patient = Utils.GetPatientDetailsById(inputID);

            // Check if the patient exists
            if (patient == null)
            {
                Console.WriteLine("No patient found with the given ID.");
            }
            else
            {
                // Display patient details
                Console.WriteLine("\nPatient Details:\n");
                Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Patient", "Email Address", "Phone", "Address");
                Console.WriteLine(new string('-', 110)); // Divider line
                Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                    patient.FirstName + " " + patient.LastName,
                    patient.Email,
                    patient.Phone,
                    patient.StreetNumber + " " + patient.Street + ", " + patient.City + ", " + patient.State);
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }


        // Case 5: Check all appointments with a particular patient using Appointments.txt
        public static void DoctorListAppointmentsWithPatient(Doctor currentDoctor)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("Appointments With Patient");

            Console.Write("\nEnter the ID of the patient you would like to view appointments for: ");
            string? inputID = Console.ReadLine();

            // Ensure that inputID is not null or empty before calling the method
            if (string.IsNullOrEmpty(inputID))
            {
                Console.WriteLine("The patient ID cannot be empty. Please enter a valid ID.");
                return;  // Or re-prompt the user to enter a valid ID
            }

            // Validate the patient ID by retrieving patient details from PatientsDetail.txt
            Patient? patient = Utils.GetPatientDetailsById(inputID);

            if (patient == null)
            {
                Console.WriteLine("No patient found with that ID.");
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(true);
                return;
            }

            // Display appointments for this patient from Appointments.txt
            string appointmentFilePath = @"Appointments.txt";
            if (File.Exists(appointmentFilePath))
            {
                string[] appointmentLines = File.ReadAllLines(appointmentFilePath);
                Console.WriteLine("\n{0,-20} | {1,-20} | {2,-40}", "Doctor", "Patient", "Description");
                Console.WriteLine(new string('-', 90));  // Divider line

                bool appointmentFound = false;
                foreach (var line in appointmentLines)
                {
                    var parts = line.Split(',');

                    // Check if the appointment involves this doctor and the patient
                    if (parts.Length == 4 && parts[1] == inputID && parts[2] == currentDoctor.DoctorID.ToString())
                    {
                        // Print appointment details
                        Console.WriteLine("{0,-20} | {1,-20} | {2,-40}",
                            currentDoctor.FirstName + " " + currentDoctor.LastName,  // Doctor's Name
                            patient.FirstName + " " + patient.LastName,  // Patient's Name
                            parts[3]);  // Appointment Description

                        appointmentFound = true;
                    }
                }

                if (!appointmentFound)
                {
                    Console.WriteLine("\nNo appointments found for this patient.");
                }
            }
            else
            {
                Console.WriteLine("\nNo appointments found in the system.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}

