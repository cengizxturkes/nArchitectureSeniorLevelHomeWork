using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeletedLanguage
{
    public class DeletedLanguageCommandValidator: AbstractValidator<DeletedLanguageCommand>
    {
        public DeletedLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
