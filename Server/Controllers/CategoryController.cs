using ElevenNoteBlazor.Server.Services.Category;
using ElevenNoteBlazor.Shared.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Category(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreate model)
    {
        if (model == null || !ModelState.IsValid)
            return BadRequest();

        bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);
        if (!wasSuccessful)
            return UnprocessableEntity();

        return Ok();
    }
}