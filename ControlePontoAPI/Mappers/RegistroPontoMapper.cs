using ControlePontoAPI.DTOs.RegistroPonto;
using ControlePontoAPI.Models;

namespace ControlePontoAPI.Mappers;

public static class RegistroPontoMapper
{
    public static RegistroPontoDto ToRegistroPontoDto(this RegistroPonto registroPonto)
    {
        return new RegistroPontoDto
        {
            Id = registroPonto.Id,
            FuncionarioId = registroPonto.FuncionarioId,
            DataHora = registroPonto.DataHora,
            Tipo = registroPonto.Tipo,
            Observacao = registroPonto.Observacao,
        };
    }

    public static RegistroPonto ToRegistroPonto(this RegistroPontoCreateDto registroPontoDto)
    {
        return new RegistroPonto
        {
            FuncionarioId = registroPontoDto.FuncionarioId,
            DataHora = DateTime.Now,
            Observacao = registroPontoDto.Observacao,
        };
    }

    public static RegistroPonto ToRegistroPonto(this RegistroPontoUpdateDTO registroPontoDto, int id)
    {
        return new RegistroPonto
        {
            Id = id,
            DataHora = registroPontoDto.DataHora,
            Observacao = registroPontoDto.Observacao,
        };
    }
}
