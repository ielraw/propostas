using AutoMapper;
using Domain.Dto;
using Domain.Entities;

namespace Domain.Mapper
{
    public class PropostaMapper : Profile
    {
        public PropostaMapper()
        {
            CreateMap<PropostaRequestDto, Proposta>();
            CreateMap<Proposta, PropostaResponseDto>();
        }
    }
}
