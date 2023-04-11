using System;
using System.Collections.Generic;

namespace EF_Layer.Entities;

public partial class Prescription
{
    public int Id { get; set; }

    public int? VisitDetailsId { get; set; }

    public string? PrescriptionName { get; set; }

    public string? Dosage { get; set; }

    public string? Notes { get; set; }

    public virtual VisitDetail? VisitDetails { get; set; }
}
