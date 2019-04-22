
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IUserWithDetailService
    {
        IEnumerable<SiteUserRole> FindSiteUser(int roleId, string username, string password);
        IEnumerable<Menu> GetSidebar(int roleId, string currentController, string CurrentAction);
        Person FindPersonByUserId(int userId);
        void Create(SiteUserRole siteUserRole);
    }
}
