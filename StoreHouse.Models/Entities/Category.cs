using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [DisplayName("Category Name")]
    [MaxLength(30)]
    public string Name { get; set; }

    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "Order value should be between 1 - 100")]
    public int Order { get; set; }
}
