using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.Entities;

public class Color
{
    [Key]
    public int ColorId { get; set; }

    [Required, DisplayName("Category Name"), MaxLength(30)]
    public string Title { get; set; }

    [Required]
    public string CssCode { get; set; }

    [DisplayName("Display Order"), Range(1, 100, ErrorMessage = "Order value should be between 1 - 100")]
    public int Order { get; set; }

    public ICollection<ProductColor> ProductColors { get; set; }
}
