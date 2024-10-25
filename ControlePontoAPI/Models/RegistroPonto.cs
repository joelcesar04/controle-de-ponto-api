using ControlePontoAPI.Enums;
using ControlePontoAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControlePontoAPI.Models;

public class RegistroPonto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo FuncionarioId é obrigatório.")]
    public int FuncionarioId { get; set; }

    [Required(ErrorMessage = "A DataHora é obrigatória.")]
    public DateTime DataHora { get; set; }

    [Required(ErrorMessage = "O Tipo é obrigatório.")]
    [TipoPontoValidation(ErrorMessage = "Tipo de ponto inválido. Deve ser 0 (Entrada) ou 1 (Saída).")]
    public TipoRegistro Tipo { get; set; }

    [StringLength(500, ErrorMessage = "A observação deve ter no máximo 500 caracteres.")]
    public string? Observacao { get; set; }

    [JsonIgnore]
    public Funcionario? Funcionario { get; set; }
}
