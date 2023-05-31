using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.Entities;

public class ProductColorImage
{
    [Key]
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }

    public ProductColor ProductColor { get; set; }
}
