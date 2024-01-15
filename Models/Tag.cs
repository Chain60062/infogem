using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoGem.Models;

public class Tag
{
    [Key]
    public long TagId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    //Skip navigations for many-to-many relationship
    public virtual ICollection<Product> Products { get; } = new HashSet<Product>();
}
