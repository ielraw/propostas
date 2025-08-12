using AutoMapper;
using Domain.Dto;
using Domain.Entities;

namespace Application.Mapper
{
    public class ContratacaoMapper : Profile
    {
        public ContratacaoMapper()
        {
            CreateMap<ContratacaoRequestDto, Contratacao>();
            CreateMap<Contratacao, ContratacaoResponseDto>();
        }
    }
}
