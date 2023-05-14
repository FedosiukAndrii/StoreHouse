using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;

namespace StoreHouse.Web.Components;

public class SideMenuViewComponent : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;

    public SideMenuViewComponent(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await _categoryRepository.GetAll();

        return View(categories);
    }
}
