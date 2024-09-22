using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HMS;

namespace HMS
{
    public static class Utils
    {
        // Display repetitive menu header
        public static void DisplayMenuHeader(string menuTitle)
        {
            Console.Clear();
            Console.WriteLine("┌-----------------------------------------------┐");
            Console.WriteLine("        DOTNET Hospital Management System");
            Console.WriteLine("│-----------------------------------------------│");
            Console.WriteLine($"                    {menuTitle}");
            Console.WriteLine("└-----------------------------------------------┘");
        }

        // Validate the ID and password for both patients and doctors
        public static (string? name, string? role, object? user) ValidateCredentials(string id, string password)
        {
            try
            {
                string userFilePath = @"Users.txt";

                // Exception handling when files can't be found
                if (!File.Exists(userFilePath))
                {
                    throw new FileNotFoundException("The file does not exist.");
                }

                string[] lines = File.ReadAllLines(userFilePath);

                // Validate the user from Users.txt
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string validID = parts[0];
                        string validPassword = parts[1];
                        string validUsername = parts[2];
                        string validRole = parts[3];

                        // If the ID and password match
                        if (id == validID && password == validPassword)
                        {
                            if (validRole == "Patient")
                            {
                                // Load the patient details from PatientDetails.txt
                                Patient? patient = GetPatientDetailsById(validID);

                                if (patient != null)
                                {
                                    // Return name, role, and patient object
                                    return (validUsername, validRole, patient);
                                }
                            }
                            else if (validRole == "Doctor")
                            {
                                // Load the doctor details from DoctorsDetail.txt
                                Doctor? doctor = GetDoctorDetailsById(validID);

                                if (doctor != null)
                                {
                                    // Return name, role, and doctor object
                                    return (validUsername, validRole, doctor);
                                }
                            }
                            else
                            {
                                // Return name and role for non-patient and non-doctor users
                                return (validUsername, validRole, null);
                            }
                        }
                    }
                }

                // Return null if validation fails
                return (null, null, null);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (null, null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return (null, null, null);
            }
        }

        // Load patient details from PatientDetails.txt
        public static Patient? GetPatientDetailsById(string id)
        {
            try
            {
                string patientFilePath = @"PatientsDetail.txt";
                if (!File.Exists(patientFilePath))
                {
                    throw new FileNotFoundException("The patient details file does not exist.");
                }

                string[] patientLines = File.ReadAllLines(patientFilePath);

                foreach (var line in patientLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 9)
                    {
                        // Check if the patient ID matches
                        if (parts[0] == id)
                        {
                            // Create a Patient object with the details
                            return new Patient(
                                int.Parse(parts[0]), // PatientID
                                parts[1], // FirstName
                                parts[2], // LastName
                                parts[3], // Email
                                parts[4], // Phone
                                parts[5], // StreetNumber
                                parts[6], // Street
                                parts[7], // City
                                parts[8]  // State
                            );
                        }
                    }
                }

                return null; // No match found
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error parsing patient details: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

        // Load doctor details from DoctorsDetail.txt
        public static Doctor? GetDoctorDetailsById(string id)
        {
            try
            {
                string doctorFilePath = @"DoctorsDetail.txt";
                string[] doctorLines = File.ReadAllLines(doctorFilePath);

                foreach (var line in doctorLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 9)
                    {
                        // Check if the doctor ID matches
                        if (parts[0] == id)
                        {
                            // Create a Doctor object with the details
                            return new Doctor(
                                int.Parse(parts[0]), // DoctorID
                                parts[1], // FirstName
                                parts[2], // LastName
                                parts[3], // Email
                                parts[4], // Phone
                                parts[5], // StreetNumber
                                parts[6], // Street
                                parts[7], // City
                                parts[8]  // State
                            );
                        }
                    }
                }

                // Return null if no doctor is found with the ID
                return null;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error parsing details: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

        // Display a list of all available doctors
        public static void DisplayDoctorList()
        {
            string doctorFilePath = @"DoctorsDetail.txt";

            if (!File.Exists(doctorFilePath))
            {
                Console.WriteLine("No doctors available in the system.");
                return;
            }

            Console.WriteLine("{0,-10} | {1,-20} | {2,-30} | {3,-12} | {4,-40}", "Doctor ID", "Name", "Email", "Phone", "Address");
            Console.WriteLine(new string('-', 110)); // Divider line

            string[] doctorLines = File.ReadAllLines(doctorFilePath);
            foreach (var line in doctorLines)
            {
                var parts = line.Split(',');
                if (parts.Length == 9)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-30} | {3,-12} | {4,-40}",
                        parts[0],
                        parts[1] + " " + parts[2],
                        parts[3],
                        parts[4],
                        parts[5] + " " + parts[6] + ", " + parts[7] + ", " + parts[8]);
                }
            }
        }


        // Validate and get a valid doctor selection
        public static int GetValidDoctorSelection()
        {
            Console.Write("\nPlease choose a doctor (Enter the ID): ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int doctorSelection) && doctorSelection > 0)
                {
                    // Verify that the doctor exists in DoctorsDetail.txt
                    Doctor? doctor = GetDoctorDetailsById(doctorSelection.ToString());
                    if (doctor != null)
                    {
                        return doctorSelection;
                    }
                    else
                    {
                        Console.WriteLine("Doctor not found. Please enter a valid Doctor ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }


        // Generate a unique Appointment ID
        public static int GenerateAppointmentId()
        {
            int maxId = 0;
            string appointmentFilePath = @"Appointments.txt";

            if (File.Exists(appointmentFilePath))
            {
                string[] appointmentLines = File.ReadAllLines(appointmentFilePath);

                foreach (var line in appointmentLines)
                {
                    var parts = line.Split(',');
                    if (parts.Length > 0 && int.TryParse(parts[0], out int existingId))
                    {
                        if (existingId > maxId)
                        {
                            maxId = existingId;
                        }
                    }
                }
            }

            return maxId + 1;
        }

        // Save appointment to file
        public static void SaveAppointment(Appointment appointment)
        {
            string appointmentFilePath = @"Appointments.txt";
            string appointmentDetails = $"{appointment.AppointmentID},{appointment.PatientID},{appointment.DoctorID},{appointment.AppointmentDetails}";

            File.AppendAllText(appointmentFilePath, appointmentDetails + Environment.NewLine);
        }

        // Generate the next patient ID, ensuring it's unique
        private static int currentPatientId = 222222;

        public static int GeneratePatientId()
        {
            int newId;
            do
            {
                newId = currentPatientId++;  // Increment after returning the current ID
            } while (!IsPatientIdUnique(newId));  // Ensure the ID is unique

            return newId;
        }

        // Generate the next doctor ID, ensuring it's unique
        private static int currentDoctorId = 333333;

        public static int GenerateDoctorId()
        {
            int newId;
            do
            {
                newId = currentDoctorId++;  // Increment after returning the current ID
            } while (!IsDoctorIdUnique(newId));  // Ensure the ID is unique

            return newId;
        }

        // Check if the patient ID is unique by reading from PatientsDetail.txt
        public static bool IsPatientIdUnique(int id)
        {
            if (!File.Exists("PatientsDetail.txt"))
            {
                return true; // If file doesn't exist, the ID is unique
            }

            string[] lines = File.ReadAllLines("PatientsDetail.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 0 && int.TryParse(parts[0], out int existingId) && existingId == id)
                {
                    return false; // ID is not unique
                }
            }

            return true; // ID is unique
        }

        // Check if the doctor ID is unique by reading from DoctorsDetail.txt
        public static bool IsDoctorIdUnique(int id)
        {
            if (!File.Exists("DoctorsDetail.txt"))
            {
                return true; // If file doesn't exist, the ID is unique
            }

            string[] lines = File.ReadAllLines("DoctorsDetail.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 0 && int.TryParse(parts[0], out int existingId) && existingId == id)
                {
                    return false; // ID is not unique
                }
            }

            return true; // ID is unique
        }

        // Function to ensure the user input is not null, empty, or whitespace
        public static string GetNonNullInput(string prompt)
        {
            // ? is to Telling the compiler that null is a valid value to prevent the CS8600 warning
            string? input;

            do
            {
                Console.Write(prompt); // Show the prompt
                input = Console.ReadLine(); // Get user input

                // Check if the input is null, empty, or just whitespace
                if (input == null || string.IsNullOrWhiteSpace(input))
                {
                    // Show error message
                    Console.WriteLine("Input cannot be null or empty. Please try again.");
                }
            } while (input == null || string.IsNullOrWhiteSpace(input)); // Repeat until valid input is provided

            // Return valid input
            return input;
        }

        // Get valid email input
        public static string GetValidEmailInput(string prompt)
        {
            string email;
            do
            {
                email = GetNonNullInput(prompt);

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                }
            } while (!IsValidEmail(email));

            return email;
        }

        // Get valid phone input
        public static string GetValidPhoneInput(string prompt)
        {
            string phone;
            do
            {
                phone = GetNonNullInput(prompt);

                if (!IsValidPhone(phone))
                {
                    Console.WriteLine("Invalid phone number. Please enter a valid phone number.");
                }
            } while (!IsValidPhone(phone));

            return phone;
        }

        // Validate email format
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Validate phone number with a valid length
        public static bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 8 && phone.Length <= 12; 
        }
    }
}
