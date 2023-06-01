using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.DTOs;
using StoreHouse.Models.Entities;
using StoreHouse.Models.Utils;
using StoreHouse.Models.ViewModels;
using System.Data;

namespace StoreHouse.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = Roles.Role_Admin)]
public class ProductController : Controller
{
    private const string ImagesPath = @"images\product";
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepositrory;
    private readonly IColorRepository _colorRepository;
    private readonly IImageRepository _imageRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMapper _mapper;

    public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepositrory, IColorRepository colorRepository, IWebHostEnvironment webHostEnvironment, IImageRepository imageRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _productRepositrory = productRepositrory;
        _colorRepository = colorRepository;
        _webHostEnvironment = webHostEnvironment;
        _imageRepository = imageRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productRepositrory.GetAll();

        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepositrory.Products.ToListAsync();

        var productDtos = _mapper.Map<IEnumerable<ProductListItemDto>>(products).ToArray();

        return Json(new { data = productDtos });
    }

    public async Task<IActionResult> CreateOrUpdate(int? productId)
    {
        var categories = await _categoryRepository.GetAll();
        var colors = await _colorRepository.GetAll();

        ProductVM viewModel;

        if (productId is null || productId == 0)
        {
            viewModel = new ProductVM(categories, colors);
        }
        else
        {
            var product = await _productRepositrory.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

            if (product is null)
            {
                return NotFound();
            }

            viewModel = new ProductVM(product, categories, colors);
        }

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrUpdate(ProductVM productVM, List<ColorImagesVM> colorImagesVM)
    {
        if (ModelState.IsValid)
        {
            var product = productVM.Product;
            var action = product.ProductId == 0 ? "created" : "updated";
            product.ProductColors = productVM.ColorIds
                .Select(id => new ProductColor { ColorId = id, ProductId = product.ProductId })
                .ToList();

            if (product.ProductId == 0)
            {
                await _productRepositrory.Add(product);
                await UploadImages(colorImagesVM, product.ProductId);
            }
            else
            {
                await _productRepositrory.Update(product);
                await UploadImages(colorImagesVM, product.ProductId);
            }

            TempData["success"] = $"Product {action} successfully!";

            return RedirectToAction("Index");
        }

        productVM = await Populate(productVM);

        return View(productVM);
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int? productId)
    {
        if (productId is null || productId == 0)
        {
            return NotFound();
        }

        var product = await _productRepositrory.Get(p => p.ProductId == productId);

        if (product is null)
        {
            return NotFound();
        }

        await _productRepositrory.Remove(product);

        return Json(new { success = true, message = "Product deleted successfully!" });
    }

    private async Task<ProductVM> Populate(ProductVM productVm)
    {
        var categories = await _categoryRepository.GetAll();
        var colors = await _colorRepository.GetAll();

        productVm.Categories = categories.ToSelectListItems();
        productVm.Colors = colors.ToSelectListItems();
        productVm.CssCodes = colors.ToDictionary(color => color.ColorId, color => color.CssCode);

        return productVm;
    }

    public async Task UploadImages(IEnumerable<ColorImagesVM> colorImages, int productId)
    {
        colorImages = colorImages.Where(i => i.Images is not null).ToList();

        string wwwRootPath = _webHostEnvironment.WebRootPath;
        var images = new List<ProductColorImage>();

        foreach (var imageVM in colorImages)
        {
            foreach (var image in imageVM.Images)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                string productPath = Path.Combine(wwwRootPath, ImagesPath);
                using var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create);

                await image.CopyToAsync(fileStream);

                images.Add(new ProductColorImage { ImageUrl = Path.Combine(ImagesPath, fileName), ColorId = imageVM.ColorId, ProductId = productId });
            }
        }

        await _imageRepository.AddRange(images);
    }
}
