using Domain.Dto;
using Domain.Entities;
using Domain.Services;
using Infra.Queue.Interfaces;

namespace Contratacao.Consumer.Handlers
{
    public class ContratacaoMessageHandler : IMessageHandler<ContratacaoRequestDto>
    {
        private readonly ILogger<ContratacaoMessageHandler> _logger;
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoMessageHandler(ILogger<ContratacaoMessageHandler> logger, IContratacaoService contratacaoService)
        {
            _logger = logger;
            _contratacaoService = contratacaoService;
        }
        public async Task HandleAsync(ContratacaoRequestDto message)
        {
            await _contratacaoService.PostAsync(message);
            await Task.CompletedTask;
        }
    }
}
