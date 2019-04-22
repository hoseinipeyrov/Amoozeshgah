
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IClassroomTypeService
    {
        IEnumerable<ClassroomType> GetClassroomTypes();
    }
}
