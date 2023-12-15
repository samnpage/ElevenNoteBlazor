using ElevenNoteBlazor.Server.Data;
using ElevenNoteBlazor.Server.Models;
using ElevenNoteBlazor.Shared.Note;
using Microsoft.EntityFrameworkCore;

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
    public async Task<bool> CreateNoteAsync(NoteCreate model)
    {
        NoteEntity entity = new()
        {
            Title = model.Title,
            Content = model.Content,
            OwnerId = _userId,
            CreatedUtc = DateTimeOffset.Now,
            CategoryId = model.CategoryId
        };

        _context.Notes.Add(entity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    // Read
    public async Task<IEnumerable<NoteListItem>> GetAllNotesAsync()
    {
        var noteQuery = _context.Notes
            .Where(n => n.OwnerId == _userId)
            .Select(n =>
            new NoteListItem
            {
                Id = n.Id,
                Title = n.Title,
                CategoryName = n.Category.Name,
                CreatedUtc = n.CreatedUtc
            });

        return await noteQuery.ToListAsync();
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