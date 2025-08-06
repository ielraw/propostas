using Application.Services;
using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Domain.Services;
using NSubstitute;

namespace Propostas.UnitTests.Services
{
    public class PropostaServiceTest
    {
        //private readonly IPropostaService _propostaService;

        //public PropostaServiceTest()
        //{
        //    _propostaService = Substitute.For<IPropostaService>();
        //}

        //[Fact]
        //public void Test1()
        //{
        //    var propostaService = Substitute.For<IPropostaService>();
        //    var mockService = Substitute.For<IPropostaService>();

        //    var result = propostaService.GetAsync(Arg.Any<string>())
        //        .Returns(new Domain.Dto.PropostaResponseDto
        //        {
        //            Id = "123",
        //            Price = 10.6M,
        //            StatusProposta = Domain.Enums.StatusProposta.Aprovada
        //        });
        //    Assert.NotNull(result);
        //}

        private readonly IPropostaRepository _propostaRepository;
        private readonly IMapper _mapper;
        private readonly PropostaService _propostaService;

        public PropostaServiceTest()
        {
            _propostaRepository = Substitute.For<IPropostaRepository>();
            _mapper = Substitute.For<IMapper>();
            _propostaService = new PropostaService(_propostaRepository, _mapper);
        }

        [Fact]
        public async Task GetAsync_QuandoPropostaExiste_DeveRetornarPropostaDto()
        {
            // Arrange
            var id = "123";
            var proposta = new Proposta { Id = id, Price = 1000m };
            var propostaDto = new PropostaResponseDto { Id = id, Price = 1000m };

            _propostaRepository.GetByIdAsync(id).Returns(proposta);
            _mapper.Map<PropostaResponseDto>(proposta).Returns(propostaDto);

            // Act
            var result = await _propostaService.GetAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(1000m, result.Price);
        }

        [Fact]
        public async Task GetListAsync_DeveRetornarListaDePropostas()
        {
            // Arrange
            var propostas = new List<Proposta>
            {
                new() { Id = "1", Price = 1000m },
                new() { Id = "2", Price = 2000m }
            };
            var propostasDto = propostas.Select(p => new PropostaResponseDto
            {
                Id = p.Id,
                Price = p.Price
            });

            _propostaRepository.GetAllAsync().Returns(propostas);
            _mapper.Map<IEnumerable<PropostaResponseDto>>(propostas).Returns(propostasDto);

            // Act
            var result = await _propostaService.GetListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task PostAsync_DevecriarNovaProposta()
        {
            // Arrange
            var requestDto = new PropostaRequestDto { Price = 1000m };
            var proposta = new Proposta { Id = "1", Price = 1000m };
            var responseDto = new PropostaResponseDto { Id = "1", Price = 1000m };

            _mapper.Map<Proposta>(requestDto).Returns(proposta);
            _propostaRepository.AddAsync(proposta).Returns(proposta);
            _mapper.Map<PropostaResponseDto>(proposta).Returns(responseDto);

            // Act
            var result = await _propostaService.PostAsync(requestDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.Id);
            Assert.Equal(1000m, result.Price);
        }

        [Fact]
        public async Task UpdateAsync_QuandoPropostaExiste_DeveAtualizarProposta()
        {
            // Arrange
            var id = "1";
            var requestDto = new PropostaRequestDto { Price = 2000m };
            var proposta = new Proposta { Id = id, Price = 2000m };

            _mapper.Map<Proposta>(requestDto).Returns(proposta);
            _propostaRepository.UpdateAsync(proposta).Returns(1);

            // Act
            var result = await _propostaService.UpdateAsync(id, requestDto);

            // Assert
            Assert.True(result);
            await _propostaRepository.Received(1).UpdateAsync(Arg.Any<Proposta>());
        }

        [Fact]
        public async Task ChangeStatus_QuandoPropostaExiste_DeveAtualizarStatus()
        {
            // Arrange
            var id = "1";
            var proposta = new Proposta
            {
                Id = id,
                Price = 1000m,
                StatusProposta = StatusProposta.EmAnalise
            };

            _propostaRepository.GetByIdAsync(id).Returns(proposta);
            _propostaRepository.UpdateAsync(Arg.Any<Proposta>()).Returns(1);

            // Act
            await _propostaService.ChangeStatus(id, StatusProposta.Aprovada);

            // Assert
            await _propostaRepository.Received(1).GetByIdAsync(id);
            await _propostaRepository.Received(1).UpdateAsync(Arg.Is<Proposta>(
                p => p.StatusProposta == StatusProposta.Aprovada));
        }

        [Fact]
        public async Task ChangeStatus_QuandoPropostaNaoExiste_NaoDeveAtualizarStatus()
        {
            // Arrange
            var id = "1";
            _propostaRepository.GetByIdAsync(id).Returns((Proposta)null);

            // Act
            await _propostaService.ChangeStatus(id, StatusProposta.Aprovada);

            // Assert
            await _propostaRepository.Received(1).GetByIdAsync(id);
            await _propostaRepository.DidNotReceive().UpdateAsync(Arg.Any<Proposta>());
        }

        [Fact]
        public async Task ChangeStatusAuto_DeveAtualizarStatus()
        {
            // Arrange
            var id = "1";
            var proposta = new Proposta
            {
                Id = id,
                StatusProposta = StatusProposta.EmAnalise
            };

            _propostaRepository.GetByIdAsync(id).Returns(proposta);

            // Act
            await _propostaService.ChangeStatusAuto(id, StatusProposta.Aprovada);

            // Assert
            await _propostaRepository.Received(1).GetByIdAsync(id);
            await _propostaRepository.Received(1).UpdateAsync(Arg.Is<Proposta>(
                p => p.StatusProposta == StatusProposta.Aprovada));
        }
    }
}