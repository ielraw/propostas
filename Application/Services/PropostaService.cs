using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly IContratacaoRepository _contratacaoRepository;
        public PropostaService(IPropostaRepository propostaRepository, IContratacaoRepository contratacaoRepository)
        {
            _propostaRepository = propostaRepository;
            _contratacaoRepository = contratacaoRepository;
        }
        // Implement service methods here
    }
}
