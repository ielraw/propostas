using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaService(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<Proposta> GetAsync(string Id)
        {
            var result = await _propostaRepository.GetByIdAsync(Id);
            return result;
        }

        public async Task<IEnumerable<Proposta>> GetListAsync(int page = 1, int itens = 10)
        {
            var result = await _propostaRepository.GetAllAsync();
            return result;
        }

        public async Task<Proposta> PostAsync(Proposta model)
        {
            var result = await _propostaRepository.AddAsync(model);
            return result;
        }

        public async Task<bool> UpdateAsync(string id, Proposta model)
        {
            var result = await _propostaRepository.UpdateAsync(model);
            return result > 0;
        }
    }
}
