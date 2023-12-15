using ElevenNoteBlazor.Shared.Category;

namespace ElevenNoteBlazor.Server.Services.Category;

public interface ICategoryService
{
    // Create
    Task<bool> CreateCategoryAsync(CategoryCreate model);

    // Read
    Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
    Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);

    // Update
    Task<bool> UpdateCategoryAsync(CategoryEdit model);

    // Delete
    Task<bool> DeleteCategoryAsync(int categoryId);
}