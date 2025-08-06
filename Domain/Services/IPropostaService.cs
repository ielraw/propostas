using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPropostaService
    {
        Task<PropostaResponseDto> PostAsync(PropostaRequestDto model);
        Task<PropostaResponseDto> GetAsync(string Id);
        Task<IEnumerable<PropostaResponseDto>> GetListAsync(int page = 1, int itens = 10);
        Task<bool> UpdateAsync(string id, PropostaRequestDto model);
    }
}
