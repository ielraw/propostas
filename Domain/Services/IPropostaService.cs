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
        Task<Proposta> PostAsync(Proposta model);
        Task<Proposta> GetAsync(string Id);
        Task<IEnumerable<Proposta>> GetListAsync(int page = 1, int itens = 10);
        Task<bool> UpdateAsync(string id, Proposta model);
    }
}
