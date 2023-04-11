using System;
using System.Collections.Generic;

namespace EF_Layer.Entities;

public partial class Patient
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Dob { get; set; }

    public string? ContactNumber { get; set; }

    public string? Password { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<VisitDetail> VisitDetails { get; } = new List<VisitDetail>();
}
