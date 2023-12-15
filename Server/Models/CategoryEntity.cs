using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Server.Models;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}