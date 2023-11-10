using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
            => _categoryService = categoryService;

        public async Task<IActionResult> Index()
        {
            var categories = await this._categoryService.GetCategories(new CancellationToken());

            return View(categories);
        }
    }
}
