using System;
using System.Collections.Generic;

namespace GroGem.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string Title { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }
}
