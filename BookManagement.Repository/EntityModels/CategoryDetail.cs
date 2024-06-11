using System;
using System.Collections.Generic;

namespace BookManagement.Repository.EntityModels;

public partial class CategoryDetail
{
    public int CategoryDetailId { get; set; }

    public int? CategoryId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Category? Category { get; set; }
}
