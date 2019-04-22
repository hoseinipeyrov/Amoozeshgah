using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.UoW;

using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.Services
{
    public class LanguageService : Service, ILanguageService
    {
        public LanguageService(IUnitOfWork uow) : base(uow)
        {
        }

        //public void CreateNewLanguage(Language Language)
        //{
        //    uow.Repository<Language>().Create(Language);
        //    Language.CreatedBy = "Test";
        //    Language.CreatedDate = DateTime.Now;
        //    uow.SaveChanges();
        //}

        //public void CreateNewLanguageDto(LanguageDto languageDto)
        //{
        //    var Language = Mapper.Map<Language>(languageDto);
        //    CreateNewLanguage(Language);
        //}

        ////public IEnumerable<Language> GetLanguages(int placeId)
        ////{
        ////    return uow.Repository<Language>().GetAll(l=> l.PlaceId == null || l.PlaceId == placeId);
        ////}
        //public IEnumerable<LanguageDto> GetLanguagesDto(int placeId)
        //{
        //    var languages= GetLanguages(placeId).Select(l=>new LanguageDto { Id=(l.PlaceId==null)?0:l.Id,Name=l.Name,NameFa=l.NameFa}).ToList();
        //    return languages;
        //}
        //CreateNewLanguageDto


    }
}
