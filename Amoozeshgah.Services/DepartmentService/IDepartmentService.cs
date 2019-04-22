
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Amoozeshgah.Services
{
    public interface IDepartmentService
    {
        Department DeleteDepartmentById(int id);
        IEnumerable<Department> GetDepartments();
        IEnumerable<DepartmentDto> GetDepartmentsDto();

        Department GetDepartmentById(int id);

        void UpdateDepartment(Department department);
        void UpdateDepartmentDto(DepartmentDto departmentDto);

        void DeleteDepartment(Department department);
        DepartmentDto GetDepartmentDtoById(int id);
        void InsertDepartment(Department department);
        void InsertDepartmentDto(DepartmentDto departmentDto);


    }
}
