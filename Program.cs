using System;
using System.IO;

namespace HMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name = null;
            string? role = null;

            while (role == null)
            {
                Console.Clear();
                Console.WriteLine("┌-----------------------------------------------┐");
                Console.WriteLine("        DOTNET Hospital Management System");
                Console.WriteLine("│-----------------------------------------------│");
                Console.WriteLine("                      Login");
                Console.WriteLine("└-----------------------------------------------┘");

                // Get the ID
                Console.Write("\nID: ");
                string? inputID = Console.ReadLine();

                if (inputID == null)
                {
                    Console.WriteLine("ID cannot be null. Please try again.");
                    return;
                }

                // Get the password
                Console.Write("Password: ");
                string inputPassword = GetPassword();

                // Validate the credentials and get the name and role
                (name, role) = ValidateCredentials(inputID, inputPassword);

                if (role == null)
                {
                    Console.WriteLine("\nInvalid credentials. Please try again.");
                    Console.WriteLine("Press any key to retry...");
                    Console.ReadKey();
                }
            }

            // Redirect to other menu based on the role
            if (role == "Admin")
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = "Admin";
                }
                Console.Clear();
                Admin.AdminMenu(name);
            }
            else if (role == "Patient")
            {
                // If the name is null or empty, replace it with defalut "Patient"
                if (string.IsNullOrEmpty(name))
                {
                    name = "Patient";  
                }

                Console.Clear();

                // Pass the name to the PatientMenu method
                Patient.PatientMenu(name);
            }
            else if (role == "Doctor")
            {
                // If the name is null or empty, replace it with "Doctor"
                if (string.IsNullOrEmpty(name))
                {
                    name = "Doctor";
                }

                Console.Clear();
                // Pass the name to the DoctorMenu method
                Doctor.DoctorMenu(name);
            }
            else
            {
                // Need to change this later
                Console.WriteLine("Welcome to the system!");
            }
        }


        // Function to read the password with '*' masking
        private static string GetPassword()
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

        // Function to validate the ID and password 
        private static (string? name, string? role) ValidateCredentials(string id, string password)
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
    }
}