using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Patient(int patientID, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state, int? doctorID = null) : Users(firstName, lastName, email, phone, streetNumber, street, city, state)
    {
        public int PatientID { get; set; } = patientID;
        public int? DoctorID { get; set; } = doctorID;

        public override string ToString()
        {
            return $"Patient ID: {PatientID}, {base.ToString()}";
        }

        // Display patient menu
        public static void PatientMenu(Patient currentPatient) 
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                // Call the display menu header function from Utils.cs
                Utils.DisplayMenuHeader("Patient Menu");

                // Display the welcome message with the name
                Console.WriteLine($"\nWelcome to DOTNET Hospital Management System, {currentPatient.FirstName} {currentPatient.LastName}!");

                // Display the Patient Menu detail
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. List patient details");
                Console.WriteLine("2. List my doctor details");
                Console.WriteLine("3. List all appointments");
                Console.WriteLine("4. Book appointment");
                Console.WriteLine("5. Exit to login");
                Console.WriteLine("6. Exit System\n");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        PatientListDetail(currentPatient);
                        break;
                    case "2":
                        Console.Clear();
                        PatientListDoctorDetail(currentPatient);
                        break;
                    case "3":
                        Console.Clear();
                        PatientListAppointments(currentPatient);
                        break;
                    case "4":
                        Console.Clear();
                        // Call the new appointment booking function
                        currentPatient.PatientBookAppointment();  
                        break;
                    case "5":
                        Console.Clear();
                        // exit = true;
                        return;
                    case "6":
                        // Exit the program
                        Environment.Exit(0);  
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        // Case 1 function for patient to check their own detail
        public static void PatientListDetail(Patient currentPatient)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("My Details");

            // Display the patient details
            Console.WriteLine($"\n{currentPatient.FirstName} {currentPatient.LastName}'s Details:\n");
            Console.WriteLine($"Patient ID: {currentPatient.PatientID}");
            Console.WriteLine($"Full Name: {currentPatient.FirstName} {currentPatient.LastName}");
            Console.WriteLine($"Address: {currentPatient.StreetNumber} {currentPatient.Street}, {currentPatient.City}, {currentPatient.State}");
            Console.WriteLine($"Email: {currentPatient.Email}");
            Console.WriteLine($"Phone: {currentPatient.Phone}");

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Case 2: Function to list the doctor details for the logged-in patient
        public static void PatientListDoctorDetail(Patient currentPatient)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("My Doctor");

            // Check if the patient is registered with a doctor
            if (!currentPatient.DoctorID.HasValue)
            {
                Console.WriteLine("\nYou are not currently registered with any doctor.");
            }
            else
            {
                // Fetch doctor details using DoctorID
                Doctor? doctor = Utils.GetDoctorDetailsById(currentPatient.DoctorID.Value.ToString());

                if (doctor != null)
                {
                    // Display the doctor details in a compressed line format
                    Console.WriteLine($"\nYour doctor:");
                    Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}", "Name", "Email Address", "Phone", "Address");
                    Console.WriteLine(new string('-', 110));
                    Console.WriteLine("{0,-20} | {1,-30} | {2,-12} | {3,-40}",
                        doctor.FirstName + " " + doctor.LastName,
                        doctor.Email,
                        doctor.Phone,
                        doctor.StreetNumber + " " + doctor.Street + ", " + doctor.City + ", " + doctor.State);
                }
                else
                {
                    Console.WriteLine("\nDoctor information could not be found.");
                }
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }

        // Case 3: Function to list all appointments for the current patient
        public static void PatientListAppointments(Patient currentPatient)
        {
            Console.Clear();

            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("My Appointments");

            // Open and read the Appointments.txt file
            string appointmentFilePath = @"Appointments.txt";
            if (!File.Exists(appointmentFilePath))
            {
                Console.WriteLine("No appointments found.");
                Console.ReadKey();
                return;
            }

            string[] appointmentLines = File.ReadAllLines(appointmentFilePath);
            bool foundAppointments = false;

            Console.WriteLine($"Appointments for {currentPatient.FirstName} {currentPatient.LastName}\n");
            Console.WriteLine("{0,-20} | {1,-20} | {2,-30}", "Doctor", "Patient", "Description");
            Console.WriteLine(new string('-', 80));

            foreach (var line in appointmentLines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4 && int.Parse(parts[1]) == currentPatient.PatientID) // Matching PatientID
                {
                    // Fetch doctor details using DoctorID
                    Doctor? doctor = Utils.GetDoctorDetailsById(parts[2]);

                    if (doctor != null)
                    {
                        Console.WriteLine("{0,-20} | {1,-20} | {2,-30}",
                            doctor.FirstName + " " + doctor.LastName,
                            currentPatient.FirstName + " " + currentPatient.LastName,
                            parts[3]); // Appointment description
                        foundAppointments = true;
                    }
                }
            }

            if (!foundAppointments)
            {
                Console.WriteLine("No appointments found for the current patient.");
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }


        // Function case 4 to book an appointment
        public void PatientBookAppointment()
        {
            // Call the display menu header function from Utils.cs
            Utils.DisplayMenuHeader("Book Appointment");

            // If not registered with a doctor, prompt to register
            if (!DoctorID.HasValue)
            {
                Console.WriteLine("\nYou are not registered with any doctor! Please choose which doctor you would like to register with:\n");
                Utils.DisplayDoctorList();  // Displays all available doctors

                int selectedDoctorID = Utils.GetValidDoctorSelection();  // Get a valid doctor selection
                DoctorID = selectedDoctorID;

                Console.WriteLine($"\nYou are now registered with Doctor ID: {selectedDoctorID}");
            }
            else
            {
                Console.WriteLine($"\nYou are booking a new appointment with Doctor ID: {DoctorID}");
            }

            // Proceed with appointment detail
            Console.Write("\nDescription of the appointment: ");
            string appointmentDescription = Console.ReadLine() ?? "";

            // Generate a new Appointment ID
            int newAppointmentID = Utils.GenerateAppointmentId();
            Appointment newAppointment = new (newAppointmentID, PatientID, DoctorID.Value, appointmentDescription);

            // Save the appointment details to file
            Utils.SaveAppointment(newAppointment);

            Console.WriteLine("\nThe appointment has been booked successfully.");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(true);
        }
    }
}

