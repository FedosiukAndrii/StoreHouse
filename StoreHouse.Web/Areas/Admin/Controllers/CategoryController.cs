using Microsoft.AspNetCore.Mvc;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAll();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Add(category);

                TempData["success"] = "Category created successfully!";

                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> EditAsync(int? categoryId)
        {
            if (categoryId is null || categoryId == 0)
            {
                return NotFound();
            }

            var category = await _categoryRepository.Get(c => c.CategoryId == categoryId);

            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.Update(category);

                TempData["success"] = "Category updated successfully!";

                return RedirectToAction("Index");
            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int? categoryId)
        {
            if (categoryId is null || categoryId == 0)
            {
                return NotFound();
            }

            var category = await _categoryRepository.Get(c => c.CategoryId == categoryId);

            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? categoryId)
        {
            var category = await _categoryRepository.Get(c => c.CategoryId == categoryId);

            if (category is null)
            {
                return NotFound();
            }

            await _categoryRepository.Remove(category);

            TempData["success"] = "Category deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}
