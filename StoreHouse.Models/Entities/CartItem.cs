using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreHouse.Models.Entities
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }
        public string UserId { get; set; }


        [ForeignKey("UserId"),ValidateNever]
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; }

        [NotMapped] 
        public double Price { get; set;}

		public void Method()
		{
            throw new System.NotImplementedException();
        }
    }
}
