using ControlePontoAPI.Enums;
using ControlePontoAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.RegistroPonto;

public class RegistroPontoCreateDto
{
    [Required(ErrorMessage = "O campo FuncionarioId é obrigatório.")]
    public int FuncionarioId { get; set; }

    [StringLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
    public string? Observacao { get; set; }

}
