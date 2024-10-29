using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.Funcionario;

public class FuncionarioUpdateDTO
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Cargo é obrigatório.")]
    [StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "O campo Ativo é obrigatório.")]
    public bool Ativo { get; set; }
}
