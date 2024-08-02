using BookVerseAPI.Interfaces;
using BookVerseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookVerseAPI.Controllers;
[Route("api/rentals")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly IRentalRepository _rentalRepository;
    private readonly IUserRepository _userRepository;

    public RentalsController(IRentalRepository rentalRepository, IUserRepository userRepository)
    {
        _rentalRepository = rentalRepository;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var rentals = await _rentalRepository.GetRentalAsync();
        return Ok(rentals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var rental = await _rentalRepository.GetRentalByIdAsync(id);

        if (rental == null)
            return NotFound();

        return Ok(rental);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Rental rental)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userExist = await _userRepository.GetUserByIdAsync(rental.UserId) != null;

        if(userExist)
            return NotFound("Usuário não encontrado.");

        if(!await _rentalRepository.CanRentalBookAsync(rental.BookId))
            return BadRequest("Livro fora de estoque.");

        await _rentalRepository.AddRentalAsync(rental);
        return CreatedAtAction(nameof(Get), new {id = rental.Id }, rental);

        
    }
}
