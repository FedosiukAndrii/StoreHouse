using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;
using StoreHouse.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace StoreHouse.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IShopingCartRepository _cartRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository, ISizeRepository sizeRepository, IShopingCartRepository cartRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _sizeRepository = sizeRepository;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index(int? categoryId = null)
        {
            var products = await _productRepository.Products.Where(p => categoryId == null || p.CategoryId == categoryId).ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Detail(int? productId, int? colorId)
        {
            var product = await _productRepository.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return NotFound();
            }

            var selectedColor = product.ProductColors.FirstOrDefault(color => colorId is null || color.ColorId == colorId);
            var sizes = (await _sizeRepository.GetAll()).OrderBy(s => s.Order).ToList();
            return View(new ProductDetailVM { Product = product, SelectedColor = selectedColor, Sizes = sizes });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Detail(ProductDetailVM detailVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var exisingItem = await _cartRepository.CartItems
                .FirstOrDefaultAsync(i =>
                   i.ProductId == detailVM.Product.ProductId
                && i.ColorId == detailVM.SelectedColor.ColorId
                && i.SizeId == detailVM.SizeId);

            if (exisingItem == null)
            {
                var cartItem = new CartItem
                {
                    ColorId = detailVM.SelectedColor.ColorId,
                    ProductId = detailVM.Product.ProductId,
                    SizeId = detailVM.SizeId,
                    Count = detailVM.Count,
                    UserId = userId,
                };

                await _cartRepository.Add(cartItem);
            }
            else
            {
                exisingItem.Count += detailVM.Count;

                await _cartRepository.Update(exisingItem);
            }

            TempData["success"] = "Item added successfully!";

            return await Detail(detailVM.Product.ProductId, detailVM.SelectedColor.ColorId);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}