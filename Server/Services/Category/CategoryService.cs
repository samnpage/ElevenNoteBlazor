using ElevenNoteBlazor.Server.Data;
using ElevenNoteBlazor.Server.Models;
using ElevenNoteBlazor.Shared.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace ElevenNoteBlazor.Server.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task<bool> CreateCategoryAsync(CategoryCreate model)
    {
        if (model == null) return false;

        CategoryEntity entity = new()
        {
            Name = model.Name
        };

        _context.Categories.Add(entity);

        return await _context.SaveChangesAsync() == 1;
    }

    // Read
    public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
    {
        var categoryQuery = _context.Categories
            .Select(entity => new CategoryListItem
            {
                Id = entity.Id,
                Name = entity.Name
            });

        return await categoryQuery.ToListAsync();
    }

    public Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    // Update
    public Task<bool> UpdateCategoryAsync(CategoryEdit model)
    {
        throw new NotImplementedException();
    }

    // Delete
    public Task<bool> DeleteCategoryAsync(int categoryId)
    {
        throw new NotImplementedException();
    }
}