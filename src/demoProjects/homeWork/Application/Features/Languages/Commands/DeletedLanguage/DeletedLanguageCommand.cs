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

namespace Application.Features.Languages.Commands.DeletedLanguage
{
    public class DeletedLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }
        public class DeletedLanguageCommandHandler : IRequestHandler<DeletedLanguageCommand, DeletedLanguageDto>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeletedLanguageCommandHandler(IProgrammingRepository programmingRepository, IMapper mapper,LanguageBusinessRules languageBusinessRules)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules; 
            }

            public async Task<DeletedLanguageDto> Handle(DeletedLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.LanguageShouldExistWhenRequested(request.Id);
                ProgrammingLanguage? programmingLanguage = await _programmingRepository.GetAsync(pl => pl.Id == request.Id);

                //ProgrammingLanguage mappedLanguages = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedLanguages = await _programmingRepository.DeleteAsync(programmingLanguage);
                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguages);
                return deletedLanguageDto;
            }
        }
    }
}