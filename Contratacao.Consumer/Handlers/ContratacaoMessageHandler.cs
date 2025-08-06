using Domain.Dto;
using Infra.Queue.Interfaces;

namespace Contratacao.Consumer.Handlers
{
    public class ContratacaoMessageHandler : IMessageHandler<ContratacaoResponseDto>
    {
        public async Task HandleAsync(ContratacaoResponseDto message)
        {

            await Task.CompletedTask;
        }
    }
}
