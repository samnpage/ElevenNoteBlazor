using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Shared.Models.Note;

public class NoteEdit
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;
    public int CategoryId { get; set; }
}