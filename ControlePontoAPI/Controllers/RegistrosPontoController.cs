using ControlePontoAPI.DTOs.RegistroPonto;
using ControlePontoAPI.Mappers;
using ControlePontoAPI.Queries;
using ControlePontoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ControlePontoAPI.Controllers;

[Route("api/registrosponto")]
[ApiController]
[Authorize(Roles = "Admin, Employee")]
public class RegistrosPontoController : ControllerBase
{
    private readonly IRegistroPontoService _service;
    private readonly IFuncionarioService _funcionarioService; 

    public RegistrosPontoController(IRegistroPontoService service, IFuncionarioService funcionarioService)
    {
        _service = service;
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    [Authorize("Admin")]
    public async Task<IActionResult> Get([FromQuery] RegistroPontoQueryParams registroPontoQueryParams)
    {
        try
        {         
            var registros = await _service.GetAllAsync(registroPontoQueryParams);

            if (registros == null || !registros.Any())
                return NotFound("Nenhum registro encontrado.");

            return Ok(registros.Select(r => r.ToRegistroPontoDto()));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    //[HttpGet("{id:int}")]
    //public async Task<IActionResult> Get(int id)
    //{
    //    try
    //    {
    //        var registro = await _service.GetByIdAsync(id);

    //        if (registro == null)
    //            return NotFound("Registro não encontrado.");

    //        return Ok(registro.ToRegistroPontoDto());
    //    }
    //    catch (Exception ex)
    //    {
    //        return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
    //    }
    //}

    [HttpGet("funcionario")]
    public async Task<IActionResult> GetRegistroByFuncionario()
    {
        try
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("Usuário não autenticado ou ID não disponível no token.");

            var id = int.Parse(userIdClaim.Value);

            var funcionario = await _funcionarioService.GetByIdAsync(id);

            if (funcionario == null)
                return NotFound("Funcionário não encontrado.");

            var registros = await _service.GetByFuncionarioAsync(id);

            if (!registros.Any())
                return NotFound("Sem registros para esse funcionário");

            return Ok(registros.Select(r => r.ToRegistroPontoDto()));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegistroPontoCreateDto registroPontoDto)
    {
        try
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("Usuário não autenticado ou ID não disponível no token.");

            var id = int.Parse(userIdClaim.Value);

            var registroPonto = registroPontoDto.ToRegistroPonto(id);

            var funcionario = await _funcionarioService.GetByIdAsync(id);

            if (funcionario == null)
                return NotFound("Funcionário não encontrado.");

            var resultado = await _service.AddAsync(registroPonto);

            return CreatedAtAction(nameof(Get), new { id = registroPonto.Id }, resultado.ToRegistroPontoDto());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody]RegistroPontoUpdateDTO registroPontoDto)
    {
        try
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("Usuário não autenticado ou ID não disponível no token.");

            var idfuncionarioAutenticado = int.Parse(userIdClaim.Value);

            var funcionarioAutenticado = await _funcionarioService.GetByIdAsync(idfuncionarioAutenticado);

            if (funcionarioAutenticado == null)
                return NotFound("Funcionário não encontrado.");

            var registrosDoFuncionario = await _service.GetByFuncionarioAsync(idfuncionarioAutenticado);

            if (registrosDoFuncionario == null || !registrosDoFuncionario.Any())
                return NotFound("Nenhum registro de ponto encontrado para este funcionário.");

            var registroExistente = registrosDoFuncionario.FirstOrDefault(r => r.Id == id);

            if (registroExistente == null)
                return StatusCode(403, "Você não tem permissão para alterar este registro.");

            var registroAtualizado = registroPontoDto.ToRegistroPonto(id);

            var resultado = await _service.UpdateAsync(id, registroAtualizado);

            if (resultado == null)
                return NotFound("Registro não encontrado.");

            return Ok(resultado.ToRegistroPontoDto());
        }
        catch(Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize("Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var resultado = await _service.DeleteAsync(id);

            if (resultado == null)
                return NotFound("Registro não encontrado.");

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }
}