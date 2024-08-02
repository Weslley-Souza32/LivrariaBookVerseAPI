using BookVerseAPI.Utils.CostumersValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookVerseAPI.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Nome completo é obrigatório.")]
    [MaxLength(255, ErrorMessage = "Nome completo deve ter no máximo 255 caracteres.")]
    [Display(Name = "Nome Completo")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
    [DataType(DataType.Date, ErrorMessage = "Data de nascimento deve ser uma data válida.")]
    [MaiorDeIdade(ErrorMessage = "O usuário dever ter 18 anos ou mais.")]
    [Display(Name = "Data de Nascimento")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "CPF é obrigatório.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ser válido e conter 11 dígitos.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    [Phone(ErrorMessage = "Telefone deve ser um número válido.")]
    [Display(Name ="Telefone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail deve ser válido.")]
    public string Email { get; set; }

    [MaxLength(255)]
    public string Street { get; set; }

    [MaxLength(100)]
    public string City { get; set; }

    [MaxLength(100)]
    public string State { get; set; }

    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000.")]
    public string PostalCode { get; set; }

 
    [NotMapped]
    public bool IsAdult => DateTime.Now.Year - DateOfBirth.Year >= 18;
}
