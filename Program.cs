using System;
using System.IO;

namespace HMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loginSuccess = false;

            // Keep showing login until valid credentials
            while (!loginSuccess)
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

                // Check if the ID is null
                if (inputID == null)
                {
                    Console.WriteLine("ID cannot be null. Please try again.");
                    return;
                }

                // Get the password
                Console.Write("Password: ");
                string inputPassword = GetPassword();

                // Validate the credentials
                loginSuccess = ValidateCredentials(inputID, inputPassword);

                if (!loginSuccess)
                {
                    Console.WriteLine("\nInvalid credentials. Please try again.");
                    Console.WriteLine("Press any key to retry...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nValid Credentials");
                }
            }

            // After logged in proceed to other Menus
            Console.WriteLine("Welcome to the system!");
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
        private static bool ValidateCredentials(string id, string password)
        {
            string filePath = @"..\..\..\users.txt"; 
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                // Check the length in the txt file
                if (parts.Length == 4)
                {
                    string validID = parts[0];
                    string validPassword = parts[1];
                    string validUsername = parts[2];
                    string validRole = parts[3];

                    if (id == validID && password == validPassword)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}