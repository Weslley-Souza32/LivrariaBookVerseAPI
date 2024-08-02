using BookVerseAPI.Data;
using BookVerseAPI.Interfaces;
using BookVerseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookVerseAPI.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly AppDbContext _context;

    public RentalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rental>> GetRentalAsync()
    {
        return await _context.Rentals.ToListAsync();
    }

    public async Task<Rental> GetRentalByIdAsync(Guid id)
    {
        return await _context.Rentals.FindAsync(id);
    }

    public async Task AddRentalAsync(Rental rental)
    {
        var book = await _context.Books.FindAsync(rental.BookId);
        if (book == null && book.StockQuantity > 0)
        {
            book.StockQuantity--;
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        } 

    }

    public async Task<bool> CanRentalBookAsync(Guid bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        return book != null && book.StockQuantity > 0;
    }
}
