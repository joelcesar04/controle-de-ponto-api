using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.Validations;

public class FutureDateValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var data = (DateTime?)value;

        if (data > DateTime.Now)
            return new ValidationResult("A data não pode ser no futuro.");

        return ValidationResult.Success;
    }
}
