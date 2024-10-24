using ControlePontoAPI.Models;
using ControlePontoAPI.Repositories.Interfaces;
using ControlePontoAPI.Services.Interfaces;

namespace ControlePontoAPI.Services
{
    public class RegistroPontoService : IRegistroPontoService
    {
        private readonly IRegistroPontoRepository _repository;

        public RegistroPontoService(IRegistroPontoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<RegistroPonto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RegistroPonto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(RegistroPonto registroPonto)
        {
            throw new NotImplementedException();
        }

        public Task<RegistroPonto?> UpdateAsync(RegistroPonto registroPonto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
