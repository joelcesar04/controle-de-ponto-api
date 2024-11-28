using ControlePontoAPI.Enums;

namespace ControlePontoAPI.Queries;

public class RegistroPontoQueryParams
{
    public int? FuncionarioId { get; set; }
    public TipoRegistro? Tipo { get; set; }
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    //Trouxe a validação para dentro da classe, deixando encapsulado, a logica do comportamento dentro da propria classe.
    public void ApplyDefaults()
    {
        PageNumber = EnforceMinimum(PageNumber, 1);
        PageSize = EnforceMinimum(PageSize, 1, 10);
    }

    private int EnforceMinimum(int value, int min, int defaultValue = 0)
    {
        return value > 0 ? Math.Max(value, min) : defaultValue;
    }
}
