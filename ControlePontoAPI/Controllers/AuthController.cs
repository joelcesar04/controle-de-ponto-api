using ControlePontoAPI.DTOs.Funcionario;
using ControlePontoAPI.Mappers;
using ControlePontoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlePontoAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IFuncionarioService _service;
    private readonly ITokenService _tokenService;
    public AuthController(IFuncionarioService service, ITokenService tokenService)
    {
        _service = service;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(FuncionarioLoginDto loginDto)
    {
        var funcionario = await _service.ValidateCredentialsAsync(loginDto.Email, loginDto.Senha);

        if (funcionario == null)
            return Unauthorized("Credenciais inválidas.");

        var token = _tokenService.GenerateToken(funcionario);

        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    [Authorize("Admin")]
    public async Task<IActionResult> Register(FuncionarioCreateDTO funcionarioDto)
    {
        try
        {
            var funcionario = await _service.GetByEmailAsync(funcionarioDto.Email);

            if (funcionario != null && funcionario.Email == funcionarioDto.Email)
                return BadRequest("Email já registrado.");

            var resultado = funcionarioDto.ToFuncionario();

            await _service.AddAsync(resultado);
            return CreatedAtAction("GetById", "Funcionarios", new { id = resultado.Id }, resultado.ToFuncionarioDto());

        }
        catch (Exception) // não estava usando a variavel pra nada
        {
            return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
        }
    }
}