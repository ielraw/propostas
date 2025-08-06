using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System.Reflection;

namespace Application.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly IMapper _mapper;

        public PropostaService(IPropostaRepository propostaRepository, IMapper mapper)
        {
            _propostaRepository = propostaRepository;
            _mapper = mapper;
        }

        public async Task<PropostaResponseDto> GetAsync(string Id)
        {
            var result = await _propostaRepository.GetByIdAsync(Id);
            var proposta = _mapper.Map<PropostaResponseDto>(result);
            return proposta;
        }

        public async Task<IEnumerable<PropostaResponseDto>> GetListAsync(int page = 1, int itens = 10)
        {
            var result = await _propostaRepository.GetAllAsync();
            var propostas = _mapper.Map<IEnumerable<PropostaResponseDto>>(result);
            return propostas;
        }

        public async Task<PropostaResponseDto> PostAsync(PropostaRequestDto model)
        {
            var proposta = _mapper.Map<Proposta>(model);
            var result = await _propostaRepository.AddAsync(proposta);
            return _mapper.Map<PropostaResponseDto>(result);
        }

        public async Task<bool> UpdateAsync(string id, PropostaRequestDto model)
        {
            var proposta = _mapper.Map<Proposta>(model);
            var result = await _propostaRepository.UpdateAsync(proposta);
            return result > 0;
        }
    }
}
