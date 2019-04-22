using Amoozeshgah.Core.UoW;
using System.Collections.Generic;

using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using System.Threading.Tasks;
using Amoozeshgah.Common.Domain;

namespace Amoozeshgah.Services
{
    public class TermService : Service, ITermService
    {
        public TermService(IUnitOfWork uow) : base(uow) { }

        public void DeleteTerm(Term term)
        {
            uow.Repository<Term>().Delete(term);
            uow.SaveChanges();
        }

        public void DeleteTermById(int id)
        {
            var term = GetTermById(id);
            if (term.EducationalCenterId == WebUserInfo.SiteId)
            {
                uow.Repository<Term>().Delete(term);
                uow.SaveChanges();
            }
        }

        public Term GetTermByCode(int code)
        {
            return uow.Repository<Term>().Get(t => t.Code == code);
        }

        public Term GetTermById(int id)
        {
            return uow.Repository<Term>().Get(t => t.Id == id);
        }

        public IEnumerable<Term> GetTerms()
        {
            return uow.Repository<Term>().GetAll().ToList();
        }

        public IEnumerable<TermDto> GetTermsDto()
        {
            return uow.Repository<Term>().GetAll(x => x.EducationalCenterId == WebUserInfo.SiteId).Select(Mapper.Map<Term, TermDto>).ToList();
        }

        public void InsertTerm(Term term)
        {
            term.EducationalCenterId = WebUserInfo.SiteId;
            term.CreatedBy = WebUserInfo.UserId.ToString();
            uow.Repository<Term>().Create(term);
            uow.SaveChanges();
        }

        public void InsertTermDto(TermDto termDto)
        {
            var term = Mapper.Map<Term>(termDto);
            InsertTerm(term);
        }

        public void UpdateTerm(Term term)
        {
            uow.Repository<Term>().Update(term);
            uow.SaveChanges();
        }
    }

}
