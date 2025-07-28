using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentType { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
