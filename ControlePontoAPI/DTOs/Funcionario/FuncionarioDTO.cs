namespace ControlePontoAPI.DTOs.Funcionario;

public class FuncionarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Cargo { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataAdmissao { get; set; }
}
