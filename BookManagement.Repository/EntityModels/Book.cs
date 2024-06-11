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

    public double? Price { get; set; }

    public string? BookDescription { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<CategoryDetail> CategoryDetails { get; set; } = new List<CategoryDetail>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
