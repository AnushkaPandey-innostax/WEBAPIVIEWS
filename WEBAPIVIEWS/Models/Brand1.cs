using System;
using System.Collections.Generic;

namespace WEBAPIVIEWS.Models;

public partial class Brand1
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Category { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}
