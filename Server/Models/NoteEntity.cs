using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElevenNoteBlazor.Server.Models;

public class NoteEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string OwnerId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }
    public int CategoryId { get; set; }
    public virtual CategoryEntity Category { get; set; }

    [Required]
    public DateTimeOffset CreatedUtc { get; set; }
    public DateTimeOffset? ModifiedUtc { get; set; }
}