using System;
using System.Collections.Generic;

namespace WEBAPIVIEWS.Models;

public partial class Brand
{
    public int ID { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Category { get; set; } = null!;

    public string ImagePath { get; set; } = null!;
}
