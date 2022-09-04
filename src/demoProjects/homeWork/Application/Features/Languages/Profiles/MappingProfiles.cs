using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ProgrammingLanguage, CreatedLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, LanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, LanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, LanguageGetByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedLanguageDto>().ReverseMap();

        }
    }
}
