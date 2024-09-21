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

        // Validate phone number to ensure it only contains digits and has a valid length
        public static bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 8 && phone.Length <= 12; 
        }
    }
}

