using BookVerseAPI.Data;
using BookVerseAPI.Interfaces;
using BookVerseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> IsISBNExistsAsync(string isbn)
    {
        return await _context.Books.AnyAsync(b => b.ISBN == isbn);
    }
}
