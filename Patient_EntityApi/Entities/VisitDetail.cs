using System;
using System.Collections.Generic;

namespace EF_Layer.Entities;

public partial class VisitDetail
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

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
}
