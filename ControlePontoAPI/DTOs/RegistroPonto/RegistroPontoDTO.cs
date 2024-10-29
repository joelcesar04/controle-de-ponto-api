using ControlePontoAPI.Enums;

namespace ControlePontoAPI.DTOs.RegistroPonto;

public class RegistroPontoDto
{
    public int Id { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataHora { get; set; }
    public TipoRegistro Tipo { get; set; }
    public string? Observacao { get; set; }
}
