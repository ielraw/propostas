using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proposta.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {

        private readonly ILogger<PropostaController> _logger;

        public PropostaController(ILogger<PropostaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Task<Domain.Entities.Proposta> Post(Domain.Entities.Proposta model)
        {
            return Task.FromResult(new Domain.Entities.Proposta { Id = model.Id });
        }

        [HttpGet]
        [Route("{id}")]
        public Task<Domain.Entities.Proposta> Get(Guid id)
        {
            return Task.FromResult(new Domain.Entities.Proposta { Id = id });
        }

        [HttpPut]
        [Route("{id}/change-status")]
        public Task<Domain.Entities.Proposta> ChangeStatus(Guid id)
        {
            return Task.FromResult(new Domain.Entities.Proposta { Id = id });
        }

        [HttpGet]
        public IEnumerable<Domain.Entities.Proposta> GetList()
        {
            return new List<Domain.Entities.Proposta>
            {
                new Domain.Entities.Proposta(),
                new Domain.Entities.Proposta(),
                new Domain.Entities.Proposta()
            };
        }
    }
}
