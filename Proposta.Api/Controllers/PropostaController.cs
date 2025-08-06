using Application.Services;
using Domain.Dto;
using Domain.Entities;
using Domain.Enums;
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
        public async Task<PropostaResponseDto> Post(PropostaRequestDto model)
        {
            return await _propostaService.PostAsync(model);   
        }

        [HttpGet]
        [Route("{id}")]
        public Task<PropostaResponseDto> Get(string id)
        {
            return _propostaService.GetAsync(id);
        }

        [HttpPut]
        [Route("{id}/change-status/{status}")]
        public async Task ChangeStatus(string id, StatusProposta status)
        {
            await _propostaService.ChangeStatus(id, status);
        }

        [HttpPut]
        [Route("{id}/change-status-auto/{status}")]
        public async Task ChangeStatusAuto(string id, StatusProposta status)
        {
            await _propostaService.ChangeStatusAuto(id, status);
        }

        [HttpGet]
        public async Task<IEnumerable<PropostaResponseDto>> GetList(int page = 1)
        {
            return await  _propostaService.GetListAsync(page);
        }
    }
}
