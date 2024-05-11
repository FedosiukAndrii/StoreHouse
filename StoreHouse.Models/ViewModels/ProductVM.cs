using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreHouse.Models.Entities;
using StoreHouse.Models.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StoreHouse.Models.ViewModels;

public class ProductVM
{
    public ProductVM(Product product, IEnumerable<Category> categories, IEnumerable<Color> colors)
    {
        Product = product;
        Categories = categories.ToSelectListItems();
        Colors = colors.ToSelectListItems();
        ColorIds = product.ProductColors.Select(c => c.ColorId).ToList();
        CssCodes = colors.ToDictionary(color => color.ColorId, color => color.CssCode);
    }
    public ProductVM(IEnumerable<Category> categories, IEnumerable<Color> colors)
    {
        Categories = categories.ToSelectListItems();
        Colors = colors.ToSelectListItems();
        CssCodes = colors.ToDictionary(color => color.ColorId, color => color.CssCode);
    }
    public ProductVM()
    {

    }

    public Product Product { get; set; }

    [Required, DisplayName("Category")]
    public int CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    [Required, DisplayName("Colors")]
    public List<int> ColorIds { get; set; } = new List<int>();

    public IEnumerable<SelectListItem> Colors { get; set; }

    public Dictionary<int, string> CssCodes { get; set; }
}
