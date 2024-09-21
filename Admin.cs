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
                Console.WriteLine("                 Admin Menu");
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
                Console.WriteLine("8. Exit\n");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        ListAllDoctors();
                        break;
                    case "2":
                        Console.Clear();
                        CheckDoctorDetail();
                        break;
                    case "3":
                        Console.Clear();
                        ListAllPatients();
                        break;
                    case "4":
                        Console.Clear();
                        CheckPatientDetail();
                        break;
                    case "5":
                        AddDoctor();
                        break;
                    case "6":
                        AddPatient();
                        break;
                    case "7":
                        exit = true; // Logout and return to the login screen
                        return;
                    case "8":
                        Environment.Exit(0);  // Exit the program
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Function to list all the doctors information
        public static void ListAllDoctors()
        {
            Console.Clear();
            Console.WriteLine("┌-----------------------------------------------┐");
            Console.WriteLine("        DOTNET Hospital Management System");
            Console.WriteLine("│-----------------------------------------------│");
            Console.WriteLine("                 All Doctors");
            Console.WriteLine("└-----------------------------------------------┘");

            // Set headers with fixed-width formatting
            Console.WriteLine("\nAll doctors registered to the DOTNET Hospital Management System\n");
            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Name", "Email Address", "Phone", "Address");
            Console.WriteLine(new string('-', 110)); // Divider line

            if (File.Exists("DoctorsDetail.txt"))
            {
                string[] doctorLines = File.ReadAllLines("DoctorsDetail.txt");
                foreach (var line in doctorLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 9)
                    {
                        Doctor doctor = new Doctor(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                        // Format the output with fixed-width columns for alignment
                        Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                            doctor.FirstName + " " + doctor.LastName,
                            doctor.Email,
                            doctor.Phone,
                            doctor.StreetNumber + " " + doctor.Street + ", " + doctor.City + ", " + doctor.State);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo doctors found in the system.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        public static void CheckDoctorDetail()
        {
            while (true)  // Keep the loop running until 'n' is pressed
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                 Doctor Details");
                Console.WriteLine("└-----------------------------------------------┘");

                Console.Write("\nPlease enter the ID of the doctor whose details you are checking. Or press 'n' to return to menu: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;  // If input is empty, re-prompt the user
                }

                if (input.ToLower() == "n")
                {
                    return;  // Exit to the menu
                }

                bool found = false;
                if (File.Exists("DoctorsDetail.txt"))
                {
                    string[] doctorLines = File.ReadAllLines("DoctorsDetail.txt");
                    foreach (var line in doctorLines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 9 && parts[0] == input) // Check if the ID matches
                        {
                            Doctor doctor = new Doctor(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);

                            Console.Clear();
                            Console.WriteLine($"\nDetails for Dr. {doctor.FirstName} {doctor.LastName}");
                            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Name", "Email Address", "Phone", "Address");
                            Console.WriteLine(new string('-', 110)); // Divider
                            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                                doctor.FirstName + " " + doctor.LastName,
                                doctor.Email,
                                doctor.Phone,
                                doctor.StreetNumber + " " + doctor.Street + ", " + doctor.City + ", " + doctor.State);

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("\nDoctor with the provided ID not found. Please try again.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();  // Ensure this is inside the loop to pause after each operation
            }
        }

        // Function to list all the patients information
        public static void ListAllPatients()
        {
            Console.Clear();
            Console.WriteLine("┌-----------------------------------------------┐");
            Console.WriteLine("        DOTNET Hospital Management System");
            Console.WriteLine("│-----------------------------------------------│");
            Console.WriteLine("                 All Patients");
            Console.WriteLine("└-----------------------------------------------┘");

            // Set headers with fixed-width formatting
            Console.WriteLine("\nAll patients registered to the DOTNET Hospital Management System\n");
            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Patient", "Email Address", "Phone", "Address");
            Console.WriteLine(new string('-', 110)); // Divider line

            if (File.Exists("PatientsDetail.txt"))
            {
                string[] patientLines = File.ReadAllLines("PatientsDetail.txt");
                foreach (var line in patientLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 9)
                    {
                        Patient patient = new Patient(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);
                        // Format the output with fixed-width columns for alignment
                        Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                            patient.FirstName + " " + patient.LastName,
                            patient.Email,
                            patient.Phone,
                            patient.StreetNumber + " " + patient.Street + ", " + patient.City + ", " + patient.State);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo patients found in the system.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Function to check patient detail according to the input ID
        public static void CheckPatientDetail()
        {
            while (true)  // Keep the loop running until 'n' is pressed
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                 Patient Details");
                Console.WriteLine("└-----------------------------------------------┘");

                Console.Write("\nPlease enter the ID of the patient whose details you are checking. Or press 'n' to return to menu: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    continue;  // If input is empty, re-prompt the user
                }

                if (input.ToLower() == "n")
                {
                    return;  // Exit to the menu
                }

                bool found = false;
                if (File.Exists("PatientsDetail.txt"))
                {
                    string[] patientLines = File.ReadAllLines("PatientsDetail.txt");
                    foreach (var line in patientLines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 9 && parts[0] == input) // Check if the ID matches
                        {
                            Patient patient = new Patient(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8]);

                            Console.Clear();
                            Console.WriteLine($"\nDetails for {patient.FirstName} {patient.LastName}");
                            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Patient", "Email Address", "Phone", "Address");
                            Console.WriteLine(new string('-', 110)); // Divider
                            Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                                patient.FirstName + " " + patient.LastName,
                                patient.Email,
                                patient.Phone,
                                patient.StreetNumber + " " + patient.Street + ", " + patient.City + ", " + patient.State);

                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("\nPatient with the provided ID not found. Please try again.");
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();  // Ensure this is inside the loop to pause after each operation
            }
        }

        // Function to add a new doctor
        public static void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System:\n");

            int doctorID = Utils.GenerateDoctorId(); // Generate a unique doctor ID
            string firstName = Utils.GetNonNullInput("First Name: ");
            string lastName = Utils.GetNonNullInput("Last Name: ");
            string email = Utils.GetValidEmailInput("Email: ");  // Call GetValidEmailInput
            string phone = Utils.GetValidPhoneInput("Phone: ");  // Call GetValidPhoneInput
            string streetNumber = Utils.GetNonNullInput("Street Number: ");
            string street = Utils.GetNonNullInput("Street: ");
            string city = Utils.GetNonNullInput("City: ");
            string state = Utils.GetNonNullInput("State: ");

            // Write the input to the DoctorsDetail.txt file
            string doctorDetails = $"{doctorID},{firstName},{lastName},{email},{phone},{streetNumber},{street},{city},{state}";
            File.AppendAllText("DoctorsDetail.txt", doctorDetails + Environment.NewLine);

            Console.WriteLine($"\nDr {firstName} {lastName} added to the system!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Function to add a new patient
        public static void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System:\n");

            int patientID = Utils.GeneratePatientId(); // Generate a unique patient ID
            string firstName = Utils.GetNonNullInput("First Name: ");
            string lastName = Utils.GetNonNullInput("Last Name: ");
            string email = Utils.GetValidEmailInput("Email: ");  // Call GetValidEmailInput
            string phone = Utils.GetValidPhoneInput("Phone: ");  // Call GetValidPhoneInput
            string streetNumber = Utils.GetNonNullInput("Street Number: ");
            string street = Utils.GetNonNullInput("Street: ");
            string city = Utils.GetNonNullInput("City: ");
            string state = Utils.GetNonNullInput("State: ");

            // Write to the PatientsDetail.txt file
            string patientDetails = $"{patientID},{firstName},{lastName},{email},{phone},{streetNumber},{street},{city},{state}";
            File.AppendAllText("PatientsDetail.txt", patientDetails + Environment.NewLine);

            Console.WriteLine($"\n{firstName} {lastName} added to the system!");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}