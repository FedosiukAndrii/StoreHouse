using StoreHouse.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.Models.Entities;
using System.Diagnostics;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.ViewModels;
using StoreHouse.DataAccess.Repositories;

namespace StoreHouse.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISizeRepository _sizeRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository, ISizeRepository sizeRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _sizeRepository = sizeRepository;
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
            var sizes = (await _sizeRepository.GetAll()).OrderBy(s => s.Order).ToList();
            return View(new ProductDetailVM { Product = product, SelectedColor = selectedColor, Sizes = sizes });
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