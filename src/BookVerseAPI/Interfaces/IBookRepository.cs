using BookVerseAPI.Models;

namespace BookVerseAPI.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(Guid id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(Guid id);
    Task<bool> IsISBNExistsAsync(string isbn);
}
