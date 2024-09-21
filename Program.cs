﻿using System;
using System.IO;

namespace HMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loggedIn = false;

            while (!loggedIn)
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

                    if (string.IsNullOrEmpty(inputID))
                    {
                        Console.WriteLine("ID cannot be null. Please try again.");
                        continue;
                    }

                    // Get the password
                    Console.Write("Password: ");
                    string inputPassword = GetPassword();

                    // Call the ValidateCredentials method from Utils.cs
                    (name, role) = Utils.ValidateCredentials(inputID, inputPassword);

                    if (role == null)
                    {
                        Console.WriteLine("\nInvalid credentials. Please try again.");
                        Console.WriteLine("\nPress any key to retry...");
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
                    if (string.IsNullOrEmpty(name))
                    {
                        name = "Patient";
                    }

                    Console.Clear();
                    Patient.PatientMenu(name);
                }
                else if (role == "Doctor")
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        name = "Doctor";
                    }

                    Console.Clear();
                    Doctor.DoctorMenu(name);
                }

                // After exiting from the menu, reset the role to null to show the login again.
                role = null;
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
    }
}