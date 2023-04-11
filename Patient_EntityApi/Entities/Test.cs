using System;
using System.Collections.Generic;

namespace EF_Layer.Entities;

public partial class Test
{
    public int Id { get; set; }

    public int? VisitDetailsId { get; set; }

    public string? TestName { get; set; }

    public string? Result { get; set; }

    public string? Notes { get; set; }

    public virtual VisitDetail? VisitDetails { get; set; }
}
