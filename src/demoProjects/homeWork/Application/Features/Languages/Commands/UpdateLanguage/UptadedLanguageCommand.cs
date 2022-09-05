using Application.Features.Languages.Commands.DeletedLanguage;
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

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UptadedLanguageCommand:IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UptadedLanguageCommandHandler : IRequestHandler<UptadedLanguageCommand, UpdatedLanguageDto>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UptadedLanguageCommandHandler(IProgrammingRepository programmingRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdatedLanguageDto> Handle(UptadedLanguageCommand request, CancellationToken cancellationToken)
            {
                
                await _languageBusinessRules.LanguageShouldExistWhenRequested(request.Id);
                await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage? programmingLanguage = await _programmingRepository.GetAsync(pl => pl.Id == request.Id);

                programmingLanguage.Name=request.Name;
                ProgrammingLanguage updatedLanguages = await _programmingRepository.UpdateAsync(programmingLanguage);
                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguages);
                return updatedLanguageDto;
            }
        }
         
    }
}
