using Domain.Dto;
using FluentValidation;

namespace Application.Validators
{
    public class PropostaValidator : AbstractValidator<PropostaRequestDto>
    {
        public PropostaValidator()
        {
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
