using Domain.Dto;
using Domain.Enums;

namespace Domain.Services
{
    public interface IPropostaService
    {
        Task<PropostaResponseDto> PostAsync(PropostaRequestDto model);
        Task<PropostaResponseDto> GetAsync(string Id);
        Task<IEnumerable<PropostaResponseDto>> GetListAsync(int page = 1, int itens = 10);
        Task ChangeStatus(string id, StatusProposta status);
        Task ChangeStatusAuto(string id, StatusProposta status);
    }
}
