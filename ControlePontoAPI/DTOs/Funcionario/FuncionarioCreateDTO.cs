using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.Funcionario;

public class FuncionarioCreateDTO
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [StringLength(50, ErrorMessage = "O email deve ter no máximo 50 caracteres.")]
    [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Cargo é obrigatório.")]
    [StringLength(50, ErrorMessage = "O cargo deve ter no máximo 50 caracteres.")]
    public string Cargo { get; set; }
}
