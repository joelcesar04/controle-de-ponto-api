namespace ControlePontoAPI.Queries;

public class FuncionarioQueryParams
{
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public bool? Ativo { get; set; }
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
