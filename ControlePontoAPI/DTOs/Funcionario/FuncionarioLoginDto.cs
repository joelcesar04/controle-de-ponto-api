using System.ComponentModel.DataAnnotations;

namespace ControlePontoAPI.DTOs.Funcionario;

public class FuncionarioLoginDto
{
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [StringLength(50, ErrorMessage = "O email deve ter no máximo 50 caracteres.")]
    [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    public string Senha { get; set; }
}
