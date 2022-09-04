using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreatedLanguageDto>

    {
        public string Name { get; set; }
        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public CreateLanguageCommandHandler(IProgrammingRepository programmingRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {


                await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage mappedLanguages = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdLanguage = await _programmingRepository.AddAsync(mappedLanguages);
                CreatedLanguageDto createdLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);
                return createdLanguageDto;

            }
        }
    }
}
