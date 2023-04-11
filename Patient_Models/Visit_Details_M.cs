using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Visit_Details_M

    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public double? Height { get; set; }

        public double? Weight { get; set; }

        public int? BloodPressureSystolic { get; set; }

        public int? BloodPressureDiastolic { get; set; }

        public double? BodyTemperature { get; set; }

        public int? RespirationRate { get; set; }

        public string? BloodGroup { get; set; }

        public string? NurseEmail { get; set; }

        public string? PhysicianEmail { get; set; }

        public int? AppointmentId { get; set; }

        public string? KeyNotes { get; set; }
    }
}
