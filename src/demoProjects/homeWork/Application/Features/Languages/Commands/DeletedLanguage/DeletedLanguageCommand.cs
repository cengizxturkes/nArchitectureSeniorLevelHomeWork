using Application.Features.Languages.Dtos;
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
        public string Name { get; set; }
        public class DeletedLanguageCommandHandler : IRequestHandler<DeletedLanguageCommand, DeletedLanguageDto>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;

            public DeletedLanguageCommandHandler(IProgrammingRepository programmingRepository, IMapper mapper)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageDto> Handle(DeletedLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage mappedLanguages = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedLanguages = await _programmingRepository.DeleteAsync(mappedLanguages);
                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguages);
                return deletedLanguageDto;  
            }
        }
    }
}
