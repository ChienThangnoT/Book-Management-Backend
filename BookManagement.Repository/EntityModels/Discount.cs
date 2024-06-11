using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string? Description { get; set; }

    public double? DiscountPercentage { get; set; }

    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
