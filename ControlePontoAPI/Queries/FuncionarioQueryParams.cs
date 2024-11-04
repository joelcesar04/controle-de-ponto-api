namespace ControlePontoAPI.Queries;

public class FuncionarioQueryParams
{
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public bool? Ativo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}
