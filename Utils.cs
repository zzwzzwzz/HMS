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
        // Validate the ID and password
        public static (string? name, string? role) ValidateCredentials(string id, string password)
        {
            string filePath = @"Users.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string validID = parts[0];
                    string validPassword = parts[1];
                    string validUsername = parts[2];
                    string validRole = parts[3];

                    if (id == validID && password == validPassword)
                    {
                        // Return the name and role
                        return (validUsername, validRole);
                    }
                }
            }

            // Return null if validation fails
            return (null, null);
        }

        // Function to read the password with '*' masking
        public static string GetPassword()
        {
            string password = "";
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    // Erase the last '*' and remove the last character
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
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

