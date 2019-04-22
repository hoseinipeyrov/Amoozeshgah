using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amoozeshgah.Core.UoW;

using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Common.Domain;

namespace Amoozeshgah.Services
{
    public class DepartmentService : Service, IDepartmentService
    {
        int siteId;
        public DepartmentService(IUnitOfWork uow) : base(uow)
        {
            siteId = WebUserInfo.SiteId;
        }
        public Department DeleteDepartmentById(int id)
        {
            var department = GetDepartmentById(id);
            uow.Repository<Department>().Delete(department);
            uow.SaveChanges();
            return department;
        }
        public void DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int id)
        {
            var department = uow.Repository<Department>().Get(d => d.Id == id);
          
            if (department == null || department.DepartmentType.EducationalCenterId != siteId)
            {
                throw new Exception("دسترسی غیر مجاز");
            }
            return department;
        }

        public DepartmentDto GetDepartmentDtoById(int id)
        {
            return Mapper.Map<DepartmentDto>(GetDepartmentById(id));

        }

        public IEnumerable<Department> GetDepartments()
        {

            return uow.Repository<Department>().GetAll(d => d.DepartmentType.EducationalCenterId == siteId).ToList();
        }

        public IEnumerable<DepartmentDto> GetDepartmentsDto()
        {
            return GetDepartments().Select(Mapper.Map<Department, DepartmentDto>);
        }

        public void InsertDepartment(Department department)
        {
            uow.Repository<Department>().Create(department);
            uow.SaveChanges();
        }
        public void InsertDepartmentDto(DepartmentDto departmentDto)
        {
            var department = Mapper.Map<Department>(departmentDto);
            InsertDepartment(department);
        }
        public void UpdateDepartment(Department department)
        {
            var departmentType = uow.Repository<DepartmentType>().Get(d => d.Id == department.DepartmentTypeId);

            if (departmentType.EducationalCenterId != siteId)
            {
                throw new Exception("دسترسی غیر مجاز");
            }
            uow.Repository<Department>().Update(department);
            uow.SaveChanges();
        }
        public void UpdateDepartmentDto(DepartmentDto departmentDto)
        {
            var department = Mapper.Map<Department>(departmentDto);
            UpdateDepartment(department);
        }


    }
}
