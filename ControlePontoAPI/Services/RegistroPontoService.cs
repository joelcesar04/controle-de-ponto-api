using ControlePontoAPI.Enums;
using ControlePontoAPI.Models;
using ControlePontoAPI.Repositories.Interfaces;
using ControlePontoAPI.Services.Interfaces;

namespace ControlePontoAPI.Services
{
    public class RegistroPontoService : IRegistroPontoService
    {
        private readonly IRegistroPontoRepository _repository;
        private readonly IFuncionarioRepository _repositoryFuncionario;

        public RegistroPontoService(IRegistroPontoRepository repository,
            IFuncionarioRepository repositoryFuncionario)
        {
            _repository = repository;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public async Task<IEnumerable<RegistroPonto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<RegistroPonto?> GetByIdAsync(int id)
        {
            var registroPonto = await _repository.GetByIdAsync(id);

            if (registroPonto == null)
                return null;

            return registroPonto;
        }

        public async Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario)
        {
            var registrosPonto = await _repository.GetByFuncionarioAsync(idFuncionario);

            return registrosPonto;
        }

        public async Task<RegistroPonto> AddAsync(RegistroPonto registroPonto)
        {
            var ultimoRegistro = await _repository.GetLastRegistroPontoAsync(registroPonto.FuncionarioId);

            if (ultimoRegistro != null && ultimoRegistro.Tipo == TipoRegistro.Entrada)
            {
                registroPonto.Tipo = TipoRegistro.Saida;
            }
            else
            {
                registroPonto.Tipo = TipoRegistro.Entrada;
            }

            registroPonto.DataHora = DateTime.Now;
            await _repository.AddAsync(registroPonto);
            return registroPonto;
        }

        public async Task<RegistroPonto?> UpdateAsync(int id, RegistroPonto registroPonto)
        {
            var existingRegistro = await _repository.GetByIdAsync(id);

            if (existingRegistro == null)
                return null;

            existingRegistro.DataHora = registroPonto.DataHora;
            existingRegistro.Observacao = registroPonto.Observacao;

            await _repository.UpdateAsync(existingRegistro);
            return existingRegistro;
        }

        public async Task<RegistroPonto?> DeleteAsync(int id)
        {
            var registro = await _repository.GetByIdAsync(id);

            if (registro == null)
                return null;

            await _repository.DeleteAsync(registro);
            return registro;
        }
    }
}