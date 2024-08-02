using System.ComponentModel.DataAnnotations;

namespace BookVerseAPI.Models;

public class Rental
{
    [Key]
    public long Id { get; set; }
    public long UsuarioId { get; set; }
    public long LivroId { get; set; }
    public DateTime DataAluguel { get; set; }

    public User Usuario { get; set; }
    public Book Livro { get; set; }
}
