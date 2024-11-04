using ControlePontoAPI.Enums;

namespace ControlePontoAPI.Queries;

public class RegistroPontoQueryParams
{
    public int? FuncionarioId { get; set; }
    public TipoRegistro? Tipo { get; set; }
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
