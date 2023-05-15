using System;
using System.Collections.Generic;

namespace GroGem.Models;

public partial class ImageViewModel
{
    public string Url { get; set; } = null!;

    public string? AltText { get; set; }

    public virtual Product? Product { get; set; }
}
