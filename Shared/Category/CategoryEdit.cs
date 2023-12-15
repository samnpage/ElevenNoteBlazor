using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Category;

public class CategoryEdit
{
    [Required]
    public string Name { get; set; } = string.Empty;
}