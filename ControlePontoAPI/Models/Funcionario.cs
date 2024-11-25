using ControlePontoAPI.Validations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControlePontoAPI.Models;

public class Funcionario
{
    public int Id { get; set; }

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

    [Required(ErrorMessage = "O campo Ativo é obrigatório.")]
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "O campo Data de Admissão é obrigatório.")]
    [FutureDateValidation(ErrorMessage = "A data de admissão não pode ser no futuro.")]
    public DateTime DataAdmissao { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo Role é obrigatório.")]
    [RegularExpression("^(Admin|Employee)$", ErrorMessage = "A Role deve ser 'Admin' ou 'Employee'.")]
    public string Role { get; set; }

    [JsonIgnore]
    public ICollection<RegistroPonto>? RegistrosPonto { get; set; } = new List<RegistroPonto>();
}
