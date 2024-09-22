using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    // Use primary constructor
    public class Appointment(int appointmentID, int patientID, int doctorID, string appointmentDetails)
    {
        public int AppointmentID { get; set; } = appointmentID;
        public int PatientID { get; set; } = patientID;
        public int DoctorID { get; set; } = doctorID;
        public string AppointmentDetails { get; set; } = appointmentDetails;

        public override string ToString()
        {
            return $"Appointment ID: {AppointmentID}, Patient ID: {PatientID}, Doctor ID: {DoctorID}, Details: {AppointmentDetails}";
        }
    }
}
