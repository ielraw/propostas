using Application.Validators;
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
        private readonly ContratacaoValidator _validator;

        public ContratacaoMessageHandler(ILogger<ContratacaoMessageHandler> logger, IContratacaoService contratacaoService, ContratacaoValidator validator)
        {
            _logger = logger;
            _contratacaoService = contratacaoService;
            _validator = validator;
        }
        public async Task HandleAsync(ContratacaoRequestDto message)
        {
            var validationResult = await  _validator.ValidateAsync(message);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                _logger.LogError("Erro de validação: {Errors}", errorMessage);
                await Task.FromException(new Exception(errorMessage));
            }
            await _contratacaoService.PostAsync(message);
            await Task.CompletedTask;
        }
    }
}
