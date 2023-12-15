using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Category;

public class CategoryCreate
{
    [Required]
    public string Name { get; set; } = string.Empty;
}