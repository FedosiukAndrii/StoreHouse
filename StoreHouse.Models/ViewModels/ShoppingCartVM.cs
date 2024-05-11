using StoreHouse.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Models.ViewModels
{
	public class ShoppingCartVM
	{
		public IEnumerable<CartItem> Items { get; set; }

		public OrderHeader OrderHeader { get; set;}
	}
}
