using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public double? TotalAmount { get; set; }

    public int? OrderStatus { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? TransactionNo { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
