using ElevenNoteBlazor.Shared.Note;

namespace ElevenNoteBlazor.Server.Services.Note;

public interface INoteService
{
    // Create
    Task<bool> CreateNoteAsync(NoteCreate model);

    // Read
    Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
    Task<NoteDetail> GetNoteByIdAsync(int noteId);

    // Update
    Task<bool> UpdateNoteAsync(NoteEdit model);

    // Delete
    Task<bool> DeleteNoteAsync(int noteId);
    Task<bool> DeleteNoteAsync(string userId);

    void SetUserId(string userId);
}