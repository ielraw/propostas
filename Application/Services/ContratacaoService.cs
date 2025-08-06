using AutoMapper;
using Domain.Dto;
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
        private readonly IMapper _mapper;

        public ContratacaoService(ILogger<ContratacaoService> logger, IContratacaoRepository contratacaoRepository, IMapper mapper) {
            _logger = logger;
            _contratacaoRepository = contratacaoRepository;
            _mapper = mapper;
        }

        public async Task<ContratacaoResponseDto> PostAsync(ContratacaoRequestDto model)
        {
            try
            {
                if (model == null)
                    throw new ArgumentNullException(nameof(model));

                var contratacao = _mapper.Map<Contratacao>(model);
                var result = await _contratacaoRepository.AddAsync(contratacao);
                return _mapper.Map<ContratacaoResponseDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar contratação");
                throw;
            }
        }
    }
}
