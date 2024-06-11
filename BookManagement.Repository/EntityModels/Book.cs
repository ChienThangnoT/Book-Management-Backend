using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? BookImg { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public int? CategoryId { get; set; }

    public double? Price { get; set; }

    public string? BookDescription { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
