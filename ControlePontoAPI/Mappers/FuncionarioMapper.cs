using ControlePontoAPI.DTOs.Funcionario;
using ControlePontoAPI.Models;

namespace ControlePontoAPI.Mappers;

public static class FuncionarioMapper
{
    public static FuncionarioDTO ToFuncionarioDto(this Funcionario funcionario)
    {
        return new FuncionarioDTO
        {
            Id = funcionario.Id,
            Nome = funcionario.Nome,
            Email = funcionario.Email,
            Cargo = funcionario.Cargo,
            Ativo = funcionario.Ativo,
            DataAdmissao = funcionario.DataAdmissao
        };
    }

    public static Funcionario ToFuncionario(this FuncionarioCreateDTO funcionarioDTO)
    {
        return new Funcionario
        {
            Nome = funcionarioDTO.Nome,
            Email = funcionarioDTO.Email,
            Cargo = funcionarioDTO.Cargo,
            Ativo = true,
            DataAdmissao = DateTime.Now,
            Role = funcionarioDTO.Role,
            Senha = funcionarioDTO.Senha,
        };
    }

    public static Funcionario ToFuncionario(this FuncionarioUpdateDTO funcionarioDTO, int id)
    {
        return new Funcionario
        {
            Id = id,
            Nome = funcionarioDTO.Nome,
            Cargo = funcionarioDTO.Cargo,
            Ativo = funcionarioDTO.Ativo,
        };
    }
}
