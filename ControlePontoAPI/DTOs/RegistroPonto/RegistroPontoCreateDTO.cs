using ControlePontoAPI.Enums;
using ControlePontoAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.RegistroPonto;

public class RegistroPontoCreateDto
{
   [StringLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
    public string? Observacao { get; set; }

}
