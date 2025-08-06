using Application.Services;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Propostas.UnitTests.Services
{
    public class ContratacaoServiceTest
    {

        private readonly ILogger<ContratacaoService> _logger;
        private readonly IContratacaoRepository _contratacaoRepository;
        private readonly IMapper _mapper;
        private readonly ContratacaoService _contratacaoService;

        public ContratacaoServiceTest()
        {
            _logger = Substitute.For<ILogger<ContratacaoService>>();
            _contratacaoRepository = Substitute.For<IContratacaoRepository>();
            _mapper = Substitute.For<IMapper>();
            _contratacaoService = new ContratacaoService(_logger, _contratacaoRepository, _mapper);
        }

        [Fact]
        public async Task PostAsync_QuandoSucesso_DeveRetornarContratacaoResponseDto()
        {
            // Arrange
            var requestDto = new ContratacaoRequestDto
            {
                PropostaId = "123"
            };

            var contratacao = new Contratacao
            {
                Id = "1",
                PropostaId = 123,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var responseDto = new ContratacaoResponseDto
            {
                Id = "1",
                PropostaId = "123",
                CreatedAt = contratacao.CreatedAt,
                UpdatedAt = contratacao.UpdatedAt
            };

            _mapper.Map<Contratacao>(requestDto).Returns(contratacao);
            _contratacaoRepository.AddAsync(contratacao).Returns(contratacao);
            _mapper.Map<ContratacaoResponseDto>(contratacao).Returns(responseDto);

            // Act
            var result = await _contratacaoService.PostAsync(requestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.Id);
            Assert.Equal("123", result.PropostaId);

            await _contratacaoRepository.Received(1).AddAsync(Arg.Any<Contratacao>());
            _mapper.Received(1).Map<Contratacao>(Arg.Any<ContratacaoRequestDto>());
            _mapper.Received(1).Map<ContratacaoResponseDto>(Arg.Any<Contratacao>());
        }

        [Fact]
        public async Task PostAsync_QuandoRequestNulo_DeveLancarArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _contratacaoService.PostAsync(null));
        }
    }
}
