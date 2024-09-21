using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Receptionist : Users
    {
        public int ReceptionistID { get; set; }

        public Receptionist(int receptionistID, string firstName, string lastName, string email, string phone, string streetNumber, string street, string city, string state)
            : base(firstName, lastName, email, phone, streetNumber, street, city, state)
        {
            ReceptionistID = receptionistID;
        }

        public override string ToString()
        {
            return $"Receptionist ID: {ReceptionistID}, {base.ToString()}";
        }
    }

    //public void ManageAppointments()
    //{
    //    // Logic to manage appointments
    //}
}
