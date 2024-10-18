using ControlePontoAPI.Models;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var funcionarios = await _service.GetAllAsync();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var funcionario = await _service.GetByIdAsync(id);

                if (funcionario == null)
                    return NotFound("Funcionário não encontrado.");

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            try
            {
                var resultado = await _service.AddAsync(funcionario);

                return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Funcionario funcionario)
        {
            try
            {
                var resultado = await _service.UpdateAsync(id, funcionario);

                if (resultado == null)
                    return NotFound("Funcionário não encontrado.");

                return Ok(resultado);

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
