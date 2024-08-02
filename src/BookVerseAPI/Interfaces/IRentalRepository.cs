using BookVerseAPI.Models;

namespace BookVerseAPI.Interfaces;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetRentalAsync();
    Task<Rental> GetRentalByIdAsync(Guid id);
    Task<bool> CanRentalBookAsync(Guid bookId);
    Task AddRentalAsync(Rental rental);
}
