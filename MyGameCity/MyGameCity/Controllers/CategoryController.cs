using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.Services.CatService;
using MyGameCity.Services.GameService;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            // TODO: implement all functions using new game
        }
    }
}
