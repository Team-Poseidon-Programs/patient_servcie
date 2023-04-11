using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Prescription_M
    {
        public int Id { get; set; }

        public int? VisitDetailsId { get; set; }

        public string? PrescriptionName { get; set; }

        public string? Dosage { get; set; }

        public string? Notes { get; set; }
    }
}
