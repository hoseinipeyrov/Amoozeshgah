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
    public class DepartmentTypeService : Service, IDepartmentTypeService
    {
        public DepartmentTypeService(IUnitOfWork uow) : base(uow)
        {
            siteId = WebUserInfo.SiteId;
        }
        int siteId;
        public IEnumerable<DepartmentType> GetDepartmentTypes()
        {
            return uow.Repository<DepartmentType>().GetAll(dt=>dt.EducationalCenterId==siteId);
        }
        public IEnumerable<DepartmentTypeDto> GetDepartmentTypesDto()
        {
            return GetDepartmentTypes().Select(Mapper.Map<DepartmentType, DepartmentTypeDto>);

        }
        public DepartmentType GetDepartmentTypeById(int id)
        {
            return uow.Repository<DepartmentType>().Get(d => d.Id == id);
        }

        public DepartmentTypeDto GetDepartmentTypeDtoById(int id)
        {
            return Mapper.Map<DepartmentTypeDto>(GetDepartmentTypeById(id));
        }

        public void UpdateDepartmentType(DepartmentType departmentType)
        {
            uow.Repository<DepartmentType>().Update(departmentType);
            uow.SaveChanges();
        }
        public void UpdateDepartmentTypeDto(DepartmentTypeDto departmentTypeDto)
        {
            var departmentType = Mapper.Map<DepartmentType>(departmentTypeDto);
            departmentType.CreatedBy = "Test";
            departmentType.CreatedDate = DateTime.Now;
            UpdateDepartmentType(departmentType);
        }

        public DepartmentType DeleteDepartmentTypeById(int id)
        {
            var departmentType = GetDepartmentTypeById(id);
            uow.Repository<DepartmentType>().Delete(departmentType);
            uow.SaveChanges();
            return departmentType;
        }

        public void CreateNewDepartmentType(DepartmentType departmentType)
        {
            uow.Repository<DepartmentType>().Create(departmentType);
            uow.SaveChanges();
        }

        public void CreateNewDepartmentTypeDto(DepartmentTypeDto departmentTypeDto)
        {
            var departmentType= Mapper.Map<DepartmentType>(departmentTypeDto);
            departmentType.EducationalCenterId = WebUserInfo.SiteId;

            departmentType.CreatedBy = WebUserInfo.UserId.ToString(); 
            departmentType.CreatedDate = DateTime.Now;
            CreateNewDepartmentType(departmentType);
        }
    }
}
