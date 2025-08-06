using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContratacaoService : IContratacaoService
    {
        private readonly ILogger<ContratacaoService> _logger;
        private readonly IContratacaoRepository _contratacaoRepository;

        public ContratacaoService(ILogger<ContratacaoService> logger, IContratacaoRepository contratacaoRepository) {
            _logger = logger;
            _contratacaoRepository = contratacaoRepository;
        }

        public async Task<Contratacao> PostAsync(Contratacao model)
        {
            return await _contratacaoRepository.AddAsync(model);
        }
    }
}
