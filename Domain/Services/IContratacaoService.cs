using Domain.Dto;

namespace Domain.Services
{
    public interface IContratacaoService
    {
        Task<ContratacaoResponseDto> PostAsync(ContratacaoRequestDto model);
    }
}
