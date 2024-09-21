using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Users
    {
        // Fields to store User information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Constructor to initialize the user details
        public Users(string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            StreetNumber = streetNumber;
            Street = street;
            City = city;
            State = state;
        }

        // Override ToString() to display user details in a formatted string
        public override string ToString()
        {
            return $"{FirstName} {LastName}  | {Email}  | {Phone}  | {StreetNumber} {Street}, {City}, {State}";
        }
    }
}
