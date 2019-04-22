
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public interface ITermService
    {
        IEnumerable<Term> GetTerms();
        IEnumerable<TermDto> GetTermsDto();

        Term GetTermByCode(int code);
        Term GetTermById(int id);

        void InsertTerm(Term term);
        void UpdateTerm(Term term);
        void DeleteTerm(Term term);
        void DeleteTermById(int id);
        void InsertTermDto(TermDto termDto);

        
    }
}
