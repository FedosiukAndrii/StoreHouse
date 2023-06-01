using StoreHouse.Models.Entities;

namespace StoreHouse.Models.ViewModels;

public class ProductDetailVM
{
    public Product Product { get; set; }
    public ProductColor SelectedColor { get; set; }

    public IEnumerable<Size> Sizes { get; set; }
}
