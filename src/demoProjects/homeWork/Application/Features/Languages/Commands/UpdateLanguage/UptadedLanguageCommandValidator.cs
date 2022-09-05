using Application.Features.Languages.Commands.DeletedLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UptadedLanguageCommandValidator: AbstractValidator<UptadedLanguageCommand>
    {
        public UptadedLanguageCommandValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();
        }
    }
}
