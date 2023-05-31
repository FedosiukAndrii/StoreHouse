using StoreHouse.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.Models.Entities;
using System.Diagnostics;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.ViewModels;

namespace StoreHouse.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.Products.ToListAsync();

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

            return View(new ProductDetailVM { Product = product, SelectedColor = selectedColor });
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