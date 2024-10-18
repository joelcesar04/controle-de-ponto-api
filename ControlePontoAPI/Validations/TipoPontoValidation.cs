using ControlePontoAPI.Enums;
using ControlePontoAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.Validations;

public class TipoPontoValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var registroPonto = (RegistroPonto)validationContext.ObjectInstance;
        var tipo = registroPonto.Tipo;

        if (tipo != TipoRegistro.Entrada && tipo != TipoRegistro.Saida)
            return new ValidationResult("Tipo de ponto inválido. Deve ser Entrada ou Saída.");

        return ValidationResult.Success;
    }
}
