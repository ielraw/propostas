using Domain.Dto;
using Domain.Entities;
using Domain.Services;
using Infra.Queue.Interfaces;

namespace Contratacao.Consumer.Handlers
{
    public class ContratacaoMessageHandler : IMessageHandler<Proposta>
    {
        private readonly ILogger<ContratacaoMessageHandler> _logger;
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoMessageHandler(ILogger<ContratacaoMessageHandler> logger, IContratacaoService contratacaoService)
        {
            _logger = logger;
            _contratacaoService = contratacaoService;
        }
        public async Task HandleAsync(Proposta message)
        {
            await _contratacaoService.PostAsync(new ContratacaoRequestDto
            {
                PropostaId = message.Id
            });
            await Task.CompletedTask;
        }
    }
}
