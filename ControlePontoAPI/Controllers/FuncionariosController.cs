using ControlePontoAPI.DTOs.Funcionario;
using ControlePontoAPI.Mappers;
using ControlePontoAPI.Queries;
using ControlePontoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlePontoAPI.Controllers
{
    [Route("api/funcionarios")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        public FuncionariosController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FuncionarioQueryParams funcionarioQueryParams)
        {
            try
            {
                var funcionarios = await _service.GetAllAsync(funcionarioQueryParams);
                
                if (funcionarios == null || !funcionarios.Any())
                    return NotFound("Nenhum funcionário encontrado.");

                return Ok(funcionarios.Select(f => f.ToFuncionarioDto()));
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
                var funcionario = await _service.GetByIdAsync(id);

                if (funcionario == null)
                    return NotFound("Funcionário não encontrado.");

                return Ok(funcionario.ToFuncionarioDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(FuncionarioCreateDTO funcionarioDto)
        {
            try
            {
                var funcionario = funcionarioDto.ToFuncionario();

                var resultado = await _service.AddAsync(funcionario);

                return CreatedAtAction(nameof(Get), new { id = resultado.Id }, resultado.ToFuncionarioDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, FuncionarioUpdateDTO funcionarioDto)
        {
            try
            {
                var funcionario = funcionarioDto.ToFuncionario(id);

                var resultado = await _service.UpdateAsync(id, funcionario);

                if (resultado == null)
                    return NotFound("Funcionário não encontrado.");

                return Ok(resultado.ToFuncionarioDto());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var funcionario = await _service.DeleteAsync(id);

                if (funcionario == null)
                    return NotFound("Funcionário não encontrado.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }
    }
}
