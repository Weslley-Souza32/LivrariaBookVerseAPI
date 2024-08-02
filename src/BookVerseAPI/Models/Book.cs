using System.ComponentModel.DataAnnotations;

namespace BookVerseAPI.Models;

public class Book
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Título é obrigatório.")]
    [StringLength(150)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Autor é obrigatório.")]
    [StringLength(255)]
    public string Author { get; set; }

    [Required(ErrorMessage = "ISBN é obrigatório.")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "O ISBN deve conter exatamente 13 caracteres.")]
    public string ISBN { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Data da publicação deve ser uma data válida.")]
    public DateTime? PublicationDate { get; set; }

    [Required(ErrorMessage = "Categoria é obrigatória.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Quantidade em estoque é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque deve ser um número inteiro não negativo.")]
    public int StockQuantity { get; set; }

    [Required(ErrorMessage = "Preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor decimal positivo.")]
    public decimal Price { get; set; }
}
