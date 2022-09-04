using Application.Features.Languages.Models;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {
            private readonly IProgrammingRepository _programmingRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(IProgrammingRepository programmingRepository, IMapper mapper)
            {
                _programmingRepository = programmingRepository;
                _mapper = mapper;
            }


            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
            IPaginate<ProgrammingLanguage> programmingLanguage= await  _programmingRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                LanguageListModel mappedLanguageListModel=_mapper.Map<LanguageListModel>(programmingLanguage);
                return mappedLanguageListModel;
            }
        }
    }
}
