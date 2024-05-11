﻿namespace StoreHouse.Models.Entities;

public class ProductColor
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int ColorId { get; set; }
    public Color Color { get; set; }

    public ICollection<ProductColorImage> Images { get; set; }
}
