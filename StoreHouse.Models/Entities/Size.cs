using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.Entities;

public class Size
{
    [Key]
    public int SizeId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int Order { get; set; }
}
