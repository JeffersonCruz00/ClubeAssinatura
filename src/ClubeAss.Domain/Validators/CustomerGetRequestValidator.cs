using ClubeAss.Domain.Commands;
using FluentValidation;

namespace ClubeAss.Domain.Validators
{
    public class CustomerGetRequestValidator : AbstractValidator<CustomerGetRequest>
    {
        public CustomerGetRequestValidator()
        {
            RuleFor(c => c.Id)
               .NotEmpty()
               .WithMessage("O id do usuário é obrigatório");
        }
    }
}
