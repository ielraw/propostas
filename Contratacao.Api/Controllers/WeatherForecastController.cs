using Domain.Dto;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContratacaoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : ControllerBase
    {

        private readonly ILogger<ContratacaoController> _logger;
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoController(ILogger<ContratacaoController> logger, IContratacaoService contratacaoService)
        {
            _logger = logger;
            _contratacaoService = contratacaoService;
        }

        [HttpPost]
        public async Task<ContratacaoResponseDto> Post(ContratacaoRequestDto contratacao)
        {
            return await _contratacaoService.PostAsync(contratacao);
        }
    }
}
