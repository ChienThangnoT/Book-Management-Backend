using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public int? Quantity { get; set; }

    public int? DiscountId { get; set; }

    public double? Price { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual Order? Order { get; set; }
}
