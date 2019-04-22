
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IDepartmentTypeService
    {
        IEnumerable<DepartmentType> GetDepartmentTypes();
        IEnumerable<DepartmentTypeDto> GetDepartmentTypesDto();

        DepartmentTypeDto GetDepartmentTypeDtoById(int id);
        void UpdateDepartmentType(DepartmentType departmentType);
        void UpdateDepartmentTypeDto(DepartmentTypeDto departmentTypeDto);
        DepartmentType DeleteDepartmentTypeById(int id);
        void CreateNewDepartmentType(DepartmentType departmentType);

        void CreateNewDepartmentTypeDto(DepartmentTypeDto departmentTypeDto);
    }
}
