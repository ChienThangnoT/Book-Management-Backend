using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? StartDay { get; set; }

    public DateTime? CompleteDay { get; set; }

    public int? Status { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User? User { get; set; }
}
