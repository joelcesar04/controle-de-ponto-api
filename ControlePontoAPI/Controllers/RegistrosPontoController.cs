using ControlePontoAPI.DTOs.RegistroPonto;
using ControlePontoAPI.Mappers;
using ControlePontoAPI.Models;
using ControlePontoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlePontoAPI.Controllers;

[Route("api/registrosponto")]
[ApiController]
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
    public async Task<IActionResult> Get()
    {
        try
        {
            var registros = await _service.GetAllAsync();

            return Ok(registros.Select(r => r.ToRegistroPontoDto()));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var registro = await _service.GetByIdAsync(id);

            if (registro == null)
                return NotFound("Registro não encontrado.");

            return Ok(registro.ToRegistroPontoDto());
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }

    [HttpGet("funcionario/{id:int}")]
    public async Task<IActionResult> GetRegistroByFuncionario(int id)
    {
        try
        {
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
            var registroPonto = registroPontoDto.ToRegistroPonto();

            var funcionario = await _funcionarioService.GetByIdAsync(registroPonto.FuncionarioId);

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
            var registroPonto = registroPontoDto.ToRegistroPonto(id);

            var resultado = await _service.UpdateAsync(id, registroPonto);

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