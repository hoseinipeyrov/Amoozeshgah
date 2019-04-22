
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages(int placeId);
        IEnumerable<LanguageDto> GetLanguagesDto(int placeId);
        void CreateNewLanguage(Language Language);

        void CreateNewLanguageDto(LanguageDto languageDto);
    }
}
