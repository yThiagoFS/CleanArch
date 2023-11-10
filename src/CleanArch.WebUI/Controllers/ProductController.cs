using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
            => _productService = productService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await this._productService.GetProducts(new CancellationToken());

            return View(products);
        }
    }
}
