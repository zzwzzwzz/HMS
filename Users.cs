using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Users(string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state)
    {
        // Fields to store User information; Use primary constructors
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public string StreetNumber { get; set; } = streetNumber;
        public string Street { get; set; } = street;
        public string City { get; set; } = city;
        public string State { get; set; } = state;

        // Override ToString() to display user details in a formatted string
        public override string ToString()
        {
            return $"{FirstName} {LastName}  | {Email}  | {Phone}  | {StreetNumber} {Street}, {City}, {State}";
        }

        // Overloaded method to display only the full name of the user
        public void DisplayFullName()
        {
            Console.WriteLine($"User: {FirstName} {LastName}");
        }
    }
}
