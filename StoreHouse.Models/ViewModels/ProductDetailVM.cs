using StoreHouse.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.ViewModels;

public class ProductDetailVM
{
    public Product Product { get; set; }
    public ProductColor SelectedColor { get; set; }
    [Required]
    public int SizeId { get; set; }
    public int Count { get; set; }

    public IEnumerable<Size> Sizes { get; set; }
}
