using Fiorello_PB101.Services.Interfaces;
using Fiorello_PB101.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello_PB101.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IExpertService _expertService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(
            IBlogService blogService,
            IExpertService expertService,
            ICategoryService categoryService,
            IProductService productService
            )
        {
            _blogService = blogService;
            _expertService = expertService;
            _categoryService = categoryService;
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM model = new()
            {
                Blogs = await _blogService.GetAllAsync(3),
                Experts = await _expertService.GetAllAsync(),
                Categories = await _categoryService.GetAllAsync(),
                Products = await _productService.GetAllAsync()
            };

            return View(model);
        }

    }
}
