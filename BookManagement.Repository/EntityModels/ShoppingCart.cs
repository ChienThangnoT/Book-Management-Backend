using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class ShoppingCart
{
    public int ShoppingCartId { get; set; }

    public int? BookId { get; set; }

    public int? UserId { get; set; }

    public int? Quanity { get; set; }

    public double? Price { get; set; }

    public virtual Book? Book { get; set; }

    public virtual User? User { get; set; }
}
