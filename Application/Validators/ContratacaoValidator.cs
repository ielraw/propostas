using Domain.Dto;
using FluentValidation;

namespace Application.Validators
{
    public class ContratacaoValidator : AbstractValidator<ContratacaoRequestDto>
    {
        public ContratacaoValidator()
        {
            RuleFor(x => x.PropostaId).NotEmpty();
        }
    }
}
