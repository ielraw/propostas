using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Domain.Services;
using Infra.Queue.Interfaces;
using System.Reflection;

namespace Application.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly IMapper _mapper;
        private readonly IMessageBusPublisher _publisher;

        public PropostaService(IPropostaRepository propostaRepository, IMapper mapper, IMessageBusPublisher publisher)
        {
            _propostaRepository = propostaRepository;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task ChangeStatus(string id, StatusProposta status)
        {
            var proposta = await _propostaRepository.GetByIdAsync(id);

            if (proposta == null) return;

            proposta.StatusProposta = status;

            await _propostaRepository.UpdateAsync(proposta);
        }

        public async Task ChangeStatusAuto(string id, StatusProposta status)
        {
            var contratacao = new ContratacaoResponseDto { };
            await ChangeStatus(id, status);
            if(StatusProposta.Aprovada == status)
                await _publisher.PublishAsync("contratacoes", contratacao);

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
