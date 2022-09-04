using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetListLanguage;
using Application.Features.Languages.Rules;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(IProgrammingRepository programmingRepository, IMapper mapper,LanguageBusinessRules languageBusinessRules)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }


            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
               ProgrammingLanguage? programmingLanguage= await _programmingRepository.GetAsync(b => b.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(programmingLanguage);
                LanguageGetByIdDto languageGetByIdDto=_mapper.Map<LanguageGetByIdDto>(programmingLanguage);
                return languageGetByIdDto;
            }
        }
    }
}
