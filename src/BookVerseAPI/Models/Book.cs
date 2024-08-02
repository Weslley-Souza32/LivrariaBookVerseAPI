using System.ComponentModel.DataAnnotations;

namespace BookVerseAPI.Models;

public class Book
{
    [Key]
    public long Id { get; set; }
    [Required(ErrorMessage = "Título é obrigatório.")]
    [MaxLength(150, ErrorMessage = "Título deve ter no máximo 150 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Autor é obrigatório.")]
    [MaxLength(255, ErrorMessage = "Autor deve ter no máximo 255 caracteres.")]
    public string Autor { get; set; }

    [Required(ErrorMessage = "ISBN é obrigatório.")]
    [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN deve conter exatamente 13 caracteres.")]
    public string ISBN { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Data da publicação deve ser uma data válida.")]
    public DateTime? DataPublicacao { get; set; }

    [Required(ErrorMessage = "Categoria é obrigatória.")]
    [MaxLength(100, ErrorMessage = "Categoria deve pertencer a uma lista predefinida.")]
    public string Categoria { get; set; }

    [Required(ErrorMessage = "Quantidade em estoque é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantidade em estoque deve ser um número inteiro não negativo.")]
    public int QuantidadeEmEstoque { get; set; }

    [Required(ErrorMessage = "Preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser um valor decimal positivo.")]
    public decimal Preco { get; set; }
}
