using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;
using StoreHouse.Models.Utils;
using StoreHouse.Models.ViewModels;
using Stripe;
using Stripe.Checkout;

namespace StoreHouse.Web.Areas.Customer.Controllers
{
	[Area("Customer"), Authorize]
	public class ShoppingCartController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IShopingCartRepository _cartRepository;
		private readonly IUserRepository _userRepository;
		private readonly IOrderHeaderRepository _orderHeaderRepository;
		private readonly IOrderDetailRepository _orderDetailRepository;

		public ShoppingCartController(ILogger<HomeController> logger, IShopingCartRepository cartRepository, IUserRepository userRepository, IOrderHeaderRepository orderHeaderRepository, IOrderDetailRepository orderDetailRepository)
		{
			_logger = logger;
			_cartRepository = cartRepository;
			_userRepository = userRepository;
			_orderHeaderRepository = orderHeaderRepository;
			_orderDetailRepository = orderDetailRepository;
		}

		public async Task<IActionResult> Index()
		{
			return View(await GetShoppingCartVM());
		}

		public async Task<IActionResult> Summary()
		{
			var cartVm = await GetShoppingCartVM();

			cartVm.OrderHeader.ApplicationUser = await _userRepository.Get(u => u.Id == User.GetId());
			cartVm.OrderHeader.Name = cartVm.OrderHeader.ApplicationUser.Name;
			cartVm.OrderHeader.StreetAddress = cartVm.OrderHeader.ApplicationUser.StreetAddress;
			cartVm.OrderHeader.PostalCode = cartVm.OrderHeader.ApplicationUser.PostalCode;
			cartVm.OrderHeader.City = cartVm.OrderHeader.ApplicationUser.City;
			cartVm.OrderHeader.PhoneNumber = cartVm.OrderHeader.ApplicationUser.PhoneNumber;

			return View(cartVm);
		}

		[HttpPost, ActionName("Summary")]
		public async Task<IActionResult> SummaryPost(ShoppingCartVM cartVm)
		{
			var existingCart = await GetShoppingCartVM();

			cartVm.Items = existingCart.Items;
			cartVm.OrderHeader.OrderTotal = existingCart.OrderHeader.OrderTotal;
			cartVm.OrderHeader.UserId = User.GetId();
			cartVm.OrderHeader.OrderTotal = cartVm.Items.Select(i => i.Product.Price * i.Count).Aggregate((i, j) => i + j);
			cartVm.OrderHeader.PaymentStatus = Status.PaymentPending;
			cartVm.OrderHeader.OrderStatus = Status.Pending;

			await _orderHeaderRepository.Add(cartVm.OrderHeader);

			foreach (var item in cartVm.Items)
			{
				var detail = new OrderDetail
				{
					ProductId = item.ProductId,
					OrderHeaderId = cartVm.OrderHeader.Id,
					Price = item.Price
				};

				await _orderDetailRepository.Add(detail);
			}

			var session = await CreateStripeSessionAsync(cartVm);

			Response.Headers.Add("Location", session.Url);

			return new StatusCodeResult(303);
		}

		public async Task<IActionResult> OrderConfirmation(int orderId)
		{
			var order = await _orderHeaderRepository.Orders.FirstOrDefaultAsync(i => i.Id == orderId);
			var service = new SessionService();
			var session = service.Get(order.SessionId);

			if(session.PaymentStatus.ToLower() == "paid")
			{
				await _orderHeaderRepository.UpdateStripePaymetId(orderId, session.Id, session.PaymentIntentId);
				await _orderHeaderRepository.UpdateStatus(orderId, Status.Approved, Status.PaymentApproved);
			}

			var cartItems = await _cartRepository.CartItems.Where(u => u.UserId == User.GetId()).ToListAsync();

			await  _cartRepository.RemoveRange(cartItems);

			return View(orderId);
		}


		public async Task<IActionResult> Plus(int? cartId)
		{
			var cartItem = await _cartRepository.CartItems.FirstOrDefaultAsync(i => i.CartId == cartId);
			cartItem.Count += 1;

			await _cartRepository.Update(cartItem);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Minus(int? cartId)
		{
			var cartItem = await _cartRepository.CartItems.FirstOrDefaultAsync(i => i.CartId == cartId);
			cartItem.Count -= 1;

			if (cartItem.Count == 0)
			{
				await _cartRepository.Delete(cartItem);
			}
			else
			{
				await _cartRepository.Update(cartItem);
			}

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Remove(int? cartId)
		{
			var cartItem = await _cartRepository.CartItems.FirstOrDefaultAsync(i => i.CartId == cartId);

			await _cartRepository.Delete(cartItem);

			return RedirectToAction(nameof(Index));
		}

		private async Task<ShoppingCartVM> GetShoppingCartVM()
		{
			var userId = User.GetId();
			var items = await _cartRepository.CartItems.Where(i => i.UserId == userId).ToListAsync();

			var totalPrice = items.Any() ?
				items.Select(i => i.Product.Price * i.Count).Aggregate((i, j) => i + j)
				: 0;

			return new ShoppingCartVM
			{
				Items = items,
				OrderHeader = new OrderHeader { OrderTotal = totalPrice }
			};
		}

		private async Task<Session> CreateStripeSessionAsync(ShoppingCartVM cartVM)
		{
			var domain = "http://localhost:5220/";

			var options = new SessionCreateOptions()
			{
				SuccessUrl = domain + $"customer/ShoppingCart/OrderConfirmation?orderId={cartVM.OrderHeader.Id}",
				CancelUrl = domain + "customer/cart/index",
				Mode = "payment",
				LineItems = cartVM.Items.Select(i => new SessionLineItemOptions
				{
					Quantity = i.Count,
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(i.Product.Price * 100),
						Currency = "uah",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = i.Product.Title
						}
					}
				}).ToList()
			};

			var service = new SessionService();

			var session = await service.CreateAsync(options);

			await _orderHeaderRepository.UpdateStripePaymetId(cartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);

			return session;
		}
	}
}