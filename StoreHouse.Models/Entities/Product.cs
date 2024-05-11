using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StoreHouse.Models.Entities;

public class Product
{
    [ValidateNever, Key]
    public int ProductId { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required, Range(1, 100000)]
    public double Price { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public ICollection<ProductColor> ProductColors { get; set; }
}
