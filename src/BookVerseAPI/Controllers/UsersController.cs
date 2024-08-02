using BookVerseAPI.Interfaces;
using BookVerseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookVerseAPI.Controllers;
[Route("api/user")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userRepository.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null) 
            NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if(!user.IsAdult)
        {
            return BadRequest("O usuário deve ser maior de idade");
        }
        await _userRepository.AddUserAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, User user)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingUser = await _userRepository.GetUserByIdAsync(id);
        if(existingUser == null)
        {
            return NotFound();
        }
        await _userRepository.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if(user == null)
        {
            return NotFound();
        }
        await _userRepository.DeleteUserAsync(id);
        return NoContent();
    }
}

