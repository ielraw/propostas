using Application.Services;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Proposta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {

        private readonly ILogger<PropostaController> _logger;
        private readonly IPropostaService _propostaService;

        public PropostaController(ILogger<PropostaController> logger, IPropostaService propostaService)
        {
            _logger = logger;
            _propostaService = propostaService;
        }

        [HttpPost]
        public async Task<Domain.Entities.Proposta> Post(Domain.Entities.Proposta model)
        {
            return await _propostaService.PostAsync(model);   
        }

        [HttpGet]
        [Route("{id}")]
        public Task<Domain.Entities.Proposta> Get(string id)
        {
            return _propostaService.GetAsync(id);
        }

        [HttpPut]
        [Route("{id}/change-status")]
        public async Task<Domain.Entities.Proposta> ChangeStatus(string id)
        {
            return await Task.FromResult(new Domain.Entities.Proposta { Id = id });
        }

        [HttpPut]
        [Route("{id}/change-status-auto")]
        public async Task<Domain.Entities.Proposta> ChangeStatus(string id)
        {
            return await Task.FromResult(new Domain.Entities.Proposta { Id = id });
        }

        [HttpGet]
        public async Task<IEnumerable<Domain.Entities.Proposta>> GetList(int page = 1)
        {
            return await  _propostaService.GetListAsync(page);
        }
    }
}
