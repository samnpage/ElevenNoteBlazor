using ElevenNoteBlazor.Server.Data;
using ElevenNoteBlazor.Server.Models;
using ElevenNoteBlazor.Shared.Models.Note;
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

    public async Task<NoteDetail> GetNoteByIdAsync(int noteId)
    {
        var noteEntity = await _context.Notes
            .Include(nameof(CategoryEntity))
            .FirstOrDefaultAsync(n => n.Id == noteId && n.OwnerId == _userId);
        if (noteEntity is null)
            return null;

        NoteDetail detail = new()
        {
            Id = noteEntity.Id,
            Title = noteEntity.Title,
            Content = noteEntity.Content,
            CreatedUtc = noteEntity.CreatedUtc,
            ModifiedUtc = noteEntity.ModifiedUtc,
            CategoryName = noteEntity.Category.Name,
            CategoryId = noteEntity.Category.Id
        };

        return detail;
    }

    // Update
    public async Task<bool> UpdateNoteAsync(NoteEdit model)
    {
        if (model == null)
            return false;

        var entity = await _context.Notes.FindAsync(model.Id);
        if (entity?.OwnerId != _userId)
            return false;

        entity.Title = model.Title;
        entity.Content = model.Content;
        entity.CategoryId = model.CategoryId;
        entity.ModifiedUtc = DateTimeOffset.Now;

        return await _context.SaveChangesAsync() == 1;
    }

    // Delete
    public async Task<bool> DeleteNoteAsync(int noteId)
    {
        var entity = await _context.Notes.FindAsync(noteId);
        if(entity?.OwnerId != _userId)
            return false;

        _context.Notes.Remove(entity);
        return await _context.SaveChangesAsync() == 1;
    }

    public Task<bool> DeleteNoteAsync(string userId)
    {
        throw new NotImplementedException();
    }
}