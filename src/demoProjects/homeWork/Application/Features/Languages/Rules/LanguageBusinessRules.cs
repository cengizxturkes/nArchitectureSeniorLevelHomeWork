using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly IProgrammingRepository _languageRepository;

        public LanguageBusinessRules(IProgrammingRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("LanguageEntity name exists.");
        }
        public async Task LanguageShouldExistWhenRequested(int id)
        {
            ProgrammingLanguage result = await _languageRepository.GetAsync(pl => pl.Id == id);
            if (result == null) throw new BusinessException("Requested language does not exists.");
            
        }
        public async Task ProgrammingLanguageShouldBeExist(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Programming Language does not exist.");
        }



    }
}
