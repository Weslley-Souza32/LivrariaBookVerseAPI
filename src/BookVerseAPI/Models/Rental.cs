using System.ComponentModel.DataAnnotations;

namespace BookVerseAPI.Models;

public class Rental
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid BookId { get; set; }

    public User User { get; set; }

    public Book Book { get; set; }

    [Required]
    public DateTime RentalDate { get; set; } = DateTime.Now;
}
