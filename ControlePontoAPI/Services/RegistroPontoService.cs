using ControlePontoAPI.Enums;
using ControlePontoAPI.Models;
using ControlePontoAPI.Queries;
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

        public async Task<IEnumerable<RegistroPonto>> GetAllAsync(RegistroPontoQueryParams registroPontoQueryParams)
        {
            var query = _repository.GetAll();

            if (registroPontoQueryParams.FuncionarioId.HasValue)
                query = query.Where(r => r.FuncionarioId == registroPontoQueryParams.FuncionarioId);

            if (registroPontoQueryParams.Tipo.HasValue)
                query = query.Where(r => r.Tipo == registroPontoQueryParams.Tipo.Value);

            if (registroPontoQueryParams.DataInicial.HasValue)
                query = query.Where(r => r.DataHora >= registroPontoQueryParams.DataInicial.Value);

            if (registroPontoQueryParams.DataFinal.HasValue)
                query = query.Where(r => r.DataHora <= registroPontoQueryParams.DataFinal.Value);

            registroPontoQueryParams.ApplyDefaults();

            query = query
                .OrderBy(r => r.FuncionarioId)
                .Skip((registroPontoQueryParams.PageNumber - 1) * registroPontoQueryParams.PageSize)
                .Take(registroPontoQueryParams.PageSize);

            var registros = await _repository.GetAllAsync(query);

            return registros;
        }

        // Se voce faz uma comparação se é nulo e devolve nulo pode devolver diretamente.
        public async Task<RegistroPonto?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
       

        // Reduzida logica.
        public async Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario) 
            => await _repository.GetByFuncionarioAsync(idFuncionario);


        
        public async Task<RegistroPonto> AddAsync(RegistroPonto registroPonto)
        {
            var ultimoRegistro = await _repository.GetLastRegistroPontoAsync(registroPonto.FuncionarioId);

            // Esse é o código mais enxuto e mantém a mesma funcionalidade
            registroPonto.Tipo = (ultimoRegistro?.Tipo == TipoRegistro.Entrada)
                ? TipoRegistro.Saida
                : TipoRegistro.Entrada;

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