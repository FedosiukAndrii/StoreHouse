using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreHouse.Models.Entities
{
	public class OrderDetail
	{
		[Key]
		public int OrderId { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public int OrderHeaderId { get; set; }

		public double Price { get; set; }


		[ForeignKey(nameof(ProductId)), ValidateNever]
		public Product Product { get; set; }

		[ForeignKey(nameof(OrderHeaderId)), ValidateNever]
		public OrderHeader OrderHeader { get; set; }
	}
}
