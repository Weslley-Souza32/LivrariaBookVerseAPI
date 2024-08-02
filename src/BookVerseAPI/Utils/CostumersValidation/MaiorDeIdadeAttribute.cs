using System.ComponentModel.DataAnnotations;

namespace BookVerseAPI.Utils.CostumersValidation;

public class MaiorDeIdadeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if(value is DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if(dataNascimento > DateTime.Today.AddYears(-idade)) idade--;

            if(idade < 18)
            {
                return new ValidationResult("O usuário deve ter 18 anos ou mais.");
            }
        }
        return ValidationResult.Success;
    }
}
