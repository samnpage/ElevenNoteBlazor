using ElevenNoteBlazor.Server.Data;
using ElevenNoteBlazor.Shared.Note;

namespace ElevenNoteBlazor.Server.Services.Note;

public class NoteService : INoteService
{
    private readonly ApplicationDbContext _context;
    private string _userId;

    public NoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Set
    public void SetUserId(string userId) => _userId = userId;

    // Create
    public Task<bool> CreateNoteAsync(NoteCreate model)
    {
        throw new NotImplementedException();
    }

    // Read
    public Task<IEnumerable<NoteListItem>> GetAllNotesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<NoteDetail> GetNoteByIdAsync(int noteId)
    {
        throw new NotImplementedException();
    }

    // Update
    public Task<bool> UpdateNoteAsync(NoteEdit model)
    {
        throw new NotImplementedException();
    }

    // Delete
    public Task<bool> DeleteNoteAsync(int noteId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteNoteAsync(string userId)
    {
        throw new NotImplementedException();
    }
}