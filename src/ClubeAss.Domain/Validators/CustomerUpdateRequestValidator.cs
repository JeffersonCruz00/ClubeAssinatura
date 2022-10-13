﻿using ClubeAss.Domain.Commands;
using FluentValidation;

namespace ClubeAss.Domain.Validators
{
    public class CustomerUpdateRequestValidator : AbstractValidator<CustomerUpdateRequest>
    {
        public CustomerUpdateRequestValidator()
        {
            RuleFor(c => c.Id)
               .NotEmpty()
               .WithMessage("O id do usuário é obrigatório");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do usuário é obrigatório");
        }
    }
}
