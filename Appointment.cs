using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string AppointmentDetails { get; set; }

        public Appointment(int appointmentID, int patientID, int doctorID, string appointmentDetails)
        {
            AppointmentID = appointmentID;
            PatientID = patientID;
            DoctorID = doctorID;
            AppointmentDetails = appointmentDetails;
        }

        public override string ToString()
        {
            return $"Appointment ID: {AppointmentID}, Patient ID: {PatientID}, Doctor ID: {DoctorID}, Details: {AppointmentDetails}";
        }
    }
}
