using ControlePontoAPI.Enums;
using ControlePontoAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.RegistroPonto;

public class RegistroPontoUpdateDTO
{
    [Required(ErrorMessage = "A DataHora é obrigatória.")]
    public DateTime DataHora { get; set; }

    [StringLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
    public string? Observacao { get; set; }

}
