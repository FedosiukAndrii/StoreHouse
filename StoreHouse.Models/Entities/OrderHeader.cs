using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreHouse.Models.Entities
{
	public class OrderHeader
	{
		public int Id { get; set; }
		public string UserId { get; set; }

		public DateTime OrderDate { get; set; }
		public DateTime ShipingDate { get; set; }
		public double OrderTotal { get; set; }


		public string OrderStatus { get; set; }
		public string PaymentStatus { get; set; }
		public string TrackingNumber { get; set; }
		public string Carrier { get; set; }

		public string PaymentIntentId { get; set; }
		public string SessionId { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string StreetAddress { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string PostalCode { get; set; }
		[Required]
		public string Name { get; set; }




		[ForeignKey(nameof(UserId)), ValidateNever]
		public ApplicationUser ApplicationUser { get; set; }
	}
}
