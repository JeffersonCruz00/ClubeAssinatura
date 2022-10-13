using ClubeAss.Domain.Commands;
using FluentValidation;

namespace ClubeAss.Domain.Validators
{
    public class CustomerDeleteRequestValidator : AbstractValidator<CustomerDeleteRequest>
    {
        public CustomerDeleteRequestValidator()
        {
            RuleFor(c => c.Id)
               .NotEmpty()
               .WithMessage("O id do usuário é obrigatório");
        }
    }
}
