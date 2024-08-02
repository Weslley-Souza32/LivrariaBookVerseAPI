using BookVerseAPI.Interfaces;
using BookVerseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookVerseAPI.Controllers;
[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null) 
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Book book)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if(await _bookRepository.IsISBNExistsAsync(book.ISBN))
        {
            return Conflict("ISBN já existe no sistema!");
        }

        await _bookRepository.AddBookAsync(book);
        return CreatedAtAction(nameof(Get), new {id = book.Id}, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, Book book)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingBook = await _bookRepository.GetBookByIdAsync(id);
        if(existingBook == null)
        {
            return NotFound();
        }

        if(book.ISBN != existingBook.ISBN && await _bookRepository.IsISBNExistsAsync(book.ISBN))
        {
            return Conflict("ISBN já existe no sistema!");
        } 

        await _bookRepository.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        if(book == null)  
           NotFound();

        await _bookRepository.DeleteBookAsync(id);
        return NoContent();
    }

}
